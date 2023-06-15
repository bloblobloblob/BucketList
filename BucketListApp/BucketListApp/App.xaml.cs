using BucketListApp.Class;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BucketListApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TabBar());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            AppInitials.SaveGoals();
        }

        protected override void OnResume()
        {
        }
    }
}
