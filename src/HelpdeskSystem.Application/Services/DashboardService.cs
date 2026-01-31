using HelpdeskSystem.Application.DTOs;
using HelpdeskSystem.Application.Interfaces;
using HelpdeskSystem.Domain.Enums;

namespace HelpdeskSystem.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IUnitOfWork _unitOfWork;

    public DashboardService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DashboardDto> GetDashboardDataAsync(CancellationToken cancellationToken = default)
    {
        var allTickets = (await _unitOfWork.Tickets.GetAllAsync(cancellationToken)).ToList();

        var dashboard = new DashboardDto
        {
            TotalTickets = allTickets.Count,
            OpenTickets = allTickets.Count(t => t.Status == TicketStatus.Open),
            InProgressTickets = allTickets.Count(t => t.Status == TicketStatus.InProgress),
            ResolvedTickets = allTickets.Count(t => t.Status == TicketStatus.Resolved),
            ClosedTickets = allTickets.Count(t => t.Status == TicketStatus.Closed)
        };

        // Tickets by status
        dashboard.TicketsByStatus = Enum.GetValues<TicketStatus>()
            .Select(s => new TicketsByStatusDto
            {
                Status = s.ToString(),
                Count = allTickets.Count(t => t.Status == s)
            })
            .ToList();

        // Tickets per day (last 14 days)
        var startDate = DateTime.UtcNow.Date.AddDays(-13);
        dashboard.TicketsPerDay = Enumerable.Range(0, 14)
            .Select(i => startDate.AddDays(i))
            .Select(date => new TicketsPerDayDto
            {
                Date = date,
                Count = allTickets.Count(t => t.CreatedAt.Date == date)
            })
            .ToList();

        // Average resolution hours (for resolved tickets)
        var resolvedTickets = allTickets
            .Where(t => t.Status == TicketStatus.Resolved && t.UpdatedAt.HasValue)
            .ToList();

        if (resolvedTickets.Any())
        {
            var totalHours = resolvedTickets
                .Sum(t => (t.UpdatedAt!.Value - t.CreatedAt).TotalHours);
            dashboard.AverageResolutionHours = Math.Round(totalHours / resolvedTickets.Count, 2);
        }

        return dashboard;
    }
}
