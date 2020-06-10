using MobileApp.Models.Events;
using MobileApp.Services.Events;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MobileApp.Services.LiteDB;

namespace MobileApp.ViewModels.Events
{
    class EventsViewModel : BaseViewModel
    {
        private EventsService eventsService => DependencyService.Get<EventsService>();
        private FavoureService favoureService => DependencyService.Get<FavoureService>();

        public ObservableCollection<Event> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

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

        public EventsViewModel()
        {
            Title = "Events";

            Items = new ObservableCollection<Event>();

            DependencyService.Get<EventsLiteDBService>().RemoveAll();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //Items.Add(new EventResponse { Title = "First Event", Description = "Add some description there", StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(1).AddHours(1), SupportPhone = "+38(096)-55-66-454" });
            //Items.Add(new EventResponse { Title = "Second Event", Description = "Add some description there", StartDate = DateTime.Now.AddDays(2), EndDate = DateTime.Now.AddDays(2).AddHours(2), SupportPhone = "+38(096)-55-66-454" });
            //Items.Add(new EventResponse { Title = "Third Event", Description = "Add some description there", StartDate = DateTime.Now.AddDays(3), EndDate = DateTime.Now.AddDays(3).AddHours(3), SupportPhone = "+38(096)-55-66-454" });
            //Items.Add(new EventResponse { Title = "Fourth Event", Description = "Add some description there", StartDate = DateTime.Now.AddDays(4), EndDate = DateTime.Now.AddDays(4).AddHours(4), SupportPhone = "+38(096)-55-66-454" });
            //Items.Add(new EventResponse { Title = "Fifth Event", Description = "Add some description there", StartDate = DateTime.Now.AddDays(5), EndDate = DateTime.Now.AddDays(5).AddHours(5), SupportPhone = "+38(096)-55-66-454" });

        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();

                var items = (await eventsService.GetItemsAsync(true)).OrderBy(x => x.StartDateTime);
                var favoureItems = await favoureService.GetItemsAsync();


                foreach (var i in items)
                {
                    var favoure = favoureItems.FirstOrDefault(x => x.Id == i.Id);

                    if (favoure != null)
                    {
                        i.isFavoure = true;
                    }
                    else
                    {
                        i.isFavoure = false;
                    }

                    Items.Add(i);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
