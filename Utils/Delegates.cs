using DoYourTasks.UserControls;
using System;
using System.Windows.Forms;

namespace DoYourTasks
{
    public delegate void SetPlaceHolderEventHandler(SetPlaceHolderEventArgs arg);
    public class SetPlaceHolderEventArgs : EventArgs
    {
        public TextBox TB { get; set; }
        public SetPlaceHolderEventArgs(TextBox tb)
        {
            TB = tb;
        }
    }

    public delegate void SetProjectViewEventHandler(SetProjectViewEventArgs arg);
    public class SetProjectViewEventArgs : EventArgs
    {
        public ProjectView PV { get; set; }
        public SetProjectViewEventArgs(ProjectView pv)
        {
            PV = pv;
        }
    }

    public delegate void SetProjectTasksViewEventHandler(SetProjectTasksViewEventArgs arg);
    public class SetProjectTasksViewEventArgs : EventArgs
    {
        public ProjectView PV { get; set; }
        public SetProjectTasksViewEventArgs(ProjectView pv)
        {
            PV = pv;
        }
    }



    public delegate void SetIndicatorEventHandlerEventHandler(SetIndicatorEventHandlerEventArgs arg);
    public class SetIndicatorEventHandlerEventArgs : EventArgs
    {
        public Panel Indicator { get; set; }
        public SetIndicatorEventHandlerEventArgs(Panel indicator)
        {
            Indicator = indicator;
        }
    }

    public delegate void UpdateSubTaskViewEventHandler(UpdateSubTaskViewEventHandlerEventArgs arg);
    public class UpdateSubTaskViewEventHandlerEventArgs : EventArgs
    {
        public SubTaskView SubTaskView { get; set; }
        public UpdateSubTaskViewEventHandlerEventArgs(SubTaskView subtaskview)
        {
            SubTaskView = subtaskview;
        }
    }


    public delegate void ProjectViewDeletedEventHandler(ProjectViewDeletedEventHandlerArgs arg);
    public class ProjectViewDeletedEventHandlerArgs : EventArgs
    {
        public ProjectView ProjectView { get; set; }
        public ProjectViewDeletedEventHandlerArgs(ProjectView projectView)
        {
            ProjectView = projectView;
        }
    }


    public delegate void UpdateCurrentTaskViewEventHandler(UpdateCurrentTaskViewEventHandlerArgs arg);
    public class UpdateCurrentTaskViewEventHandlerArgs : EventArgs
    {
        public TaskView TaskView { get; set; }
        public UpdateCurrentTaskViewEventHandlerArgs(TaskView tv)
        {
            TaskView = tv;
        }
    }


    public delegate string GetUniqueIDEventHandler(GetUniqueIDEventArgs args);
    public class GetUniqueIDEventArgs : EventArgs
    {
        public GetUniqueIDEventArgs() { }
    }
}
