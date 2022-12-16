using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYourTasks
{
    public class Project
    {
        #region Fields
        private string projectID;
        private string projectName;
        private DateTime dateCreated;
        private Dictionary<string, Task> Tasks = new Dictionary<string, Task>();
        #endregion

        #region Constructors
        public Project(string projectID, string projectName)
        {
            this.projectID = projectID;
            this.projectName = projectName;
            dateCreated = DateTime.Now;
        }
        public Project(string projectID)
        {
            this.projectID = projectID;
            dateCreated = DateTime.Now;
        }
        #endregion

        #region Setters
        public void AddTask(Task task)
        {
            Tasks.Add(task.GetTaskID(), task);
        }
        public void RemoveTask(string taskID)
        {
            Tasks.Remove(taskID);
        }
        public void AddSubTask(string taskID, SubTask subTask)
        {
            Tasks[taskID].AddSubTask(subTask.GetSubTaskID(), subTask);
        }
        public void Rename(string newName) { projectName = newName; }
        #endregion

        #region Getters
        public string GetProjectID() { return projectID; }
        public string GetProjectName() { return projectName; }
        public DateTime GetDateCreated() { return dateCreated; }
        public Dictionary<string, Task> GetTasks() { return Tasks; }
        #endregion
    }
}
