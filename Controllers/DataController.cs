using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYourTasks
{
    public class DataController
    {
        private Dictionary<string, Project> Data;
        private Utils utils;

        public DataController() {
            Data = new Dictionary<string, Project>();
            utils = new Utils();
        }


        #region Getters
        #region ProejctGetters
        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();
            return Data.Values.ToList();
            //foreach (var pair in Data)
            //    projects.Add(pair.Value);
            //return projects;
        }
        public Project GetSingleProjects(string projectID)
        {
            return Data[projectID];
        }

        #endregion
      
        #region TaskGetters
        public List<Task> GetAllProjTasks(string projectID, string taskID)
        {
            return Data[projectID].Tasks.Values.ToList();

            //List<Task> Tasks = new List<Task>();
            //foreach (KeyValuePair<string, Project> projects in Data)
            //{
            //    Project proj = projects.Value;
            //    foreach (KeyValuePair<string, Task> tasks in proj.Tasks)
            //    {
            //        Tasks.Add(tasks.Value);
            //    }
            //}
            //return Tasks;
        }
        public Task GetSingleTask(string projectID, string taskID)
        {
            return Data[projectID].Tasks[taskID];
        }
        public bool GetTaskStarredState(string projectID, string taskID)
        {
            return Data[projectID].Tasks[taskID].IsStarred;
        }
        public bool GetTaskCompleteState(string projectID, string taskID)
        {
            return Data[projectID].Tasks[taskID].IsCompleted;
        }
        public string GetTaskNotes(string projectID, string taskID)
        {
            return Data[projectID].Tasks[taskID].Note;
        }
        #endregion

        #region SubTaskGetters
        public List<SubTask> GetAllSubTaks(string projectID, string taskID)
        {
            return Data[projectID].Tasks[projectID].SubTasks.Values.ToList();
            //List<SubTask> subTasks = new List<SubTask>();
            //foreach (KeyValuePair<string, Project> projects in Data)
            //{
            //    Project proj = projects.Value;
            //    foreach (KeyValuePair<string, Task> tasks in proj.Tasks)
            //    {
            //        Task task = tasks.Value;
            //        foreach (KeyValuePair<string, SubTask> subtasks in task.SubTasks)
            //        {
            //            SubTask subtask = subtasks.Value;
            //            subTasks.Add(subtask);
            //        }
            //    }
            //}
            //return subTasks;
        }
        public SubTask GetSingleSubTaks(string projectID, string taskID, string subTaskID)
        {
            return Data[projectID].Tasks[taskID].SubTasks[subTaskID];
        }
        public bool GetSubTaskCompleteState(string projectID, string taskID, string subTaskID)
        {
            return Data[projectID].Tasks[taskID].SubTasks[subTaskID].IsCompleted;
        }
        #endregion

        #endregion

        #region Setters
        public void AddNewProject(string projectName)
        {
            Project project = new Project(utils.GetUniqueID(), projectName);
            Data.Add(project.ID, project);
        }
        public void AddNewTask(string projectID, string taskName)
        {
            Task task = new Task(utils.GetUniqueID(), taskName, projectID);
            Data[projectID].Tasks.Add(task.ID, task);
        }
        public void AddNewSubTask(string projectID, string taskID, string subTaskName)
        {
            SubTask subTask = new SubTask(subTaskName, taskID, utils.GetUniqueID());
            Data[projectID].Tasks[taskID].SubTasks.Add(subTask.ID, subTask);
        }
        #endregion

        #region Modifiers
        #region projectsModifiers
        public void RenameProject(string projectID, string newName)
        {
            Data[projectID].ProjectName = newName;
        }
        #endregion

        #region TaskModifiers
        public void RenameTask(string projectID, string taskID, string newName)
        {
            Data[projectID].Tasks[taskID].Name = newName;
        }
        public void AddTaskDueDate(string projectID, string taskID, DateTime dueDate)
        {
            Data[projectID].Tasks[taskID].DueDate = dueDate;
        }
        public void SetTaskStarredState(string projectID, string taskID, bool state)
        {
            Data[projectID].Tasks[taskID].IsStarred = state;
        }
        public void SetTaskCompletedState(string projectID, string taskID ,bool state) {
            Data[projectID].Tasks[taskID].IsStarred = state;
        }
        public void SetTaskNotes(string projectID, string taskID, string note) {
            Data[projectID].Tasks[taskID].Note = note;
        }
        #endregion

        #region SubTaskModifiers
        public void RenameSubTask(string projectID, string taskID, string subTaskID, string newName)
        {
            Data[projectID].Tasks[taskID].SubTasks[subTaskID].SubTaskName = newName;
        }
        public void SetSubTaskCompletedState(string projectID, string taskID, string subTaskID, bool state)
        {
            Data[projectID].Tasks[taskID].SubTasks[subTaskID].IsCompleted = state;
        }
        #endregion

        #endregion
    }
}
