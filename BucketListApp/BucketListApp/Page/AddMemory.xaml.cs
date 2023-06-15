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
    public partial class AddMemory : ContentPage
    {
        public AddMemory()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        public void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            OnBackButtonPressed();
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<AddMemory, string>(this, "GetMemory", textMem.Text);
            OnBackButtonPressed();
        }
    }
}