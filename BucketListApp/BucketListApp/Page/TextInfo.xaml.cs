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
    public partial class TextInfo : ContentPage
    {
        public TextInfo()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MessagingCenter.Subscribe<ArticlesPage, Article>(this, "currInfo", (sender, arg) =>
            {
                TitleArticle.Text = arg.Name;
                TextArt.Text = arg.Text;
                Img.Source = arg.ImageUrl;
            });
        }
    }
}