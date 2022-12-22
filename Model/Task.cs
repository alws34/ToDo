using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoYourTasks
{
    [Serializable]
    public class Task
    {
        #region Properties
        public string TaskName;
        public string TaskID;
        public string ParentProjectID;
        public string Notes;
        public DateTime DateCreated;
        public DateTime? DueDate;
        public bool IsStarred;
        public bool IsCompleted;
        public Dictionary<string, SubTask> SubTasks;
        #endregion

        #region Constructors
        public Task(string id, string taskName, string projectID)
        {
            TaskName = taskName;
            ParentProjectID = projectID;
            TaskID = id;
            DateCreated = DateTime.Now;
            IsStarred = false;
            IsCompleted = false;
            Notes = null;
            DueDate = null;
            SubTasks = new Dictionary<string, SubTask>();
        }

        #endregion
        #region Modifiers
        public void RemoveSubTask(string subtaskID)
        {
            SubTasks.Remove(subtaskID);
        }
        public void Rename(string newName)
        {
            TaskName = newName;
        }
        #endregion

        #region Setters
        public void SetStarred(bool mode)
        {
            IsStarred = mode;
        }
        public void SetCompleted(bool mode)
        {
            IsCompleted = mode;
        }
        public void AddSubTask(string subtaskID, SubTask subtask)
        {
            SubTasks.Add(subtaskID, subtask);
        }
        public void SetDueDate(DateTime dueTime)
        {
            DueDate = dueTime;
        }
        public void AddNotes(string note)
        {
            Notes = note;
        }
        #endregion

        #region Getters
        public string GetParentProjectID()
        {
            return ParentProjectID;
        }
        public string GetTaskName()
        {
            return TaskName;
        }
        public string GetTaskID()
        {
            return TaskID;
        }
        public string GetNotes()
        {
            return Notes;
        }
        public DateTime? GetDueDate()
        {
            return DueDate;
        }
        public DateTime GetDateCreated()
        {
            return DateCreated;
        }
        public Dictionary<string, SubTask> GetSubTasks()
        {
            return SubTasks;
        }
        public bool GetIsStarred()
        {
            return IsStarred;
        }
        public bool GetIsCompleted()
        {
            return IsCompleted;
        }
        #endregion
    }
}
