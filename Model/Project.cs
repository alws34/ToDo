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
        public string ProjectID;
        public string ProjectName;
        public DateTime DateCreated;
        public Dictionary<string, Task> Tasks = new Dictionary<string, Task>();
        #endregion

        #region Constructors
        public Project(string projectID, string projectName)
        {
            this.ProjectID = projectID;
            this.ProjectName = projectName;
            DateCreated = DateTime.Now;
        }
        public Project(string projectID)
        {
            this.ProjectID = projectID;
            DateCreated = DateTime.Now;
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
        public void Rename(string newName) { ProjectName = newName; }
        #endregion

        #region Getters
        public string GetProjectID() { return ProjectID; }
        public string GetProjectName() { return ProjectName; }
        public DateTime GetDateCreated() { return DateCreated; }
        public Dictionary<string, Task> GetTasks() { return Tasks; }
        #endregion
    }
}
