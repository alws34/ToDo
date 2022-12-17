using System;
using System.Collections.Generic;
using System.Drawing;
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
        public string BackGroundImagePath;
        public Dictionary<string, Task> Tasks;
        #endregion

        #region Constructors
        public Project() { }
        public Project(string projectID, string projectName)
        {
            ProjectID = projectID;
            ProjectName = projectName;
            DateCreated = DateTime.Now;
            BackGroundImagePath = null;
            Tasks = new Dictionary<string, Task>();
        }

        public Project(string projectID)
        {
            this.ProjectID = projectID;
            DateCreated = DateTime.Now;
            Tasks = new Dictionary<string, Task>();
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
        public void SetImagePath(string path) { BackGroundImagePath = path; }
        #endregion

        #region Getters
        public string GetImagePath()
        {
            return BackGroundImagePath;
        }
        public string GetProjectID() { return ProjectID; }
        public string GetProjectName() { return ProjectName; }
        public DateTime GetDateCreated() { return DateCreated; }
        public Dictionary<string, Task> GetTasks() { return Tasks; }
        #endregion
    }
}
