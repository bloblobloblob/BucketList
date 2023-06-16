using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BucketListApp.Class;
using BucketListApp.Page;
using BucketListApp.Custom;

namespace BucketListApp.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditGoal : ContentPage
    {
        Category cat;
        Goal CurrGoal;

        public EditGoal()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MessagingCenter.Subscribe<GoalCard, Goal>(this, "edit", (sender, arg) =>
            {
                CurrGoal = arg;
                cat = arg.Category;
                Name.Text = arg.Title;
                ButCat.Text = arg.Category.Name;
                About.Text = arg.Description;
                if (arg.SubTasks.Count != 0)
                {
                    for (int i = 0; i < arg.SubTasks.Count; i++)
                    {
                        SubTask task = arg.SubTasks[i];
                        if (i == 0) Pod1.Text = task.Description; Pod2.IsVisible = true;
                        if (i == 1) Pod2.Text = task.Description; Pod3.IsVisible = true;
                        if (i == 3) Pod3.Text = task.Description; Pod4.IsVisible = true;
                        if (i == 4) Pod4.Text = task.Description; Pod5.IsVisible = true;
                        if (i == 5) Pod5.Text = task.Description; Pod6.IsVisible = true;
                    }
                }
            });
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

        public async void EditThisGoal(object sender, EventArgs e)
        {
            string desc = "Без описания";

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

            if (!string.IsNullOrEmpty(About.Text))
            {
                desc = About.Text.Trim();
            }

            string title = Name.Text.Trim();
            List<SubTask> tasks = new List<SubTask>();
            if (Pod2.IsVisible == true) tasks.Add(new SubTask(Pod1.Text));
            if (Pod3.IsVisible == true) tasks.Add(new SubTask(Pod2.Text));
            if (Pod4.IsVisible == true) tasks.Add(new SubTask(Pod3.Text));
            if (Pod5.IsVisible == true) tasks.Add(new SubTask(Pod4.Text));
            if (Pod6.IsVisible == true) tasks.Add(new SubTask(Pod5.Text));

            Goal goal = new Goal(title, desc, cat, tasks, "Цель пока не завершена");
            var list = AppInitials.Goals;
            if (list.goals.Contains(CurrGoal))
            {
                var index = list.goals.IndexOf(CurrGoal);
                list.goals.RemoveAt(index);
                list.goals.Insert(index, goal);
            }
            else
            {
                var ap = new AlertPage();
                ap.ErrTxt.Text = "Ошибка";
                ap.Txt.Text = "Ошибка при изменении цели";
                await Navigation.PushModalAsync(ap);
            }
            Clear();
            OnBackButtonPressed();
            OnBackButtonPressed();
        }
    }
}