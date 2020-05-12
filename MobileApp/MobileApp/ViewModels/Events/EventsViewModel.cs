using MobileApp.Models.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MobileApp.ViewModels.Events
{
    class EventsViewModel : BaseViewModel
    {
        public ObservableCollection<EventModel> Events { get; set; }

        public EventsViewModel()
        {
            Title = "Events";

            Events = new ObservableCollection<EventModel>();

            Events.Add(new EventModel { Title = "First Event", Description = "Add some description there", StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(1) });
            Events.Add(new EventModel { Title = "Second Event", Description = "Add some description there", StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(2) });
            Events.Add(new EventModel { Title = "Third Event", Description = "Add some description there", StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(3) });
            Events.Add(new EventModel { Title = "Fourth Event", Description = "Add some description there", StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(4) });
            Events.Add(new EventModel { Title = "Fifth Event", Description = "Add some description there", StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(5) });
        }
    }
}
