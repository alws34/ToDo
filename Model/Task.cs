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
        public string TaskName;
        public string TaskID;
        public string ParentProjectID;
        public string Notes;
        public string DueDate;
        public DateTime DateCreated;
        public DateTime DateCompleted;
        public int Priority;
        public bool IsStarred;
        public bool IsCompleted;
        public bool IsHidden;
        public string Assigner;// who asked\opened the issue?
        public int Index;
        public Dictionary<string, SubTask> SubTasks;
        public List<Attachment> Attachments = new List<Attachment>();//list will hold file paths
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
            DueDate = "No Due Date";
            Index = 10000;
            Priority = 0; // low as default
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

        public void AddAttachment(Attachment attachment)
        {
            Attachments.Add(attachment);
        }

        #endregion

        #region Setters
        public void SetIsHidden(bool mode) { IsHidden = mode; }
        public void SetIndex(int index) { Index = index; }
        public void SetAssigner(string assigner) { Assigner = assigner; }
        public void SetPriority(int priority) { Priority = priority; }
        public void SetStarred(bool mode) { IsStarred = mode; }
        public void SetCompleted(bool mode) { IsCompleted = mode; }
        public void AddSubTask(string subtaskID, SubTask subtask) { SubTasks.Add(subtaskID, subtask); }
        public void SetDueDate(string dueTime) { DueDate = dueTime; }
        public void SetDateCompleted(DateTime dateCompleted) { DateCompleted = dateCompleted; }
        public void AddNotes(string note) { Notes = note; }
        #endregion

        #region Getters
        public string GetAssigner() { return Assigner; }
        public int GetPriority() { return Priority; }
        public string GetParentProjectID() { return ParentProjectID; }
        public string GetTaskName() { return TaskName; }
        public string GetTaskID() { return TaskID; }
        public string GetNotes() { return Notes; }
        public string GetDueDate() { return DueDate; }
        public DateTime GetDateCreated() { return DateCreated; }
        public DateTime GetDateCompleted() { return DateCompleted; }
        public Dictionary<string, SubTask> GetSubTasks() { return SubTasks; }
        public bool GetIsStarred() { return IsStarred; }
        public bool GetIsCompleted() { return IsCompleted; }
        public List<Attachment> GetAttachements() { return Attachments; }
        public int GetIndex() { return Index; }
        public bool GetIsHidden() { return IsHidden; }
        #endregion
    }
}
