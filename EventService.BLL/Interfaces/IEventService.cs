using EventService.BLL.Models;
using System.Collections.Generic;

namespace EventService.BLL.Interfaces
{
    public interface IEventService
    {
        public EventDto Create(EventDto eventDto);
        public void Update(EventDto eventDto);
        void Remove(int eventId);
        IEnumerable<EventDto> GetAll();
    }
}
