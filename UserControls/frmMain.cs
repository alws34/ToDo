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
        private DataController DataController;
        private viewsController viewsController;
        #endregion

        #region Classes
        Utils utils;
        Serializer serializer;
        #endregion

        int lx, ly, sw, sh;
        #endregion

        #region Constructors
        public frmMain()
        {
            InitializeComponent();
            tbAddTask.GotFocus += TbAddTask_GotFocus;
            tbAddTask.LostFocus += TbAddTask_LostFocus;
            Opacity = 1;
            serializer = new Serializer();
            DataController = new DataController();
            viewsController = new viewsController();

            viewsController.SetProjectView += SetProjectViewOnScreen;
            viewsController.ProjectViewDeleted += DeleteProject;

            utils = new Utils();
            CenterToScreen();
            CheckControlsCount(flpProjects, tbAddTask);
            CheckControlsCount(flpTasks, textBoxAddSubTask);


            string path = serializer.GetDBPath();
            if (File.Exists(path))
            {
                LoadFromDB(path);

            }

        }
        #endregion

        #region DataManagement
        private void LoadFromDB(string path)
        {

            viewsController.LoadFromDB(path);//DEBUG
            //IMPLEMENT LOADING
        }

        private void SaveToFile(object data)
        {
            serializer.JsonSerialize_(data);
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
                currentProjectView.SetIndicator(true);

                ChangeProjNameLbl(currentProjectView.GetProjName());
                tbAddTask.Show();
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

        private void SetProjectViewOnScreen(SetProjectViewEventArgs arg)
        {
            /*
             This method will load the tasks abd sub tasks for the selected project
             */
            currentProjectView = arg.PV;


            flpTasks.Controls.Clear();//clear the task view
            flpSubTasks.Controls.Clear();

            ResetIndicators();

            foreach (KeyValuePair<string, TaskView> tv in viewsController.Taskviews)/*Will display all projects*/
            {
                if (tv.Value.GetParentID() == currentProjectView.ProjectID)
                {
                    flpTasks.Controls.Add(tv.Value);
                }
            }

            SetIndicator(currentProjectView);
            string date = viewsController.Projects[currentProjectView.ProjectID].DateCreated.ToString("dd/MM/yy");
            lblCreationDate.Text = $"Created on: {date}";

        }
        private void AddProjectViewToFlp(ProjectView projectView)
        {
            flpProjects.Controls.Add(projectView);
            ChangeProjNameLbl(projectView.GetProjName());
            SetCurrentProjectView(new SetProjectViewEventArgs(projectView));
            currentProjectView.SetIndicator(true);
        }

        #endregion

        #region Task
        private void SetNewTasksView(UpdateSubTaskViewEventArgs arg)
        {
            SubTaskView stv = arg.SubTaskView;
            flpSubTasks.Controls.Add(stv);
        }
        private void UpdateCurrentTaskView(UpdateCurrentTaskViewEventArgs arg)
        {
            //currentProjectTaskView = arg.ProjectTaskView;
            //SetTaskViewsOnScreen();
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
            foreach (KeyValuePair<string, SubTask> subTask in viewsController.SubTasks)
            {
                if (subTask.Value.ParentID == taskViewID)
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
                tb.Text = "Add new task";
            }
            return;
        }
       
        private void CheckControlsCount(FlowLayoutPanel flp, TextBox tb)
        {
            if (flp.Controls.Count > 0)
                tb.Enabled = true;
            else
                tb.Enabled = false;
        }
        #endregion

        #region Events

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
                    case "textBoxAddSubTask":
                        SubTaskView stv = viewsController.CreateSubTaskView(currentTaskView.TaskID, utils.GetUniqueID(), taskName);
                        currentSubTaskView = stv;
                        AddSubTaskViewToFlp(stv);
                        break;
                    case "tbAddTask":
                        TaskView tv = viewsController.CreateNewTaskView(taskName, utils.GetUniqueID(), currentProjectView.ProjectID);
                        tv.Rename(taskName);
                        tv.UpdateTaskView += UpdateCurrentTaskView;
                        currentTaskView = tv;
                        AddTaskViewToFlp(tv);
                        break;
                }
                tb.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();//close
        }

        #region TBPalecHolder
        private void TbAddTask_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (!tb.Focused && string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = "Add new task";
                return;
            }
        }

        private void TbAddTask_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "Add new task")
                tb.Text = "";
            return;
        }
        #endregion

        private void tbAddTask_Leave(object sender, EventArgs e)
        {
            SetTBPlaceHolder(new SetPlaceHolderEventArgs(sender as TextBox));
        }

        private void flpProjects_ControlAdded(object sender, ControlEventArgs e)
        {
            CheckControlsCount(flpProjects, tbAddTask);
        }
      
        private void flpTasks_ControlAdded(object sender, ControlEventArgs e)
        {
            CheckControlsCount(flpTasks, textBoxAddSubTask);
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
