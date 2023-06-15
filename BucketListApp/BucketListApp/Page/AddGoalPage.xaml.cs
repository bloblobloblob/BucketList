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
            CollView.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
            {
                ItemSpacing = 8
            };
        }

        public async void ToCreateGoalPage(object sender, EventArgs e)
        {
            var cgp = new CreateGoalPage();
            await Navigation.PushModalAsync(cgp);
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ap = new CreateGoalPage();
            Goal curr = e.CurrentSelection.FirstOrDefault() as Goal;
            MessagingCenter.Send<AddGoalPage, Goal>(this, "CreateGoal", curr);
            //CollView.SelectionMode = SelectionMode.None;
            //CollView.SelectionMode = SelectionMode.Single;
            await Navigation.PushModalAsync(ap);
            return;
        }
    }
}
