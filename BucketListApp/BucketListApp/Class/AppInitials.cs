using System;
using System.Collections.Generic;
using System.Text;

namespace BucketListApp.Class
{
    public static class AppInitials
    {
        public static GoalList Goals = new GoalList();
        private readonly static List<string> motivationalPhrases = new List<string>() { };

        public static int TotalProgressRatio
        {
            get { return Goals.InProgressRatio(); }
            private set { }
        }
        public static int TotalCompletedRatio
        {
            get { return Goals.CompletedRatio(); }
            private set { }
        }

        public static int TotalCompletedPerYear
        {
            get { return Goals.CompletedPerYear(); }
            private set { }
        }

        public static int MostCompletedCategoryRatio
        {
            get { return Goals.MostCompletedCategory().Ratio; }
            private set { }
        }

        public static string MostCompletedCategoryName
        {
            get { return Goals.MostCompletedCategory().Name; }
            private set { }
        }

        public static string GetMotivationPhrase()
        {
            var random = new Random();
            return motivationalPhrases[random.Next(0, motivationalPhrases.Count)];
        }
    }
}
