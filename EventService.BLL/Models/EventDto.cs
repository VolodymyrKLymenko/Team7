using System;

namespace EventService.BLL.Models
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public int EventStatusId { get; set; }
        public int FacultyId { get; set; }
    }
}
