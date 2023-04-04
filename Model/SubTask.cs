using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYourTasks
{
    public class SubTask
    {
        #region Constructors
        public SubTask(string name, string parentTaskID, string parentProjectID, string id, string createdAt)
        {
            SubTaskName = name;
            SubtaskID = id;
            ParentTaskID = parentTaskID;
            ParentProjectID = parentProjectID;
            CreatedAt = createdAt;
            Index = 0;
            Priority = 1;
        }
        #endregion

        #region Properties
        public string ParentTaskID;
        public string ParentProjectID;
        public string SubtaskID;
        public string SubTaskName;
        public string CreatedAt;
        public bool IsCompleted;
        public int Index;
        public int Priority;
        #endregion

        #region Getters
        public string GetCreatedAt()
        {
            if (CreatedAt == null)
                CreatedAt = DateTime.Now.ToString("dd/MM/yy HH:mm tt");
            return CreatedAt;
        }
        public int GetIndex() { return Index; }
        public string GetParentProjectID() { return ParentProjectID; }
        public string GetParentTaskID() { return ParentTaskID; }
        public string GetSubTaskID() { return SubtaskID; }
        public string GetSubTaskName() { return SubTaskName; }
        public bool GetIsCompleted() { return IsCompleted; }
        public int GetPriority() { return Priority; }
        #endregion

        #region Setters

        public void SetCompleted(bool mode) { IsCompleted = mode; }
        public void Rename(string newName) { SubTaskName = newName; }

        public void SetIndex(int idx)
        {
            Index = idx;
        }

        public void SetPriority(int priority) { Priority = priority; }
        #endregion
    }
}
