using HelpdeskSystem.Application.Interfaces;
using HelpdeskSystem.Domain.Entities;
using HelpdeskSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskSystem.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _context;

    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Comment?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _context.Comments
            .Include(c => c.CreatedByUser)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Comment>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Comments
            .Include(c => c.CreatedByUser)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Comment> AddAsync(Comment entity, CancellationToken cancellationToken = default)
    {
        await _context.Comments.AddAsync(entity, cancellationToken);
        return entity;
    }

    public Task UpdateAsync(Comment entity, CancellationToken cancellationToken = default)
    {
        _context.Comments.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Comment entity, CancellationToken cancellationToken = default)
    {
        _context.Comments.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Comment>> GetByTicketIdAsync(string ticketId, CancellationToken cancellationToken = default)
    {
        return await _context.Comments
            .Include(c => c.CreatedByUser)
            .Where(c => c.TicketId == ticketId)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync(cancellationToken);
    }
}
