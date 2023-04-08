using DoYourTasks.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.UI.Xaml.Media;
using System.Collections.Concurrent;

namespace DoYourTasks
{
    public class DataController
    {
        #region CustomEvents
        #region GeneralEvents
        public event HideItemEventHandler HideItem;
        public event SendNotificationEventHandler SendNotification;
        #endregion GeneralEvents

        #region Project
        public event SetProjectViewEventHandler SetProjectView;
        public event MouseEventHandler ProjectViewMouseDown;
        public event ProjectViewDeletedEventHandler ProjectViewDeleted;
        public event ProjectViewRenamedEventHandler ProjectViewRenamed;
        public event PriorityChangedEventHandler PriorityChaned;
        public event AddNewProjectAttachmentEventHandler AddNewProjectAttachment;

        #endregion Project

        #region Task
        public event UpdateCurrentTaskViewEventHandler UpdateTaskView;
        public event TaskDueDateChangedEventHandler TaskDueDateChanged;
        public event TaskRenamedEventHandler TaskRenamed;
        public event TaskCompletedEventHandler TaskCompleted;
        public event TaskModifierEventHandler TaskDeleted;
        public event HideItemEventHandler HideTask;
        public event TaskModifierEventHandler AddTaskAttachment;
        #endregion Task

        #region SubTask
        public event UpdateSubTaskViewCompleteCounterEventHandler UpdateSubTaskViewCompleteCounter;
        public event SubTaskDeletedEventHandler SubTaskDeleted;
        public event NewSubTaskViewEventHandler NewSubTaskView;

        #endregion SubTask
        #endregion CustomEvents

        #region Fields
        public ConcurrentDictionary<string, ProjectView> Projectviews;
        public ConcurrentDictionary<string, TaskView> Taskviews;
        public ConcurrentDictionary<string, SubTaskView> SubTaskviews;

        public ConcurrentDictionary<string, Project> Projects;
        public ConcurrentDictionary<string, Project> HiddenProjects;

        public Theme CurrentTheme { get; set; }
        public Settings settings { get; set; }

        Utils utils;
        Serializer serializer;
        Timer timer;
        #endregion Fields

        #region Constructors
        public DataController()
        {
            Projects = new ConcurrentDictionary<string, Project>();
            HiddenProjects = new ConcurrentDictionary<string, Project>();

            Projectviews = new ConcurrentDictionary<string, ProjectView>();
            Taskviews = new ConcurrentDictionary<string, TaskView>();
            SubTaskviews = new ConcurrentDictionary<string, SubTaskView>();

            utils = new Utils();
            serializer = new Serializer();

            //timer = new Timer();
            //timer.Interval = 1000 * 60 * 10; //10 minutes
            //timer.Tick += Timer_Tick;
            //timer.Start();
        }

        #endregion Constructors

        #region Utils

        #endregion Utils

        #region DataHandling
        public void LoadFromDB(string path)
        {
            Projectviews.Clear();
            Taskviews.Clear();
            SubTaskviews.Clear();

            SaveObject saveObject = (SaveObject)serializer.JsonDeserialize_(typeof(SaveObject), path);

            Projects = saveObject.Project;
            settings = saveObject.Settings;
            if (settings != null)
                CurrentTheme = settings.SavedTheme;
            else
                settings = new Settings();

            if (Projects == null)
            {
                Projects = new ConcurrentDictionary<string, Project>();
                SendNotification.Invoke(new SendNotificationEventArgs("Empty DB", "DB was empty.\nStarting from scratch", Utils.NotificationType.Info));
                return;
            }

            Project p = null;
            foreach (Project project in Projects.Values)
            {
                p = project;
                if (project.GetIsHidden())
                {
                    HiddenProjects.TryAdd(project.GetProjectID(), project);
                    Projects.TryRemove(project.GetProjectID(), out p);
                    continue;
                }

                ProjectView pv = CreateNewProjectView(project.GetProjectID(), false, project.GetIsHidden());
                pv.Rename(project.GetProjectName());
                List<Task> tasks = new List<Task>();
                tasks.AddRange(project.GetTasks().Values);
                tasks.AddRange(project.GetHiddenTasks().Values);

                int completedTasks = 0;

                foreach (Task task in tasks)
                {
                    TaskView taskView = CreateNewTaskView(task.GetTaskName(), task.GetTaskID(), task.GetParentProjectID(), false, task.Priority);
                    taskView.Rename(task.GetTaskName());
                    taskView.SetCompleted(task.IsCompleted);

                    taskView.SetDateCreated(task.GetDateCreated());
                    taskView.SetDueDate(task.GetDueDate());

                    if (task.IsCompleted)
                    {
                        taskView.SetCompletedOn(task.GetDateCompleted());
                        completedTasks++;
                    }

                    foreach (SubTask subtask in task.GetSubTasks().Values)
                    {
                        SubTaskView stv = CreateSubTaskView(subtask.GetParentProjectID(), subtask.GetParentTaskID(), subtask.GetSubTaskID(), subtask.GetSubTaskName(), subtask.GetCreatedAt(), false);
                        stv.Rename(subtask.GetSubTaskName());
                        stv.SetCheckedState(subtask.IsCompleted);
                        stv.IsCompleted = subtask.IsCompleted;
                    }
                }

                pv.SetTasksLabel($"Tasks: {completedTasks}/{tasks.Count}");
            }
        }

        public void BackupDB()
        {
            string sourcePath = serializer.GetDBPath();
            string fileName = Path.GetFileName(sourcePath);
            string destinationPath = Directory.Exists("K:\\ToDoBackup") ? "K:\\ToDoBackup" : Directory.Exists("H:\\ToDoBackup") ? "H:\\ToDoBackup" : null;
            if (destinationPath == null) return;

            try
            {
                File.Copy(sourcePath, Path.Combine(destinationPath, fileName), false);
            }
            catch (IOException)
            {
                int i = 1;
                string newFileName = Path.GetFileNameWithoutExtension(fileName) + $".{i.ToString()}" + Path.GetExtension(fileName);
                while (File.Exists(Path.Combine(destinationPath, newFileName)))
                {
                    i++;
                    newFileName = Path.GetFileNameWithoutExtension(fileName) + $".{i.ToString()}" + Path.GetExtension(fileName);
                }
                File.Copy(sourcePath, Path.Combine(destinationPath, newFileName), false);
            }

            string[] filePaths = Directory.GetFiles(destinationPath);
            foreach (string filePath in filePaths)
                if (File.GetCreationTime(filePath) < DateTime.Now.AddMonths(-1))
                    File.Delete(filePath);
        }

        public bool SaveToFile(bool isAutoSave = false, bool toAppend = false)
        {
            // Check if any ProjectView is in edit mode
            if (!isAutoSave && Projectviews.Values.Any(pv => pv.GetIsInEditMode()))
            {
                SendNotification.Invoke(new SendNotificationEventArgs("Edit Mode", "Edit Mode Detected.\nCant Save", Utils.NotificationType.Warning));
                return false;
            }
            // Combine Projects and HiddenProjects dictionaries
            //ConcurrentDictionary<string, Project> saveAllProjects = Projects.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            ConcurrentDictionary<string, Project> saveAllProjects = new ConcurrentDictionary<string, Project>(Projects);

            foreach (var project in HiddenProjects)
                if (!saveAllProjects.ContainsKey(project.Key))
                    saveAllProjects.TryAdd(project.Key, project.Value);

            // Serialize and save all projects
            SaveObject saveObject = new SaveObject()
            {
                Settings = settings,
                Project = saveAllProjects
            };

            serializer.JsonSerialize_(saveObject, false);

            return true;
        }

        #endregion DataHandling

        #region Models

        #region Projects

        /// <summary>
        /// Get project name from the view object (ProjectView)
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public string GetProjectName(string projectID)
        {
            return Projectviews[projectID].GetProjectName();
        }

        /// <summary>
        /// Get The Project object by its coresponding View object
        /// </summary>
        /// <param name="projctID"></param>
        /// <returns></returns>
        public Project GetProject(string projctID)
        {
            return GetCorrectProject(projctID);
        }

        #endregion Projects

        #region Tasks
        public Task GetNewTask(string taskID, string taskName, string projectID)
        {
            return new Task(taskID, taskName, projectID);
        }
        #endregion Tasks

        #region SubTasks
        public SubTask GetNewSubTask(string subTaskName, string taskID, string projectID, string subTaskID, string createdAt)
        {
            return new SubTask(subTaskName, taskID, projectID, subTaskID, createdAt);
        }
        #endregion SubTasks

        #endregion Models

        #region Views
        #region ProjectViews
        public ProjectView CreateNewProjectView(string projectID, bool isNew = true, bool isHidden = false)
        {
            Project project = null;

            if (CurrentTheme == null)
                CurrentTheme = utils.LightTheme;

            ProjectView pv = new ProjectView(projectID, CurrentTheme, isNew);
            if (isNew)
            {
                pv.SetIsInEditMode(true);
                project = new Project(projectID, isHidden);
            }

            pv.Name = "ProjectView";
            SubscribeProejctViewEvents(pv);

            AddProjectsToDicts(project, pv, projectID);
            pv.SetPriority(GetCorrectProject(projectID).GetPriority(), !isNew);
            pv.SetHidden(isHidden);

            return pv;
        }

        #region ProjectViewSetters

        #endregion ProjectViewSetters

        #region ProjectViewEvents

        private void ProjectView_MouseDown(object sender, MouseEventArgs e)
        {
            ProjectViewMouseDown.Invoke(sender, e);
        }

        private void SubscribeProejctViewEvents(ProjectView pv)
        {
            //pv.Load += RoundCorners;
            pv.MouseDown += ProjectView_MouseDown;
            pv.SetProjectView += SetProjectViewOnScreen;
            pv.ProjectViewDeleted += DeletedProject;
            pv.ProjectViewRenamed += ProjectRenamed;
            pv.ChangePriority += Pv_ChangePriority;
            pv.HideProject += Pv_HideProject;
            pv.AddAttachment += Pv_AddAttachment;
        }

        private void Pv_AddAttachment()
        {
            AddNewProjectAttachment.Invoke();
        }

        private void Pv_HideProject(HideItemEventArgs arg)
        {
            HideItem.Invoke(arg);//delegate to main form
        }

        private void Pv_ChangePriority(ChangePriorityEventArgs arg)
        {
            switch (arg.Control.GetType().Name)
            {
                case "ProjectView":
                    ProjectView pv = arg.Control as ProjectView;
                    if (pv == null)
                        return;
                    GetCorrectProject(pv.ProjectID).SetPriority(arg.Priority);
                    break;
                case "TaskView":
                    TaskView tv = arg.Control as TaskView;
                    if (tv == null)
                        return;
                    GetCorrectProject(tv.GetParentProjectID()).GetTasks()[tv.GetTaskID()].SetPriority(arg.Priority);
                    break;
                case "SubTaskView":
                    SubTaskView stv = arg.Control as SubTaskView;
                    if (stv == null)
                        return;
                    GetCorrectProject(stv.GetParentProjectID()).GetTasks()[stv.GetParentTaskID()].GetSubTasks()[stv.GetParentTaskID()].SetPriority(arg.Priority);
                    break;
            }

        }

        #endregion ProjectViewEvents



        #region ProjectView





        /// <summary>
        /// Return the appropriate project object weather its hidden or not
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public Project GetCorrectProject(string projectID)
        {
            if (Projects.ContainsKey(projectID))
                return Projects[projectID];
            else if (HiddenProjects.ContainsKey(projectID))
                return HiddenProjects[projectID];
            else return null;
        }

        public ConcurrentDictionary<string, Project> GetProjects() { return Projects; }

        public ConcurrentDictionary<string, Project> GetHiddenProjects() { return HiddenProjects; }

        public void RemoveCorrectProject(string projectID)
        {
            Project p = Projects[projectID];
            if (Projects.ContainsKey(projectID))
                Projects.TryRemove(projectID, out p);
            else
                HiddenProjects.TryRemove(projectID, out p);
        }

        public ConcurrentDictionary<string, Project> GetAllProjects()
        {
            return new ConcurrentDictionary<string, Project>(Projects.Concat(HiddenProjects));
        }

        private void ProjectRenamed(RenameProjectEventArgs args)
        {
            GetCorrectProject(args.ProjectID).Rename(args.ProjectName);
        }

        private void SetProjectViewOnScreen(SetProjectViewEventArgs args)
        {
            SetProjectView.Invoke(args);
        }

        private void DeletedProject(ProjectViewDeletedEventArgs args)
        {
            ProjectViewDeleted.Invoke(args);
        }

        private void AddProjectsToDicts(Project project, ProjectView projectView, string projectID)
        {
            Projectviews.TryAdd(projectID, projectView);

            if (project != null)
                Projects.TryAdd(projectID, project);
        }
        #endregion

        #region ProjectViewsGetters

        #endregion

        #region ProjectViewsModifiers
        public void RenameProjectView(string projectID, string newName)
        {
            Projectviews[projectID].Rename(newName);
            GetCorrectProject(projectID).Rename(newName);
        }
        public void DeleteProjectView(string projectID)
        {
            Project p = Projects[projectID];
            ProjectView pv = Projectviews[projectID];
            Projectviews.TryRemove(projectID, out pv);

            if (Projects.ContainsKey(projectID))
                Projects.TryRemove(projectID, out p);
            else
                HiddenProjects.TryRemove(projectID, out p);
        }
        #endregion

        #endregion

        #region Taskviews

        #region TaskviewsSetters
        public TaskView CreateNewTaskView(string taskName, string taskID, string projectID, bool isNew = true, int priority = 0)
        {
            if (CurrentTheme == null)
                CurrentTheme = utils.LightTheme;

            TaskView tv = new TaskView(taskName, taskID, projectID, priority, CurrentTheme);
            SubscribeTaskViewEvents(tv);
            Task task = null;
            if (isNew)
            {
                task = GetNewTask(taskID, taskName, projectID);
                GetCorrectProject(projectID).GetTasks().TryAdd(taskID, task);
                tv.SetDateCreated(task.DateCreated);
                tv.isHidden = false;
            }
            if (tv.GetCheckedState()) {
                tv.SetPBStatus(Utils.NotificationType.Success);
            }
            AddTaskToDicts(task, tv, taskID);
            UpdateTaskView.Invoke(new UpdateCurrentTaskViewEventArgs(tv));
            return tv;
        }
        private void SubscribeTaskViewEvents(TaskView tv)
        {
            //tv.Load += RoundCorners;
            tv.TaskCompleted += Tv_TaskCompleted;
            tv.TaskDeleted += Tv_TaskDeleted;
            tv.DueDateChanged += Tv_TaskDueDateChanged;
            tv.UpdateTaskView += UpdateTaskView;
            tv.TaskRenamed += Tv_TaskRenamed;
            tv.AttachemntRemoved += Tv_AttachemntRemoved;
            tv.PriorityChanged += Tv_PriorityChanged;
            tv.MouseDown += Tv_MouseDown;
            tv.HideTask += Tv_HideTask;
            tv.AddTaskAttachment += Tv_AddTaskAttachment;
        }
        private void AddTaskToDicts(Task task, TaskView taskView, string taskID)
        {
            try
            {
                Taskviews.TryAdd(taskID, taskView);
            }
            catch (Exception ex) { }
        }

        #region TaskViewEvents

        private void Tv_AddTaskAttachment(TaskModifiedEventArgs args)
        {
            AddTaskAttachment.Invoke(args);
        }

        private void Tv_HideTask(HideItemEventArgs arg)
        {
            HideItem.Invoke(arg);
        }

        private void Tv_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            c.DoDragDrop(c, DragDropEffects.Move);
        }

        private void Tv_PriorityChanged(PriorityChangedEventArgs args)
        {
            TaskView tv = args.TaskView;
            int priority = args.Priority;
            string projectID = tv.GetParentProjectID();
            string taskID = tv.GetTaskID();

            GetCorrectProject(projectID).GetAllTasks()[taskID].SetPriority(priority);
            PriorityChaned.Invoke(args);
        }

        private void Tv_AttachemntRemoved(AttachmentRemovedEventArgs arg)
        {
            Attachment attachment = arg.Attachment.Attachment;
            string projectID = attachment.GetParentProjectID();
            string taskID = attachment.GetParentTaskID();
            Task task = GetCorrectProject(projectID).GetAllTasks()[taskID];

            Attachment atToRemove = task.GetAttachements().FirstOrDefault(a => a.GetAttachmentID() == attachment.GetAttachmentID());

            if (atToRemove != null)
                task.GetAttachements().Remove(atToRemove);

            Taskviews[attachment.GetParentTaskID()].ResizeAttachmentsFLP();

            //Reset taskview -- delegate to main
        }

        private void Tv_TaskRenamed(TaskRenamedEventArgs args)
        {
            TaskView tv = args.TaskView;
            GetCorrectProject(tv.GetParentProjectID()).Tasks[tv.GetTaskID()].Rename(tv.GetName());
            TaskRenamed.Invoke(new TaskRenamedEventArgs(args.TaskView));
        }

        private void Tv_TaskDeleted(TaskModifiedEventArgs args)
        {
            string projectID = args.TV.GetParentProjectID();
            string taskID = args.TV.GetTaskID();
            TaskView tv = Taskviews[taskID];

            GetCorrectProject(projectID).RemoveTask(taskID);
            Taskviews.TryRemove(taskID, out tv);
            TaskDeleted.Invoke(args);
            args.TV.Dispose();
        }

        private void Tv_TaskDueDateChanged(DueDateChangedEventArgs args)
        {
            string projectID = args.TaskView.GetParentProjectID();
            string taskID = args.TaskView.GetTaskID();
            string dueDate = args.TaskView.GetDueDate();
            GetCorrectProject(projectID).GetTasks()[taskID].SetDueDate(dueDate);
        }
        private void Tv_TaskCompleted(TaskCompletedEventArgs args)
        {
            // Retrieve project and task ID
            Project project = GetCorrectProject(args.TV.GetParentProjectID());
            string taskID = args.TV.GetTaskID();

            // Check if task is in project or hidden tasks
            if (project.GetTasks().ContainsKey(taskID))
            {
                project.GetTasks()[taskID].SetCompleted(args.TV.GetCheckedState());
                project.GetTasks()[taskID].SetDateCompleted(DateTime.Now.ToString("dd/MM/yy"));
            }
            else if (project.GetHiddenTasks().ContainsKey(taskID))
            {
                project.GetHiddenTasks()[taskID].SetCompleted(args.TV.GetCheckedState());
                project.GetHiddenTasks()[taskID].SetDateCompleted(DateTime.Now.ToString(""));
            }

            // Get list of all tasks and count completed tasks
            List<Task> tasks = project.GetAllTasks().Values.ToList();
            int completedTasks = tasks.Count(t => t.IsCompleted);

            // Update project view label and BeginInvoke TaskCompleted event
            Projectviews[args.TV.GetParentProjectID()].SetTasksLabel($"Tasks: {completedTasks}/{tasks.Count}");
            TaskCompleted.Invoke(new TaskCompletedEventArgs(args.TV));
        }

        #endregion TaskViewEvents


        #endregion

        #region TaskviewsGetters
        public string GetTaskViewName(string taskID)
        {
            return Taskviews[taskID].GetName();
        }
        #endregion

        #region TaskviewsModifiers
        public void RenameTask(string taskID, string newName)
        {
            Taskviews[taskID].Rename(newName);
            GetCorrectProject(Taskviews[taskID].GetParentProjectID()).GetTasks()[taskID].Rename(newName);
        }

        public void DeleteTask(string taskID)
        {
            TaskView tv = null;
            Task t = null;
            Taskviews.TryRemove(taskID, out tv);
            GetCorrectProject(Taskviews[taskID].GetParentProjectID()).GetTasks().TryRemove(taskID, out t);
        }
        #endregion

        #endregion

        #region SubTaskView
        public SubTaskView CreateSubTaskView(string projectID, string taskID, string subTaskID, string subTaskName, string createdAt, bool isNew = true)
        {
            SubTask subTask = null;
            SubTaskView subTaskView = new SubTaskView(taskID, subTaskID, projectID, subTaskName, createdAt);
            SubscribeSubTaskViewEvents(subTaskView);

            if (isNew)
                subTask = GetNewSubTask(subTaskName, taskID, projectID, subTaskID, createdAt);

            AddSubTaskToDicts(subTask, subTaskView, projectID, taskID, subTaskID);
            UpdateSubTaskViewCompleteCounter.Invoke(new UpdateSubTaskViewCompleteCounterEventArgs(projectID, taskID));
            return subTaskView;
        }

        private void SubscribeSubTaskViewEvents(SubTaskView stv)
        {
            stv.SubTaskCompleted += Stv_SubTaskCompleted;
            stv.SubTaskDeleted += Stv_SubTaskDeleted;
            //stv.Load += RoundCorners;
        }

        private void AddSubTaskToDicts(SubTask subTask, SubTaskView subTaskView, string projectID, string taskID, string subTaskID)
        {
            SubTaskviews.TryAdd(subTaskView.SubTaskID, subTaskView);

            if (subTask != null)
                GetCorrectProject(projectID).GetTasks()[taskID].AddSubTask(subTaskID, subTask);
        }


        #region SubTaskViewSetters

        #endregion

        #region SubTaskViewGetters
        public SubTask GetSubTask(string projectID, string taskID, string subTaskID)
        {
            return GetAllProjects()[projectID].GetAllTasks()[taskID].GetSubTasks()[subTaskID];
        }

        public string GetSubTaskName(string id)
        {
            return SubTaskviews[id].GetName();
        }
        #endregion

        #region SubTaskViewEvents
        private void Stv_SubTaskCompleted(SubTaskCompletedEventArgs args)
        {
            try
            {
                GetCorrectProject(args.STV.GetParentProjectID()).GetAllTasks()[args.STV.GetParentTaskID()].GetSubTasks()[args.STV.GetSubTaskID()].SetCompleted(args.STV.IsCompleted);
                UpdateSubTaskViewCompleteCounter.Invoke(new UpdateSubTaskViewCompleteCounterEventArgs(args.STV.GetParentProjectID(), args.STV.GetParentTaskID()));
            }
            catch (KeyNotFoundException) { return; }

        }

        private void Stv_SubTaskDeleted(SubTaskDeletedEventArgs arg)
        {
            try
            {
                SubTaskView stv = null;
                SubTaskviews.TryRemove(arg.STV.GetParentTaskID(), out stv);
                GetCorrectProject(arg.STV.GetParentProjectID()).GetAllTasks()[arg.STV.GetParentTaskID()].RemoveSubTask(arg.STV.GetSubTaskID());
                SubTaskDeleted.Invoke(new SubTaskDeletedEventArgs(arg.STV));
                arg.STV.Dispose();
            }
            catch (KeyNotFoundException) { return; }
        }

        public Theme GetTheme()
        {
            if (settings != null)
                return settings.SavedTheme;
            return utils.LightTheme;
        }
        #endregion

        #endregion
        #endregion Views
    }
}