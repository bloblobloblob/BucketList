using System;
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
        public CreateGoalPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MessagingCenter.Subscribe<CategoryPage, string>(this, "ChangeCat", (sender, arg) =>
            {
                ButCat.Text = arg;
            });
        }

        public async void Cat(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CategoryPage());
            return;
        }

        public async void NewGoal(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AlertPage());
            return;
            //string title = Name.Text.Trim();
            //string cat = Cat.Text.Trim();
            //string desc = About.Text.Trim();
            //string pod = Pod.Text.Trim();

            //if (string.IsNullOrEmpty(title))
            //{
            //    var ap = new AlertPage();
            //    ap.LblTitle.Text = "Instructions";
            //    ap.LblText.Text = "The text to display!";
            //    ap.Button1.Text = "Done";
            //    ap.Button1.Clicked += async (s, a) =>
            //    {
            //        await Navigation.PopModalAsync();
            //    };
            //    ap.Button2.IsVisible = false;
            //    await Navigation.PushModalAsync(ap);
            //    return;
            //}

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