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

namespace DoYourTasks
{
    public partial class frmMain : Form
    {
        #region Fields
        ProjectView currentProjectView;
        TaskView currentTaskView;
        SubTaskView currentSubTaskView;

        private DataController DataController;
        private viewsController viewsController;
        Utils utils;
        Serializer serializer;
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
            viewsController.ProjectViewDeleted;

            utils = new Utils();
            CenterToScreen();
            tbAddTask.Enabled = false;
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

        private void AddProjectTaskViewToTable(TaskView taskView)
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
            string id = utils.GetUniqueID();
            ProjectView pv = new ProjectView(id);
            Project p = new Project(id, projectName);
            pv.IsIndicating = true;

            pv.SetProjectView += SetProjectViewOnScreen;
            pv.ProjectViewDeleted += DeletedProject;

            viewsController.Projects.Add(id, p);
            viewsController.Projectviews.Add(id, pv);
            return pv;
        }
        private SubTaskView GetSubTaskView(string subtaskName = "")
        {
            string id = utils.GetUniqueID();
            SubTaskView stv =  viewsController.CreateSubTaskView(currentTaskView.ID,id,subtaskName);
            SubTask subTask = new SubTask(subtaskName, currentProjectView.ProjectID,id);
            return stv;
        }
        private TaskView GetTaskView(string taskname = "")
        {
            TaskView tv = viewsController.CreateNewTaskView(utils.GetUniqueID());
            tv.UpdateTaskView += UpdateCurrentTaskView;
            //ptv.UpdateSubTaskView += SetNewTasksView;
            tv.Rename(taskname);
            return tv;
        }
        #endregion

        #region DelegatedMethods

        private void SetCurrentProjectView(SetProjectViewEventArgs arg)
        {
            currentProjectView = arg.PV;
        }

        private void SetNewTasksView(UpdateSubTaskViewEventHandlerEventArgs arg)
        {
            SubTaskView stv = arg.SubTaskView;
            UpdateRowCount(tlpSubTasks);
            tlpSubTasks.Controls.Add(stv);
        }

        private void UpdateCurrentTaskView(UpdateCurrentTaskViewEventHandlerArgs arg)
        {
            //currentProjectTaskView = arg.ProjectTaskView;
            //SetTaskViewsOnScreen();
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
            //TODO: Delete from dict and view
        }

        private void SetTaskViewsOnScreen(string taskViewID)
        {
            tlpSubTasks.Controls.Clear();
            string id;
            foreach (KeyValuePair<string, SubTask> subTask in viewsController.SubTasks)
            {
                if (subTask.Value.ParentID == taskViewID)
                {
                    id = subTask.Key;
                    tlpSubTasks.Controls.Add(viewsController.SubTaskviews[id]);
                }
            }
        }

        private void SetProjectViewOnScreen(SetProjectViewEventArgs arg)
        {
            /*
             This method will load the tasks sub tasks for the selected project
             */
            //if (currentProjectView.ProjectTasks == null)
            //    return;

            currentProjectView = arg.PV;


            tlpTasks.Controls.Clear();//clear the task view
            tlpSubTasks.Controls.Clear();

            ResetIndicators();

            foreach (KeyValuePair<string, ProjectView> pv in viewsController.Projectviews)/*Will display all projects*/
            {
                pv.Value.SetIndicator(false);
                tlpProjects.Controls.Add(pv.Value);
            }

            SetIndicator(currentProjectView);
        }

        //private string GetUniqueID()
        //{//calculates a hash (sha512) -- (*ID*) based on current datetime milliseconds
        //    byte[] result = default;
        //    using (var stream = new MemoryStream())
        //    {
        //        using (var writer = new BinaryWriter(stream, Encoding.UTF8, true))
        //            writer.Write(DateTime.Now.Millisecond);

        //        stream.Position = 0;

        //        using (var hash = SHA256.Create())
        //        {
        //            result = hash.ComputeHash(stream);
        //        }
        //    }

        //    var text = new string[32];

        //    for (var i = 0; i < text.Length; i++)
        //    {
        //        text[i] = result[i].ToString("x2");
        //    }
        //    return string.Concat(text);
        //}


        #endregion

        #region Events
        private void btnNewList_Click(object sender, EventArgs e)
        {
            ProjectView projectView = viewsController.CreateNewProjectView(utils.GetUniqueID());
            currentProjectView = projectView;
            AddProjectViewToTable(projectView);
            tbAddTask.Enabled = true;
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
                        SubTaskView stv = viewsController.CreateSubTaskView(currentTaskView.ID, GetUniqueID(), taskName);
                        currentSubTaskView = stv;
                        AddSubTaskViewToTable(stv);
                        break;
                    case "tbAddTask":
                        TaskView ptv = viewsController.CreateNewTaskView(taskName);
                        currentTaskView = ptv;
                        AddProjectTaskViewToTable(ptv);
                        break;
                }
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
            //SetTBPlaceHolder(new SetPlaceHolderEventArgs(sender as TextBox));
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            //foreach (Control c in pnlMain.Controls)
            //    if (c.Focused)
            //        c.Invalidate();
        }

        #endregion

        #region ProjectIndication
        private void ResetIndicators()
        {
            foreach (Control pv in tlpProjects.Controls)//disable all other indicators
            {
                if (pv.Name != "ProjectView")
                    return;

                ProjectView p = pv as ProjectView;
                if (p == null)
                    return;

                if (p.IsIndicating)
                    p.SetIndicator(false);
            }
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
