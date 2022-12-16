using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoYourTasks.UserControls
{
    public partial class SubTaskView : UserControl, IViewAble
    {
        #region CustomEvents
        public event SubTaskCompletedEventHandler SubTaskCompleted;
        public event SubTaskDeletedEventHandler SubTaskDeleted;
        #endregion

        #region Properties
        public string SubTaskID { get; set; }
        public string ParentTaskID { get; set; }
        public string ParentProjectID { get; set; }
        public bool IsCompleted { get; set; }
        #endregion

        #region Constructors
        public SubTaskView(string parent_id, string id,string parentProjectID, string subTaskName)
        {
            InitializeComponent();
            ParentTaskID = parent_id;
            ParentProjectID = parentProjectID;
            SubTaskID = id;
            Name = "SubTaskView";
            Rename(subTaskName);
            EventSubscriber();
            ForeColor = Color.Transparent;
        }

        #endregion

        #region Getters
        public string GetName()
        {
            return customRadioButtonTaskName.Text;
        }
        public bool GetCheckedState()
        {
            return customRadioButtonTaskName.Checked;
        }

        public string GetParentTaskID()
        {
            return ParentTaskID;
        }
        public string GetParentProjectID()
        {
            return ParentProjectID;
        }
        #endregion

        #region Setters
        public void SetSubTaskText(string text)
        {
            //customTextBox.SetText(text);
        }
        public void SetCheckedState(bool value)
        {
            customRadioButtonTaskName.Checked = value;
        }
        #endregion

        #region Modifiers
        private void EventSubscriber()
        {
            customRadioButtonTaskName.customCheckedChanged += CustomRadioButtonTaskName_checkedChanged;
        }
        public void Rename(string newName)
        {
            customRadioButtonTaskName.Rename(newName);
        }
        public void Delete()
        {
            SubTaskDeleted.Invoke(new SubTaskDeletedEventArgs(this));
        }
        #endregion

        #region Events
        private void CustomRadioButtonTaskName_checkedChanged(CustomCBcheckedChangedEventArgs arg)
        {

            IsCompleted = arg.CRB.Checked; // set the current state of the Radiobutton.
            SubTaskCompleted.Invoke(new SubTaskCompletedEventArgs(this));
        }

        private void CustomTextBox_gotHidden(bool isHidden, EventArgs arg)
        {
            //throw new NotImplementedException();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void customRadioButtonTaskName_CheckedChanged(object sender, EventArgs e)
        {

        }

        public string GetID()
        {
            return SubTaskID;
        }

        public string GetParentID()
        {
            return ParentTaskID;
        }
        #endregion
    }
}
