using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DoYourTasks.UserControls
{
    public partial class TaskView : UserControl,IViewAble
    {
        Color startBackgroundColor;
        public event UpdateCurrentTaskViewEventHandler UpdateTaskView;
        public string TaskID { get; set; }
   
        public TaskView(string id)
        {
            InitializeComponent();
            SetBackColor();
            TaskID = id;
            Name = "TaskView";
        }
        public TaskView(string taskName, string id)
        {
            InitializeComponent();
            SetBackColor();
            TaskID = id;
            Rename(taskName);
            Name = "TaskView";
        }

        #region Methods
        private void SetBackColor()
        {
            startBackgroundColor = customRadioButtonTaskName.BackColor;
        }

        private void SetForeColor(Color color) {
            customRadioButtonTaskName.ForeColor = color;
        }

        private void RemoveSelected()
        {
            if(customRadioButtonTaskName.Checked)
                customRadioButtonTaskName.Checked = false;
        }


        public void Rename(string newName)
        {
            customRadioButtonTaskName.Rename(newName);
        }

        public string GetName()
        {
            return customRadioButtonTaskName.GetName();
        }

        public string GetID()
        {
            return TaskID;
        }
       
        public string GetParentID()
        {
            return null;
        }

        public bool GetCheckedState()
        {
            return customRadioButtonTaskName.Checked;
        }

        public void SetCheckedState(bool mode)
        {
            customRadioButtonTaskName.Checked= mode;
        }

        public void Delete()
        {
            //throw new NotImplementedException();
        }
        #endregion

        private void TaskView_Click(object sender, EventArgs e)
        {
            UpdateTaskView.Invoke(new UpdateCurrentTaskViewEventArgs(this));
        }

        private void customRadioButtonTaskName_CheckedChanged(object sender, EventArgs e)
        {

        }

        #region Events
        private void pnlColorIndicator_MouseEnter(object sender, EventArgs e)
        {
            pnlColorIndicator.BackColor = Color.Gainsboro;
            customRadioButtonTaskName.BackColor = Color.Gainsboro;
            lblCompletedSubTasks.BackColor = Color.Gainsboro;

            customRadioButtonTaskName.ForeColor = Color.Black;
            lblCompletedSubTasks.ForeColor = Color.Black;
        }

        private void pnlColorIndicator_MouseLeave(object sender, EventArgs e)
        {
            pnlColorIndicator.BackColor = Color.Transparent;
            customRadioButtonTaskName.BackColor = startBackgroundColor;
            lblCompletedSubTasks.BackColor = Color.Transparent;

            customRadioButtonTaskName.ForeColor = Color.White;
            lblCompletedSubTasks.ForeColor = Color.White;
        }

        #endregion

    }
}
