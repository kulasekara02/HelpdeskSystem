namespace HelpdeskSystem.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ITicketRepository Tickets { get; }
    ICommentRepository Comments { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
}
