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

        #region Fields
        Color initialBackColor;
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
            ForeColor = Color.White;
            initialBackColor = BackColor;
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

        private void customRadioButtonTaskName_MouseEnter(object sender, EventArgs e)
        {
            customRadioButtonTaskName.ForeColor = customRadioButtonTaskName.CheckedColor;
            customRadioButtonTaskName.BackColor = Color.Gainsboro;
            customRadioButtonTaskName.isSelected = true;
            BackColor = Color.Gainsboro;
        }

        private void customRadioButtonTaskName_MouseLeave(object sender, EventArgs e)
        {
            customRadioButtonTaskName.ForeColor = Color.White;
            customRadioButtonTaskName.BackColor = initialBackColor;
            customRadioButtonTaskName.isSelected = false;
            BackColor = initialBackColor;
        }
        private void CustomRadioButtonTaskName_checkedChanged(CustomCBcheckedChangedEventArgs arg)
        {
            IsCompleted = arg.CRB.Checked; // set the current state of the Radiobutton.
           
            SetCheckedState(arg.CRB.Checked);
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
        #endregion

    }
}
