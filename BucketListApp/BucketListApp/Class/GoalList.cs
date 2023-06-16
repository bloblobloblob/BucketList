using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BucketListApp.Class
{
    public class GoalList
    {
        public ObservableCollection<Goal> goals { get; set; }

        public GoalList(IEnumerable<Goal> goals)
        {
            //this.goals = goals.ToList();
        }

        public GoalList()
        {
            goals = new ObservableCollection<Goal>();
        }

        public void AddCustomGoal(string title, string descript, Category category, List<SubTask> subTasks)
        {
            goals.Add(new Goal(title, descript, category, subTasks, "Цель еще не выполнена"));
        }

        public void AddExampleGoal(Goal exampleGoal, string customTitle,
            string customDescript, Category customCategory, List<SubTask> customSubTasks)
        {
            var title = customTitle ?? exampleGoal.Title;
            var description = customDescript ?? exampleGoal.Description;
            var category = customCategory ?? exampleGoal.Category;
            var subTasks = customSubTasks ?? exampleGoal.SubTasks;
            goals.Add(new Goal(title, description, category, subTasks, "Цель еще не выполнена"));
        }

        public static void ChangeGoal(Goal goal, string customTitle,
            string customDescript, Category customCategory, Action<Goal> changeSubTasks)
        {
            goal.Title = customTitle ?? goal.Title;
            goal.Description = customDescript ?? goal.Description;
            goal.Category = customCategory ?? goal.Category;
            goal.Image = goal.Category.Icon;
            if (changeSubTasks != null)
                changeSubTasks(goal);
        }

        public List<Goal> GetGoals()
        {
            return SortGoals(goals).ToList();
        }

        public List<Goal> GetFilteredGoals(Category filter)
        {
            return SortGoals(goals)
                .Where(goal => goal.Category == filter)
                .ToList();
        }

        public void DeleteGoal(Goal goal)
        {
            goals.Remove(goal);
        }

        public double CompletedRatio()
        {
            if (!goals.Any())
                return 0;
            return (double) goals.Where(goal => goal.Status == true).Count() / goals.Count;
        }

        public int Completed()
        {
            if (!goals.Any())
                return 0;
            return goals.Where(goal => goal.Status == true).Count();
        }

        public int Total()
        {
            return goals.Count();
        }

        public int CompletedPerYear()
        {
            var currentdate = DateTime.Now;
            if (!goals.Any())
                return 0;
            return goals.Where(goal => goal.Status == true && (goal.CreationDate - currentdate).TotalDays < 366).Count();
        }

        public (int Ratio, string Name) MostCompletedCategory()
        {
            var currentdate = DateTime.Now;
            if (!goals.Any())
                return (0, "");
            var completed = goals.Where(goal => goal.Status == true && (goal.CreationDate - currentdate).TotalDays < 366);
            if (!completed.Any())
                return (0, "");
            var mostCompleted = completed
                    .GroupBy(goal => goal.Category)
                    .OrderByDescending(group => group.Count())
                    .FirstOrDefault();
            var ratio = mostCompleted.Count() / completed.Count() * 100;
            var name = mostCompleted.Key.Name;
            return (ratio, name);
        }

        public double InProgressRatio()
        {
            if (!goals.Any())
                return 0;
            return 100 - CompletedRatio();
        }
        private static IEnumerable<Goal> SortGoals(IEnumerable<Goal> goals)
        {
            return goals
                .OrderBy(goal => goal.CreationDate)
                .ThenBy(goal => goal.Status);
        }
    }
}
