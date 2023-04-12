using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BucketListApp
{
    internal class Category
    {
        public string Name { get; set; }

        public Category(string name)
        { 
            Name = name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var category = obj as Category;
            return category != null
                && this.Name == category.Name;
        }

        public static Category Create(string name) => new Category(name);

    }
}
