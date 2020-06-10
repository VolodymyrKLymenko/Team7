using AutoMapper;
using EventService.BLL.Models;
using EventService.DAL.Entities;

namespace EventService.BLL.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>()
                .ForMember(eDto => eDto.FacultyName, options => options.MapFrom(e => e.Faculty.Name))
                .ForMember(eDto => eDto.SupportPhone, options => options.MapFrom(e => e.Faculty.PhoneNumber));
            CreateMap<EventDto, Event>();
        }
    }
}
