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
        public SubTask(string name, string parentID, string id)
        {
            SubTaskName = name;
            ID = id;
            ParentID = parentID;
        }
        #endregion
        #region Properties
        public string ParentID { get; set; }
        public string ID { get; set; }
        public bool IsCompleted { get; set; }
        public string SubTaskName { get; set; }
        #endregion


        public void SetCompleted(bool mode)
        {
            IsCompleted = mode;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
