using BucketListApp.Class;
using BucketListApp.Custom;
using BucketListApp.Page;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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
            GoalList = AppInitials.Goals;
            MessagingCenter.Subscribe<CreateGoalPage, Goal>(this, "AddGoal", (sender, arg) =>
            {
                GoalList.AddCustomGoal(arg.Title, arg.Description, arg.Category, arg.SubTasks);
                GoalList.goals[GoalList.goals.Count - 1].Memories = "Цель еще не выполнена";
            });

            BindingContext = GoalList;
            CollView.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
            {
                ItemSpacing = 8
            };
        }
        protected override void OnAppearing()
        {
            
            if (GoalList.goals.Count == 0)
            {
                Empty.Source = "EmptyGoals.png";
            }
            else
            {
                Empty.Source = "";
            }
            base.OnAppearing();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CollView.SelectedItem == null) return;
            var ap = new GoalCard();
            Goal curr = e.CurrentSelection.FirstOrDefault() as Goal;
            MessagingCenter.Send<GoalsPage, Goal>(this, "OpenGoalCard", curr);
            //CollView.SelectionMode = SelectionMode.None;
            //CollView.SelectionMode = SelectionMode.Single;
            await Navigation.PushModalAsync(ap);
            CollView.SelectedItem = null;
            return;
        }
    }
}
