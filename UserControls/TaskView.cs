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
        public event TaskDueDateChangedEventHandler DueDateChanged;
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
            DoubleBuffered = true;
        }

        #endregion

        #region Getters
        public string GetParentTaskID()
        {
            return parentProjectID;
        }

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
        public void SetDueDate(DateTime Duedate)
        {
            lblDueDate.Show();
            lblDueDate.Text = $"Due to: {Duedate.ToString("dd/MM/yy")}";// HH:mm tt")}";
            //DueDateChanged.Invoke(new DueDateChangedEventArgs(null));
        }
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


        private void SubscribeToEvents()
        {
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            TaskDeleted.Invoke(new TaskDeletedEventArgs(this));
        }

        private void CustomRadioButtonTaskName_checkedChanged(CustomCBcheckedChangedEventArgs arg)
        {
            SetCompleted(arg.CRB.Checked); // set the current state of the Radiobutton.
            TaskCompleted.Invoke(new TaskCompletedEventArgs(this));//let the main form know the task is completed.
        }

        private void TaskView_Click(object sender, EventArgs e)
        {
            UpdateTaskView.Invoke(new UpdateCurrentTaskViewEventArgs(this));
        }

        public void UpdateCompletedSubTasks(int completedSubtasks, int totalSubtasks)
        {
            lblCompletedSubTasks.Text = $"{completedSubtasks}/{totalSubtasks}";
        }
        public void SetCompleted(bool mode)
        {
            isCompleted = mode;
            customRadioButtonTaskName.Checked = mode;
            if (mode)
                customRadioButtonTaskName.Font = new Font(new FontFamily("Arial"), 14, FontStyle.Strikeout);
            else
                customRadioButtonTaskName.Font = new Font(new FontFamily("Arial"), 14);

        }

        private void pnlColorIndicator_MouseEnter(object sender, EventArgs e)
        {
            pnlColorIndicator.BackColor = Color.Gainsboro;
            customRadioButtonTaskName.BackColor = Color.Gainsboro;
            lblCompletedSubTasks.BackColor = Color.Gainsboro;
            lblDueDate.BackColor = Color.Gainsboro;

            customRadioButtonTaskName.ForeColor = Color.Black;
            lblCompletedSubTasks.ForeColor = Color.Black;
            lblDueDate.ForeColor = Color.Black;
        }

        private void pnlColorIndicator_MouseLeave(object sender, EventArgs e)
        {
            pnlColorIndicator.BackColor = Color.Transparent;
            customRadioButtonTaskName.BackColor = startBackgroundColor;
            lblCompletedSubTasks.BackColor = Color.Transparent;
            lblDueDate.BackColor = Color.Transparent;

            customRadioButtonTaskName.ForeColor = Color.White;
            lblCompletedSubTasks.ForeColor = Color.White;
            lblDueDate.ForeColor = Color.White;
        }

        #endregion
    }
}
