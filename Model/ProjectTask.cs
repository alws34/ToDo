using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DoYourTasks
{
    public class ProjectTask
    {
        #region Constructors
        public ProjectTask(string taskName)
        {
            TaskName = taskName;
            DateCreated = DateTime.Now;
        }
        #endregion

        #region Properties
        public string TaskName { get; set; }
        public int ID { get; set; }
        public int ParentID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsStarred { get; set; }
        public bool IsCompleted { get; set; }
        public List<ProjectTask> Tasks { get; set; }
        #endregion
    }
}
