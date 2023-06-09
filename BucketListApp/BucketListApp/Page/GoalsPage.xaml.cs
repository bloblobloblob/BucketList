using BucketListApp.Class;
using BucketListApp.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Xaml.Diagnostics;

namespace BucketListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoalsPage : ContentPage
    {
        public GoalList GoalList { get; set; }
        public GoalsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            GoalList = new GoalList();
            MessagingCenter.Subscribe<CreateGoalPage, Goal>(this, "AddGoal", (sender, arg) =>
            {
                GoalList.AddCustomGoal(arg.Title, arg.Description, arg.Category, arg.SubTasks);
            });

            BindingContext = GoalList;
        }
        protected override void OnAppearing()
        {
            
            base.OnAppearing();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new GoalCard());
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
