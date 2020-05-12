using System;

namespace MobileApp.Models.Events
{
    class EventModel
    {
        public string Title { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string CategoryId { get; set; }
    }
}
