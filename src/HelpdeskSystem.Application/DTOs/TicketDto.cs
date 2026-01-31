using HelpdeskSystem.Domain.Enums;

namespace HelpdeskSystem.Application.DTOs;

public class TicketDto
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TicketPriority Priority { get; set; }
    public TicketStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string CreatedByUserId { get; set; } = string.Empty;
    public string CreatedByUserName { get; set; } = string.Empty;
    public string? AssignedAgentId { get; set; }
    public string? AssignedAgentName { get; set; }
    public int CommentCount { get; set; }
}

public class CreateTicketDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TicketPriority Priority { get; set; } = TicketPriority.Medium;
}

public class UpdateTicketDto
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TicketPriority Priority { get; set; }
    public TicketStatus Status { get; set; }
    public string? AssignedAgentId { get; set; }
}

public class TicketDetailsDto : TicketDto
{
    public List<CommentDto> Comments { get; set; } = new();
    public List<StatusHistoryDto> StatusHistory { get; set; } = new();
}
