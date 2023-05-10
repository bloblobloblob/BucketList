using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;
using BucketListApp.Class;

namespace BucketListApp
{
    public partial class App : Application
    {
        private readonly static List<string> motivationalPhrases = new List<string>() { };
        private static Profile defaultProfile;
        private static Profile currentProfile;
        public List<Category> Categories {
            get
            {
                if (Categories == null)
                {
                    Categories = new List<Category>()
                    {
                        new Category("без категории")
                    };
                }
                return Categories;
            }
            private set { }
        }
        public (int InProgress, int Completed) Statistics
        {
            get
            {
                return (CurrentProfile.Goals.InProgress(), CurrentProfile.Goals.Completed());
            } 
        }

        private Profile DefaultProfile
        { 
            get 
            {
                if (defaultProfile == null)
                    defaultProfile = new Profile()
                    { Name = String.Empty, Login = null, Password = null, Goals = new GoalList() };
                return defaultProfile;
            } 
        }
        private Profile CurrentProfile
        {
            get
            {
                if (currentProfile == null)
                    currentProfile = DefaultProfile;
                return currentProfile;
            }
        }

        public string GetMotivationPhrase()
        {
            var random = new Random();
            return motivationalPhrases[random.Next(0, motivationalPhrases.Count)];
        }
    }
}
