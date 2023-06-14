﻿using BucketListApp.Class;
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
            });

            BindingContext = GoalList;
            CollView.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
            {
                ItemSpacing = 8
            };
            MessagingCenter.Subscribe<EditGoal, Goal>(this, "Edit", (sender, arg) =>
            {
                //GoalList.ChangeGoal
                GoalList.AddCustomGoal(arg.Title, arg.Description, arg.Category, arg.SubTasks);
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ap = new GoalCard();
            Goal curr = e.CurrentSelection.FirstOrDefault() as Goal;
            MessagingCenter.Send<GoalsPage, Goal>(this, "OpenGoalCard", curr);
            //CollView.SelectionMode = SelectionMode.None;
            //CollView.SelectionMode = SelectionMode.Single;
            await Navigation.PushModalAsync(ap);
            return;
        }
    }
}
