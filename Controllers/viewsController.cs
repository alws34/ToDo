using DoYourTasks.UserControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYourTasks
{
    public class viewsController
    {
        #region Fields
        public Dictionary<string, ProjectView> Projectviews;
        public Dictionary<string, TaskView> Taskviews;
        public Dictionary<string, SubTaskView> SubTaskviews;
        public Dictionary<string, Project> Projects;
        public Dictionary<string, Task> Tasks;
        public Dictionary<string, SubTask> SubTasks;

        Utils utils;
        Serializer serializer;
        #endregion

        #region Events
        public event SetProjectViewEventHandler SetProjectView;
        public event ProjectViewDeletedEventHandler ProjectViewDeleted;
        #endregion


        public viewsController()
        {
            Projectviews = new Dictionary<string, ProjectView>();
            Taskviews = new Dictionary<string, TaskView>();
            SubTaskviews = new Dictionary<string, SubTaskView>();
            Projects = new Dictionary<string, Project>();
            Tasks = new Dictionary<string, Task>();
            SubTasks = new Dictionary<string, SubTask>();

            utils = new Utils();
            serializer = new Serializer();
        }

        #region ProjectViews

        #region ProjectViewsSetters
        public ProjectView CreateNewProjectView(string projectID)
        {
            ProjectView pv = new ProjectView(projectID);
            Project project = new Project(projectID);

            pv.SetProjectView += SetProjectViewOnScreen;
            pv.ProjectViewDeleted += DeletedProject;

            AddProjectsToDicts(project, pv, projectID);

            return pv;
        }
        private void SetProjectViewOnScreen(SetProjectViewEventArgs args) {
            SetProjectView.Invoke(args);
        }

        private void DeletedProject(ProjectViewDeletedEventHandlerArgs args) {
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
            Projectviews[id].SetProjectName(newName);
            Projects[id].ProjectName = newName; 
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
        public TaskView CreateNewTaskView(string taskID)
        {
            TaskView tv = new TaskView(taskID);
            Task task = new Task(taskID);
            AddTaskToDicts(task, tv, taskID);
            return tv;
        }
        private void AddTaskToDicts(Task task, TaskView taskView, string id)
        {
            Taskviews.Add(id, taskView);
            Tasks.Add(id, task);
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
            Tasks[taskID].Name = newName;
        }
        public void DeleteTask(string taskID)
        {
            Taskviews.Remove(taskID);
            Tasks.Remove(taskID);
        }
        #endregion

        #endregion

        #region SubTaskView

        #region SubTaskViewSetters
        public SubTaskView CreateSubTaskView(string taskID, string subTaskID, string subTaskName)
        {
            SubTaskView stv = new SubTaskView(taskID, subTaskID, subTaskName);
            SubTask st = new SubTask(taskID, subTaskID, subTaskName);
            AddSubTaskToDicts(st, stv);
            return stv;
        }

        private void AddSubTaskToDicts(SubTask subTask, SubTaskView subTaskView) {
            SubTaskviews.Add(subTaskView.SubTaskID, subTaskView);
            SubTasks.Add(subTask.ID, subTask);
        }
        #endregion

        #region SubTaskViewGetters
        public string GetSubTaskName(string id)
        {
            return SubTaskviews[id].GetName();
        }
        #endregion

        #region SubTaskViewModifiers
        public void RenameSubTask(string id, string newName)
        {
            SubTaskviews[id].Rename(newName);
            SubTasks[id].SubTaskName = newName;
        }
        public void DeleteSubTask(string id)
        {
            SubTaskviews.Remove(id);
            SubTasks.Remove(id);
        }
        #endregion

        #endregion


    }
}
