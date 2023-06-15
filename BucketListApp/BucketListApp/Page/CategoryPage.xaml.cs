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
            var image1 = String.Empty;
            var image2 = String.Empty;

            if (One.IsChecked)
            {
                name = "Отдых";
                image1 = "chill.jpg";
                image2 = "chillWhite.jpg";
            }
            else if (Two.IsChecked)
            {
                name = "Активности";
                image1 = "activity.jpg";
                image2 = "activityWhite.jpg";
            }
            else if (Three.IsChecked)
            {
                name = "Путешествия";
                image1 = "airplane.jpg";
                image2 = "airplaneWhite.jpg";
            }
            else if (Four.IsChecked)
            {
                name = "Челленджи";
                image1 = "challange.jpg";
                image2 = "challangeWhite.jpg";
            }
            else if (Five.IsChecked)
            {
                name = "Духовность";
                image1 = "god.jpg";
                image2 = "godWhite.jpg";
            }
            else if (Six.IsChecked)
            {
                name = "Другое";
                image1 = "other.jpg";
                image2 = "otherWhite.jpg";
            }

            Category cate = new Category(name, image1, image2);
            MessagingCenter.Send<CategoryPage, Category>(this, "ChangeCat", cate);
            await Navigation.PopModalAsync();
        }
    }
}