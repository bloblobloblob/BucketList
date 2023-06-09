﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BucketListApp.Class;
using BucketListApp.Page;
using BucketListApp.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BucketListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateGoalPage : ContentPage
    {
        Category cat;
        public CreateGoalPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MessagingCenter.Subscribe<CategoryPage, Category>(this, "ChangeCat", (sender, arg) =>
            {
                ButCat.Text = arg.Name;
                cat = arg;
            });
        }

        public void Pod1Ch(object sender, TextChangedEventArgs e)
        {
            Pod2.IsVisible = true;
        }

        public void Pod2Ch(object sender, TextChangedEventArgs e)
        {
            Pod3.IsVisible = true;
        }

        public void Pod3Ch(object sender, TextChangedEventArgs e)
        {
            Pod4.IsVisible = true;
        }

        public void Pod4Ch(object sender, TextChangedEventArgs e)
        {
            Pod5.IsVisible = true;
        }

        public void Pod5Ch(object sender, TextChangedEventArgs e)
        {
            Pod6.IsVisible = true;
        }

        public async void Cat(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CategoryPage());
            return;
        }

        public void Clear()
        {
            Name.Text = "";
            ButCat.Text = "Выбрать категорию";
            About.Text = "";
            Pod1.Text = "";
            Pod2.IsVisible = false;
            Pod3.IsVisible = false;
            Pod4.IsVisible = false;
            Pod5.IsVisible = false;
            Pod6.IsVisible = false;
        }

        public async void NewGoal(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text))
            {
                var ap = new AlertPage();
                ap.ErrTxt.Text = "Введены не все данные";
                ap.Txt.Text = "Введите название цели";
                await Navigation.PushModalAsync(ap);
                return;
            }

            if (ButCat.Text == "Выбрать категорию")
            {
                var ap = new AlertPage();
                ap.ErrTxt.Text = "Введены не все данные";
                ap.Txt.Text = "Выберите категорию";
                await Navigation.PushModalAsync(ap);
                return;
            }

            if (string.IsNullOrEmpty(About.Text))
            {
                var ap = new AlertPage();
                ap.ErrTxt.Text = "Введены не все данные";
                ap.Txt.Text = "Введите описание";
                await Navigation.PushModalAsync(ap);
                return;
            }

            string title = Name.Text.Trim();
            string desc = About.Text.Trim();
            List<SubTask> tasks = new List<SubTask>();
            if (Pod2.IsVisible == true) tasks.Add(new SubTask(Pod1.Text));
            if (Pod3.IsVisible == true) tasks.Add(new SubTask(Pod2.Text));
            if (Pod4.IsVisible == true) tasks.Add(new SubTask(Pod3.Text));
            if (Pod5.IsVisible == true) tasks.Add(new SubTask(Pod4.Text));
            if (Pod6.IsVisible == true) tasks.Add(new SubTask(Pod5.Text));

            Goal goal = new Goal(title, desc, cat, tasks);
            MessagingCenter.Send<CreateGoalPage, Goal>(this, "AddGoal", goal);
            Clear();
        }
    }
}