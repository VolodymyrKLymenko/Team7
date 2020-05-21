using MobileApp.Models.Events;
using MobileApp.Services.LiteDB;
using MobileApp.ViewModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsPage : ContentPage
    {
        EventsViewModel viewModel;

        public EventsPage()
        {
            BindingContext = viewModel = new EventsViewModel();

            if (viewModel.Items.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }

            InitializeComponent();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as EventResponse;
            if (item == null)
                return;

            await Navigation.PushAsync(new EventPage(new EventVM(item)), true);

            // Manually deselect item.
            EventsListView.SelectedItem = null;
        }

        #region Search
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchReq.Text))
            {
                EventsListView.ItemsSource = viewModel.Items;
            }
            else
            {
                string req = searchReq.Text;

                if (req.Length > 50)
                {
                    req = req.Remove(50);
                }

                if (req.Length == 0 || req.ToList().FindIndex(r => Char.IsLetterOrDigit(r)) == -1)
                {
                    EventsListView.ItemsSource = viewModel.Items;
                }

                req = req.Trim().ToLower();

                List<string> words = new List<string>();
                int index = 0;

                for (int i = req.ToList().FindIndex(r => Char.IsLetterOrDigit(r)); i < req.Length; i++)
                {
                    if (words.Count <= index && Char.IsLetterOrDigit(req[i]))
                    {
                        words.Add(string.Empty);
                    }

                    else if (!Char.IsLetterOrDigit(req[i]))
                    {
                        continue;
                    }

                    while (i < req.Length && Char.IsLetterOrDigit(req[i]))
                    {
                        words[index] += req[i];
                        i++;
                    }

                    index++;
                }
                words = words.Distinct().ToList();

                Dictionary<EventResponse, int> searchRes = new Dictionary<EventResponse, int>();

                var all = viewModel.Items;

                IEnumerable<EventResponse> events;
                foreach (var w in words)
                {
                    events = all.Where(cust => cust.Title.ToLower().Contains(w)).ToList();
                    foreach (var c in events)
                    {
                        if (searchRes.ContainsKey(c))
                        {
                            searchRes[c]++;
                        }
                        else
                        {
                            searchRes.Add(c, 1);
                        }
                    }
                }

                events = searchRes.OrderByDescending(s => s.Value).Select(r => r.Key).ToList();

                EventsListView.ItemsSource = events;
            }
        }
        #endregion

        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            if (btn.AutomationId != null)
            {
                var item = viewModel.Items.FirstOrDefault(x => x.Id == Convert.ToInt32(btn.AutomationId));

                if (item != null)
                {
                    if (item.isFavoure)
                    {
                        item.isFavoure = false;
                        DependencyService.Get<EventsLiteDBService>().RemoveEventFromFavoure(item.Id);
                    }
                    else
                    {
                        item.isFavoure = true;
                        DependencyService.Get<EventsLiteDBService>().InsertEventToFavoure(item);
                    }

                    viewModel.LoadItemsCommand.Execute(null);
                }
            }

        }
    }
}