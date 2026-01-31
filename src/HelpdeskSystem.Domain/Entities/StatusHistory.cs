using HelpdeskSystem.Domain.Common;
using HelpdeskSystem.Domain.Enums;

namespace HelpdeskSystem.Domain.Entities;

public class StatusHistory : BaseEntity
{
    public string TicketId { get; set; } = string.Empty;
    public TicketStatus? OldStatus { get; set; }
    public TicketStatus NewStatus { get; set; }
    public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
    public string ChangedByUserId { get; set; } = string.Empty;

    // Navigation properties
    public virtual Ticket? Ticket { get; set; }
    public virtual ApplicationUser? ChangedByUser { get; set; }
}
