using HelpdeskSystem.Application.Interfaces;
using HelpdeskSystem.Infrastructure.Data;

namespace HelpdeskSystem.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private ITicketRepository? _tickets;
    private ICommentRepository? _comments;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public ITicketRepository Tickets => _tickets ??= new TicketRepository(_context);
    public ICommentRepository Comments => _comments ??= new CommentRepository(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
