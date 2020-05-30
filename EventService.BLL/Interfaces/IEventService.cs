using EventService.BLL.Models;

namespace EventService.BLL.Interfaces
{
    public interface IEventService
    {
        public void Create(EventDto eventDto);
        public void Update(EventDto eventDto);
        void Remove(int eventId);
    }
}
