using AutoMapper;
using HelpdeskSystem.Application.DTOs;
using HelpdeskSystem.Domain.Entities;

namespace HelpdeskSystem.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Ticket mappings
        CreateMap<Ticket, TicketDto>()
            .ForMember(dest => dest.CreatedByUserName,
                opt => opt.MapFrom(src => src.CreatedByUser != null ? src.CreatedByUser.FullName : string.Empty))
            .ForMember(dest => dest.AssignedAgentName,
                opt => opt.MapFrom(src => src.AssignedAgent != null ? src.AssignedAgent.FullName : null))
            .ForMember(dest => dest.CommentCount,
                opt => opt.MapFrom(src => src.Comments.Count));

        CreateMap<Ticket, TicketDetailsDto>()
            .ForMember(dest => dest.CreatedByUserName,
                opt => opt.MapFrom(src => src.CreatedByUser != null ? src.CreatedByUser.FullName : string.Empty))
            .ForMember(dest => dest.AssignedAgentName,
                opt => opt.MapFrom(src => src.AssignedAgent != null ? src.AssignedAgent.FullName : null))
            .ForMember(dest => dest.CommentCount,
                opt => opt.MapFrom(src => src.Comments.Count))
            .ForMember(dest => dest.Comments,
                opt => opt.MapFrom(src => src.Comments.OrderByDescending(c => c.CreatedAt)))
            .ForMember(dest => dest.StatusHistory,
                opt => opt.MapFrom(src => src.StatusHistories.OrderByDescending(h => h.ChangedAt)));

        CreateMap<CreateTicketDto, Ticket>();

        // Comment mappings
        CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.CreatedByUserName,
                opt => opt.MapFrom(src => src.CreatedByUser != null ? src.CreatedByUser.FullName : string.Empty));

        CreateMap<CreateCommentDto, Comment>();

        // Status history mappings
        CreateMap<StatusHistory, StatusHistoryDto>()
            .ForMember(dest => dest.ChangedByUserName,
                opt => opt.MapFrom(src => src.ChangedByUser != null ? src.ChangedByUser.FullName : string.Empty));

        // User mappings
        CreateMap<ApplicationUser, UserDto>()
            .ForMember(dest => dest.Roles, opt => opt.Ignore());
    }
}
