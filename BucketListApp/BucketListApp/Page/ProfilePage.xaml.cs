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
            ComplG.Text = string.Format("{0}%",(AppInitials.TotalCompletedRatio * 100).ToString());
            progressRing.Progress = AppInitials.TotalCompletedRatio;
            DiffrentCompAndProgress.Text = string.Format("{0}/{1}", AppInitials.CompletedGoals, AppInitials.TotalGoals);
            StatComplYear.Text = AppInitials.TotalCompletedPerYear.ToString();
            SpecificCat.Text = AppInitials.MostCompletedCategoryRatio.ToString();
            NameSpecCat.Text = string.Format("Целей выполнено \n в категории\n «{0}» ", AppInitials.MostCompletedCategoryName);
        }
    }
}