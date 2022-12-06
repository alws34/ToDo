using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DoYourTasks
{
    public class Task
    {

        #region Properties
        public string Name { get; set; }
        public string ID { get; set; }
        public string ParentID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsStarred { get; set; }
        public bool IsCompleted { get; set; }
        public string Note { get; set; }

        public Dictionary<string, SubTask> SubTasks = new Dictionary<string, SubTask>();
        #endregion

        #region Constructors
        public Task(string taskName)
        {
            Name = taskName;
            DateCreated = DateTime.Now;
        }

        public Task(string id, string taskName, string projectID)
        {
            Name = taskName;
            ParentID = projectID;
            ID = id;
            DateCreated = DateTime.Now;
            IsStarred = false;
            IsCompleted = false;
        }

        #endregion

        

    }
}
