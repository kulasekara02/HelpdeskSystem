using HelpdeskSystem.Application.DTOs;
using HelpdeskSystem.Domain.Entities;

namespace HelpdeskSystem.Application.Interfaces;

public interface ITicketService
{
    Task<PagedResultDto<TicketDto>> GetTicketsAsync(TicketFilterDto filter, CancellationToken cancellationToken = default);
    Task<TicketDetailsDto?> GetTicketByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<TicketDto> CreateTicketAsync(CreateTicketDto dto, string userId, CancellationToken cancellationToken = default);
    Task<TicketDto?> UpdateTicketAsync(UpdateTicketDto dto, string userId, CancellationToken cancellationToken = default);
    Task<bool> DeleteTicketAsync(string id, CancellationToken cancellationToken = default);
    Task<bool> AssignAgentAsync(string ticketId, string agentId, string changedByUserId, CancellationToken cancellationToken = default);
    Task<List<TicketDto>> GetUserTicketsAsync(string userId, CancellationToken cancellationToken = default);
    Task<List<TicketDto>> GetAgentTicketsAsync(string agentId, CancellationToken cancellationToken = default);
}

public interface ITicketRepository : IRepository<Ticket>
{
    Task<(IEnumerable<Ticket> Tickets, int TotalCount)> GetFilteredAsync(TicketFilterDto filter, CancellationToken cancellationToken = default);
    Task<Ticket?> GetTicketWithDetailsAsync(string id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Ticket>> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Ticket>> GetByAgentIdAsync(string agentId, CancellationToken cancellationToken = default);
}
