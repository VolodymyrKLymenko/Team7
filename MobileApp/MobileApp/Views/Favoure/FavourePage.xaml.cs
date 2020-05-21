using MobileApp.ViewModels.Events;
using MobileApp.ViewModels.Favoure;
using MobileApp.Views.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views.Favoure
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavourePage : ContentPage
    {
        FavoureViewModel viewModel;

        public FavourePage()
        {
            BindingContext = viewModel = new FavoureViewModel();
            InitializeComponent();
            Calenar.StartDay = DayOfWeek.Monday;
            if (viewModel.Events.Count == 0)
            {
                viewModel.LoadEventsCommand.Execute(null);
            }
            Calenar.SelectedDate = DateTime.Now;
        }

        private void EventsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (viewModel.SelectedEvent != null)
            {
                Navigation.PushAsync(new EventPage(new EventVM(viewModel.SelectedEvent)), true);
                viewModel.SelectedEvent = null;
            }
        }
    }
}