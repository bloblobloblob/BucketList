using BucketListApp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BucketListApp.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
        }

        public async void Next(object sender, EventArgs e)
        {
            string name = "Выбрать категорию";
            Image image1 = new Image();
            Image image2 = new Image();

            if (One.IsChecked)
            {
                name = "Отдых";
                image1 = new Image { Source = "chill.jpg" };
                image2 = new Image { Source = "chillWhite.jpg" };
            }
            else if (Two.IsChecked)
            {
                name = "Активности";
                image1 = new Image { Source = "activity.jpg" };
                image2 = new Image { Source = "activityWhite.jpg" };
            }
            else if (Three.IsChecked)
            {
                name = "Путешествия";
                image1 = new Image { Source = "airplane.jpg" };
                image2 = new Image { Source = "airplaneWhite.jpg" };
            }
            else if (Four.IsChecked)
            {
                name = "Челленджи";
                image1 = new Image { Source = "challange.jpg" };
                image2 = new Image { Source = "challangeWhite.jpg" };
            }
            else if (Five.IsChecked)
            {
                name = "Духовность";
                image1 = new Image { Source = "god.jpg" };
                image2 = new Image { Source = "godWhite.jpg" };
            }
            else if (Six.IsChecked)
            {
                name = "Другое";
                image1 = new Image { Source = "other.jpg" };
                image2 = new Image { Source = "otherWhite.jpg" };
            }

            Category cate = new Category(name, image1, image2);
            MessagingCenter.Send<CategoryPage, Category>(this, "ChangeCat", cate);
            await Navigation.PopModalAsync();
        }
    }
}