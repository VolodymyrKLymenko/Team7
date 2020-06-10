using AutoMapper;
using EventService.BLL.Interfaces;
using EventService.BLL.Models;
using EventService.DAL.Entities;
using EventService.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public EventDto Create(EventDto eventDto)
        {
            var newEvent = events.Create(mapper.Map<Event>(eventDto));

            newEvent = events.GetWithInclude(e => e.Faculty).Single(e => e.Id == newEvent.Id);

            return mapper.Map<EventDto>(newEvent);
        }

        public EventDto Update(EventDto eventDto)
        {
            var newEvent = events.Update(mapper.Map<Event>(eventDto));

            newEvent = events.GetWithInclude(e => e.Faculty).Single(e => e.Id == newEvent.Id);

            return mapper.Map<EventDto>(newEvent);
        }

        public void Remove(int eventId) =>
                events.Remove(eventId);

        public IEnumerable<EventDto> GetAll() =>
            events.GetWithInclude(e => e.Faculty).Select(x => mapper.Map<EventDto>(x)).ToArray();
    }
}
