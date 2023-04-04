using DoYourTasks.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoYourTasks
{
    public class DataController
    {
        #region CustomEvents
        #region General
        public event HideItemEventHandler HideItem;
        #endregion

        #region Project
        public event SetProjectViewEventHandler SetProjectView;
        public event ProjectViewDeletedEventHandler ProjectViewDeleted;
        public event ProjectViewRenamedEventHandler ProjectViewRenamed;
        public event PriorityChangedEventHandler PriorityChaned;
        public event AddNewProjectAttachmentEventHandler AddNewProjectAttachment;

        #endregion

        #region Task
        public event UpdateCurrentTaskViewEventHandler UpdateTaskView;
        public event TaskDueDateChangedEventHandler TaskDueDateChanged;
        public event TaskRenamedEventHandler TaskRenamed;
        public event TaskCompletedEventHandler TaskCompleted;
        public event TaskDeletedEventHandler TaskDeleted;
        public event HideItemEventHandler HideTask;
        #endregion

        #region SubTask
        public event UpdateSubTaskViewCompleteCounterEventHandler UpdateSubTaskViewCompleteCounter;
        public event SubTaskDeletedEventHandler SubTaskDeleted;
        public event NewSubTaskViewEventHandler NewSubTaskView;

        #endregion
        #endregion


        #region Fields
        public Dictionary<string, ProjectView> Projectviews;
        public Dictionary<string, TaskView> Taskviews;
        public Dictionary<string, SubTaskView> SubTaskviews;

        public Dictionary<string, Project> Projects;
        public Dictionary<string, Project> HiddenProjects;
        Utils utils;
        Serializer serializer;
        Timer timer;
        #endregion

        #region Constructors
        public DataController()
        {
            Projects = new Dictionary<string, Project>();
            HiddenProjects = new Dictionary<string, Project>();

            Projectviews = new Dictionary<string, ProjectView>();
            Taskviews = new Dictionary<string, TaskView>();
            SubTaskviews = new Dictionary<string, SubTaskView>();

            utils = new Utils();
            serializer = new Serializer();

            timer = new Timer();
            timer.Interval = 1000 * 60 * 10; //10 minutes
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!SaveToFile(toAppend: true))
                return;
        }

        #endregion

        public void LoadFromDB(string path)
        {
            Projectviews.Clear();
            Taskviews.Clear();
            SubTaskviews.Clear();
            List<string> tmpList = new List<string>() { "ProjectView", "TaskView", "SubTaskView" };

            Projects = (Dictionary<string, Project>)serializer.JsonDeserialize_(typeof(Dictionary<string, Project>), path);

            if (Projects == null)
                return;

            string taskViewID;
            string pvID;
            string stvID;
            ProjectView pv;
            TaskView tv;
            SubTaskView stv;

            List<Project> projects = new List<Project>();
            foreach (Project project in Projects.Values.ToList())
            {
                if (project.GetIsHidden())//load correctly
                {
                    HiddenProjects.Add(project.GetProjectID(), project);
                    Projects.Remove(project.GetProjectID());
                }

                projects.Add(project);// this in order to create the view object
            }

            foreach (Project project in projects)
            {
                //create the Projects Property
                pv = CreateNewProjectView(project.GetProjectID(), false, project.GetIsHidden());
                pv.Rename(project.GetProjectName());
                pvID = pv.ProjectID;
                //Projectviews.Add(pvID, pv);

                //create the TaskViews
                List<Task> tasks = project.GetTasks().Values.ToList();
                tasks.AddRange(project.GetHiddenTasks().Values.ToList());

                int completedTasks = 0;
                foreach (var task in tasks)
                {
                    tv = CreateNewTaskView(task.GetTaskName(), task.GetTaskID(), task.GetParentProjectID(), false, task.Priority);
                    tv.Rename(task.GetTaskName());
                    tv.SetCompleted(task.IsCompleted);

                    if (task.GetDateCreated() != null)
                        tv.SetDateCreated(task.DateCreated);

                    if (task.GetDueDate() != null)
                        tv.SetDueDate(task.GetDueDate());

                    taskViewID = task.GetTaskID();
                    if (task.IsCompleted)
                        completedTasks++;
                    //Taskviews.Add(taskViewID, tv);

                    //create the SubTaskViews
                    List<SubTask> subTasks = task.GetSubTasks().Values.ToList();
                    foreach (var subtask in subTasks)
                    {
                        stv = CreateSubTaskView(subtask.GetParentProjectID(), subtask.GetParentTaskID(), subtask.GetSubTaskID(), subtask.GetSubTaskName(), subtask.GetCreatedAt(), false);
                        stv.Rename(subtask.GetSubTaskName());
                        stvID = subtask.GetSubTaskID();
                        stv.SetCheckedState(subtask.IsCompleted);
                        stv.IsCompleted = subtask.IsCompleted;
                    }
                }

                pv.SetTasksLabel($"Tasks: {completedTasks}/{tasks.Count}");
            }
        }

        public bool SaveToFile(bool isAutoSave = false, bool toAppend = false)
        {
            foreach (ProjectView pv in Projectviews.Values.ToList())
            {
                if (pv.GetIsInEditMode())
                {
                    if (!isAutoSave)//dont disturb the user
                                    //MessageBox.Show("One or more projects are in edit mode.\ncannot quit.", "Editing in progress", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                }
            }
            serializer.JsonSerialize_(Projects, false);
            return true;
        }

        #region ProjectViews

        #region ProjectViewsSetters
        public ProjectView CreateNewProjectView(string projectID, bool isNew = true, bool isHidden = false)
        {
            Project project = null;
            ProjectView pv = new ProjectView(projectID, isNew);
            if (isNew)
            {
                pv.SetIsInEditMode(true);
                project = new Project(projectID, isHidden);
            }

            pv.Name = "ProjectView";

            pv.SetProjectView += SetProjectViewOnScreen;
            pv.ProjectViewDeleted += DeletedProject;
            pv.ProjectViewRenamed += ProjectRenamed;
            pv.ChangePriority += Pv_ChangePriority;
            pv.HideProject += Pv_HideProject;
            pv.AddAttachment += Pv_AddAttachment;

            AddProjectsToDicts(project, pv, projectID);
            pv.SetPriority(GetCorrectProject(projectID).GetPriority(), !isNew);
            pv.SetHidden(isHidden);

            return pv;
        }

        private void Pv_AddAttachment()
        {
            AddNewProjectAttachment.Invoke();
        }

        private void Pv_HideProject(HideItemEventArgs arg)
        {
            HideItem.Invoke(arg);//delegate to main form
        }

        /// <summary>
        /// Return the appropriate project object weather its hidden or not
        /// </summary>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public Project GetCorrectProject(string projectID)
        {
            if (Projects.ContainsKey(projectID))
                return Projects[projectID];
            else
                return HiddenProjects[projectID];
        }
        public Dictionary<string, Project> GetProjects() { return Projects; }
        public Dictionary<string, Project> GetHiddenProjects() { return HiddenProjects; }
        public void RemoveCorrectProject(string projectID)
        {
            if (Projects.ContainsKey(projectID))
                Projects.Remove(projectID);
            else
                HiddenProjects.Remove(projectID);
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
            Projectviews.Add(projectID, projectView);

            if (project != null)
                Projects.Add(projectID, project);
        }
        #endregion

        #region ProjectViewsGetters
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
        #endregion

        #region ProjectViewsModifiers
        public void RenameProjectView(string projectID, string newName)
        {
            Projectviews[projectID].Rename(newName);
            GetCorrectProject(projectID).Rename(newName);
        }
        public void DeleteProjectView(string projectID)
        {
            Projectviews.Remove(projectID);

            if (Projects.ContainsKey(projectID))
                Projects.Remove(projectID);
            else
                HiddenProjects.Remove(projectID);
        }
        #endregion

        #endregion

        #region Taskviews

        #region TaskviewsSetters
        public TaskView CreateNewTaskView(string taskName, string taskID, string projectID, bool isNew = true, int priority = 0)
        {
            Task task = null;
            TaskView tv = new TaskView(taskName, taskID, projectID, priority);

            tv.TaskCompleted += Tv_TaskCompleted;
            tv.TaskDeleted += Tv_TaskDeleted;
            tv.DueDateChanged += Tv_TaskDueDateChanged;
            tv.UpdateTaskView += UpdateTaskView;
            tv.TaskRenamed += Tv_TaskRenamed;
            tv.AttachemntRemoved += Tv_AttachemntRemoved;
            tv.PriorityChanged += Tv_PriorityChanged;
            tv.MouseDown += Tv_MouseDown;
            tv.HideTask += Tv_HideTask;

            //create the coresponding Task
            if (isNew)
            {
                task = new Task(taskID, taskName, projectID);
                GetCorrectProject(projectID).GetTasks().Add(taskID, task);//Add task to coresponding project
                tv.SetDateCreated(task.DateCreated);
            }

            UpdateTaskView.Invoke(new UpdateCurrentTaskViewEventArgs(tv));//update task view in form

            AddTaskToDicts(task, tv, taskID);
            return tv;
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

        public void BackupDB()
        {
            string SourcePath = serializer.GetDBPath();

            string desdtFileName = Path.GetFileName(serializer.GetDBPath());
            string destPath = "K:\\ToDoBackup";
            string originalDesdtFileName = desdtFileName;
            try
            {
                if (!Directory.Exists("K:\\"))
                    return;
                if (!Directory.Exists(destPath))
                    Directory.CreateDirectory(destPath);
            }
            catch
            {
                destPath = "H:\\ToDoBackup";
                if (!Directory.Exists("H:\\"))
                    return;
                if (!Directory.Exists(destPath))
                    Directory.CreateDirectory(destPath);
            }
            try
            {
                File.Copy(SourcePath, $"{destPath}\\{desdtFileName}", false); //do not overwrite
            }
            catch (IOException ioe)
            {
                int i = 1;
                while (File.Exists($"{destPath}\\{desdtFileName}"))
                {
                    desdtFileName = originalDesdtFileName + $".{i.ToString()}";
                    i++;
                }

                File.Copy(SourcePath, $"{destPath}\\{desdtFileName}", false);
            }


            // Delete files older than a month
            string[] filePaths = Directory.GetFiles(Path.GetDirectoryName(destPath));
            foreach (string filePath in filePaths)
                if (File.GetCreationTime(filePath) < DateTime.Now.AddMonths(-1))
                    File.Delete(filePath);
        }

        private void Tv_PriorityChanged(PriorityChangedEventArgs args)
        {
            TaskView tv = args.TaskView;
            int priority = args.Priority;

            string projeID = tv.GetParentProjectID();
            string taskID = tv.GetTaskID();
            GetCorrectProject(tv.GetParentProjectID()).GetTasks()[tv.GetTaskID()].SetPriority(priority);
            PriorityChaned.Invoke(args);
        }

        private void Tv_AttachemntRemoved(AttachmentRemovedEventArgs arg)
        {
            Attachment attachment = arg.Attachment.Attachment;
            Attachment atToRemove = null;
            foreach (Attachment at in Projects[attachment.GetParentProjectID()].GetTasks()[attachment.GetParentTaskID()].GetAttachements())
            {
                if (at.GetAttachmentID() == attachment.GetAttachmentID())
                {
                    atToRemove = at;
                    break;
                }
            }
            if (atToRemove != null)
                GetCorrectProject(attachment.GetParentProjectID()).GetTasks()[attachment.GetParentTaskID()].GetAttachements().Remove(atToRemove);
            Taskviews[attachment.GetParentTaskID()].ResizeAttachmentsFLP();
        }

        private void Tv_TaskRenamed(TaskRenamedEventArgs args)
        {
            TaskView task = args.TaskView;
            GetCorrectProject(task.GetParentProjectID()).Tasks[task.GetTaskID()].Rename(task.GetName());
            TaskRenamed.Invoke(new TaskRenamedEventArgs(args.TaskView));

        }

        private void Tv_TaskDeleted(TaskDeletedEventArgs args)
        {
            GetCorrectProject(args.TV.GetParentProjectID()).RemoveTask(args.TV.GetTaskID());
            Taskviews.Remove(args.TV.GetTaskID());
            args.TV.Dispose();
            TaskDeleted.Invoke(args);
        }
        private void Tv_TaskDueDateChanged(DueDateChangedEventArgs args)
        {
            TaskDueDateChanged.Invoke(new DueDateChangedEventArgs(args.TaskView, args.DueDate));
        }


        private void Tv_TaskCompleted(TaskCompletedEventArgs args)
        {
            List<Task> tasks = new List<Task>();
            if (GetCorrectProject(args.TV.GetParentProjectID()).GetTasks().ContainsKey(args.TV.GetTaskID()))
            {
                GetCorrectProject(args.TV.GetParentProjectID()).GetTasks()[args.TV.GetTaskID()].SetCompleted(args.TV.GetCheckedState());
                tasks = GetCorrectProject(args.TV.GetParentProjectID()).GetTasks().Values.ToList();
            }
            else if (GetCorrectProject(args.TV.GetParentProjectID()).GetHiddenTasks().ContainsKey(args.TV.GetTaskID()))
            {
                GetCorrectProject(args.TV.GetParentProjectID()).GetHiddenTasks()[args.TV.GetTaskID()].SetCompleted(args.TV.GetCheckedState());
                tasks = GetCorrectProject(args.TV.GetParentProjectID()).GetHiddenTasks().Values.ToList();
            }

            int completedTasks = 0;
            foreach (var task in tasks)
            {
                if (task.IsCompleted)
                    completedTasks++;
            }

            Projectviews[args.TV.GetParentProjectID()].SetTasksLabel($"Tasks: {completedTasks}/{tasks.Count}");
            TaskCompleted.Invoke(new TaskCompletedEventArgs(args.TV));
        }

        private void AddTaskToDicts(Task task, TaskView taskView, string taskID)
        {
            Taskviews.Add(taskID, taskView);
        }
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
            Taskviews.Remove(taskID);
            GetCorrectProject(Taskviews[taskID].GetParentProjectID()).GetTasks().Remove(taskID);
        }
        #endregion

        #endregion

        #region SubTaskView

        #region SubTaskViewSetters
        public SubTaskView CreateSubTaskView(string projectID, string taskID, string subTaskID, string subTaskName, string createdAt, bool isNew = true)
        {
            SubTask st = null;
            SubTaskView stv = new SubTaskView(taskID, subTaskID, projectID, subTaskName, createdAt);
            stv.SubTaskCompleted += Stv_SubTaskCompleted;
            stv.SubTaskDeleted += Stv_SubTaskDeleted;

            if (isNew)
            {
                st = new SubTask(subTaskName, taskID, projectID, subTaskID, createdAt);
            }

            AddSubTaskToDicts(st, stv, projectID, taskID, subTaskID);
            UpdateSubTaskViewCompleteCounter.Invoke(new UpdateSubTaskViewCompleteCounterEventArgs(projectID, taskID));
            return stv;
        }

        private void AddSubTaskToDicts(SubTask subTask, SubTaskView subTaskView, string projectID, string taskID, string subTaskID)
        {
            SubTaskviews.Add(subTaskView.SubTaskID, subTaskView);

            if (subTask != null)
                GetCorrectProject(projectID).GetTasks()[taskID].AddSubTask(subTaskID, subTask);
        }
        #endregion

        #region SubTaskViewGetters
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
                GetCorrectProject(args.STV.GetParentProjectID()).GetTasks()[args.STV.GetParentTaskID()].GetSubTasks()[args.STV.GetParentTaskID()].SetCompleted(args.STV.IsCompleted);
                UpdateSubTaskViewCompleteCounter.Invoke(new UpdateSubTaskViewCompleteCounterEventArgs(args.STV.GetParentProjectID(), args.STV.GetParentTaskID()));
            }
            catch (KeyNotFoundException) { return; }

        }

        private void Stv_SubTaskDeleted(SubTaskDeletedEventArgs arg)
        {
            try
            {
                SubTaskviews.Remove(arg.STV.GetParentTaskID());
                GetCorrectProject(arg.STV.GetParentProjectID()).GetTasks()[arg.STV.GetParentTaskID()].RemoveSubTask(arg.STV.GetParentTaskID());
                SubTaskDeleted.Invoke(new SubTaskDeletedEventArgs(arg.STV));
                arg.STV.Dispose();
            }
            catch (KeyNotFoundException) { return; }
        }
        #endregion

        #endregion
    }
}