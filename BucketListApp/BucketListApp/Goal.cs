using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BucketListApp
{
    internal class Goal
    {
        public static Dictionary<string, Goal> ExampleGoals = new Dictionary<string, Goal>();

        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<SubTask> SubTasks { get; set; }
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }

        public Goal(string title, string descript, Category category, List<SubTask> subTasks)
        {
            Title = title;
            Description = descript;
            Category = category;
            SubTasks = subTasks;
            Status = false;
            CreationDate = DateTime.Now;
        }

        public override int GetHashCode()
        {
            return ((Title.GetHashCode() ^ Description.GetHashCode()) * 1021
                ^ Category.GetHashCode()) * 1021;
        }

        public override bool Equals(object obj)
        {
            var goal = obj as Goal;
            return goal != null
                && this.Title == goal.Title
                && this.Status == goal.Status
                && this.Description == goal.Description
                && this.Category.Equals(goal.Category)
                && this.SubTasks.Equals(goal.SubTasks);
        }

        public void AddSubTask(SubTask subtask)
        {
            this.SubTasks.Add(subtask);
        }

        public void DeleteSubTask(SubTask subtask)
        {
            this.SubTasks.Remove(subtask);
        }
    }
}
