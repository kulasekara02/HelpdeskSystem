using HelpdeskSystem.Application.DTOs;
using HelpdeskSystem.Domain.Entities;

namespace HelpdeskSystem.Application.Interfaces;

public interface ICommentService
{
    Task<List<CommentDto>> GetCommentsByTicketIdAsync(string ticketId, CancellationToken cancellationToken = default);
    Task<CommentDto> AddCommentAsync(CreateCommentDto dto, string userId, CancellationToken cancellationToken = default);
    Task<bool> DeleteCommentAsync(string id, CancellationToken cancellationToken = default);
}

public interface ICommentRepository : IRepository<Comment>
{
    Task<IEnumerable<Comment>> GetByTicketIdAsync(string ticketId, CancellationToken cancellationToken = default);
}
