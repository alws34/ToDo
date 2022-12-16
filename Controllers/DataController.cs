using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYourTasks
{
    public class DataController
    {
        #region Properties
        private Dictionary<string, Project> Data;
        private Utils utils;
        #endregion

        #region Constructors
        public DataController()
        {
            Data = new Dictionary<string, Project>();
            utils = new Utils();
        }

        #endregion

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
            return Data[projectID].GetTasks().Values.ToList();

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
            return Data[projectID].GetTasks()[taskID];
        }
        public bool GetTaskStarredState(string projectID, string taskID)
        {
            return Data[projectID].GetTasks()[taskID].GetIsStarred();
        }
        public bool GetTaskCompleteState(string projectID, string taskID)
        {
            return Data[projectID].GetTasks()[taskID].GetIsCompleted();
        }
        public string GetTaskNotes(string projectID, string taskID)
        {
            return Data[projectID].GetTasks()[taskID].GetNotes();
        }
        #endregion

        #region SubTaskGetters
        public List<SubTask> GetAllSubTaks(string projectID, string taskID)
        {
            return Data[projectID].GetTasks()[projectID].GetSubTasks().Values.ToList();
        }

        public SubTask GetSingleSubTaks(string projectID, string taskID, string subTaskID)
        {
            return Data[projectID].GetTasks()[taskID].GetSubTasks()[subTaskID];
        }

        public bool GetSubTaskCompleteState(string projectID, string taskID, string subTaskID)
        {
            return Data[projectID].GetTasks()[taskID].GetSubTasks()[subTaskID].GetIsCompleted();
        }

        #endregion

        #endregion

        #region Setters
        public void AddNewProject(string projectName)
        {
            Project project = new Project(utils.GetUniqueID(), projectName);
            Data.Add(project.GetProjectID(), project);
        }

        public void AddNewTask(string projectID, string taskName)
        {
            Task task = new Task(utils.GetUniqueID(), taskName, projectID);
            Data[projectID].GetTasks().Add(task.GetTaskID(), task);
        }

        public void AddNewSubTask(string projectID, string taskID, string subTaskName)
        {
            SubTask subTask = new SubTask(subTaskName, taskID, projectID, utils.GetUniqueID());
            Data[projectID].GetTasks()[taskID].AddSubTask(subTask.GetSubTaskID(), subTask);
        }
        #endregion

        #region Modifiers
        #region projectsModifiers
        public void RenameProject(string projectID, string newName)
        {
            Data[projectID].Rename(newName) ;
        }
        #endregion

        #region TaskModifiers
        public void RenameTask(string projectID, string taskID, string newName)
        {
            Data[projectID].GetTasks()[taskID].Rename(newName);
        }
        public void AddTaskDueDate(string projectID, string taskID, DateTime dueDate)
        {
            Data[projectID].GetTasks()[taskID].SetDueDate(dueDate);
        }
        public void SetTaskStarredState(string projectID, string taskID, bool state)
        {
            Data[projectID].GetTasks()[taskID].SetStarred(state);
        }
        public void SetTaskCompletedState(string projectID, string taskID, bool state)
        {
            Data[projectID].GetTasks()[taskID].SetCompleted(state);
        }
        public void SetTaskNotes(string projectID, string taskID, string note)
        {
            Data[projectID].GetTasks()[taskID].AddNotes(note);
        }
        #endregion

        #region SubTaskModifiers
        public void RenameSubTask(string projectID, string taskID, string subTaskID, string newName)
        {
            Data[projectID].GetTasks()[taskID].GetSubTasks()[subTaskID].Rename(newName);
        }

        public void SetSubTaskCompletedState(string projectID, string taskID, string subTaskID, bool state)
        {
            Data[projectID].GetTasks()[taskID].GetSubTasks()[subTaskID].SetCompleted(state);
        }
        #endregion

        #endregion
    }
}
