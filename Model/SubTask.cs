using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYourTasks
{
    [Serializable]
    public class SubTask
    {
        #region Constructors
        public SubTask(string name, string parentTaskID, string parentProjectID, string id)
        {
            SubTaskName = name;
            SubtaskID = id;
            ParentTaskID = parentTaskID;
            ParentProjectID = parentProjectID;
        }
        #endregion

        #region Properties
        public string ParentTaskID;
        public string ParentProjectID;
        public string SubtaskID;
        public bool IsCompleted;
        public string SubTaskName;
        #endregion


        #region Getters
        public string GetParentProjectID() { return ParentProjectID; }
        public string GetParentTaskID() { return ParentTaskID; }
        public string GetSubTaskID() { return SubtaskID; }
        public string GetSubTaskName() { return SubTaskName; }
        public bool GetIsCompleted() { return IsCompleted; }
        #endregion
        
        #region Setters
        public void SetCompleted(bool mode) { IsCompleted = mode; }
        public void Rename(string newName) { SubTaskName = newName; }
        #endregion
    }
}
