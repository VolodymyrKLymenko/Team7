using System;

namespace EventService.DAL.Entities
{
    public class EventLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int EventActionId { get; set; }
        public EventAction EventAction { get; set; }
        public DateTime DateTime { get; set; }
    }
}
