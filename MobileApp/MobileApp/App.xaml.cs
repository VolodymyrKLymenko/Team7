using MobileApp.Services;
using MobileApp.Views;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    public partial class App : Application
    {
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://localhost:7777/api/" : "http://localhost:7777/api/";

        internal static readonly string dbConectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "lnuevents.db");

        internal void SwichView<T>() where T : Page
        {
            MainPage = Activator.CreateInstance<T>();
        }

        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            HttpSingleton.Get(AzureBackendUrl);

            ((App)Application.Current).SwichView<MainPage>();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
