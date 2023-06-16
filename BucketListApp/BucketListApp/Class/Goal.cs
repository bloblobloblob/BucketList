using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xamarin.Forms;

namespace BucketListApp.Class
{
    public class Goal : INotifyPropertyChanged
    {
        private string image;
        private string imageWhite;
        private string memories;
        private string title;
        private string description;
        private Category category;
        private List<SubTask> subtasks;
        private bool status;
        private readonly DateTime creationDate;

        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                if (image != value)
                {
                    image = value;
                    OnPropertyChanged("Image");
                }
            }
        }

        public string ImageWhite
        {
            get
            {
                return imageWhite;
            }
            set
            {
                if (imageWhite != value)
                {
                    imageWhite = value;
                    OnPropertyChanged("ImageWhite");
                }
            }
        }

        public string Memories
        {
            get
            {
                return memories;
            }
            set
            {
                if (memories != value)
                {
                    memories = value;
                    OnPropertyChanged("Memories");
                }
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged("Text");
                }
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public Category Category
        {
            get
            {
                return category;
            }
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged("Category");
                }
            }
        }
        public List<SubTask> SubTasks
        {
            get
            {
                return subtasks;
            }
            set
            {
                if (subtasks != value)
                {
                    subtasks = value;
                    OnPropertyChanged("Subtasks");
                }
            }
        }
        public bool Status
        {
            get
            {
                return status;
            }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        public DateTime CreationDate => creationDate;
        public double Done
        {
            get { return Completed(); }
            private set { }
        }

        public double InProcess
        {
            get { return InProgress(); }
            private set { }
        }

        private int SubTasksCount => SubTasks.Count;

        public Goal(string title, string description, Category category, List<SubTask> subTasks)
        {
            Image = category.Icon;
            ImageWhite = category.IconWhite;
            Title = title;
            Description = description;
            Category = category;
            SubTasks = subTasks;
            Status = false;
            creationDate = DateTime.Now;
            Memories = memories;
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
                && Title == goal.Title
                && Status == goal.Status
                && Description == goal.Description
                && Category.Equals(goal.Category)
                && SubTasks.Equals(goal.SubTasks);
        }

        public void AddSubTask(SubTask subtask)
        {
            SubTasks.Add(subtask);
        }

        public void DeleteSubTask(SubTask subtask)
        {
            SubTasks.Remove(subtask);
        }

        public bool ChangeCompletionState()
        {
            if (SubTasksCount == 0 || InProcess == 0)
                status = true;
            return Status;
        }

        private double Completed()
        {
            if (!SubTasks.Any())
                return 0;
            return (double) SubTasks.Where(subTask => subTask.Status == true).Count() / SubTasks.Count;
        }

        private double InProgress()
        {
            if (!SubTasks.Any())
                return 0;
            return (double) SubTasks.Where(subTask => subTask.Status == false).Count() / SubTasks.Count;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
