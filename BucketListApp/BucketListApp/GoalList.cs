using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BucketListApp
{
    internal static class GoalList
    {
        private static HashSet<Goal> goals = new HashSet<Goal>();

        public static void AddCustomGoal(string title, string descript, Category category, List<SubTask> subTasks)
        {
            goals.Add(new Goal(title, descript, category, subTasks));
        }

        public static void AddExampleGoal(Goal exampleGoal, string customTitle,
            string customDescript, Category customCategory, List<SubTask> customSubTasks)
        {
            var title = customTitle ?? exampleGoal.Title;
            var description = customDescript ?? exampleGoal.Description;
            var category = customCategory ?? exampleGoal.Category;
            var subTasks = customSubTasks ?? exampleGoal.SubTasks;
            goals.Add(new Goal(title,description, category, subTasks));
        }

        public static void ChangeGoal(Goal goal, string customTitle,
            string customDescript, Category customCategory, Action<Goal> changeSubTasks)
        {
            goal.Title = customTitle ?? goal.Title;
            goal.Description = customDescript ?? goal.Description;
            goal.Category = customCategory ?? goal.Category;
            if (changeSubTasks != null) 
                changeSubTasks(goal);
        }

        public static List<Goal> GetGoals()
        {
            return goals.SortGoals();
        }

        public static List<Goal> GetFilteredGoals(Category filter)
        {
            return goals
                .Where(goal => goal.Category == filter)
                .SortGoals();
        }

        public static void DeleteGoal(Goal goal)
        {
            goals.Remove(goal);
        }

        private static List<Goal> SortGoals(this IEnumerable<Goal> goals)
        {
            return goals
                .OrderBy(goal => goal.CreationDate)
                .ThenBy(goal => goal.Status)
                .ToList();
        }
    }
}
