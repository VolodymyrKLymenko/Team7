using MobileApp.Models.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.ViewModels.Events
{
    public class EventVM : BaseViewModel
    {
        private EventResponse _selectedEvent;
        public EventResponse SelectedEvent
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

        public EventVM(EventResponse model)
        {
            SelectedEvent = model;

            Title = "Event";
        }
    }
}
