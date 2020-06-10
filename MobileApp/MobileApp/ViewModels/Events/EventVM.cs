using MobileApp.Models.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.ViewModels.Events
{
    public class EventVM : BaseViewModel
    {
        private Event _selectedEvent;
        public Event SelectedEvent
        {
            get
            {
                return _selectedEvent;
            }
            set
            {
                SetProperty(ref _selectedEvent, value);
            }
        }

        public EventVM(Event model)
        {
            SelectedEvent = model;

            Title = "Event";
        }
    }
}
