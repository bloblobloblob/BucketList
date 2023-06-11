using BucketListApp.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BucketListApp.Class;
using BucketListApp.Page;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BucketListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddGoalPage : ContentPage
    {
        public GoalList ReadyGoals;
        public AddGoalPage()
        {
            InitializeComponent();
            ReadyGoals = AppInitials.ExampleGoals;
            BindingContext = ReadyGoals;

        }

        public async void ToCreateGoalPage(object sender, EventArgs e)
        {
            var cgp = new CreateGoalPage();
            await Navigation.PushModalAsync(cgp);
        }
    }
}