using DoYourTasks.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoYourTasks
{
    public class viewsController
    {

        #region CustomEvents

        #region Project
        public event SetProjectViewEventHandler SetProjectView;
        public event ProjectViewDeletedEventHandler ProjectViewDeleted;
        public event ProjectViewRenamedEventHandler ProjectViewRenamed;
        public event ShowTooltipEventHandler ShowTooltip;

        #endregion
        #region Task
        public event UpdateCurrentTaskViewEventHandler UpdateTaskView;
        public event TaskDueDateChangedEventHandler TaskDueDateChanged;
        #endregion

        #region SubTask
        public event UpdateSubTaskViewCompleteCounterEventHandler UpdateSubTaskViewCompleteCounter;
        #endregion
        #endregion


        #region Fields
        public Dictionary<string, ProjectView> Projectviews;
        public Dictionary<string, TaskView> Taskviews;
        public Dictionary<string, SubTaskView> SubTaskviews;

        public Dictionary<string, Project> Projects;

        Utils utils;
        Serializer serializer;
        Timer timer;
        #endregion

        #region Constructors
        public viewsController()
        {
            Projects = new Dictionary<string, Project>();

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
            if (!SaveToFile())
                return;
        }

        #endregion

        public void LoadFromDB(string path)
        {
            Projectviews.Clear();
            Taskviews.Clear();
            SubTaskviews.Clear();
            List<string> tmpList = new List<string>() { "ProjectView", "TaskView", "SubTaskView" };

            Projects = (Dictionary<string, Project>)serializer.Deserialize(typeof(Dictionary<string, Project>), path);
           
            if (Projects == null)
                return;

            string taskViewID;
            string pvID;
            string stvID;
            ProjectView pv;
            TaskView tv;
            SubTaskView stv;
            foreach (Project project in Projects.Values.ToList())
            {
                //create the Projects Property
                pv = CreateNewProjectView(project.GetProjectID(), false);
                pv.Rename(project.GetProjectName());
                pvID = pv.ProjectID;
                //Projectviews.Add(pvID, pv);

                //create the TaskViews
                List<Task> tasks = project.GetTasks().Values.ToList();
                foreach (var task in tasks)
                {
                    tv = CreateNewTaskView(task.GetTaskName(), task.GetTaskID(), task.GetParentProjectID(), false);
                    tv.Rename(task.GetTaskName());

                    if (task.GetDueDate()!= null)
                        tv.SetDueDate((DateTime)task.GetDueDate());

                    taskViewID = task.GetTaskID();
                    //Taskviews.Add(taskViewID, tv);

                    //create the SubTaskViews
                    List<SubTask> subTasks = task.GetSubTasks().Values.ToList();
                    foreach (var subtask in subTasks)
                    {
                        stv = CreateSubTaskView(subtask.GetParentProjectID(), subtask.GetParentTaskID(), subtask.GetSubTaskID(), subtask.GetSubTaskName(), false);
                        stv.Rename(subtask.GetSubTaskName());
                        stvID = subtask.GetSubTaskID();
                        stv.SetCheckedState(subtask.IsCompleted);
                        stv.IsCompleted = subtask.IsCompleted;
                    }
                }
            }
        }

        public bool SaveToFile()
        {
            foreach (ProjectView pv in Projectviews.Values.ToList()) {
                if (pv.GetIsInEditMode()) {
                    MessageBox.Show("One or more projects are in edit mode.\ncannot quit.", "Editing in progress", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            serializer.Serialize(Projects, false);
            return true;
        }

        #region ProjectViews

        #region ProjectViewsSetters
        public ProjectView CreateNewProjectView(string projectID, bool isNew = true)
        {
            Project project = null;
            ProjectView pv = new ProjectView(projectID);
            if (isNew)
                project = new Project(projectID);

            pv.SetProjectView += SetProjectViewOnScreen;
            pv.ProjectViewDeleted += DeletedProject;
            pv.ProjectViewRenamed += ProjectRenamed;
            pv.ShowTooltip += Pv_ShowTooltip;
            AddProjectsToDicts(project, pv, projectID);

            return pv;
        }

        private void Pv_ShowTooltip(ShowTooltipEventArgs arg)
        {
            ShowTooltip.Invoke(arg);
        }

        private void ProjectRenamed(RenameProjectEventArgs args)
        {
            Projects[args.ProjectID].Rename(args.ProjectName);
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
        public string GetProjectName(string id)
        {
            return Projectviews[id].GetProjName();
        }

        public Project GetProject(string id)
        {
            return Projects[id];
        }
        #endregion

        #region ProjectViewsModifiers
        public void RenameProjectView(string id, string newName)
        {
            Projectviews[id].Rename(newName);
            Projects[id].Rename(newName);
        }
        public void DeleteProjectView(string id)
        {
            Projectviews.Remove(id);
            Projects.Remove(id);
        }
        #endregion

        #endregion

        #region Taskviews

        #region TaskviewsSetters
        public TaskView CreateNewTaskView(string taskName, string taskID, string projectID, bool isNew = true)
        {
            Task task = null;
            TaskView tv = new TaskView(taskName, taskID, projectID);
            tv.TaskCompleted += Tv_TaskCompleted;
            tv.TaskDeleted += Tv_TaskDeleted;
            tv.DueDateChanged += Tv_TaskDueDateChanged;
            tv.UpdateTaskView += UpdateTaskView;
            tv.ShowToolTip += Pv_ShowTooltip;
            UpdateTaskView.Invoke(new UpdateCurrentTaskViewEventArgs(tv));//update task view in form

            //create the coresponding Task
            if (isNew)
            {
                task = new Task(taskID, taskName, projectID);
                Projects[projectID].GetTasks().Add(taskID, task);//Add task to coresponding project
            }

            AddTaskToDicts(task, tv, taskID);
            return tv;
        }

        private void Tv_TaskDeleted(TaskDeletedEventArgs args)
        {
            Projects[args.TV.GetParentProjectID()].RemoveTask(args.TV.GetID());
            Taskviews.Remove(args.TV.GetID());
            args.TV.Dispose();
        }
        private void Tv_TaskDueDateChanged(DueDateChangedEventArgs args)
        {
            TaskDueDateChanged.Invoke(new DueDateChangedEventArgs(null));
        }


        private void Tv_TaskCompleted(TaskCompletedEventArgs args)
        {
            Projects[args.TV.GetParentProjectID()].GetTasks()[args.TV.GetID()].SetCompleted(args.TV.GetCheckedState());
        }

        private void AddTaskToDicts(Task task, TaskView taskView, string id)
        {
            Taskviews.Add(id, taskView);
            //if (task != null)
            //    Projects[task.GetParentProjectID()].Tasks.Add(id, task);
        }
        #endregion

        #region TaskviewsGetters
        public string GetTaskViewName(string id)
        {
            return Taskviews[id].GetName();
        }
        #endregion

        #region TaskviewsModifiers
        public void RenameTask(string taskID, string newName)
        {
            Taskviews[taskID].Rename(newName);
            Projects[Taskviews[taskID].GetParentProjectID()].GetTasks()[taskID].Rename(newName);
        }
        public void DeleteTask(string taskID)
        {
            Taskviews.Remove(taskID);
            Projects[Taskviews[taskID].GetParentProjectID()].GetTasks().Remove(taskID);
        }
        #endregion

        #endregion

        #region SubTaskView

        #region SubTaskViewSetters
        public SubTaskView CreateSubTaskView(string projectID, string taskID, string subTaskID, string subTaskName, bool isNew = true)
        {
            SubTask st = null;
            SubTaskView stv = new SubTaskView(taskID, subTaskID, projectID, subTaskName);
            stv.SubTaskCompleted += Stv_SubTaskCompleted;
            stv.SubTaskDeleted += Stv_SubTaskDeleted;
            stv.ShowTooltip += Pv_ShowTooltip;
            if (isNew)
                st = new SubTask(subTaskName, taskID, projectID, subTaskID);
            AddSubTaskToDicts(st, stv, projectID, taskID, subTaskID);
            UpdateSubTaskViewCompleteCounter.Invoke(new UpdateSubTaskViewCompleteCounterEventArgs(projectID, taskID));
            return stv;
        }

        private void AddSubTaskToDicts(SubTask subTask, SubTaskView subTaskView, string projectID, string taskID, string subTaskID)
        {
            SubTaskviews.Add(subTaskView.SubTaskID, subTaskView);

            if (subTask != null)
                Projects[projectID].GetTasks()[taskID].AddSubTask(subTaskID, subTask);
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
                Projects[args.STV.GetParentProjectID()].GetTasks()[args.STV.GetParentTaskID()].GetSubTasks()[args.STV.GetID()].SetCompleted(args.STV.IsCompleted);
                UpdateSubTaskViewCompleteCounter.Invoke(new UpdateSubTaskViewCompleteCounterEventArgs(args.STV.GetParentProjectID(), args.STV.GetParentTaskID()));
            }
            catch (KeyNotFoundException) { return; }

        }

        private void Stv_SubTaskDeleted(SubTaskDeletedEventArgs arg)
        {
            try
            {
                SubTaskviews.Remove(arg.STV.GetID());
                Projects[arg.STV.GetParentProjectID()].GetTasks()[arg.STV.GetParentTaskID()].RemoveSubTask(arg.STV.GetID());
                arg.STV.Dispose();
            }
            catch (KeyNotFoundException) { return; }
        }
        #endregion

        #endregion
    }
}
