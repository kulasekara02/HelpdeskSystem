using HelpdeskSystem.Application.DTOs;
using HelpdeskSystem.Application.Interfaces;
using HelpdeskSystem.Domain.Entities;
using HelpdeskSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HelpdeskSystem.Infrastructure.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Ticket?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _context.Tickets
            .Include(t => t.CreatedByUser)
            .Include(t => t.AssignedAgent)
            .Include(t => t.StatusHistories)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Tickets
            .Include(t => t.CreatedByUser)
            .Include(t => t.AssignedAgent)
            .Include(t => t.Comments)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Ticket> AddAsync(Ticket entity, CancellationToken cancellationToken = default)
    {
        await _context.Tickets.AddAsync(entity, cancellationToken);
        return entity;
    }

    public Task UpdateAsync(Ticket entity, CancellationToken cancellationToken = default)
    {
        _context.Tickets.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Ticket entity, CancellationToken cancellationToken = default)
    {
        _context.Tickets.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<(IEnumerable<Ticket> Tickets, int TotalCount)> GetFilteredAsync(
        TicketFilterDto filter, CancellationToken cancellationToken = default)
    {
        var query = _context.Tickets
            .Include(t => t.CreatedByUser)
            .Include(t => t.AssignedAgent)
            .Include(t => t.Comments)
            .AsQueryable();

        // Apply filters
        if (filter.Status.HasValue)
        {
            query = query.Where(t => t.Status == filter.Status.Value);
        }

        if (filter.Priority.HasValue)
        {
            query = query.Where(t => t.Priority == filter.Priority.Value);
        }

        if (filter.DateFrom.HasValue)
        {
            query = query.Where(t => t.CreatedAt >= filter.DateFrom.Value);
        }

        if (filter.DateTo.HasValue)
        {
            query = query.Where(t => t.CreatedAt <= filter.DateTo.Value);
        }

        if (!string.IsNullOrEmpty(filter.AssignedAgentId))
        {
            query = query.Where(t => t.AssignedAgentId == filter.AssignedAgentId);
        }

        if (!string.IsNullOrEmpty(filter.SearchTerm))
        {
            var searchTerm = filter.SearchTerm.ToLower();
            query = query.Where(t =>
                t.Title.ToLower().Contains(searchTerm) ||
                t.Description.ToLower().Contains(searchTerm));
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var tickets = await query
            .OrderByDescending(t => t.CreatedAt)
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync(cancellationToken);

        return (tickets, totalCount);
    }

    public async Task<Ticket?> GetTicketWithDetailsAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _context.Tickets
            .Include(t => t.CreatedByUser)
            .Include(t => t.AssignedAgent)
            .Include(t => t.Comments)
                .ThenInclude(c => c.CreatedByUser)
            .Include(t => t.StatusHistories)
                .ThenInclude(h => h.ChangedByUser)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Ticket>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await _context.Tickets
            .Include(t => t.CreatedByUser)
            .Include(t => t.AssignedAgent)
            .Where(t => t.CreatedByUserId == userId)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Ticket>> GetByAgentIdAsync(string agentId, CancellationToken cancellationToken = default)
    {
        return await _context.Tickets
            .Include(t => t.CreatedByUser)
            .Include(t => t.AssignedAgent)
            .Where(t => t.AssignedAgentId == agentId)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync(cancellationToken);
    }
}
