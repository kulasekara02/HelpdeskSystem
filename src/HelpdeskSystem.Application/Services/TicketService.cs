using AutoMapper;
using HelpdeskSystem.Application.DTOs;
using HelpdeskSystem.Application.Interfaces;
using HelpdeskSystem.Domain.Entities;
using HelpdeskSystem.Domain.Enums;

namespace HelpdeskSystem.Application.Services;

public class TicketService : ITicketService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedResultDto<TicketDto>> GetTicketsAsync(TicketFilterDto filter, CancellationToken cancellationToken = default)
    {
        var (tickets, totalCount) = await _unitOfWork.Tickets.GetFilteredAsync(filter, cancellationToken);

        var ticketDtos = _mapper.Map<List<TicketDto>>(tickets);

        return new PagedResultDto<TicketDto>
        {
            Items = ticketDtos,
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

    public async Task<TicketDetailsDto?> GetTicketByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var ticket = await _unitOfWork.Tickets.GetTicketWithDetailsAsync(id, cancellationToken);
        return ticket == null ? null : _mapper.Map<TicketDetailsDto>(ticket);
    }

    public async Task<TicketDto> CreateTicketAsync(CreateTicketDto dto, string userId, CancellationToken cancellationToken = default)
    {
        var ticket = new Ticket
        {
            Id = Guid.NewGuid().ToString(),
            Title = dto.Title,
            Description = dto.Description,
            Priority = dto.Priority,
            Status = TicketStatus.Open,
            CreatedAt = DateTime.UtcNow,
            CreatedByUserId = userId
        };

        await _unitOfWork.Tickets.AddAsync(ticket, cancellationToken);

        // Add initial status history
        var statusHistory = new StatusHistory
        {
            Id = Guid.NewGuid().ToString(),
            TicketId = ticket.Id,
            OldStatus = null,
            NewStatus = TicketStatus.Open,
            ChangedAt = DateTime.UtcNow,
            ChangedByUserId = userId
        };

        ticket.StatusHistories.Add(statusHistory);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TicketDto>(ticket);
    }

    public async Task<TicketDto?> UpdateTicketAsync(UpdateTicketDto dto, string userId, CancellationToken cancellationToken = default)
    {
        var ticket = await _unitOfWork.Tickets.GetByIdAsync(dto.Id, cancellationToken);
        if (ticket == null) return null;

        var oldStatus = ticket.Status;

        ticket.Title = dto.Title;
        ticket.Description = dto.Description;
        ticket.Priority = dto.Priority;
        ticket.Status = dto.Status;
        ticket.AssignedAgentId = dto.AssignedAgentId;
        ticket.UpdatedAt = DateTime.UtcNow;

        // Record status change if status changed
        if (oldStatus != dto.Status)
        {
            var statusHistory = new StatusHistory
            {
                Id = Guid.NewGuid().ToString(),
                TicketId = ticket.Id,
                OldStatus = oldStatus,
                NewStatus = dto.Status,
                ChangedAt = DateTime.UtcNow,
                ChangedByUserId = userId
            };
            ticket.StatusHistories.Add(statusHistory);
        }

        await _unitOfWork.Tickets.UpdateAsync(ticket, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<TicketDto>(ticket);
    }

    public async Task<bool> DeleteTicketAsync(string id, CancellationToken cancellationToken = default)
    {
        var ticket = await _unitOfWork.Tickets.GetByIdAsync(id, cancellationToken);
        if (ticket == null) return false;

        await _unitOfWork.Tickets.DeleteAsync(ticket, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> AssignAgentAsync(string ticketId, string agentId, string changedByUserId, CancellationToken cancellationToken = default)
    {
        var ticket = await _unitOfWork.Tickets.GetByIdAsync(ticketId, cancellationToken);
        if (ticket == null) return false;

        ticket.AssignedAgentId = agentId;
        ticket.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.Tickets.UpdateAsync(ticket, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<TicketDto>> GetUserTicketsAsync(string userId, CancellationToken cancellationToken = default)
    {
        var tickets = await _unitOfWork.Tickets.GetByUserIdAsync(userId, cancellationToken);
        return _mapper.Map<List<TicketDto>>(tickets);
    }

    public async Task<List<TicketDto>> GetAgentTicketsAsync(string agentId, CancellationToken cancellationToken = default)
    {
        var tickets = await _unitOfWork.Tickets.GetByAgentIdAsync(agentId, cancellationToken);
        return _mapper.Map<List<TicketDto>>(tickets);
    }
}
