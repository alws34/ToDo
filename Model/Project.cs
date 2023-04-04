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
        public int Index = -1;
        public int Priority = 5;
        public DateTime DateCreated;
        public string BackGroundImagePath;
        public string ProjectNotes;
        public bool IsHidden;
        public List<Attachment> ProjectAttachments = new List<Attachment>();
        public Dictionary<string, Task> Tasks = new Dictionary<string, Task>();
        public Dictionary<string, Task> HiddenTasks = new Dictionary<string, Task>();
        #endregion

        #region Constructors
        public Project() { }
        public Project(string projectID, bool isHidden = false)
        {
            ProjectID = projectID;
            DateCreated = DateTime.Now;
        }
        #endregion

        #region Setters
        public void AddAttachment(Attachment attachment) { ProjectAttachments.Add(attachment); }
        public void SetIsHidden(bool mode) { IsHidden = mode; }
        public void SetIndex(int index) { Index = index; }
        public void SetProjectNotes(string note) { ProjectNotes = note; }
        public void SetPriority(int priority) { Priority = priority; }
        public void AddTask(Task task) { Tasks.Add(task.GetTaskID(), task); }
        public void AddHiddenTask(Task task)
        {
            try
            {
                HiddenTasks.Add(task.GetTaskID(), task);
            }
            catch (Exception) { }
        }
        public void RemoveTask(string taskID) { Tasks.Remove(taskID); }
        public void AddSubTask(string taskID, SubTask subTask) { Tasks[taskID].AddSubTask(subTask.GetSubTaskID(), subTask); }
        public void Rename(string newName) { ProjectName = newName; }
        public void SetImagePath(string path) { BackGroundImagePath = path; }
        #endregion

        #region Getters
        public List<Attachment> GetAttachments() { return ProjectAttachments; }
        public bool GetIsHidden() { return IsHidden; }
        public int GetPriority() { return Priority; }
        public int GetIndex() { return Index; }
        public string GetImagePath() { return BackGroundImagePath; }
        public string GetProjectID() { return ProjectID; }
        public string GetProjectNotes() { return ProjectNotes; }
        public string GetProjectName() { return ProjectName; }
        public DateTime GetDateCreated() { return DateCreated; }
        public Dictionary<string, Task> GetTasks()
        {
            if (GetIsHidden())
                return GetHiddenTasks();
            return Tasks;
        }
        public Dictionary<string, Task> GetHiddenTasks() { return HiddenTasks; }
        #endregion
    }
}
