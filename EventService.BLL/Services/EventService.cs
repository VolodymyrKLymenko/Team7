using AutoMapper;
using EventService.BLL.Interfaces;
using EventService.BLL.Models;
using EventService.DAL.Entities;
using EventService.DAL.Interfaces;

namespace EventService.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IGenericRepository<Event> events;
        private readonly IMapper mapper;

        public EventService(IGenericRepository<Event> events, IMapper mapper)
        {
            this.events = events;
            this.mapper = mapper;
        }

        public void Create(EventDto eventDto) =>
            events.Create(mapper.Map<Event>(eventDto));

        public void Update(EventDto eventDto) =>
            events.Update(mapper.Map<Event>(eventDto));

        public void Remove(int eventId) =>
            events.Remove(eventId);
    }
}
