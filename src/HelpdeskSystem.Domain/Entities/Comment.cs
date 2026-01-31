using HelpdeskSystem.Domain.Common;

namespace HelpdeskSystem.Domain.Entities;

public class Comment : BaseEntity
{
    public string TicketId { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string CreatedByUserId { get; set; } = string.Empty;

    // Navigation properties
    public virtual Ticket? Ticket { get; set; }
    public virtual ApplicationUser? CreatedByUser { get; set; }
}
