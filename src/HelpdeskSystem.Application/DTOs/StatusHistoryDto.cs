using HelpdeskSystem.Domain.Enums;

namespace HelpdeskSystem.Application.DTOs;

public class StatusHistoryDto
{
    public string Id { get; set; } = string.Empty;
    public string TicketId { get; set; } = string.Empty;
    public TicketStatus? OldStatus { get; set; }
    public TicketStatus NewStatus { get; set; }
    public DateTime ChangedAt { get; set; }
    public string ChangedByUserId { get; set; } = string.Empty;
    public string ChangedByUserName { get; set; } = string.Empty;
}
