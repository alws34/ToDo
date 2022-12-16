using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DoYourTasks
{
    public class Task
    {
        #region Fields
        private string taskName;
        private string taskID;
        private string parentProjectID;
        private string notes;
        private DateTime dateCreated;
        private DateTime dueDate;
        private bool isStarred;
        private bool isCompleted;
        private Dictionary<string, SubTask> subTasks;
        #endregion

        #region Constructors
        public Task(string id, string taskName, string projectID)
        {
            this.taskName = taskName;
            parentProjectID = projectID;
            taskID = id;
            dateCreated = DateTime.Now;
            isStarred = false;
            isCompleted = false;
            subTasks = new Dictionary<string, SubTask>();
        }

        #endregion
        #region Modifiers
        public void RemoveSubTask(string subtaskID)
        {
            subTasks.Remove(subtaskID);
        }
        public void Rename(string newName)
        {
            taskName = newName;
        }
        #endregion

        #region Setters
        public void SetStarred(bool mode)
        {
            isStarred = mode;
        }
        public void SetCompleted(bool mode)
        {
            isCompleted = mode;
        }
        public void AddSubTask(string subtaskID, SubTask subtask)
        {
            subTasks.Add(subtaskID, subtask);
        }
        public void SetDueDate(DateTime dueTime)
        {
            dueDate = dueTime;
        }
        public void AddNotes(string note)
        {
            notes = note;
        }
        #endregion

        #region Getters
        public string GetParentProjectID()
        {
            return parentProjectID;
        }
        public string GetTaskName()
        {
            return taskName;
        }
        public string GetTaskID()
        {
            return taskID;
        }
        public string GetNotes()
        {
            return notes;
        }
        public DateTime GetDueDate()
        {
            return dueDate;
        }
        public DateTime GetDateCreated()
        {
            return dateCreated;
        }
        public Dictionary<string, SubTask> GetSubTasks()
        {
            return subTasks;
        }
        public bool GetIsStarred()
        {
            return isStarred;
        }
        public bool GetIsCompleted()
        {
            return isCompleted;
        }
        #endregion
    }
}
