using System;

namespace MobileApp.Models.Events
{
    public class EventResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OrganizedUniversity { get; set; }
        public string SupportPhone { get; set; }
        public EventStatus Status { get; set; }


        public bool isFavoure { get; set; } = false;
    }

    public enum EventStatus { Pending = 1, Finished, Cancelled }
}
