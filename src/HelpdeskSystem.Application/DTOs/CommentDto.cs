namespace HelpdeskSystem.Application.DTOs;

public class CommentDto
{
    public string Id { get; set; } = string.Empty;
    public string TicketId { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string CreatedByUserId { get; set; } = string.Empty;
    public string CreatedByUserName { get; set; } = string.Empty;
}

public class CreateCommentDto
{
    public string TicketId { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}
