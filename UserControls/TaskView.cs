using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DoYourTasks.UserControls
{
    public partial class TaskView : UserControl, IViewAble
    {
        #region CustomEvents
        public event UpdateCurrentTaskViewEventHandler UpdateTaskView;
        public event TaskCompletedEventHandler TaskCompleted;
        public event TaskDeletedEventHandler TaskDeleted;
        #endregion

        #region Fields
        private Color startBackgroundColor;
        private bool isCompleted = false;

        private string taskID;
        private string parentProjectID;
        #endregion

        #region Constructors
        public TaskView(string taskName, string id, string parentProjectID)
        {
            InitializeComponent();
            SetBackColor();
            taskID = id;
            this.parentProjectID = parentProjectID;
            Rename(taskName);
            Name = "TaskView";
            SubscribeToEvents();
        }

        #endregion

        #region Getters
        public string GetName()
        {
            return customRadioButtonTaskName.GetName();
        }

        public string GetID()
        {
            return taskID;
        }

        public string GetParentProjectID()
        {
            return parentProjectID;
        }
        public bool GetCheckedState()
        {
            return customRadioButtonTaskName.Checked;
        }

        #endregion

        #region Setters
        private void SetBackColor()
        {
            startBackgroundColor = customRadioButtonTaskName.BackColor;
        }

        private void SetForeColor(Color color)
        {
            customRadioButtonTaskName.ForeColor = color;
        }

        public void SetCheckedState(bool mode)
        {
            customRadioButtonTaskName.Checked = mode;
        }


        private void SubscribeToEvents() {
            customRadioButtonTaskName.customCheckedChanged += CustomRadioButtonTaskName_checkedChanged;
        }
        #endregion

        #region Modifiers
        private void RemoveSelected()
        {
            if (customRadioButtonTaskName.Checked)
                customRadioButtonTaskName.Checked = false;
        }
        public void Rename(string newName)
        {
            customRadioButtonTaskName.Rename(newName);
        }
        public void Delete()
        {
            //throw new NotImplementedException();
        }
        #endregion

        #region Events

        private void CustomRadioButtonTaskName_checkedChanged(CustomCBcheckedChangedEventArgs arg)
        {
            isCompleted = arg.CRB.Checked; // set the current state of the Radiobutton.
            TaskCompleted.Invoke(new TaskCompletedEventArgs(this));//let the main form know the task is completed.
        }

        private void TaskView_Click(object sender, EventArgs e)
        {
            UpdateTaskView.Invoke(new UpdateCurrentTaskViewEventArgs(this));
        }

        private void customRadioButtonTaskName_CheckedChanged(object sender, EventArgs e)
        {

        }


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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TaskDeleted.Invoke(new TaskDeletedEventArgs(this));
        }

        public string GetParentID()
        {
            return parentProjectID;
        }
    }
}
