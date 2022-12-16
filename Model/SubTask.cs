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
        public SubTask(string name, string parentTaskID, string parentProjectID, string id)
        {
            subTaskName = name;
            subtaskID = id;
            this.parentTaskID = parentTaskID;
            this.parentProjectID = parentProjectID;
        }
        #endregion

        #region Fields
        private string parentTaskID;
        private string parentProjectID;
        private string subtaskID;
        private bool isCompleted;
        private string subTaskName;
        #endregion


        #region Getters
        public string GetParentProjectID() { return parentProjectID; }
        public string GetParentTaskID() { return parentTaskID; }
        public string GetSubTaskID() { return subtaskID; }
        public string GetSubTaskName() { return subTaskName; }
        public bool GetIsCompleted() { return isCompleted; }
        #endregion
        
        #region Setters
        public void SetCompleted(bool mode) { isCompleted = mode; }
        public void Rename(string newName) { subTaskName = newName; }
        #endregion
    }
}
