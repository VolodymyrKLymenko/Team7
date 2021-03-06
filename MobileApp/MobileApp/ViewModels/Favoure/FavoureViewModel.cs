﻿using MobileApp.Models.Events;
using MobileApp.Services.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamForms.Controls;

namespace MobileApp.ViewModels.Favoure
{
    class DefSpecial : SpecialDate
    {
        public DefSpecial(DateTime date) : base(date)
        {
            BackgroundColor = Xamarin.Forms.Color.Red;
            Selectable = true;
        }
    }

    class FavoureViewModel : BaseViewModel
    {
        private FavoureService favoureService => DependencyService.Get<FavoureService>();

        public ObservableCollection<SpecialDate> special { get; set; }
        public ObservableCollection<Event> CurrentEvents { get; set; }
        public ObservableCollection<Event> Events { get; set; }

        private Event _SelectedEvent;
        public Event SelectedEvent
        {
            get
            {
                return _SelectedEvent;
            }
            set
            {
                SetProperty(ref _SelectedEvent, value);
            }
        }

        private DateTime _selDate;
        public DateTime selDate
        {
            get
            {
                return _selDate;
            }
            set
            {
                SetProperty(ref _selDate, value);
                FilterEventsByDate();
            }
        }

        public Command LoadEventsCommand { get; set; }

        private void FilterEventsByDate()
        {
            var filteredEvents = Events.Where(t => t.StartDateTime.Date <= selDate.Date && t.FinishDateTime.Date >= selDate.Date);
            filteredEvents.OrderBy(t => t.StartDateTime.Date);

            CurrentEvents.Clear();
            foreach (var i in filteredEvents)
            {
                CurrentEvents.Add(i);
            }
        }

        public FavoureViewModel()
        {
            special = new ObservableCollection<SpecialDate>();
            CurrentEvents = new ObservableCollection<Event>();
            Events = new ObservableCollection<Event>();
            SelectedEvent = null;

            LoadEventsCommand = new Command(async () => await ExecuteLoadEventsCommand());

            Title = "Selected Events";
        }

        async Task ExecuteLoadEventsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Events.Clear();
                var items = await favoureService.GetItemsAsync(true);

                items.OrderBy(t => t.StartDateTime.Date);
                foreach (var item in items)
                {
                    if (special.FirstOrDefault(d => d.Date == item.StartDateTime) == null)
                    {
                        special.Add(new DefSpecial(item.StartDateTime));
                        selDate = item.StartDateTime;
                    }
                    Events.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                FilterEventsByDate();
                IsBusy = false;
            }
        }
    }
}
