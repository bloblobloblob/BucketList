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
        Goal CurrGoal;
        public GoalCard()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MessagingCenter.Subscribe<GoalsPage, Goal>(this, "OpenGoalCard", (sender, arg) =>
            {
                CurrGoal = arg;
                Icon.Source = arg.ImageWhite;
                Lbl1.Text = arg.Title;
                Lbl2.Text = arg.CreationDate.ToString("dd.MM.yy");
                Lbl3.Text = arg.Description;
                Lbl4.Text = "#" + arg.Category.Name;
                Prog.Progress = arg.Done;
                if (arg.SubTasks.Count == 0)
                {
                    Frm.BackgroundColor = Xamarin.Forms.Color.FromRgb(30, 30, 30);
                    Frm.HasShadow = false;
                }
                else
                {
                    foreach (var task in arg.SubTasks)
                    {
                        StackLayout subStack = new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                        };
                        CheckBox checkBox = new CheckBox();
                        Label label = new Label()
                        {
                            Text = task.Description,
                            VerticalOptions = LayoutOptions.Center,
                            TextColor = Color.White
                        };
                        checkBox.CheckedChanged += async (s, e) =>
                        {
                            if (checkBox.IsChecked)
                            {
                                await Task.Run(() =>
                                {
                                    task.ChangeState();
                                });
                            }
                        };
                        subStack.Children.Add(checkBox);
                        subStack.Children.Add(label);
                        taskContainer.Children.Add(subStack);
                    }
                }
                
            });
        }

        public void RetutnToGoalsPage(object sender, EventArgs e)
        {
            OnBackButtonPressed();
        }

        public async void EditGoal(object sender, EventArgs e)
        {
            var ep = new EditGoal();
            MessagingCenter.Send<GoalCard, Goal>(this, "edit", CurrGoal);
            await Navigation.PushModalAsync(ep);
        }
    }
}
