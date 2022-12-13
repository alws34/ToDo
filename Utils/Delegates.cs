using DoYourTasks.UserControls;
using System;
using System.Windows.Forms;

namespace DoYourTasks
{
    #region Utils
    public delegate void SetPlaceHolderEventHandler(SetPlaceHolderEventArgs arg);
    public class SetPlaceHolderEventArgs : EventArgs
    {
        public TextBox TB { get; set; }
        public SetPlaceHolderEventArgs(TextBox tb)
        {
            TB = tb;
        }
    }



    #endregion

    #region Project
    public delegate void SetProjectViewEventHandler(SetProjectViewEventArgs arg);
    public class SetProjectViewEventArgs : EventArgs
    {
        public ProjectView PV { get; set; }
        public SetProjectViewEventArgs(ProjectView pv)
        {
            PV = pv;
        }
    }

    public delegate void ProjectViewRenamedEventHandler(RenameProjectEventArgs args);
    public class RenameProjectEventArgs : EventArgs
    {
        public string ProjectID { get; }
        public string ProjectName { get; set; }
        public RenameProjectEventArgs(string projectID, string projectName)
        {
            ProjectID = projectID;
            ProjectName = projectName;
        }
    }

    public delegate void SetIndicatorEventHandler(SetIndicatorEventArgs arg);
    public class SetIndicatorEventArgs : EventArgs
    {
        public Panel Indicator { get; set; }
        public SetIndicatorEventArgs(Panel indicator)
        {
            Indicator = indicator;
        }
    }


    public delegate void ProjectViewDeletedEventHandler(ProjectViewDeletedEventArgs arg);
    public class ProjectViewDeletedEventArgs : EventArgs
    {
        public ProjectView ProjectView { get; set; }
        public ProjectViewDeletedEventArgs(ProjectView projectView)
        {
            ProjectView = projectView;
        }
    }


    #endregion

    #region Task
    public delegate void UpdateCurrentTaskViewEventHandler(UpdateCurrentTaskViewEventArgs arg);
    public class UpdateCurrentTaskViewEventArgs : EventArgs
    {
        public TaskView TaskView { get; set; }
        public UpdateCurrentTaskViewEventArgs(TaskView tv)
        {
            TaskView = tv;
        }
    }
    #endregion

    #region SubTask
    public delegate void UpdateSubTaskViewEventHandler(UpdateSubTaskViewEventArgs arg);
    public class UpdateSubTaskViewEventArgs : EventArgs
    {
        public SubTaskView SubTaskView { get; set; }
        public UpdateSubTaskViewEventArgs(SubTaskView subtaskview)
        {
            SubTaskView = subtaskview;
        }
    }
    #endregion
}
