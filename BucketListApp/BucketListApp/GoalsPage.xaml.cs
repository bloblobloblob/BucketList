using System;
using System.Collections.Generic;
using System.Linq;
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
        public GoalsPage()
        {
            InitializeComponent();
        }
        
        async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new GoalCard());
        }
    }
}
