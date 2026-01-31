using Dapper;
using HelpdeskSystem.Application.DTOs;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace HelpdeskSystem.Infrastructure.Reports;

public interface IDapperReportService
{
    Task<DashboardDto> GetDashboardDataAsync();
    Task<List<TicketsPerDayDto>> GetTicketsPerDayAsync(int days);
}

public class DapperReportService : IDapperReportService
{
    private readonly string _connectionString;

    public DapperReportService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("OracleConnection")
            ?? throw new InvalidOperationException("Oracle connection string not configured");
    }

    public async Task<DashboardDto> GetDashboardDataAsync()
    {
        using var connection = new OracleConnection(_connectionString);
        await connection.OpenAsync();

        var dashboard = new DashboardDto();

        // Get ticket counts by status
        var statusCountsSql = @"
            SELECT STATUS, COUNT(*) AS CNT
            FROM TICKETS
            GROUP BY STATUS";

        var statusCounts = await connection.QueryAsync<(string Status, int Cnt)>(statusCountsSql);

        foreach (var (status, cnt) in statusCounts)
        {
            switch (status)
            {
                case "Open": dashboard.OpenTickets = cnt; break;
                case "InProgress": dashboard.InProgressTickets = cnt; break;
                case "Resolved": dashboard.ResolvedTickets = cnt; break;
                case "Closed": dashboard.ClosedTickets = cnt; break;
            }
            dashboard.TotalTickets += cnt;
            dashboard.TicketsByStatus.Add(new TicketsByStatusDto { Status = status, Count = cnt });
        }

        // Get average resolution time
        var avgResolutionSql = @"
            SELECT AVG((UPDATEDAT - CREATEDAT) * 24) AS AvgHours
            FROM TICKETS
            WHERE STATUS = 'Resolved'
            AND UPDATEDAT IS NOT NULL";

        var avgHours = await connection.QueryFirstOrDefaultAsync<double?>(avgResolutionSql);
        dashboard.AverageResolutionHours = Math.Round(avgHours ?? 0, 2);

        // Get tickets per day (last 14 days)
        dashboard.TicketsPerDay = await GetTicketsPerDayAsync(14);

        return dashboard;
    }

    public async Task<List<TicketsPerDayDto>> GetTicketsPerDayAsync(int days)
    {
        using var connection = new OracleConnection(_connectionString);
        await connection.OpenAsync();

        var sql = @"
            SELECT TRUNC(CREATEDAT) AS TicketDate, COUNT(*) AS CNT
            FROM TICKETS
            WHERE CREATEDAT >= TRUNC(SYSDATE) - :Days
            GROUP BY TRUNC(CREATEDAT)
            ORDER BY TRUNC(CREATEDAT)";

        var results = await connection.QueryAsync<(DateTime TicketDate, int Cnt)>(sql, new { Days = days });

        // Fill in missing days with zero counts
        var startDate = DateTime.UtcNow.Date.AddDays(-(days - 1));
        var ticketsPerDay = new List<TicketsPerDayDto>();

        for (int i = 0; i < days; i++)
        {
            var date = startDate.AddDays(i);
            var count = results.FirstOrDefault(r => r.TicketDate.Date == date).Cnt;
            ticketsPerDay.Add(new TicketsPerDayDto { Date = date, Count = count });
        }

        return ticketsPerDay;
    }
}
