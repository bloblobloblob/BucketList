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
        private readonly string name;
        private readonly string icon;
        private readonly string iconWhite;
        public string Name => name;

        public string Icon => icon;

        public string IconWhite => iconWhite;

        public Category(string name, string image1, string image2)
        {
            this.name = name;
            icon = image1;
            iconWhite = image2;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var category = obj as Category;
            return category != null
                && Name == category.Name;
        }
    }
}
