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

namespace DoYourTasks.UserControls
{
    public partial class TaskView : UserControl,IViewAble
    {
        Color startBackgroundColor;
        public event UpdateCurrentTaskViewEventHandler UpdateTaskView;
        public string ID { get; set; }
   
        public TaskView(string id)
        {
            InitializeComponent();
            SetBackColor();
            ID = id;
            Name = "TaskView";
        }

        #region Methods
        private void SetBackColor()
        {
            startBackgroundColor = customRadioButtonTaskName.BackColor;
        }

        private void RemoveSelected()
        {
            if(customRadioButtonTaskName.Checked)
                customRadioButtonTaskName.Checked = false;
        }


        public void Rename(string newName)
        {
            customRadioButtonTaskName.Text = newName;
        }

        public string GetName()
        {
            return customRadioButtonTaskName.Text;
        }

        public string GetID()
        {
            return ID;
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
            UpdateTaskView.Invoke(new UpdateCurrentTaskViewEventHandlerArgs(this));
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
