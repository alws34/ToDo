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

using System.Security.Cryptography;
using System.IO;

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

        frmHiddenItems frmHiddenProjects = new frmHiddenItems("Hidden Projects");
        frmHiddenItems frmHiddenTasks = new frmHiddenItems("Hidden Tasks");

        #endregion

        #region Controllers
        private DataController dataController;
        #endregion

        #region Utilities
        Utils utils;
        Serializer serializer;
        #endregion

        int lx, ly, sw, sh;
        bool isOptionsCollapsed = true;
        bool toBackup = false;
        Timer optionsMenuTimer;
        Timer AutoSaveTimer;
        Timer pnlSaveTimer;
        #endregion

        #region Constructors
        public frmMain()
        {
            InitializeComponent();
            CenterToScreen();
            DoubleBuffered = true;
            utils = new Utils();
            serializer = new Serializer();
            dataController = new DataController();

            optionsMenuTimer = new Timer() { Interval = 1 };
            AutoSaveTimer = new Timer() { Interval = 60000 };//60 seconds
            pnlSaveTimer = new Timer() { Interval = 2000 };
            AutoSaveTimer.Start();//auto save every {AutoSaveTimer} seconds

            optionsMenuTimer.Tick += OptionsMenuTimer_Tick;
            AutoSaveTimer.Tick += AutoSaveTimer_Tick;
            pnlSaveTimer.Tick += PnlSaveTimer_Tick;

            tbAddTask.GotFocus += TbAddTask_GotFocus;
            tbAddTask.LostFocus += TbAddTask_LostFocus;

            tbAddSubTask.GotFocus += TbAddTask_GotFocus;
            tbAddSubTask.LostFocus += TbAddTask_LostFocus;

            tbNotes.GotFocus += TbAddTask_GotFocus;
            tbNotes.LostFocus += TbAddTask_LostFocus;

            dataController.SetProjectView += SetProjectTasksViewOnScreen;
            dataController.ProjectViewDeleted += DeleteProject;
            dataController.UpdateSubTaskViewCompleteCounter += ViewsController_UpdateSubTaskViewCompleteCounter;
            dataController.UpdateTaskView += UpdateCurrentTaskView;
            dataController.TaskDueDateChanged += ViewsController_TaskDueDateChanged;
            dataController.TaskRenamed += ViewsController_TaskRenamed;
            dataController.SubTaskDeleted += ViewsController_SubTaskDeleted;
            dataController.TaskCompleted += ViewsController_TaskCompleted;
            dataController.PriorityChaned += ViewsController_PriorityChaned;
            dataController.TaskDeleted += ViewsController_TaskDeleted;
            dataController.NewSubTaskView += ViewsController_NewSubTaskView;
            dataController.HideItem += DataController_LoadViewsToScreen;
            dataController.AddNewProjectAttachment += AddProjectAttachment;

            CheckControlsCount(flpProjects, tbAddTask);
            CheckControlsCount(flpTasks, tbAddSubTask);


            string path = serializer.GetDBPath();
            lblProjName.Text = String.Empty;
            btnSave.Enabled = false;


            flpProjects.DragOver += FlpProjects_DragOver;
            flpProjects.DragDrop += FlpProjects_DragDrop;

            flpTasks.DragOver += FlpTasks_DragOver;
            flpTasks.DragDrop += FlpTasks_DragDrop;

            flpSubTasks.DragOver += FlpSubTasks_DragOver;
            flpSubTasks.DragDrop += FlpSubTasks_DragDrop;


            comboBoxProjectPriority.Items.Add(PriorityCodes.VeryLow.ToString());
            comboBoxProjectPriority.Items.Add(PriorityCodes.Low.ToString());
            comboBoxProjectPriority.Items.Add(PriorityCodes.Medium.ToString());
            comboBoxProjectPriority.Items.Add(PriorityCodes.High.ToString());
            comboBoxProjectPriority.Items.Add(PriorityCodes.Urgent.ToString());
            comboBoxProjectPriority.Items.Add(PriorityCodes.OnHold.ToString());
            comboBoxProjectPriority.Items.Add(PriorityCodes.Waiting.ToString());
            comboBoxProjectPriority.Items.Add(PriorityCodes.Done.ToString());
            comboBoxProjectPriority.Items.Add("All Projects");
            comboBoxProjectPriority.SelectedIndex = comboBoxProjectPriority.Items.Count - 1;


            comboBoxTaskPriority.Items.Add(PriorityCodes.VeryLow.ToString());
            comboBoxTaskPriority.Items.Add(PriorityCodes.Low.ToString());
            comboBoxTaskPriority.Items.Add(PriorityCodes.Medium.ToString());
            comboBoxTaskPriority.Items.Add(PriorityCodes.High.ToString());
            comboBoxTaskPriority.Items.Add(PriorityCodes.Urgent.ToString());
            comboBoxTaskPriority.Items.Add(PriorityCodes.OnHold.ToString());
            comboBoxTaskPriority.Items.Add(PriorityCodes.Waiting.ToString());
            comboBoxTaskPriority.Items.Add(PriorityCodes.Done.ToString());
            comboBoxTaskPriority.Items.Add("All Tasks");
            comboBoxTaskPriority.SelectedIndex = comboBoxTaskPriority.Items.Count - 1;

            if (File.Exists(path))
                LoadFromDB(path);

            foreach (Project project in dataController.GetHiddenProjects().Values.ToList())
            {
                frmHiddenProjects.AddControl(dataController.Projectviews[project.GetProjectID()]);
            }
            BackupDB();
        }

        private bool VerifyPriority(int priority = -1)
        {
            switch (priority)
            {
                case (int)PriorityCodes.VeryLow:
                    break;
                case (int)PriorityCodes.Low:
                    break;
                case (int)PriorityCodes.Medium:
                    break;
                case (int)PriorityCodes.High:
                    break;
                case (int)PriorityCodes.Urgent:
                    break;
                case (int)PriorityCodes.OnHold:
                    break;
                case (int)PriorityCodes.Waiting:
                    break;
                case (int)PriorityCodes.Done:
                    break;
                case -1:
                    break;
            }
            return true;
        }

        /// <summary>
        /// Load items and Hidden items to their appropriate place
        /// </summary>
        private void DataController_LoadViewsToScreen(HideItemEventArgs arg)
        {
            Control control = arg.Control;

            // bool isHidden = IsControlHidden(control);
            switch (control.Name)
            {
                case "ProjectView":
                    ProjectView pv = control as ProjectView;
                    Project project = null;
                    string projectID = pv.GetProjectID();
                    project = dataController.GetCorrectProject(projectID);

                    //project.SetIsHidden(!project.GetIsHidden());

                    if (pv.GetIsHidden())
                    {
                        //move control between view-locations
                        frmHiddenProjects.AddControl(control);
                        flpProjects.Controls.Remove(control);

                        //set project as hidden and add it to appropriate DataStructure
                        project.SetIsHidden(true);
                        try
                        {
                            dataController.GetHiddenProjects().Add(projectID, project);
                            dataController.GetProjects().Remove(projectID);
                        }
                        catch (Exception)
                        {
                            int i = 0;
                        }
                    }
                    else
                    {
                        flpProjects.Controls.Add(control);
                        frmHiddenProjects.RemoveControl(control);

                        project.SetIsHidden(false);
                        try
                        {
                            dataController.GetProjects().Add(project.GetProjectID(), project);
                            dataController.GetHiddenProjects().Remove(project.GetProjectID());
                        }
                        catch (Exception)
                        {
                            int i = 0;
                        }

                    }

                    if (flpProjects.Controls.Contains(pv))
                        flpProjects.Controls.SetChildIndex(pv, dataController.GetCorrectProject(pv.GetProjectID()).GetIndex());

                    break;
                case "TaskView":
                    TaskView tv = control as TaskView;
                    Task task = dataController.GetCorrectProject(tv.GetParentProjectID()).GetTasks()[tv.GetTaskID()];
                    if (tv.GetIsHidden())
                    {
                        frmHiddenTasks.AddControl(control);
                        flpTasks.Controls.Remove(control);
                        task.SetIsHidden(true);

                        dataController.GetCorrectProject(task.GetParentProjectID()).AddHiddenTask(task);
                        dataController.GetCorrectProject(task.GetParentProjectID()).GetTasks().Remove(task.GetTaskID());
                    }
                    else
                    {
                        flpTasks.Controls.Add(control);
                        frmHiddenTasks.RemoveControl(control);
                        task.SetIsHidden(false);

                        dataController.GetCorrectProject(task.GetParentProjectID()).AddTask(task);
                        dataController.GetCorrectProject(task.GetParentProjectID()).GetHiddenTasks().Remove(task.GetTaskID());

                    }

                    if (flpTasks.Controls.Contains(tv))
                        flpTasks.Controls.SetChildIndex(tv, dataController.GetCorrectProject(tv.GetParentProjectID()).GetTasks()[tv.GetTaskID()].GetIndex());

                    break;
            }
        }

        #endregion

        #region ViewsController
        private void ViewsController_TaskDeleted(TaskDeletedEventArgs args)
        {
            TaskView tv = args.TV;
        }


        private void ViewsController_PriorityChaned(PriorityChangedEventArgs args)
        {
            string projectID = args.TaskView.GetParentProjectID();
            Dictionary<string, Task> taskLst = dataController.GetCorrectProject(projectID).GetTasks();
            UpdatePriorityLabels(taskLst);
        }

        private void ViewsController_TaskCompleted(TaskCompletedEventArgs args)
        {
            Task task = null;
            if (args == null)
                return;

            if (dataController.GetCorrectProject(args.TV.GetParentProjectID()).GetTasks().ContainsKey(args.TV.GetTaskID()))
                task = dataController.GetCorrectProject(args.TV.GetParentProjectID()).GetTasks()[args.TV.GetTaskID()];
            else if (dataController.GetCorrectProject(args.TV.GetParentProjectID()).GetHiddenTasks().ContainsKey(args.TV.GetTaskID()))
                task = dataController.GetCorrectProject(args.TV.GetParentProjectID()).GetHiddenTasks()[args.TV.GetTaskID()];
            else
                return;

            if (!flpTasks.Controls.Contains(args.TV))
                return;

            if (task.GetIsCompleted())
            {
                flpTasks.Controls.SetChildIndex(args.TV, flpTasks.Controls.Count - 1);//move to buttom
                task.SetIndex(flpTasks.Controls.GetChildIndex(args.TV));
            }
            else
            {
                flpTasks.Controls.SetChildIndex(args.TV, task.GetIndex());
            }



            foreach (TaskView tv in flpTasks.Controls)
            {
                task = dataController.GetCorrectProject(tv.GetParentProjectID()).GetTasks()[tv.GetTaskID()];
                if (task.GetIsCompleted())
                {
                    flpTasks.Controls.SetChildIndex(tv, flpTasks.Controls.Count - 1);//move to buttom
                    task.SetIndex(flpTasks.Controls.GetChildIndex(tv));
                }
                else
                {
                    flpTasks.Controls.SetChildIndex(tv, task.GetIndex());//move to top
                }
            }
            Dictionary<string, Task> taskLst = dataController.GetCorrectProject(currentProjectView.ProjectID).GetTasks();
            UpdatePriorityLabels(taskLst);

            //low = 0;
            //med = 0;
            //high = 0;
        }

        private void UpdatePriorityLabels(Dictionary<string, Task> taskLst)
        {
            int veryLow = 0;
            int low = 0;
            int med = 0;
            int high = 0;
            int urgent = 0;
            int onHold = 0;
            int Waiting = 0;
            int done = 0;
            // Dictionary<string, Task> taskLst = viewsController.Projects[currentProjectView.ProjectID].GetTasks();
            foreach (var task in taskLst)
            {
                switch (task.Value.GetPriority())
                {
                    case 0:
                        veryLow++;
                        break;
                    case 1:
                        low++;
                        break;
                    case 2:
                        med++;
                        break;
                    case 3:
                        high++;
                        break;
                    case 4:
                        urgent++;
                        break;
                    case 5:
                        onHold++;
                        break;
                    case 6:
                        Waiting++;
                        break;
                    case 7:
                        done++;
                        break;
                }

                dataController.Projectviews[task.Value.GetParentProjectID()].SetCounters(0, veryLow);
                dataController.Projectviews[task.Value.GetParentProjectID()].SetCounters(1, low);
                dataController.Projectviews[task.Value.GetParentProjectID()].SetCounters(2, med);
                dataController.Projectviews[task.Value.GetParentProjectID()].SetCounters(3, high);
                dataController.Projectviews[task.Value.GetParentProjectID()].SetCounters(4, urgent);
                dataController.Projectviews[task.Value.GetParentProjectID()].SetCounters(5, onHold);
                dataController.Projectviews[task.Value.GetParentProjectID()].SetCounters(6, Waiting);
                dataController.Projectviews[task.Value.GetParentProjectID()].SetCounters(7, done);
            }
        }


        private void AutoSaveTimer_Tick(object sender, EventArgs e)
        {
            if (!dataController.SaveToFile(isAutoSave: true))
                return;
            pnlSave.Visible = true;
            pnlSaveTimer.Start();

            BackupDB();
        }


        private void PnlSaveTimer_Tick(object sender, EventArgs e)
        {
            pnlSave.Visible = false;
            pnlSaveTimer.Stop(); // do only once.
        }

        private void ViewsController_SubTaskDeleted(SubTaskDeletedEventArgs arg)
        {
            ViewsController_UpdateSubTaskViewCompleteCounter(new UpdateSubTaskViewCompleteCounterEventArgs(arg.STV.GetParentProjectID(), arg.STV.GetParentTaskID()));
        }

        private void ViewsController_TaskRenamed(TaskRenamedEventArgs args)
        {
            //tbAddTask.Focus();
            tbAddTask.Select();
        }
        #endregion

        #region DataManagement
        private void LoadFromDB(string path)
        {
            dataController.LoadFromDB(path);
            SetProjectViewsOnScreen(true);

            foreach (ProjectView pv in dataController.Projectviews.Values.ToList())
            {
                string projectID = pv.ProjectID;
                try
                {
                    int idx = dataController.GetCorrectProject(projectID).GetIndex();
                    if (idx != -1)
                        flpProjects.Controls.SetChildIndex(pv, idx);
                    else
                        dataController.GetCorrectProject(projectID).SetIndex(flpProjects.Controls.GetChildIndex(pv));
                }
                catch (Exception) { continue; }


                Dictionary<string, Task> taskLst = dataController.GetCorrectProject(projectID).GetTasks();
                UpdatePriorityLabels(taskLst);

            }
        }
        private void BackupDB()
        {
            try
            {
                DateTime now = DateTime.Now;
                if (now.Hour % 2 == 0 && now.Minute >= 30)
                {
                    if (toBackup)
                    {
                        dataController.BackupDB();
                        toBackup = false;
                    }
                }
                if (now.Minute < 30)
                    toBackup = true;
            }
            catch (Exception ee) { }
        }

        #endregion

        #region Project

        private void AddProjectAttachment()
        {
            string filepath = GetFilefromDialog();
            if (string.IsNullOrWhiteSpace(filepath))
                return;

            string projectID = currentProjectView.GetProjectID();

            Attachment attachment = new Attachment()
            {
                AttachmentID = utils.GetUniqueID(),
                ParentProjectID = projectID,
                FilePath = filepath,
                FileName = Path.GetFileNameWithoutExtension(filepath),
                FileType = Path.GetExtension(filepath),
                AddedOn = DateTime.Now.ToString("dd/MM/yy"),
            };

            dataController.GetCorrectProject(projectID).AddAttachment(attachment);//Add Attachment to object's list

            UCAttachmentView uca = new UCAttachmentView(attachment);
            uca.AttachemntRemoved += ProjectAttachemntRemoved;
            flpProjectAttachments.Controls.Add(uca);

            flpProjectAttachments.Refresh();
        }

        private void FlpProjects_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(ProjectView)))
                return;

            Control droppedControl = (ProjectView)e.Data.GetData(typeof(ProjectView));
            if (droppedControl == null)
                return;

            Point clientPoint = flpProjects.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            Control targetControl = flpProjects.GetChildAtPoint(clientPoint);

            if (targetControl == null)
                return;

            int targetIndex = flpProjects.Controls.IndexOf(targetControl);
            int droppedIndex = flpProjects.Controls.IndexOf(droppedControl);

            flpProjects.Controls.SetChildIndex(droppedControl, targetIndex);
            dataController.GetCorrectProject(((ProjectView)droppedControl).ProjectID).SetIndex(flpProjects.Controls.GetChildIndex((ProjectView)droppedControl));

            foreach (ProjectView pv in flpProjects.Controls)
            {// set  indexes to all objects
                string projectID = pv.ProjectID;
                dataController.GetCorrectProject(projectID).SetIndex(flpProjects.Controls.GetChildIndex(pv));
                flpProjects.Controls.SetChildIndex(pv, dataController.GetCorrectProject(projectID).GetIndex());
            }
        }

        private void FlpProjects_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }



        #region ProjectIndication
        private void ResetIndicators()
        {
            foreach (Control c in flpProjects.Controls)
            {
                if (c.Name == "ProjectView")
                {
                    ProjectView p = c as ProjectView;

                    if (p != null)
                    {
                        if (p.IsIndicating)
                            p.SetIndicator(false);
                        if (p.Size.Height > p.MinimumSize.Height)
                            p.Size = p.MinimumSize;
                    }
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
                ChangeProjNameLbl(projectView.GetProjectName());
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
            lblProjName.Text = dataController.GetCorrectProject(arg.PV.ProjectID).GetProjectName();
        }

        private void DeleteProject(ProjectViewDeletedEventArgs arg)
        {
            ChangeProjNameLbl("No project selected.");
            dataController.RemoveCorrectProject(arg.ProjectView.ProjectID);
            arg.ProjectView.Dispose();
            flpTasks.Controls.Clear();//clear the tasks view
            flpSubTasks.Controls.Clear();
            currentProjectView = null;
            //TODO: Delete from dict and view
        }

        private void ResetScreen()
        {
            flpTasks.Controls.Clear();//clear the tasks view
            flpSubTasks.Controls.Clear();
            flpProjectAttachments.Controls.Clear();
            tbCommitMsg.Clear();

            frmHiddenProjects.ClearItems();
            frmHiddenTasks.ClearItems();

            ResetIndicators();
        }

        private void SetProjectTasksViewOnScreen(SetProjectViewEventArgs arg)
        {
            /*
             This method will load the tasks abd sub tasks for the selected project
             */
            try
            {
                ResetScreen();
                SetCurrentProjectView(new SetProjectViewEventArgs(arg.PV));
                ResetIndicators();
                currentProjectView.SetIndicator(true);

                // animate
                //while (currentProjectView.Height < currentProjectView.MaximumSize.Height)
                //    currentProjectView.Height += 60;


                //currentProjectView.Size = currentProjectView.MaximumSize;

                foreach (var tv in dataController.Taskviews)/*Will display all Project's Tasks*/
                {
                    tv.Value.Width = flpTasks.Width - 6;

                    if (tv.Value.GetParentProjectID() != currentProjectView.ProjectID)
                        continue;

                    List<Task> hiddenTasks = dataController.GetCorrectProject(tv.Value.GetParentProjectID()).GetHiddenTasks().Values.ToList();
                    foreach (var hiddenTv in hiddenTasks)
                        frmHiddenTasks.AddControl(dataController.Taskviews[hiddenTv.GetTaskID()]);

                    Task task = dataController.GetCorrectProject(tv.Value.GetParentProjectID()).GetTasks()[tv.Value.GetTaskID()];
                    string taskID = task.GetTaskID();
                    int taskPriority = dataController.GetCorrectProject(task.GetParentProjectID()).GetTasks()[task.GetTaskID()].GetPriority();

                    if (comboBoxTaskPriority.SelectedIndex == taskPriority)
                        flpTasks.Controls.Add(tv.Value);
                    else
                        flpTasks.Controls.Remove(tv.Value);

                    //add all
                    if (comboBoxTaskPriority.SelectedIndex == comboBoxProjectPriority.Items.Count - 1)
                        flpTasks.Controls.Add(tv.Value);
                }

                foreach (var tv in dataController.Taskviews)/*Set Tasks Location on screen (control flp child index)*/
                {
                    if (tv.Value.GetParentProjectID() == currentProjectView.ProjectID)
                    {
                        int index = dataController.GetCorrectProject(tv.Value.GetParentProjectID()).GetTasks()[tv.Value.GetTaskID()].GetIndex();

                        if (tv.Value.GetCheckedState())
                            index = flpTasks.Controls.Count - 1;

                        flpTasks.Controls.SetChildIndex(tv.Value, index);
                    }
                }

                SetIndicator(currentProjectView);
                string date = dataController.GetCorrectProject(currentProjectView.ProjectID).GetDateCreated().ToString("dd/MM/yy");
                lblCreationDate.Text = $"Project Created at: {date}";

                //Get project's notes and set it to the TextBox
                tbProjectNotes.Text = dataController.GetCorrectProject(arg.PV.ProjectID).GetProjectNotes();

                //Add Project's Attachments
                foreach (Attachment attachment in dataController.GetCorrectProject(arg.PV.ProjectID).GetAttachments())
                {
                    UCAttachmentView uca = new UCAttachmentView(attachment);
                    uca.AttachemntRemoved += ProjectAttachemntRemoved;
                    flpProjectAttachments.Controls.Add(uca);
                }


                if (!lblCreationDate.Visible)
                    lblCreationDate.Visible = true;
            }
            catch (Exception e)
            {
                return;
            }
            ViewsController_TaskCompleted(null);
        }

        private void ProjectAttachemntRemoved(AttachmentRemovedEventArgs arg)
        {
            dataController.GetCorrectProject(currentProjectView.GetProjectID()).GetAttachments().Remove(arg.Attachment.Attachment);
        }

        private void AddProjectViewToFlp(ProjectView projectView, bool isLoading = false)
        {
            //ResetIndicators();
            ResetScreen();
            projectView.MouseDown += ProjectView_MouseDown;

            //if (!IsControlHidden(projectView))
            DataController_LoadViewsToScreen(new HideItemEventArgs(projectView));
            //flpProjects.Controls.Add(projectView);

            ChangeProjNameLbl(projectView.GetProjectName());
            SetCurrentProjectView(new SetProjectViewEventArgs(projectView));
            currentProjectView.SetIndicator(true);
        }

        private void ProjectView_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            c.DoDragDrop(c, DragDropEffects.Move);
        }

        private void SetProjectViewsOnScreen(bool isLoading = false)
        {
            bool addAll = false;
            foreach (ProjectView pv in dataController.Projectviews.Values.ToList())
            {
                string projectID = dataController.GetCorrectProject(pv.GetProjectID()).GetProjectID();
                int projectPriority = dataController.GetCorrectProject(pv.GetProjectID()).GetPriority();

                if (comboBoxProjectPriority.SelectedIndex == comboBoxProjectPriority.Items.Count - 1)
                {//add all
                    AddProjectViewToFlp(pv, isLoading);
                    addAll = true;
                }
                if (addAll)
                    continue;

                if (comboBoxProjectPriority.SelectedIndex - 1 == projectPriority)
                {
                    AddProjectViewToFlp(pv);
                }
                else
                {
                    flpProjects.Controls.Remove(pv);
                }
            }
        }
        #endregion

        #region Task


        private void FlpTasks_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void FlpTasks_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(TaskView)))
                return;

            Control droppedControl = (TaskView)e.Data.GetData(typeof(TaskView));
            if (droppedControl == null)
                return;

            Point clientPoint = flpTasks.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            Control targetControl = flpTasks.GetChildAtPoint(clientPoint);

            if (targetControl == null)
                return;

            int targetIndex = flpTasks.Controls.IndexOf(targetControl);
            int droppedIndex = flpTasks.Controls.IndexOf(droppedControl);

            flpTasks.Controls.SetChildIndex(droppedControl, targetIndex);
            dataController.GetCorrectProject(((TaskView)droppedControl).GetParentProjectID()).GetTasks()[((TaskView)droppedControl).GetTaskID()].SetIndex(flpTasks.Controls.GetChildIndex((TaskView)droppedControl));

            foreach (TaskView tv in flpTasks.Controls)
            {// set  indexes to all objects
                dataController.GetCorrectProject(tv.GetParentProjectID()).GetTasks()[tv.GetTaskID()].SetIndex(flpTasks.Controls.GetChildIndex(tv));
                flpTasks.Controls.SetChildIndex(tv, dataController.GetCorrectProject(tv.GetParentProjectID()).GetTasks()[tv.GetTaskID()].GetIndex());
            }
        }

        private void UpdateCurrentTaskView(UpdateCurrentTaskViewEventArgs arg)
        {
            if (currentTaskView != null)
            {
                currentTaskView.ResetSize(); // reste previous task view size (to hide attachments...)
                currentTaskView.Size = currentTaskView.MinimumSize;
            }

            currentTaskView = arg.TaskView;

            while (currentTaskView.Size.Height < currentTaskView.MaximumSize.Height)
                currentTaskView.Height += 55;

            try
            {
                string projectID = currentTaskView.GetParentProjectID();
                string taskID = currentTaskView.GetTaskID();
                string notes = dataController.GetCorrectProject(projectID).Tasks[taskID].GetNotes();
                List<Attachment> attachments = dataController.GetCorrectProject(projectID).Tasks[taskID].GetAttachements();
                if (tbNotes.Visible == false)
                    tbNotes.Visible = true;
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

                tbCommitMsg.Text = "";
                tbCommitMsg.Text += DateTime.Now.ToString("dd/mm/yyyy HH:mm tt");

                foreach (var subtask in dataController.GetCorrectProject(projectID).Tasks[taskID].GetSubTasks())
                {
                    var val = subtask.Value;
                    string name = val.GetSubTaskName();
                    tbCommitMsg.Text += $"\n - {name}";
                }

                if (attachments.Count > 0)
                {
                    currentTaskView.SetAttachments(attachments);
                }
            }
            catch (Exception) { tbNotes.Text = ""; }

            if (!tbAddSubTask.Enabled)
                tbAddSubTask.Enabled = true;

            SetSubTaskViewsOnScreen(currentTaskView.GetTaskID());
            currentTaskView.SetAttachmentsVisible();
            currentTaskView.ResizeAttachmentsFLP();
            // flpSubTasks.Refresh();
        }

        private void AddTaskViewToFlp(TaskView taskView)
        {
            int index = dataController.GetCorrectProject(taskView.GetParentProjectID()).GetTasks()[taskView.GetTaskID()].GetIndex();
            flpTasks.Controls.Add(taskView);
            flpTasks.Controls.SetChildIndex(taskView, 0);//add to top

            foreach (TaskView tv in flpTasks.Controls)
                dataController.GetCorrectProject(tv.GetParentProjectID()).GetTasks()[tv.GetTaskID()].SetIndex(flpTasks.Controls.GetChildIndex(tv));
        }
        #endregion

        #region SubTask

        private void ViewsController_NewSubTaskView(SubTaskDeletedEventArgs arg)
        {
            try
            {
                flpSubTasks.Controls.SetChildIndex(arg.STV, 0);//set to top
            }
            catch (Exception) { return; }

        }

        private void FlpSubTasks_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(SubTaskView)))
                return;

            Control droppedControl = (SubTaskView)e.Data.GetData(typeof(SubTaskView));
            if (droppedControl == null)
                return;

            Point clientPoint = flpSubTasks.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            Control targetControl = flpSubTasks.GetChildAtPoint(clientPoint);

            if (targetControl == null)
                return;

            int targetIndex = flpSubTasks.Controls.IndexOf(targetControl);
            int droppedIndex = flpSubTasks.Controls.IndexOf(droppedControl);

            flpSubTasks.Controls.SetChildIndex(droppedControl, targetIndex);

            // viewsController.Projects[((SubTaskView)droppedControl).GetParentProjectID()].SetIndex(flpSubTasks.Controls.GetChildIndex((SubTaskView)droppedControl));

            foreach (SubTaskView stv in flpSubTasks.Controls)
            {// set  indexes to all objects
                SubTask st = dataController.GetCorrectProject(stv.GetParentProjectID()).GetTasks()[stv.GetParentTaskID()].GetSubTasks()[stv.GetID()];
                st.SetIndex(flpSubTasks.Controls.GetChildIndex(stv));//Set new Index
                flpSubTasks.Controls.SetChildIndex(stv, st.GetIndex());//update flp
            }
        }

        private void FlpSubTasks_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        private void SetSubTaskViewsOnScreen(string taskViewID)
        {
            flpSubTasks.Controls.Clear();
            string id;
            foreach (var stv in dataController.SubTaskviews)
            {
                if (stv.Value.GetParentTaskID() == taskViewID)
                {
                    id = stv.Key;
                    flpSubTasks.Controls.Add(dataController.SubTaskviews[id]);
                    SubTask st = null;
                    if (dataController.GetCorrectProject(stv.Value.GetParentProjectID()).GetTasks().ContainsKey(stv.Value.GetParentTaskID()))
                        st = dataController.GetCorrectProject(stv.Value.GetParentProjectID()).GetTasks()[stv.Value.GetParentTaskID()].GetSubTasks()[stv.Value.GetID()];
                    else
                        st = dataController.GetCorrectProject(stv.Value.GetParentProjectID()).GetHiddenTasks()[stv.Value.GetParentTaskID()].GetSubTasks()[stv.Value.GetID()];

                    flpSubTasks.Controls.SetChildIndex(stv.Value, st.GetIndex());
                }
            }

        }

        private void AddSubTaskViewToFlp(SubTaskView subTask)
        {
            flpSubTasks.Controls.Add(subTask);
            flpSubTasks.Controls.SetChildIndex(subTask, 0);
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
            try // set indexes prior to saving
            {
                foreach (ProjectView pv in dataController.Projectviews.Values.ToList())
                {
                    int idx = dataController.GetCorrectProject(pv.ProjectID).GetIndex();
                    try
                    {
                        dataController.GetCorrectProject(pv.ProjectID).SetIndex(flpProjects.Controls.GetChildIndex(pv));
                    }
                    catch (Exception) { }

                }
            }
            catch (KeyNotFoundException) { }

            if (!dataController.SaveToFile())
                return;
            Application.Exit();
        }
        #endregion

        #region Events
        private void ViewsController_TaskDueDateChanged(DueDateChangedEventArgs args)
        {
            string projectID = args.TaskView.GetParentProjectID();
            string taskID = args.TaskView.GetTaskID();

            dataController.GetCorrectProject(projectID).GetTasks()[taskID].SetDueDate(args.TaskView.GetDueDate());
        }

        private void ViewsController_UpdateSubTaskViewCompleteCounter(UpdateSubTaskViewCompleteCounterEventArgs arg)
        {
            string projectID = arg.ParentProjectID;
            string taskID = arg.ParentTaskID;
            bool mode = false;
            Dictionary<string, SubTask> subtasks;
            try
            {
                subtasks = dataController.GetCorrectProject(projectID).GetTasks()[taskID].GetSubTasks();//get all Task subtasks
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

            dataController.GetCorrectProject(projectID).GetTasks()[taskID].SetCompleted(mode); // mark task as not completed
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
                    isOptionsCollapsed = true;
                }

            }


        }

        private void btnNewList_Click(object sender, EventArgs e)
        {
            currentProjectView = dataController.CreateNewProjectView(utils.GetUniqueID());
            AddProjectViewToFlp(currentProjectView);

            currentProjectView.GetCurrentCustomTextBox().Focus();
        }

        private void tbAddTask_KeyUp(object sender, KeyEventArgs e)
        {
            try
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
                            SubTaskView stv = dataController.CreateSubTaskView(currentProjectView.ProjectID, currentTaskView.GetTaskID(), utils.GetUniqueID(), taskName, DateTime.Now.ToString("dd/MM/yy HH:mm tt"));
                            currentSubTaskView = stv;
                            AddSubTaskViewToFlp(stv);
                            tb.Text = "";
                            break;
                        case "tbAddTask"://Completely New Task \ TaskView
                            TaskView tv = dataController.CreateNewTaskView(taskName, utils.GetUniqueID(), currentProjectView.ProjectID);
                            tv.Rename(taskName);
                            currentTaskView = tv;
                            AddTaskViewToFlp(tv);
                            tbAddSubTask.Enabled = true;
                            tb.Text = "";
                            break;
                        case "tbNotes":
                            //add note to the task object
                            //viewsController.Projects[currentProjectView.ProjectID].GetTasks()[currentTaskView.GetID()].Notes = tbNotes.Text;
                            //tbNotes.Hide();
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void Tv_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            c.DoDragDrop(c, DragDropEffects.Move);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!dataController.SaveToFile())
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
            //tb.Height = tb.MinimumSize.Height;
            if (!tb.Focused && string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = tb.Tag.ToString();
                return;
            }
        }

        private void TbAddTask_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null)
                return;
            tb.Height = 40;
            if (string.IsNullOrEmpty(tb.Text) || tb.Text == tb.Tag.ToString())
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
            Random rand = new Random();
            Color startcolor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            Color endcolor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));

            LinearGradientBrush brush = new LinearGradientBrush(pnlMain.ClientRectangle, startcolor, endcolor, 90f);
            Graphics g = pnlMain.CreateGraphics();
            g.FillRectangle(brush, pnlMain.ClientRectangle);



            foreach (Control control in pnlMain.Controls)
            {
                if (control is Panel || control is FlowLayoutPanel)
                {
                    g = control.CreateGraphics();
                    g.FillRectangle(brush, control.ClientRectangle);
                }
            }
            //g = panel2.CreateGraphics();
            //g.FillRectangle(brush, panel2.ClientRectangle);
            //g = flpTasks.CreateGraphics();
            //g.FillRectangle(brush, flpTasks.ClientRectangle);
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

        private void btnAddNotes_Click(object sender, EventArgs e)
        {
            if (!tbNotes.Visible)
                tbNotes.Visible = true;
        }
        #endregion

        #region ScreenBehaviour
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnSetBackGroundImage_Click_1(object sender, EventArgs e)
        {
            Random rand = new Random();
            Color startcolor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            Color endcolor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));

            LinearGradientBrush brush = new LinearGradientBrush(pnlMain.ClientRectangle, startcolor, endcolor, 90f);
            Graphics g = pnlMain.CreateGraphics();
            g.FillRectangle(brush, pnlMain.ClientRectangle);

            foreach (Control control in pnlMain.Controls)
            {
                if (control is Panel || control is FlowLayoutPanel)
                {
                    g = control.CreateGraphics();
                    g.FillRectangle(brush, control.ClientRectangle);
                }
            }

        }

        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            string filepath = GetFilefromDialog();
            if (string.IsNullOrWhiteSpace(filepath))
                return;
            string taskID = currentTaskView.GetTaskID();
            string projectID = currentTaskView.GetParentProjectID();
            Attachment attachment = new Attachment()
            {
                AttachmentID = utils.GetUniqueID(),
                ParentTaskID = taskID,
                ParentProjectID = projectID,
                FilePath = filepath,
                FileName = Path.GetFileNameWithoutExtension(filepath),
                FileType = Path.GetExtension(filepath),
                AddedOn = DateTime.Now.ToString("dd/MM/yy"),
            };
            dataController.GetCorrectProject(projectID).GetTasks()[taskID].AddAttachment(attachment);

            currentTaskView.SetAttachmentsVisible();
            currentTaskView.ResizeAttachmentsFLP();
            currentTaskView.Refresh();
        }

        private string GetFilefromDialog()
        {
            string fileName;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "c:\\";
                //ofd.Filter = "All Files (*.*|*.*)";
                //ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                }
                else fileName = null;
            }

            return fileName;

        }

        private void tbAttachemtns_TextChanged(object sender, EventArgs e)
        {
            return;
        }

        private void tbNotes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (currentProjectView != null && currentTaskView != null)
                    dataController.GetCorrectProject(currentProjectView.ProjectID).GetTasks()[currentTaskView.GetTaskID()].Notes = tbNotes.Text;
            }
            catch (NullReferenceException ex)
            {
                return;
            }
            catch (KeyNotFoundException) { return; }
        }

        private void btnShowHiddenProjects_Click(object sender, EventArgs e)
        {
            frmHiddenProjects.Show();
        }

        private void btnShowHiddenTasks_Click(object sender, EventArgs e)
        {
            frmHiddenTasks.Show();
        }

        /// <summary>
        /// Set current selected project notes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbProjectNotes_TextChanged(object sender, EventArgs e)
        {
            string projectNotes = tbProjectNotes.Text;
            if (string.IsNullOrWhiteSpace(projectNotes))
                projectNotes = "";

            dataController.GetCorrectProject(currentProjectView.GetProjectID()).SetProjectNotes(projectNotes);
        }

        private void comboBoxProjectPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetProjectViewsOnScreen();

            //SetProjectTasksViewOnScreen(new SetProjectViewEventArgs(null), comboBoxProjectPriority.SelectedIndex);
        }

        private void comboBoxTaskPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentProjectView != null)
                SetProjectTasksViewOnScreen(new SetProjectViewEventArgs(currentProjectView));
        }

        private void tbProjectNotes_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null)
                return;

            if (tb.Focused && tb.Text == tb.Tag.ToString())
                tb.Clear();
        }

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
