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

        #endregion
        #region Task
        public event UpdateCurrentTaskViewEventHandler UpdateTaskView;
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
            SaveToFile();
        }

        #endregion

        public void LoadFromDB(string path)
        {//TODO: DEBUG//
            List<string> tmpList = new List<string>() { "ProjectView", "TaskView", "SubTaskView" };


            Projects = (Dictionary<string, Project>)serializer.JsonDeserialize_(typeof(Dictionary<string, Project>), path);

            List<Project> projects = Projects.Values.ToList();

            foreach (Project project in projects)
            {
                //create the Projects Property
                Projects.Add(project.GetProjectID(), project);
                Projectviews.Add(project.GetProjectID(), CreateNewProjectView(project.GetProjectID()));

                //Start creating the views

                foreach (var task in project.GetTasks())
                {
                    Taskviews.Add(task.Value.GetTaskID(), CreateNewTaskView(task.Value.GetTaskName(), task.Value.GetTaskID(), task.Value.GetParentProjectID()));
                    foreach (var subtask in task.Value.GetSubTasks())
                    {
                        SubTaskviews.Add(subtask.Value.GetSubTaskID(), CreateSubTaskView(subtask.Value.GetParentProjectID(), subtask.Value.GetParentTaskID(), subtask.Value.GetSubTaskID(), subtask.Value.GetSubTaskName()));
                    }
                }



            }
        }

        public void SaveToFile()
        {
            serializer.JsonSerialize_((object)Projects, false);
        }

        #region ProjectViews

        #region ProjectViewsSetters
        public ProjectView CreateNewProjectView(string projectID)
        {
            ProjectView pv = new ProjectView(projectID);
            Project project = new Project(projectID);

            pv.SetProjectView += SetProjectViewOnScreen;
            pv.ProjectViewDeleted += DeletedProject;
            pv.ProjectViewRenamed += ProjectRenamed;

            AddProjectsToDicts(project, pv, projectID);

            return pv;
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
        public TaskView CreateNewTaskView(string taskName, string taskID, string projectID)
        {
            TaskView tv = new TaskView(taskName, taskID, projectID);
            tv.TaskCompleted += Tv_TaskCompleted;
            tv.TaskDeleted += Tv_TaskDeleted;
            tv.UpdateTaskView += UpdateTaskView;
            UpdateTaskView.Invoke(new UpdateCurrentTaskViewEventArgs(tv));//update task view in form

            //create the coresponding Task
            Task task = new Task(taskID, taskName, projectID);
            Projects[projectID].GetTasks().Add(taskID, task);//Add task to coresponding project

            AddTaskToDicts(task, tv, taskID);
            return tv;
        }

        private void Tv_TaskDeleted(TaskDeletedEventArgs args)
        {
            Projects[args.TV.GetParentProjectID()].RemoveTask(args.TV.GetID());
            Taskviews.Remove(args.TV.GetID());
            args.TV.Dispose();
        }

        private void Tv_TaskCompleted(TaskCompletedEventArgs args)
        {
            Projects[args.TV.GetParentProjectID()].GetTasks()[args.TV.GetID()].SetCompleted(args.TV.GetCheckedState());
        }

        private void AddTaskToDicts(Task task, TaskView taskView, string id)
        {
            Taskviews.Add(id, taskView);
            //Projects[task.GetParentProjectID()].Tasks.Add(id,task);
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
        public SubTaskView CreateSubTaskView(string projectID, string taskID, string subTaskID, string subTaskName)
        {
            SubTaskView stv = new SubTaskView(taskID, subTaskID, projectID, subTaskName);
            stv.SubTaskCompleted += Stv_SubTaskCompleted;
            stv.SubTaskDeleted += Stv_SubTaskDeleted;
            SubTask st = new SubTask(taskID, subTaskID, projectID, subTaskName);
            AddSubTaskToDicts(st, stv, projectID, taskID, subTaskID);
            UpdateSubTaskViewCompleteCounter.Invoke(new UpdateSubTaskViewCompleteCounterEventArgs(projectID, taskID));
            return stv;
        }

        private void AddSubTaskToDicts(SubTask subTask, SubTaskView subTaskView, string projectID, string taskID, string subTaskID)
        {
            SubTaskviews.Add(subTaskID, subTaskView);
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
