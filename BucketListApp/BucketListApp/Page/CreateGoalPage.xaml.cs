using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BucketListApp.Class;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BucketListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateGoalPage : ContentPage
    {
        public CreateGoalPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public async void NewGoal(object sender, EventArgs e)
        {
            string title = Name.Text.Trim();
            string cat = Cat.Text.Trim();
            string desc = About.Text.Trim();
            string pod = Pod.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                await DisplayAlert("Err", "NoTitle", "Ok");
                return;
            }

            //Goal goal = new Goal
            //{
            //    Title = title,
            //    Description = desc,
            //    Category = cat,
            //    SubTasks = pod,
            //};
        }
    }
}