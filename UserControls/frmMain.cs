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
using static System.Net.Mime.MediaTypeNames;
using System.Security.AccessControl;
using System.Runtime.CompilerServices;

using System.Xml;
using System.Xml.Serialization;

namespace DoYourTasks
{
    public partial class frmMain : Form
    {
        #region Fields
        private List<ProjectView> projects = new List<ProjectView>();
        ProjectView currentProjectView;
        ProjectTaskView currentProjectTaskView;
        SubTaskView currentSubTaskView;
        int lx, ly;
        int sw, sh;
        #endregion

        #region Constructors
        public frmMain()
        {
            InitializeComponent();
            tbAddTask.GotFocus += TbAddTask_GotFocus;
            tbAddTask.LostFocus += TbAddTask_LostFocus;
            Opacity = 1;
            CenterToScreen();
        }
        #endregion

        private void ChangeProjNameLbl(string projName)
        {
            this.lblProjName.Text = projName;
        }

        #region TablesControl
        private void UpdateRowCount(TableLayoutPanel tlp)
        {
            tlp.RowCount++;//update row count
            foreach (RowStyle rs in tlp.RowStyles)//resize all rows to fit perfectly
            {
                rs.SizeType = SizeType.AutoSize;
                rs.Height = 40;
            }
        }

        private void AddSubTaskViewToTable(SubTaskView subTask)
        {
            UpdateRowCount(tlpSubTasks);
            tlpSubTasks.Controls.Add(subTask);
        }

        private void AddProjectTaskViewToTable(ProjectTaskView taskView)
        {
            UpdateRowCount(tlpTasks);
            tlpTasks.Controls.Add(taskView);
        }

        private void AddProjectViewToTable(ProjectView projectView)
        {
            UpdateRowCount(tlpTasks);
            tlpProjects.Controls.Add(projectView);
        }

        #endregion

        #region ConstructViews
        private ProjectView GetProjectView(string projectName = "")
        {
            ProjectView projectList = new ProjectView()
            {
                ID = GetUniqueID(new GetUniqueIDEventArgs()),
                IsIndicating = true,
            };
            #region subscribe_to_events
            projectList.SetProjectTasksView += SetProjectViewOnScreen;
            projectList.ProjectViewDeleted += DeletedProject;
            #endregion

            projects.Add(projectList);

            return projectList;
        }
        private SubTaskView GetSubTaskView(string subtaskName = "")
        {
            return new SubTaskView()
            {
                ParentID = currentProjectView.ID,
                ID = GetUniqueID(new GetUniqueIDEventArgs()),
                SubTask = new SubTask(subtaskName, currentProjectTaskView.ID/*parent id*/, GetUniqueID(new GetUniqueIDEventArgs())/*new unique id*/),
            };
        }
        private ProjectTaskView GetProjectTaskView(string taskname = "")
        {
            ProjectTaskView ptv = new ProjectTaskView()
            {
                ID = GetUniqueID(new GetUniqueIDEventArgs()),
                ParentID = currentProjectView.ID,
            };
            ptv.UpdateCurrentTaskView += UpdateCurrentTaskView;
            ptv.UpdateSubTaskView += SetNewTasksView;
            ptv.GetUniqueID += GetUniqueID;

            ptv.SetTasklbl(taskname);
            return ptv;
        }
        #endregion

        #region DelegatedMethods
        private void SetNewTasksView(UpdateSubTaskViewEventHandlerEventArgs arg)
        {
            SubTaskView stv = arg.SubTaskView;
            UpdateRowCount(tlpSubTasks);
            tlpSubTasks.Controls.Add(stv);
        }

        private void UpdateCurrentTaskView(UpdateCurrentTaskViewEventHandlerArgs arg)
        {
            currentProjectTaskView = arg.ProjectTaskView;
            SetTaskViewsOnScreen();
        }

        public void SetTBPlaceHolder(SetPlaceHolderEventArgs arg)
        {
            TextBox tb = arg.TB;
            if (!tb.Focused && string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = "Add new task";
                return;
            }

        }

        private void DeletedProject(ProjectViewDeletedEventHandlerArgs arg)
        {
            arg.ProjectView.Dispose();
            ChangeProjNameLbl("No project selected.");
            //TODO: Remove from object
        }

        private void SetTaskViewsOnScreen()
        {
            tlpSubTasks.Controls.Clear();

            foreach (SubTaskView subTaskView in currentProjectTaskView.SubTasks)
                tlpSubTasks.Controls.Add(subTaskView);
        }

        private void SetProjectViewOnScreen(SetProjectTasksViewEventArgs arg)
        {
            /*
             This method will load the tasks sub tasks for the selected project
             */
            if (currentProjectView.Tasks == null)
                return;

            currentProjectView = arg.PV;

            #region ClearControls
            tlpTasks.Controls.Clear();//clear the task view
            tlpSubTasks.Controls.Clear();
            #endregion

            #region Indication
            ResetIndicators();
            SetIndicator(currentProjectView);
            #endregion

            foreach (ProjectTaskView taskView in currentProjectView.Tasks)//load Tasks and SubTasks.
            {
                tlpTasks.Controls.Add(taskView);
                foreach (SubTaskView subTaskView in taskView.SubTasks)
                    tlpSubTasks.Controls.Add(subTaskView);
            }

        }

        private string GetUniqueID(GetUniqueIDEventArgs args)
        {//calculates a hash (sha512) -- (*ID*) based on current datetime milliseconds
            byte[] result = default;
            using (var stream = new MemoryStream())
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
                    writer.Write(DateTime.Now.Millisecond);

                stream.Position = 0;

                using (var hash = SHA256.Create())
                {
                    result = hash.ComputeHash(stream);
                }
            }

            var text = new string[32];

            for (var i = 0; i < text.Length; i++)
            {
                text[i] = result[i].ToString("x2");
            }
            return string.Concat(text);
        }

        #endregion

        #region Events
        private void btnNewList_Click(object sender, EventArgs e)
        {
            ProjectView projectView = GetProjectView();
            currentProjectView = projectView;
            AddProjectViewToTable(projectView);
        }

        //adding new tasks and subtasks
        private void tbAddTask_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null)
                return;
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(tb.Text))
            {
                string taskName = tb.Text;
                switch (tb.Name)
                {
                    case "textBoxAddSubTask":
                        SubTaskView stv = GetSubTaskView(taskName);
                        currentSubTaskView = stv;
                        AddSubTaskViewToTable(stv);
                        break;
                    case "tbAddTask":
                        ProjectTaskView ptv = GetProjectTaskView();
                        currentProjectTaskView = ptv;
                        AddProjectTaskViewToTable(ptv);
                        break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                //TODO MAKE ALL DATA AS CONTROLLERS (SINGLE OBJECTS)
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
            Dispose();
        }

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

        private void tbAddTask_Leave(object sender, EventArgs e)
        {
            //SetTBPlaceHolder(new SetPlaceHolderEventArgs(sender as TextBox));
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            foreach (Control c in pnlMain.Controls)
                if (c.Focused)
                    c.Invalidate();
        }

        #endregion

        #region ProjectIndication
        private void ResetIndicators()
        {
            foreach (ProjectView pv in tlpProjects.Controls)//disable all other indicators
                if (pv.IsIndicating)
                    pv.SetIndicator(false);
        }

        private void SetIndicator(ProjectView projectView)
        {
            if (!projectView.IsIndicating)
            {
                currentProjectView = projectView;
                currentProjectView.SetIndicator(true);

                ChangeProjNameLbl(currentProjectView.GetProjName());
                tbAddTask.Show();
            }
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
