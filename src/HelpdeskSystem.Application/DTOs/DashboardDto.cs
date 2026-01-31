namespace HelpdeskSystem.Application.DTOs;

public class DashboardDto
{
    public int TotalTickets { get; set; }
    public int OpenTickets { get; set; }
    public int InProgressTickets { get; set; }
    public int ResolvedTickets { get; set; }
    public int ClosedTickets { get; set; }
    public double AverageResolutionHours { get; set; }
    public List<TicketsByStatusDto> TicketsByStatus { get; set; } = new();
    public List<TicketsPerDayDto> TicketsPerDay { get; set; } = new();
}

public class TicketsByStatusDto
{
    public string Status { get; set; } = string.Empty;
    public int Count { get; set; }
}

public class TicketsPerDayDto
{
    public DateTime Date { get; set; }
    public int Count { get; set; }
}
