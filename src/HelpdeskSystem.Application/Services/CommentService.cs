using AutoMapper;
using HelpdeskSystem.Application.DTOs;
using HelpdeskSystem.Application.Interfaces;
using HelpdeskSystem.Domain.Entities;

namespace HelpdeskSystem.Application.Services;

public class CommentService : ICommentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<CommentDto>> GetCommentsByTicketIdAsync(string ticketId, CancellationToken cancellationToken = default)
    {
        var comments = await _unitOfWork.Comments.GetByTicketIdAsync(ticketId, cancellationToken);
        return _mapper.Map<List<CommentDto>>(comments);
    }

    public async Task<CommentDto> AddCommentAsync(CreateCommentDto dto, string userId, CancellationToken cancellationToken = default)
    {
        var comment = new Comment
        {
            Id = Guid.NewGuid().ToString(),
            TicketId = dto.TicketId,
            Text = dto.Text,
            CreatedAt = DateTime.UtcNow,
            CreatedByUserId = userId
        };

        await _unitOfWork.Comments.AddAsync(comment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CommentDto>(comment);
    }

    public async Task<bool> DeleteCommentAsync(string id, CancellationToken cancellationToken = default)
    {
        var comment = await _unitOfWork.Comments.GetByIdAsync(id, cancellationToken);
        if (comment == null) return false;

        await _unitOfWork.Comments.DeleteAsync(comment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
