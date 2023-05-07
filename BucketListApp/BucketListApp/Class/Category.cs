using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Xamarin.Forms;

namespace BucketListApp.Class
{
    public class Category
    {
        public string Name { get; }

        public Image Icon { get; }

        public Category(string name, string imageName = null)
        {
            Name = name;
            Icon = new Image() { Source = imageName };
        }

        public Category(string name, Image image)
        {
            Name = name;
            Icon = image;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var category = obj as Category;
            return category != null
                && Name == category.Name;
        }

        public static Category Create(string name, string imageName) => new Category(name, imageName);
    }
}
