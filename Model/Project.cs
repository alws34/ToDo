using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYourTasks
{
    public class Project
    {
        #region Properties
        public string ID { get; set; }
        public string ProjectName { get; set; }
        public DateTime DateCreated { get; }

        public Dictionary<string, Task> Tasks = new Dictionary<string, Task>();

        #endregion
       
        #region Constructors
        public Project(string projectID, string projectName)
        {
            ID = projectID;
            ProjectName = projectName;
            DateCreated = DateTime.Now;
        }
        public Project(string projectName)
        {
            ProjectName = projectName;
            DateCreated = DateTime.Now;
        }

        #endregion
       
        #region Setters

        public void AddTask(Task task)
        {
            Tasks.Add(task.ID, task);
        }
        public void RemoveTask(string taskID)
        {
            Tasks.Remove(taskID);
        }

        public void AddSubTask(string taskID, SubTask subTask)
        {
            Tasks[taskID].SubTasks.Add(subTask.ID, subTask);
        }
        #endregion
    }
}
