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

            InitializeComponent();
        }
    }
}