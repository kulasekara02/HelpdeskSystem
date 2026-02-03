using Dapper;
using HelpdeskSystem.Application.DTOs;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

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
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("SQLite connection string not configured");
    }

    public async Task<DashboardDto> GetDashboardDataAsync()
    {
        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        var dashboard = new DashboardDto();

        // Get ticket counts by status
        var statusCountsSql = @"
            SELECT Status, COUNT(*) AS Cnt
            FROM Tickets
            GROUP BY Status";

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

        // Get average resolution time (in hours)
        var avgResolutionSql = @"
            SELECT AVG((julianday(UpdatedAt) - julianday(CreatedAt)) * 24) AS AvgHours
            FROM Tickets
            WHERE Status = 'Resolved'
            AND UpdatedAt IS NOT NULL";

        var avgHours = await connection.QueryFirstOrDefaultAsync<double?>(avgResolutionSql);
        dashboard.AverageResolutionHours = Math.Round(avgHours ?? 0, 2);

        // Get tickets per day (last 14 days)
        dashboard.TicketsPerDay = await GetTicketsPerDayAsync(14);

        return dashboard;
    }

    public async Task<List<TicketsPerDayDto>> GetTicketsPerDayAsync(int days)
    {
        using var connection = new SqliteConnection(_connectionString);
        await connection.OpenAsync();

        var sql = @"
            SELECT date(CreatedAt) AS TicketDate, COUNT(*) AS Cnt
            FROM Tickets
            WHERE CreatedAt >= date('now', @Days || ' days')
            GROUP BY date(CreatedAt)
            ORDER BY date(CreatedAt)";

        var results = await connection.QueryAsync<(string TicketDate, int Cnt)>(sql, new { Days = -days });

        // Fill in missing days with zero counts
        var startDate = DateTime.UtcNow.Date.AddDays(-(days - 1));
        var ticketsPerDay = new List<TicketsPerDayDto>();

        for (int i = 0; i < days; i++)
        {
            var date = startDate.AddDays(i);
            var dateStr = date.ToString("yyyy-MM-dd");
            var count = results.FirstOrDefault(r => r.TicketDate == dateStr).Cnt;
            ticketsPerDay.Add(new TicketsPerDayDto { Date = date, Count = count });
        }

        return ticketsPerDay;
    }
}
