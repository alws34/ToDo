using DoYourTasks.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MaterialSkin;
using System.Security.Cryptography;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DoYourTasks.UserControls.CustomControls;
using System.Drawing.Drawing2D;

namespace DoYourTasks
{
    public partial class frmMain : Form
    {
        #region Fields

        #region Views
        ProjectView currentProjectView;
        TaskView currentTaskView;
        SubTaskView currentSubTaskView;
        #endregion

        #region Controllers
        private viewsController viewsController;
        #endregion

        #region Utilities
        Utils utils;
        Serializer serializer;
        #endregion

        int lx, ly, sw, sh;
        bool isOptionsCollapsed = true;

        Timer optionsMenuTimer;
        #endregion

        #region Constructors
        public frmMain()
        {
            InitializeComponent();
            CenterToScreen();

            utils = new Utils();
            serializer = new Serializer();
            viewsController = new viewsController();
            optionsMenuTimer = new Timer()
            {
                Interval = 1
            };

            DoubleBuffered = true;

            optionsMenuTimer.Tick += OptionsMenuTimer_Tick;
            tbAddTask.GotFocus += TbAddTask_GotFocus;
            tbAddTask.LostFocus += TbAddTask_LostFocus;
            tbAddSubTask.GotFocus += TbAddTask_GotFocus;
            tbAddSubTask.LostFocus += TbAddTask_LostFocus;
            tbNotes.GotFocus += TbAddTask_GotFocus;
            tbNotes.LostFocus += TbAddTask_LostFocus;



            viewsController.SetProjectView += SetProjectTasksViewOnScreen;
            viewsController.ProjectViewDeleted += DeleteProject;
            viewsController.UpdateSubTaskViewCompleteCounter += ViewsController_UpdateSubTaskViewCompleteCounter;
            viewsController.UpdateTaskView += UpdateCurrentTaskView;
            viewsController.TaskDueDateChanged += ViewsController_TaskDueDateChanged;


            CheckControlsCount(flpProjects, tbAddTask);
            CheckControlsCount(flpTasks, tbAddSubTask);

            string path = serializer.GetDBPath();
            lblProjName.Text = String.Empty;
            btnSave.Enabled = false;

            if (File.Exists(path))
                LoadFromDB(path);
        }
        #endregion

        #region DataManagement
        private void LoadFromDB(string path)
        {
            viewsController.LoadFromDB(path);
            SetProjectViewsOnScreen();
        }

        #endregion

        #region Project
        #region ProjectIndication
        private void ResetIndicators()
        {
            foreach (Control c in flpProjects.Controls)
            {
                if (c.Name == "ProjectView")
                {
                    ProjectView p = c as ProjectView;
                    if (p != null)
                        if (p.IsIndicating)
                            p.SetIndicator(false);
                }
            }
        }

        private void SetIndicator(ProjectView projectView)
        {
            ResetIndicators();
            if (!projectView.IsIndicating)
            {
                currentProjectView = projectView;
                projectView.SetIndicator(true);
                ChangeProjNameLbl(projectView.GetProjName());
                //SetProjectViewOnScreen(new SetProjectViewEventArgs(projectView));
            }
        }
        #endregion
        private void ChangeProjNameLbl(string projName)
        {
            this.lblProjName.Text = projName;
        }

        private void SetCurrentProjectView(SetProjectViewEventArgs arg)
        {
            currentProjectView = arg.PV;
        }

        private void DeleteProject(ProjectViewDeletedEventArgs arg)
        {
            arg.ProjectView.Dispose();
            ChangeProjNameLbl("No project selected.");
            //TODO: Delete from dict and view
        }

        private void SetProjectTasksViewOnScreen(SetProjectViewEventArgs arg)
        {
            /*
             This method will load the tasks abd sub tasks for the selected project
             */
            currentProjectView = arg.PV;
            viewsController.Projects[arg.PV.ProjectID].Rename(arg.PV.GetProjName());
            flpTasks.Controls.Clear();//clear the tasks view
            flpSubTasks.Controls.Clear();

            ResetIndicators();

            foreach (var tv in viewsController.Taskviews)/*Will display all projects*/
            {
                if (tv.Value.GetParentProjectID() == currentProjectView.ProjectID)
                {
                    tv.Value.Width = flpTasks.Width - 6;
                    flpTasks.Controls.Add(tv.Value);
                }
            }



            SetIndicator(currentProjectView);
            string date = viewsController.Projects[currentProjectView.ProjectID].GetDateCreated().ToString("dd/MM/yy HH:mm tt");
            lblCreationDate.Text = $"Created on: {date}";

            if (!lblCreationDate.Visible)
                lblCreationDate.Visible = true;
        }
        private void AddProjectViewToFlp(ProjectView projectView)
        {
            ResetIndicators();
            flpProjects.Controls.Add(projectView);
            ChangeProjNameLbl(projectView.GetProjName());
            SetCurrentProjectView(new SetProjectViewEventArgs(projectView));
            currentProjectView.SetIndicator(true);
        }
        private void SetProjectViewsOnScreen()
        {
            foreach (ProjectView pv in viewsController.Projectviews.Values.ToList())
                AddProjectViewToFlp(pv);
        }
        #endregion

        #region Task
        private void UpdateCurrentTaskView(UpdateCurrentTaskViewEventArgs arg)
        {
            currentTaskView = arg.TaskView;
            try
            {
                string notes = viewsController.Projects[currentTaskView.GetParentProjectID()].Tasks[currentTaskView.GetID()].GetNotes();
                if (notes != null)
                {
                    tbNotes.Text = notes;
                    if (tbNotes.Visible == false)
                        tbNotes.Visible = true;
                }
                else
                {
                    tbNotes.Text = (string)tbNotes.Tag;
                }
            }
            catch (Exception) { tbNotes.Text = ""; }

            if (!tbAddSubTask.Enabled)
                tbAddSubTask.Enabled = true;

            SetSubTaskViewsOnScreen(currentTaskView.GetID());
        }

        private void AddTaskViewToFlp(TaskView taskView)
        {
            flpTasks.Controls.Add(taskView);
        }

        #endregion

        #region SubTask
        private void SetSubTaskViewsOnScreen(string taskViewID)
        {
            flpSubTasks.Controls.Clear();
            string id;
            foreach (var subTask in viewsController.SubTaskviews)
            {
                if (subTask.Value.GetParentTaskID() == taskViewID)
                {
                    id = subTask.Key;
                    flpSubTasks.Controls.Add(viewsController.SubTaskviews[id]);
                }
            }
        }

        private void AddSubTaskViewToFlp(SubTaskView subTask)
        {
            flpSubTasks.Controls.Add(subTask);
        }

        #endregion

        #region Utils
        public void SetTBPlaceHolder(SetPlaceHolderEventArgs arg)
        {
            TextBox tb = arg.TB;
            if (!tb.Focused && string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = (string)tb.Tag;
            }
            return;
        }

        private bool CheckControlsCount(FlowLayoutPanel flp, TextBox tb)
        {
            if (flp.Controls.Count > 0)
            {
                tb.Enabled = true;
                return true;
            }
            else
                tb.Enabled = false;
            return false;
        }

        private void btnOptionsMenu_Click(object sender, EventArgs e)
        {
            optionsMenuTimer.Start();
        }

        private void Exit()
        {
            if (!viewsController.SaveToFile())
                return;
            Application.Exit();
        }
        #endregion

        #region Events
        private void ViewsController_TaskDueDateChanged(DueDateChangedEventArgs args)
        {
            DueDatePicker.Hide();
        }

        private void ViewsController_UpdateSubTaskViewCompleteCounter(UpdateSubTaskViewCompleteCounterEventArgs arg)
        {
            string projectID = arg.ParentProjectID;
            string taskID = arg.ParentTaskID;
            bool mode = false;
            Dictionary<string, SubTask> subtasks;
            try
            {
                subtasks = viewsController.Projects[projectID].GetTasks()[taskID].GetSubTasks();//get all Task subtasks
            }
            catch { return; }

            int totalSubtasks = subtasks.Values.Count;
            int completed = 0;

            foreach (var subtask in subtasks.Values)
                if (subtask.GetIsCompleted())
                    completed++;

            currentTaskView.UpdateCompletedSubTasks(completed, totalSubtasks);

            if (totalSubtasks == completed)
                mode = true;
            else
                mode = false;

            viewsController.Projects[projectID].GetTasks()[taskID].SetCompleted(mode); // mark task as not completed
            currentTaskView.SetCompleted(mode);// display in the task view
        }

        private void OptionsMenuTimer_Tick(object sender, EventArgs e)
        {/*Will not resize flpTasks due to rendering performance issues*/
            if (isOptionsCollapsed)
            {
                pnlTasksHeader.Height += 55;
                //flpTasks.Height -= 5;
                if (pnlTasksHeader.Size == pnlTasksHeader.MaximumSize) //&& flpTasks.Size == flpTasks.MinimumSize)
                {
                    optionsMenuTimer.Stop();
                    isOptionsCollapsed = false;
                }
            }
            else
            {
                pnlTasksHeader.Height -= 55;
                //flpTasks.Height += 5;
                if (pnlTasksHeader.Size == pnlTasksHeader.MinimumSize) //&& flpTasks.Size == flpTasks.MaximumSize)
                {
                    optionsMenuTimer.Stop();
                    isOptionsCollapsed = true; ;
                }
            }

        }

        private void btnNewList_Click(object sender, EventArgs e)
        {
            currentProjectView = viewsController.CreateNewProjectView(utils.GetUniqueID());
            AddProjectViewToFlp(currentProjectView);

            currentProjectView.GetCurrentCustomTextBox().Focus();
        }

        private void tbAddTask_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null)
                return;
            string taskName = tb.Text;
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(taskName))
            {
                switch (tb.Name)
                {
                    case "tbAddSubTask":
                        SubTaskView stv = viewsController.CreateSubTaskView(currentProjectView.ProjectID, currentTaskView.GetID(), utils.GetUniqueID(), taskName);
                        currentSubTaskView = stv;
                        AddSubTaskViewToFlp(stv);
                        break;
                    case "tbAddTask":
                        TaskView tv = viewsController.CreateNewTaskView(taskName, utils.GetUniqueID(), currentProjectView.ProjectID);
                        tv.Rename(taskName);
                        currentTaskView = tv;
                        AddTaskViewToFlp(tv);
                        tbAddSubTask.Enabled = true;
                        break;
                    case "tbNotes":
                        //add note to the task object
                        viewsController.Projects[currentProjectView.ProjectID].GetTasks()[currentTaskView.GetID()].Notes = tbNotes.Text;
                        //tbNotes.Hide();
                        break;
                }
                tb.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!viewsController.SaveToFile())
                return;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMaximizar.Visible = true;
        }


        #region TBPalecHolder
        private void TbAddTask_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Height = 40;
            if (!tb.Focused && string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = "Add new task";
                return;
            }
        }

        private void TbAddTask_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Height = 40;
            if (!string.IsNullOrEmpty(tb.Text))
                tb.Text = string.Empty;
            return;
        }
        #endregion

        private void tbAddTask_Leave(object sender, EventArgs e)
        {
            SetTBPlaceHolder(new SetPlaceHolderEventArgs(sender as TextBox));
        }

        private void flpProjects_ControlAdded(object sender, ControlEventArgs e)
        {
            if (!CheckControlsCount(flpProjects, tbAddTask))
                return;
            btnSave.Enabled = true;
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void btnSetBackGroundImage_Click(object sender, EventArgs e)
        {
            //TODO//Choose a background for the project
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            //the rectangle, the same size as our Form
            Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            //define gradient's properties
            Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(0, 0, 0), Color.FromArgb(57, 128, 227), 65f);

            //apply gradient         
            graphics.FillRectangle(b, gradient_rectangle);
        }

        private void flpTasks_ControlAdded(object sender, ControlEventArgs e)
        {
            CheckControlsCount(flpTasks, tbAddSubTask);
        }

        private void btnAddDueDate_Click(object sender, EventArgs e)
        {
            DueDatePicker.Show();
        }

        private void btnAddNotes_Click(object sender, EventArgs e)
        {
            if (!tbNotes.Visible)
                tbNotes.Visible = true;
        }


        private void DueDatePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime dueDate = DueDatePicker.Value.Date;
            viewsController.Projects[currentProjectView.ProjectID].GetTasks()[currentTaskView.GetID()].SetDueDate(dueDate);
            viewsController.Taskviews[currentTaskView.GetID()].SetDueDate(dueDate);
        }

        #endregion

        #region ScreenBehaviour
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnNormal.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion    
    }
}
