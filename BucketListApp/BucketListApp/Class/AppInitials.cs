﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using static System.Net.WebRequestMethods;
using System.Threading;
using Xamarin.Forms;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace BucketListApp.Class
{
    public static class AppInitials
    {
        private static GoalList goals;
        public static GoalList Goals
        {
            get
            {
                if (goals == null)
                    goals = LoadGoals();
                return goals;
            }
            set { }
        }

        public static GoalList ExampleGoals = GetExampleGoals();
        private readonly static List<string> motivationalPhrases = GetMotivationalPhrases();
        public static string MotivationPhrase
        {
            get
            {
                var random = new Random();
                return motivationalPhrases[random.Next(0, motivationalPhrases.Count)];
            }
            private set { }
        }

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

        private static List<string> GetMotivationalPhrases()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(AppInitials)).Assembly;
            var stream = assembly.GetManifestResourceStream("BucketListApp.MotivationsParse.txt");
            var phrases = new List<string>();
            using (var reader = new StreamReader(stream))
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLine();
                    phrases.Add(line);
                }
            }
            return phrases;
        }

        public static GoalList GetExampleGoals()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(AppInitials)).Assembly;
            var stream = assembly.GetManifestResourceStream("BucketListApp.GoalsParse.txt");
            var goals = new GoalList();
            using (var reader = new StreamReader(stream))
            {
                while (reader.Peek() >= 0)
                {
                    var title = reader.ReadLine();
                    var desc = reader.ReadLine();
                    desc = desc == "Нет" ? "Без описания" : desc;
                    var category = GetCategory(reader.ReadLine());
                    var subtasks = GetSubtasks(reader.ReadLine());
                    goals.AddCustomGoal(title, desc, category, subtasks);
                }
            }
            return goals;
        }

        private static Category GetCategory(string name)
        {
            var image1 = new Image();
            var image2= new Image();
            
            if (name  == "Отдых")
            {
                image1 = new Image() { Source = "chill.jpg" };
                image2 = new Image() { Source = "chillWhite.jpg" };
            }
            if (name == "Активности")
            {
                image1 = new Image { Source = "activity.jpg" };
                image2 = new Image { Source = "activityWhite.jpg" };
            }
            if (name == "Путешествия")
            {
                image1 = new Image { Source = "airplane.jpg" };
                image2 = new Image { Source = "airplaneWhite.jpg" };
            }
            if (name == "Челленджи")
            {
                image1 = new Image { Source = "challange.jpg" };
                image2 = new Image { Source = "challangeWhite.jpg" };
            }
            if (name == "Духовность")
            {
                image1 = new Image { Source = "god.jpg" };
                image2 = new Image { Source = "godWhite.jpg" };
            }
            if (name == "Другое")
            {
                image1 = new Image { Source = "other.jpg" };
                image2 = new Image { Source = "otherWhite.jpg" };
            }           
            return new Category(name, image1, image2);
        }
        
        private static List<SubTask> GetSubtasks(string line)
        {
            if (line == "Нет") return new List<SubTask>();
            return line.Split(';').Select(desc => new SubTask(desc)).ToList();
        }

        private static GoalList LoadGoals()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GoalsData.json");
            if (!System.IO.File.Exists(path))
                System.IO.File.Create(path);
            var stringData = System.IO.File.ReadAllText(path);
            return JsonConvert.DeserializeObject<GoalList>(stringData) ?? new GoalList();
        }

        private static void SaveGoals()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GoalsData.json");
            var stringData = JsonConvert.SerializeObject(goals);
            System.IO.File.WriteAllText(path, stringData);
        }
    }
}
