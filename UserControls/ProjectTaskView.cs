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
    public partial class ProjectTaskView : UserControl
    {
        #region Fields
        int totalCompleted = 0;
        bool isCompleted = false;
        Color startBackgroundColor;
        #endregion

        #region Properties
        public List<SubTaskView> SubTasks = new List<SubTaskView>();
        public bool IsCompleted { get; set; }
        public string ID { get; set; }
        public string ParentID { get; set; }
        #endregion

        #region CustomEvents
        public event UpdateSubTaskViewEventHandler UpdateSubTaskView;
        public event UpdateCurrentTaskViewEventHandler UpdateCurrentTaskView;
        public event GetUniqueIDEventHandler GetUniqueID;
        #endregion

        #region Contructors
        public ProjectTaskView()
        {
            InitializeComponent();
            SetBackColor();
        }
        public ProjectTaskView(ProjectTask task)
        {
            InitializeComponent();
            SetTasklbl(task.TaskName);
            SetBackColor();
        }
        #endregion

        private void SetBackColor()
        {
            startBackgroundColor = customRadioButtonTaskName.BackColor;
        }

        public void AddSubTask(SubTask subtask)
        {
           // SubTasks.Add(subtask);
        }



        public void MarkSubTaskAsCompleted(SubTask subTask)
        {
            SetCompletedlbl(subTask);
        }
     
        public void SetTasklbl(string text)
        {
            this.customRadioButtonTaskName.Text = text;
            UpdateCurrentTaskView.Invoke(new UpdateCurrentTaskViewEventHandlerArgs(this));
        }

        public void SetCompletedlbl(SubTask subTask)
        {
            subTask.SetCompleted(true);
            totalCompleted++;

            int totalTasks = SubTasks.Count;



            lblCompletedSubTasks.Text = $"{totalCompleted}/{totalTasks}";  //update completed label. 
        }

        private void TaskView_Click(object sender, EventArgs e)
        {
            // update current task view at main form.
            UpdateCurrentTaskView.Invoke(new UpdateCurrentTaskViewEventHandlerArgs(this));
            //foreach (SubTaskView st in SubTasks)//load subtasks to tlpTaskView
            //{
            //    SubTaskView stv = new SubTaskView();
            //    stv.SetSubTaskText(st.SubTaskName);
            //    UpdateSubTaskView.Invoke(new UpdateSubTaskViewEventHandlerEventArgs(stv));
            //}
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
