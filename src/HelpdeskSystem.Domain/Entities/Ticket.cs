using HelpdeskSystem.Domain.Common;
using HelpdeskSystem.Domain.Enums;

namespace HelpdeskSystem.Domain.Entities;

public class Ticket : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TicketPriority Priority { get; set; } = TicketPriority.Medium;
    public TicketStatus Status { get; set; } = TicketStatus.Open;
    public DateTime? UpdatedAt { get; set; }

    // Foreign Keys
    public string CreatedByUserId { get; set; } = string.Empty;
    public string? AssignedAgentId { get; set; }

    // Navigation properties
    public virtual ApplicationUser? CreatedByUser { get; set; }
    public virtual ApplicationUser? AssignedAgent { get; set; }
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<StatusHistory> StatusHistories { get; set; } = new List<StatusHistory>();
}
