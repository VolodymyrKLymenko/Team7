using System;

namespace MobileApp.Models.Events
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public int EventStatusId { get; set; }
        public EventStatus EventStatus { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }


        public bool isFavoure { get; set; } = false;
    }    
}
