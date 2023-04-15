using DoYourTasks.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using LinearGradientBrush = System.Drawing.Drawing2D.LinearGradientBrush;
using DoYourTasks.Properties;
using System.Collections.Concurrent;

namespace DoYourTasks
{
    public partial class frmMain : Form
    {
        #region CustomEvents
        private delegate void ChangeThemeEventHandler(ChangeThemeEventArgs args);
        private class ChangeThemeEventArgs : EventArgs
        {
            public bool Mode { get; set; }
            public ChangeThemeEventArgs(bool mode)
            {
                Mode = mode;
            }
        }

        private event ChangeThemeEventHandler ChangeTheme;

        #endregion CustomEvents

        #region Fields

        #region Views
        ProjectView currentProjectView;
        TaskView currentTaskView;
        SubTaskView currentSubTaskView;

        frmHiddenItems frmHiddenProjects = new frmHiddenItems("Hidden Projects");
        frmHiddenItems frmHiddenTasks = new frmHiddenItems("Hidden Tasks");

        #endregion

        #region Controllers
        private DataController dataController = new DataController();
        #endregion

        #region Utilities
        Utils utils = new Utils();
        Serializer serializer = new Serializer();
        #endregion
        Theme currentTheme = null;
        int lx, ly, sw, sh;
        int notificationCounter;
        bool isOptionsCollapsed = true;
        bool toBackup = false;
        Timer optionsMenuTimer;
        Timer AutoSaveTimer;
        Timer pnlSaveTimer;
        Timer DueDateCheckTimer;
        Timer ImageAnimationTimer;
        #endregion

        #region Constructors
        public frmMain()
        {
            InitializeComponent();
            CenterToScreen();
            DoubleBuffered = true;

            ChangeTheme += FrmMain_ChangeTheme;

            pnlSaveTimer = new Timer() { Interval = 2000 };
            ImageAnimationTimer = new Timer() { Interval = 4000 };
            ImageAnimationTimer.Tick += ImageAnimationTimer_Tick;
            DueDateCheckTimer = new Timer() { Interval = 1000 };
            DueDateCheckTimer.Tick += DueDateCheckTimer_Tick;
            DueDateCheckTimer.Start();

            AutoSaveTimer = new Timer() { Interval = 60000 };//60 seconds
            AutoSaveTimer.Tick += AutoSaveTimer_Tick;
            AutoSaveTimer.Start();

            pnlSaveTimer.Tick += PnlSaveTimer_Tick;

            tbAddTask.GotFocus += TbAddTask_GotFocus;
            tbAddTask.LostFocus += TbAddTask_LostFocus;

            tbAddSubTask.GotFocus += TbAddTask_GotFocus;
            tbAddSubTask.LostFocus += TbAddTask_LostFocus;

            tbNotes.GotFocus += TbAddTask_GotFocus;
            tbNotes.LostFocus += TbAddTask_LostFocus;

            DataControllerEventSubscriber();

            CheckControlsCount(flpProjects, tbAddTask);
            CheckControlsCount(flpTasks, tbAddSubTask);


            string path = serializer.GetDBPath();
            lblProjName.Text = String.Empty;
            btnSave.Enabled = false;


            tlpTaskPrioritiesStats.AutoSize = true;

            flpProjects.DragOver += FlpProjects_DragOver;
            flpProjects.DragDrop += FlpProjects_DragDrop;

            flpTasks.DragOver += FlpTasks_DragOver;
            flpTasks.DragDrop += FlpTasks_DragDrop;

            flpSubTasks.DragOver += FlpSubTasks_DragOver;
            flpSubTasks.DragDrop += FlpSubTasks_DragDrop;

            AddPriorityItemsToComboBox(comboBoxFilterProjectPriority);
            comboBoxFilterProjectPriority.Items.Add("All Projects");
            comboBoxFilterProjectPriority.SelectedIndex = comboBoxFilterProjectPriority.Items.Count - 1;

            AddPriorityItemsToComboBox(comboBoxFilterTaskPriority);
            comboBoxFilterTaskPriority.Items.Add("All Tasks");
            comboBoxFilterTaskPriority.SelectedIndex = comboBoxFilterTaskPriority.Items.Count - 1;

            AddPriorityItemsToComboBox(comboBoxChangePriority);
            comboBoxChangePriority.Text = "Set Project Priority";

            if (File.Exists(path))
                LoadFromDB(path);

            foreach (Project project in dataController.GetHiddenProjects().Values.ToList())
                frmHiddenProjects.AddControl(dataController.Projectviews[project.GetProjectID()]);

            //utils.RoundCorners(tbAddSubTask, null);
            //utils.RoundCorners(tbAddTask, null);
            //utils.RoundCorners(tbNotes, null);
            //utils.RoundCorners(pnlStats, null);
            //utils.RoundCorners(tbCommitMsg, null);
            //utils.RoundCorners(tbProjectNotes, null);

            BackupDB();

            currentTheme = dataController.GetTheme();

            FrmMain_ChangeTheme(new ChangeThemeEventArgs(utils.GetThemeMode(currentTheme)));
        }

        private void ImageAnimationTimer_Tick(object sender, EventArgs e)
        {
            ImageAnimationTimer.Stop();
        }

        /// <summary>
        /// This method will reset any given picturebox
        /// </summary>
        /// <param name="pb"></param>
        private void ResetPictureBox(PictureBox pb)
        {
            System.Threading.Tasks.Task task = new System.Threading.Tasks.Task(() =>
            {
                while (ImageAnimationTimer.Enabled) { }
                if (pb.InvokeRequired)
                {
                    pb.Invoke(new Action(() =>
                    {
                        pb.Enabled = false;
                        pb.Image = pb.Image;
                    }));
                }
                else
                {
                    pb.Enabled = false;
                    pb.Image = pb.Image;
                }
            });
            ImageAnimationTimer.Start();
            task.Start();
        }


        private void DueDateCheckTimer_Tick(object sender, EventArgs e)
        {
            if (dataController == null)
                return;
            foreach (Project project in dataController.Projects.Values.ToList())
            {
                foreach (Task task in project.GetAllTasks().Values.ToList())
                {
                    string dueDateString = task.GetDueDate();
                    DateTime dueDate;
                    bool ConvertSuccess = DateTime.TryParse(dueDateString, out dueDate);
                    if (dueDate == null || !ConvertSuccess)
                        continue;

                    //if (dataController.Projects[task.GetParentProjectID()].GetAllTasks()[task.GetTaskID()].GetIsCompleted())
                    //{
                    //    dataController.Taskviews[task.GetTaskID()].SetPBStatus(Utils.NotificationType.Success);
                    //    continue;
                    //}

                    DateTime tomorrow = DateTime.Today.AddDays(1);
                    DateTime nextWeek = DateTime.Today.AddDays(7);
                    string timeFrame = "";
                    if (dueDate.Date == tomorrow.Date)
                        timeFrame = "Tomorrow";
                    if (dueDate.AddDays(7) == nextWeek)
                        timeFrame = "Next Week";



                    if ((timeFrame != "" && !dataController.Taskviews[task.GetTaskID()].GetDidNotify()))
                    {

                        Utils.NotificationType type = Utils.NotificationType.Warning;
                        dataController.Taskviews[task.GetTaskID()].SetPBStatus(type);
                        SendNotification(new SendNotificationEventArgs("", $"Due Date is Arriving {timeFrame}\nFor Task: {task.GetTaskName()} In Project: {project.GetProjectName()}", type));
                    }

                }
            }
        }

        private void FrmMain_ChangeTheme(ChangeThemeEventArgs args)
        {
            if (args.Mode)
            {
                currentTheme = utils.LightTheme;
                pbNotification.Image = Resources._46_notification_bell_outlineWhite;
                pbSaveAnimation.Image = Resources._18_autorenew_outline;
            }
            else
            {
                currentTheme = utils.DarkTheme;
                pbNotification.Image = Resources._46_notification_bell_outline;
                pbSaveAnimation.Image = Resources._18_autorenew_solid;
            }

            TogglebtnTheme.Checked = args.Mode;

            BackColor = currentTheme.SecondBackColor;
            ForeColor = currentTheme.ForeColor;

            pnlNotifications.BackColor = BackColor;
            pnlNotifications.ForeColor = BackColor;

            foreach (NotificationView nv in flpNotifications.Controls)
                nv.ForeColor = ForeColor;

            dataController.CurrentTheme = currentTheme;

            if(dataController.settings == null)
                dataController.settings = new Settings();

            dataController.settings.SavedTheme = currentTheme;


            //pnlTop.BackColor = BackColor;
            //pnlTop.ForeColor = ForeColor;
            pnlMainLeft.BackColor = currentTheme.BackColor;

            flpProjects.BackColor = BackColor;
            pnlMain.ForeColor = ForeColor;
            pnlMain.BackColor = BackColor;

            pnlOptions.BackColor = BackColor;
            pnlOptions.ForeColor = ForeColor;

            tbAddTask.BackColor = BackColor;
            tbAddTask.ForeColor = ForeColor;

            tbAddSubTask.BackColor = BackColor;
            tbAddSubTask.ForeColor = ForeColor;

            tbNotes.BackColor = BackColor;
            tbNotes.ForeColor = ForeColor;

            lblNotificationCounter.ForeColor = BackColor;

            btnAddProjectAttachment.ForeColor = ForeColor;
            btnHideProject.ForeColor = ForeColor;

            lblUrgentTaskCount.ForeColor = ForeColor;
            lblHighTaskCount.ForeColor = ForeColor;
            lblLowTaskCount.ForeColor = ForeColor;
            lblVeryLowTaskCount.ForeColor = ForeColor;
            lblWaitingTaskCount.ForeColor = ForeColor;
            lblMediumTaskCount.ForeColor = ForeColor;
            lblDoneTaskCount.ForeColor = ForeColor;
            lblDontProceedTaskCount.ForeColor = ForeColor;

            foreach (ProjectView pv in flpProjects.Controls)
            {
                pv.SetTheme(currentTheme);
                pv.SetImages(utils.GetThemeMode(currentTheme));
            }
            foreach (UCAttachmentView ucav in flpProjectAttachments.Controls)
                ucav.SetTheme(currentTheme);
            foreach (TaskView tv in flpTasks.Controls)
                tv.SetTheme(currentTheme);
            foreach (SubTaskView stv in flpSubTasks.Controls)
                stv.SetTheme(currentTheme);
        }

        private void DataControllerEventSubscriber()
        {

            dataController.SetProjectView += LoadProjectView;
            dataController.ProjectViewMouseDown += ProjectView_MouseDown;
            dataController.ProjectViewDeleted += DeleteProject;
            dataController.UpdateSubTaskViewCompleteCounter += DataController_UpdateSubTaskViewCompleteCounter;
            dataController.UpdateTaskView += UpdateCurrentTaskView;
            dataController.TaskRenamed += DataController_TaskRenamed;
            dataController.SubTaskDeleted += DataController_SubTaskDeleted;
            dataController.TaskCompleted += DataController_TaskCompleted;
            dataController.PriorityChaned += DataController_PriorityChaned;
            dataController.TaskDeleted += DataController_TaskDeleted;
            dataController.NewSubTaskView += DataController_NewSubTaskView;
            dataController.HideItem += DataController_LoadViewsToScreen;
            dataController.AddNewProjectAttachment += AddProjectAttachment;
            dataController.AddTaskAttachment += btnAddAttachment_Click;
            dataController.SendNotification += SendNotification;
        }

        private void SendNotification(SendNotificationEventArgs args)
        {
            AddNotification(args.Title, args.Message, args.NotificationType);
        }

        private void AddPriorityItemsToComboBox(ComboBox comboBox)
        {
            comboBox.Items.Add(PriorityCodes.VeryLow.ToString());
            comboBox.Items.Add(PriorityCodes.Low.ToString());
            comboBox.Items.Add(PriorityCodes.Medium.ToString());
            comboBox.Items.Add(PriorityCodes.High.ToString());
            comboBox.Items.Add(PriorityCodes.Urgent.ToString());
            comboBox.Items.Add(PriorityCodes.OnHold.ToString());
            comboBox.Items.Add(PriorityCodes.Waiting.ToString());
            comboBox.Items.Add(PriorityCodes.Done.ToString());

            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
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
                            Project p = null;
                            dataController.GetHiddenProjects().TryAdd(projectID, project);
                            dataController.GetProjects().TryRemove(projectID, out p);
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
                            Project p = null;
                            dataController.GetProjects().TryAdd(project.GetProjectID(), project);
                            dataController.GetHiddenProjects().TryRemove(project.GetProjectID(), out p);
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
                    projectID = tv.GetParentProjectID();
                    string taskID = tv.GetTaskID();
                    Task task = dataController.GetCorrectProject(projectID).GetAllTasks()[taskID];
                    Task t = null;
                    if (tv.GetIsHidden())
                    {
                        frmHiddenTasks.AddControl(control);
                        flpTasks.Controls.Remove(control);
                        task.SetIsHidden(true);

                        dataController.GetCorrectProject(task.GetParentProjectID()).AddHiddenTask(task);
                        dataController.GetCorrectProject(task.GetParentProjectID()).GetTasks().TryRemove(task.GetTaskID(), out t);
                    }
                    else
                    {
                        flpTasks.Controls.Add(control);
                        frmHiddenTasks.RemoveControl(control);
                        task.SetIsHidden(false);

                        dataController.GetCorrectProject(task.GetParentProjectID()).AddTask(task);
                        dataController.GetCorrectProject(task.GetParentProjectID()).GetHiddenTasks().TryRemove(task.GetTaskID(), out t);

                    }

                    if (flpTasks.Controls.Contains(tv))
                        flpTasks.Controls.SetChildIndex(tv, dataController.GetCorrectProject(tv.GetParentProjectID()).GetTasks()[tv.GetTaskID()].GetIndex());

                    break;
            }
        }

        #endregion

        #region DataController
        private void DataController_TaskDeleted(TaskModifiedEventArgs args)
        {
            TaskView tv = args.TV;
            if (currentProjectView != null)
            {
                ConcurrentDictionary<string, Task> taskLst = dataController.GetCorrectProject(currentProjectView.ProjectID).GetAllTasks();
                UpdatePriorityLabels(taskLst);
            }
            CalculateCompletedTasks();
        }

        private void DataController_PriorityChaned(PriorityChangedEventArgs args)
        {
            string projectID = args.TaskView.GetParentProjectID();
            if (currentProjectView != null)
            {
                ConcurrentDictionary<string, Task> taskLst = dataController.GetCorrectProject(currentProjectView.ProjectID).GetAllTasks();
                UpdatePriorityLabels(taskLst);
            }
        }

        private void DataController_TaskCompleted(TaskCompletedEventArgs args)
        {
            Task task = null;
            if (args == null)
                return;
            TaskView taskView = args.TV;
            Project project = dataController.GetCorrectProject(taskView.GetParentProjectID());
            string taskID = taskView.GetTaskID();

            if (project.GetTasks().ContainsKey(taskID))
                task = project.GetTasks()[taskID];
            else if (project.GetHiddenTasks().ContainsKey(taskID))
                task = project.GetHiddenTasks()[taskID];
            else
                return;

            if (!flpTasks.Controls.Contains(taskView))
                return;

            if (task.GetIsCompleted())
            {
                flpTasks.Controls.SetChildIndex(taskView, flpTasks.Controls.Count - 1);//move to buttom
                task.SetIndex(flpTasks.Controls.GetChildIndex(taskView));
            }
            else
            {
                flpTasks.Controls.SetChildIndex(taskView, task.GetIndex());
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
            ConcurrentDictionary<string, Task> taskLst = dataController.GetCorrectProject(currentProjectView.ProjectID).GetAllTasks();
            UpdatePriorityLabels(taskLst);

            //low = 0;
            //med = 0;
            //high = 0;
        }

        private void UpdatePriorityLabels(ConcurrentDictionary<string, Task> taskLst)
        {
            // Initialize counters to zero
            int[] counters = new int[8];

            // Count tasks by priority
            foreach (Task task in taskLst.Values)
            {
                int priority = task.GetPriority();
                if (priority >= 0 && priority < counters.Length)
                    counters[priority]++;
            }

            // Update UI counters
            for (int counter = 0; counter < counters.Length; counter++)
                SetCounters(counter, counters[counter]);
        }

        public void SetCounters(int lblNum, int num)
        {
            Label[] labels = { lblVeryLowTaskCount, lblLowTaskCount, lblMediumTaskCount, lblHighTaskCount,
                       lblUrgentTaskCount, lblDontProceedTaskCount, lblWaitingTaskCount, lblDoneTaskCount };

            if (lblNum >= 0 && lblNum < labels.Length)
                labels[lblNum].Text = num.ToString();
        }


        private void btnProjPriority_Click(object sender, EventArgs e)
        {
            int priority = 0;

            switch (currentProjectView.GetProjectPrioritySTR())
            {
                case "On Hold":
                    priority = (int)PriorityCodes.VeryLow;
                    break;
                case "Very Low":
                    priority = (int)PriorityCodes.Low;
                    break;
                case "Low":
                    priority = (int)PriorityCodes.Medium;
                    break;
                case "Medium":
                    priority = (int)PriorityCodes.High;
                    break;
                case "High":
                    priority = (int)PriorityCodes.Urgent;
                    break;
                case "Urgent":
                    priority = (int)PriorityCodes.Waiting;
                    break;
                case "Waiting":
                    priority = (int)PriorityCodes.Done;
                    break;
                case "Done":
                    priority = (int)PriorityCodes.OnHold;
                    break;
            }
            dataController.GetCorrectProject(currentProjectView.GetProjectID()).SetPriority(priority);
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

        private void DataController_SubTaskDeleted(SubTaskDeletedEventArgs arg)
        {
            DataController_UpdateSubTaskViewCompleteCounter(new UpdateSubTaskViewCompleteCounterEventArgs(arg.STV.GetParentProjectID(), arg.STV.GetParentTaskID()));
        }

        private void DataController_TaskRenamed(TaskRenamedEventArgs args)
        {
            //tbAddTask.Focus();
            tbAddTask.Select();
        }
        #endregion

        #region DataManagement
        private void LoadFromDB(string path)
        {
            dataController.LoadFromDB(path);

            if (dataController.settings?.SavedTheme != null)
                currentTheme = dataController.settings.SavedTheme;

            SetProjectViewsOnScreen(true);

            foreach (ProjectView pv in dataController.Projectviews.Values)
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
                catch
                {
                    continue;
                }

                UpdatePriorityLabels(dataController.GetCorrectProject(projectID).GetAllTasks());
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

        private void FlpProjects_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
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

        private void FlpProjects_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
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

            frmHiddenTasks.ClearItems();

            //ResetIndicators();
        }

        private void CalculateCompletedTasks()
        {
            int completedTasks = 0;
            if (currentProjectView == null)
                return;
            List<Task> tasks = dataController.Projects[currentProjectView.GetProjectID()].GetTasks().Values.ToList();
            foreach (var task in tasks)
                if (task.IsCompleted)
                    completedTasks++;
            currentProjectView.SetTasksLabel($"Tasks: {completedTasks}/{tasks.Count}");
        }

        private void SetHideShowUI(bool mode)
        {
            flpTaskOptions.Enabled = mode;
            tbAddSubTask.Enabled = mode;
            tbAddTask.Enabled = mode;
            tbProjectNotes.Enabled = mode;
            tbCommitMsg.Enabled = mode;
        }

        private void LoadTaskViews(Project project)
        {
            string projectID = project.GetProjectID();
            TaskView taskView = null;
            foreach (var tv in dataController.Taskviews)
            {
                taskView = tv.Value;
                taskView.SetTheme(currentTheme);
                taskView.Width = flpTasks.Width - 6;

                string parentProjectID = taskView.GetParentProjectID();
                if (parentProjectID != projectID)
                    continue;

                List<Task> hiddenTasks = project.GetHiddenTasks().Values.ToList();
                foreach (Task hiddenTv in hiddenTasks)
                    frmHiddenTasks.AddControl(dataController.Taskviews[hiddenTv.GetTaskID()]);

                Task task = project.GetTasks()[taskView.GetTaskID()];
                int taskPriority = task.GetPriority();

                if (comboBoxFilterTaskPriority.SelectedIndex == taskPriority)
                    flpTasks.Controls.Add(taskView);
                else
                    flpTasks.Controls.Remove(taskView);

                //add all
                if (comboBoxFilterTaskPriority.SelectedIndex == comboBoxFilterProjectPriority.Items.Count - 1)
                    flpTasks.Controls.Add(taskView);

                taskView.SetTheme(dataController.settings.SavedTheme);
            }


            /*Set Tasks Location on screen (control flp child index)*/
            foreach (var tv in dataController.Taskviews)
            {
                taskView = tv.Value;
                string taskID = taskView.GetTaskID();
                if (taskView.GetParentProjectID() != currentProjectView.ProjectID)
                    continue;

                if (taskView.Parent == null || taskView.Parent.Name != flpTasks.Name)
                    continue;

                int index = dataController.GetCorrectProject(projectID).GetTasks()[taskID].GetIndex();

                //Move completed tasks to bottom
                if (taskView.GetCheckedState())
                    index = flpTasks.Controls.Count - 1;

                flpTasks.Controls.SetChildIndex(taskView, index);
            }
        }

        private void UpdateProjectAttachments(Project project)
        {
            foreach (Attachment attachment in project.GetAttachments())
            {
                UCAttachmentView attachmentView = new UCAttachmentView(attachment);
                attachmentView.AttachemntRemoved += ProjectAttachemntRemoved;
                attachmentView.SetTheme(dataController.CurrentTheme);
                flpProjectAttachments.Controls.Add(attachmentView);
            }
        }

        private void LoadProjectView(SetProjectViewEventArgs arg)
        {
            ResetScreen();

            string projectID = arg.PV.ProjectID;
            Project project = dataController.GetCorrectProject(projectID);

            SetCurrentProjectView(new SetProjectViewEventArgs(arg.PV));
            ResetIndicators();
            currentProjectView.SetIndicator(true);
            CalculateCompletedTasks();

            lblCreationDate.Text = $"Project Created at: {project.GetDateCreated().ToString("dd/MM/yy")}";
            tbProjectNotes.Text = project.GetProjectNotes();

            UpdatePriorityLabels(project.GetTasks());

            SetHideShowUI(true);
            btnHideProject.Text = "Hide Project";

            if (currentProjectView.GetIsHidden())
            {
                SetHideShowUI(false);
                btnHideProject.Text = "Show Project";
            }

            LoadTaskViews(project);

            UpdateProjectAttachments(project);

            DataController_TaskCompleted(null);
        }

        private void ProjectAttachemntRemoved(AttachmentRemovedEventArgs arg)
        {
            dataController.GetCorrectProject(currentProjectView.GetProjectID()).GetAttachments().Remove(arg.Attachment.Attachment);
        }

        private void AddProjectViewToFlp(ProjectView projectView, bool isLoading = false)
        {
            //ResetIndicators();
            ResetScreen();

            DataController_LoadViewsToScreen(new HideItemEventArgs(projectView));

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
                Project project = dataController.GetCorrectProject(pv.GetProjectID());
                if(project == null)
                    continue;
                string projectID = project.GetProjectID();
                int projectPriority = project.GetPriority();

                if (comboBoxFilterProjectPriority.SelectedIndex == comboBoxFilterProjectPriority.Items.Count - 1)
                {//add all
                    AddProjectViewToFlp(pv, isLoading);
                    addAll = true;
                }
                if (addAll)
                    continue;

                if (comboBoxFilterProjectPriority.SelectedIndex - 1 == projectPriority)
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
        private void FlpTasks_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void FlpTasks_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
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

        private void ResizeTaskView(TaskView taskView)
        {
            taskView.Size = taskView.MinimumSize;

            int res;
            int.TryParse(currentTaskView.Tag.ToString(), out res);

            //Resize until reaching the median height (res)
            while (taskView.Size.Height < res)//currentTaskView.MaximumSize.Height)
            {
                taskView.Height += 35;
                taskView.Refresh();
            }

            //keep resizing for each attachment, until reaching the maximum height
            for (int i = 0; i < taskView.GetAttachmentsCount(); i++)
            {
                taskView.Height += 90;
                taskView.Refresh();
                if (taskView.Size.Height >= taskView.MaximumSize.Height) {
                    taskView.Size = taskView.MaximumSize;
                    break;
                }
            }

            taskView.Refresh();
            flpTasks.Refresh();
        }

        private void UpdateCurrentTaskView(UpdateCurrentTaskViewEventArgs arg)
        {
            if (currentTaskView != null)
            {
                currentTaskView.Size = currentTaskView.MinimumSize;
                currentTaskView.SetTheme(dataController.settings.SavedTheme);
            }

            currentTaskView = arg.TaskView;
            ResizeTaskView(currentTaskView);

            try
            {
                string projectID = currentTaskView.GetParentProjectID();
                string taskID = currentTaskView.GetTaskID();

                // Use data controller to get task information and attachments
                var project = dataController.GetCorrectProject(projectID);
                var task = project.Tasks.TryGetValue(taskID, out var foundTask) ? foundTask : null;

                if (task != null)
                {
                    // Update task notes
                    var notes = task.GetNotes();
                    if (notes != null)
                    {
                        tbNotes.Text = notes;
                        tbNotes.Visible = true;
                    }
                    else
                    {
                        tbNotes.Text = (string)tbNotes.Tag;
                    }

                    // Update commit message with subtasks
                    tbCommitMsg.Text = $"{DateTime.Now:dd/MM/yyyy HH:mm tt}";
                    foreach (var subtask in task.GetSubTasks())
                    {
                        tbCommitMsg.Text += $"\n - {subtask.Value.GetSubTaskName()}";
                    }

                    // Set attachments for the current task view
                    var attachments = task.GetAttachements();
                    if (attachments.Count > 0)
                    {
                        currentTaskView.LoadTaskViewAttachments(attachments);
                    }
                }
                else
                {
                    // Task not found, clear task notes and commit message
                    tbNotes.Text = "";
                    tbCommitMsg.Text = $"{DateTime.Now:dd/MM/yyyy HH:mm tt}";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions thrown when getting task information
                tbNotes.Text = "";
                tbCommitMsg.Text = $"{DateTime.Now:dd/MM/yyyy HH:mm tt}";
                // Log the exception (or do something appropriate for your use case)
                Console.WriteLine($"Error getting task information: {ex.Message}");
            }

            tbCommitMsg.Text += "\n";

            if (!tbAddSubTask.Enabled)
                tbAddSubTask.Enabled = true;
            if (currentTaskView != null)
                tbNotes.Visible = true;
            else
                tbNotes.Visible = false;

            CalculateCompletedTasks();

            SetSubTaskViewsOnScreen(currentTaskView.GetTaskID());
            currentTaskView.SetAttachmentsCountLbl();
            currentTaskView.ResizeAttachmentsFLP();

            if (currentProjectView != null)
            {
                // Use data controller to get all tasks for the current project
                var project = dataController.GetCorrectProject(currentProjectView.ProjectID);
                var taskLst = project.GetAllTasks();
                UpdatePriorityLabels(taskLst);
            }
        }

        private void AddTaskViewToFlp(TaskView taskView)
        {
            flpTasks.Controls.Add(taskView);
            flpTasks.Controls.SetChildIndex(taskView, 0); // add to top

            foreach (TaskView tv in flpTasks.Controls)
            {
                string projectID = tv.GetParentProjectID();
                string taskID = tv.GetTaskID();
                int index = flpTasks.Controls.GetChildIndex(tv);
                dataController.GetCorrectProject(projectID).GetAllTasks()[taskID].SetIndex(index);
            }
        }

        #endregion

        #region SubTask

        private void DataController_NewSubTaskView(SubTaskDeletedEventArgs arg)
        {
            try
            {
                flpSubTasks.Controls.SetChildIndex(arg.STV, 0);//set to top
            }
            catch (Exception) { return; }

        }

        private void FlpSubTasks_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
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

            foreach (SubTaskView stv in flpSubTasks.Controls)
            {// set  indexes to all objects
                SubTask st = dataController.GetSubTask(stv.GetParentProjectID(), stv.GetParentTaskID(), stv.GetSubTaskID());
                st.SetIndex(flpSubTasks.Controls.GetChildIndex(stv));//Set new Index
                flpSubTasks.Controls.SetChildIndex(stv, st.GetIndex());//update flp
            }
        }
        private void FlpSubTasks_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        private void SetSubTaskViewsOnScreen(string taskViewID)
        {
            flpSubTasks.Controls.Clear();
            string id,projectID,taskID,subtaskID;
            foreach (var stv in dataController.SubTaskviews)
            {
                stv.Value.SetTheme(currentTheme);
                projectID = stv.Value.GetParentProjectID();
                taskID = stv.Value.GetParentTaskID();
                subtaskID = stv.Value.GetSubTaskID();
                if (stv.Value.GetParentTaskID() == taskViewID)
                {
                    id = stv.Key;
                    flpSubTasks.Controls.Add(dataController.SubTaskviews[id]);
                    SubTask st = null;
                    if (dataController.GetCorrectProject(stv.Value.GetParentProjectID()).GetTasks().ContainsKey(taskID))
                        st = dataController.GetCorrectProject(projectID).GetTasks()[taskID].GetSubTasks()[subtaskID];
                    else
                        st = dataController.GetCorrectProject(projectID).GetHiddenTasks()[taskID].GetSubTasks()[subtaskID];

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


        public void SetTBPlaceHolder(SetPlaceHolderEventArgs arg)
        {
            TextBox tb = arg.TB;
            if (!tb.Focused && string.IsNullOrWhiteSpace(tb.Text))
                tb.Text = (string)tb.Tag;
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
            if (pnlTasksHeader.Height < pnlTasksHeader.MaximumSize.Height)
                while (pnlTasksHeader.Height < pnlTasksHeader.MaximumSize.Height)
                    pnlTasksHeader.Height += 55;
            else
                while (pnlTasksHeader.Height > pnlTasksHeader.MinimumSize.Height)
                    pnlTasksHeader.Height -= 55;


        }

        private void Exit()
        {
            try // set indexes prior to saving
            {
                foreach (ProjectView pv in dataController.Projectviews.Values.ToList())
                {
                    try
                    {
                        Project project = dataController.GetCorrectProject(pv.ProjectID);
                        if (project == null)
                            continue;
                        int idx = project.GetIndex();
                        dataController.GetCorrectProject(pv.ProjectID).SetIndex(flpProjects.Controls.GetChildIndex(pv));
                    }
                    catch (Exception) { }
                }
            }
            catch (KeyNotFoundException) { }

            if (!dataController.SaveToFile())
                return;
            //Application.Exit();
            Environment.Exit(0);
        }
        #endregion

        #region Events
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

        private void btnAddAttachment_Click(TaskModifiedEventArgs args)
        {
            string filepath = GetFilefromDialog();
            if (string.IsNullOrWhiteSpace(filepath))
                return;
            string taskID = args.TV.GetTaskID();
            string projectID = args.TV.GetParentProjectID();
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
            UpdateCurrentTaskView(new UpdateCurrentTaskViewEventArgs(currentTaskView));
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
            //if (string.IsNullOrWhiteSpace(projectNotes))
            //    projectNotes = "";
            if (currentProjectView == null)
                return;
            dataController.GetCorrectProject(currentProjectView.GetProjectID()).SetProjectNotes(projectNotes);
        }

        private void comboBoxProjectPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            int priority = 0;

            if (comboBoxChangePriority.SelectedItem == null)
                return;

            switch (comboBoxChangePriority.SelectedItem.ToString())
            {
                case "On Hold":
                    priority = (int)PriorityCodes.OnHold;
                    break;
                case "Very Low":
                    priority = (int)PriorityCodes.VeryLow;
                    break;
                case "Low":
                    priority = (int)PriorityCodes.Low;
                    break;
                case "Medium":
                    priority = (int)PriorityCodes.Medium;
                    break;
                case "High":
                    priority = (int)PriorityCodes.High;
                    break;
                case "Urgent":
                    priority = (int)PriorityCodes.Urgent;
                    break;
                case "Waiting":
                    priority = (int)PriorityCodes.Waiting;
                    break;
                case "Done":
                    priority = (int)PriorityCodes.Done;
                    break;
            }
            currentProjectView.SetPriority(priority);

            //SetProjectTasksViewOnScreen(new SetProjectViewEventArgs(null), comboBoxProjectPriority.SelectedIndex);
        }

        private void comboBoxTaskPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentProjectView != null)
                LoadProjectView(new SetProjectViewEventArgs(currentProjectView));
        }

        private void tbProjectNotes_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb == null)
                return;

            if (tb.Focused && tb.Text == tb.Tag.ToString())
                tb.Clear();
        }

        private void btnHideProject_Click(object sender, EventArgs e)
        {
            currentProjectView.btnHideProject_Click();
        }

        private void btnAddProjectAttachment_Click(object sender, EventArgs e)
        {
            currentProjectView.btnAddProjectAttachment_Click();
        }

        private void comboBoxFilterProjectPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

            ResetScreen();
            flpProjects.Controls.Clear();
            string selectedItem = comboBoxFilterProjectPriority.SelectedItem.ToString();

            foreach (ProjectView pv in dataController.Projectviews.Values.ToList())
            {
                //if (pv.GetProjectID() != currentProjectView.GetProjectID())
                //    continue;

                string prioritySTR = pv.GetProjectPrioritySTR();

                if (prioritySTR == selectedItem && !pv.GetIsHidden())
                    flpProjects.Controls.Add(pv);

            }

            if (selectedItem == "All Projects")
                SetProjectViewsOnScreen();
        }

        private void DataController_UpdateSubTaskViewCompleteCounter(UpdateSubTaskViewCompleteCounterEventArgs arg)
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

            if (totalSubtasks == completed)
                mode = true;
            else
                mode = false;

            currentTaskView.UpdateCompletedSubTasks(completed, totalSubtasks);
            if (totalSubtasks > 0)
            {
                dataController.GetCorrectProject(projectID).GetTasks()[taskID].SetCompleted(mode); // mark task as not completed
                currentTaskView.SetCompleted(mode);// display in the task view
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
                            stv.SetTheme(currentTheme);
                            currentSubTaskView = stv;
                            AddSubTaskViewToFlp(stv);
                            tb.Text = "";
                            break;
                        case "tbAddTask"://Completely New Task \ TaskView
                            TaskView tv = dataController.CreateNewTaskView(taskName, utils.GetUniqueID(), currentProjectView.ProjectID);
                            tv.Rename(taskName);
                            tv.SetTheme(currentTheme);
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

        /// <summary>
        /// Set Gradient Backgroung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
            //Graphics graphics = e.Graphics;

            ////the rectangle, the same size as our Form
            //Rectangle gradient_rectangle = new Rectangle(0, 0, Width, Height);

            ////define gradient's properties
            //Brush b = new LinearGradientBrush(gradient_rectangle, Color.FromArgb(0, 0, 0), Color.FromArgb(87, 108, 188), 45f);

            ////apply gradient         
            //graphics.FillRectangle(b, gradient_rectangle);
        }

        private void ToggleTheme_CheckedChanged(object sender, EventArgs e)
        {
            ChangeTheme.Invoke(new ChangeThemeEventArgs(TogglebtnTheme.Checked));
        }

        #endregion Events


        #region ScreenBehaviour
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void AddNotification(string title, string message, Utils.NotificationType type)
        {
            NotificationView nv = new NotificationView(title, message, type);
            nv.NotificationDeleted += Nv_NotificationDeleted;
            flpNotifications.Controls.Add(nv);

            pbNotification.Enabled = true;
            ResetPictureBox(pbNotification);
            lblNotificationCounter.Text = $"{++notificationCounter}";
        }

        private void Nv_NotificationDeleted()
        {
            lblNotificationCounter.Text = $"{--notificationCounter}";
        }

        private void pbNotification_MouseEnter(object sender, EventArgs e)
        {
            pnlNotifications.Visible = true;
            while (pnlNotifications.Height < pnlNotifications.MaximumSize.Height)
            {
                pnlNotifications.Height += 35;
                pnlNotifications.Refresh();
            }
        }

        private void pbNotification_MouseLeave(object sender, EventArgs e)
        {
            if (pnlNotifications.Visible)
            {
                while (pnlNotifications.Height > pnlNotifications.MinimumSize.Height)
                {
                    pnlNotifications.Height -= 35;
                    pnlNotifications.Refresh();
                }
                pnlNotifications.Visible = false;
            }
        }

        private void pbTimeManager_Click(object sender, EventArgs e)
        {

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
