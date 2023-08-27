
using AutoMapper;
using YourScheduler.BusinessLogic.Models.DTOs;
using YourScheduler.Infrastructure.Entities;

namespace YourScheduler.BusinessLogic.MappingConfig
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EventDto, Event>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EventId));

            CreateMap<TeamDto, Team>()
                .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Team, TeamDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TeamId));

            CreateMap<ApplicationUserDto, ApplicationUser>();

            CreateMap<ApplicationUser, ApplicationUserDto>();

            CreateMap<TeamMembersDto, Team>()
                .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Team, TeamMembersDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TeamId));

            CreateMap<EventMembersDto, Event>()
                .ForMember(dest => dest.AdministratorId, opt => opt.MapFrom(src => src.administratorId))
                .ForMember(dest => dest.IsOpen, opt => opt.MapFrom(src => src.Isopen));

            CreateMap<Event, EventMembersDto>()
                .ForMember(dest => dest.administratorId, opt => opt.MapFrom(src => src.AdministratorId))
                .ForMember(dest => dest.Isopen, opt => opt.MapFrom(src => src.IsOpen));


        }
    }
}
