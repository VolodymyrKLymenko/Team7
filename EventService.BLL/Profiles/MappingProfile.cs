using AutoMapper;
using EventService.BLL.Models;
using EventService.DAL.Entities;

namespace EventService.BLL.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();
        }
    }
}
