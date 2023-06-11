using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.XPath;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BucketListApp.Class;

namespace BucketListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        { 
            GetComplited();
        }
        private void GetComplited()
        {
            ComplG.Text = string.Format("{0}%",AppInitials.TotalCompletedRatio.ToString());
            progressRing.Progress = AppInitials.TotalCompletedRatio / 100;
            DiffrentCompAndProgress.Text = String.Format("{0}/{1}", AppInitials.TotalCompletedRatio, AppInitials.TotalProgressRatio);
        }
    }
}