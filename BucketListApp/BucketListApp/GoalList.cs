using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BucketListApp
{
    internal class GoalList
    {
        private HashSet<Goal> goals = new HashSet<Goal>();

        public void AddCustomGoal(string title, string descript, Category category, List<SubTask> subTasks)
        {
            goals.Add(new Goal(title, descript, category, subTasks));
        }

        public void AddExampleGoal(Goal exampleGoal, string customTitle,
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

        public List<Goal> GetGoals()
        {
            return SortGoals(this.goals).ToList();
        }

        public List<Goal> GetFilteredGoals(Category filter)
        {
            return SortGoals(this.goals)
                .Where(goal => goal.Category == filter)
                .ToList();
        }

        public void DeleteGoal(Goal goal)
        {
            this.goals.Remove(goal);
        }

        private static IEnumerable<Goal> SortGoals(IEnumerable<Goal> goals)
        {
            return goals
                .OrderBy(goal => goal.CreationDate)
                .ThenBy(goal => goal.Status);
        }
    }
}
