using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BucketListApp.Class
{
    public class SubTask
    {
        private string description;
        private bool status;
        public string Description
        {
            get
            {
                return description;
            }
            private set { }
        }

        public bool Status
        {
            get
            {
                return status;
            }
            private set { }
        }

        public SubTask(string description, bool status = false)
        {
            this.description = description;
            this.status = status;
        }

        public static SubTask Create(string name) => new SubTask(name);

        public void ChangeState()
        {
            status = !status;
        }

        public void ChangeName(string description)
        {
            this.description = description;
        }
        public override int GetHashCode()
        {
            return description.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var subTask = obj as SubTask;
            return subTask != null
                && Description == subTask.Description
                && Status == subTask.Status;
        }

    }
}
