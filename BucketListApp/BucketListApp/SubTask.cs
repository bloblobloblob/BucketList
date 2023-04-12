using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BucketListApp
{
    internal class SubTask
    {
        public string Name { get; set; }
        public bool Status { get; set; }

        public SubTask(string name)
        { 
            Name = name;
            Status = false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var subTask = obj as SubTask;
            return subTask != null
                && this.Name == subTask.Name
                && this.Status == subTask.Status;
        }

        public static SubTask Create(string name) => new SubTask(name);
    }
}
