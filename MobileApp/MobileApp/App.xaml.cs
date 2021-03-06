﻿using MobileApp.Services;
using MobileApp.Services.Events;
using MobileApp.Services.LiteDB;
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
            DeviceInfo.Platform == DevicePlatform.Android ? "https://localhost:44336/" : "https://localhost:44336/";

        internal static readonly string dbConectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "lnuevents.db");

        internal void SwichView<T>() where T : Page
        {
            MainPage = Activator.CreateInstance<T>();
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<EventsService>();
            DependencyService.Register<FavoureService>();
            DependencyService.Register<EventsLiteDBService>();
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
