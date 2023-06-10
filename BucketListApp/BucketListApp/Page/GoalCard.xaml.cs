using BucketListApp.Class;
using BucketListApp.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BucketListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoalCard : ContentPage
    {
        public GoalCard()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MessagingCenter.Subscribe<GoalsPage, Goal>(this, "OpenGoalCard", (sender, arg) =>
            {
                Icon.Source = arg.Category.IconWhite.Source;
                Lbl1.Text = arg.Title;
                Lbl2.Text = arg.CreationDate.ToString("dd.MM.yy");
                Lbl3.Text = arg.Description;
                Lbl4.Text = "#" + arg.Category.Name;
                Prog.Progress = arg.Done;
                if (arg.SubTasks.Count == 0)
                {
                    Lbl5.Text = "";
                    Frm.BackgroundColor = Xamarin.Forms.Color.FromRgb(30, 30, 30);
                    Frm.HasShadow = false;
                }
                else
                {
                    for (int i = 0; i < arg.SubTasks.Count; i++)
                    {
                        SubTask task = arg.SubTasks[i];
                        if (i == arg.SubTasks.Count - 1) Pod.Text += task.Description;
                        else Pod.Text += task.Description + "\n" + "\n";
                    }
                }
            });
        }

        public void RetutnToGoalsPage(object sender, EventArgs e)
        {
            OnBackButtonPressed();
        }
    }
}
