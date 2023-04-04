using DoYourTasks.UserControls;
using System;
using System.Windows.Forms;

namespace DoYourTasks
{
    #region General
    public delegate void ChangePriorityEventHandler(ChangePriorityEventArgs arg);
    /// <summary>
    /// Type: Priority - "Dont proceed" : 1, "Very Low" : 2, "Low" : 3, "Medium" : 4, "High" : 5, "Urgent" : 6 
    /// </summary>
    public class ChangePriorityEventArgs : EventArgs
    {
        public string Type { get; set; } 
        public int Priority { get; set; }
        public object Control { get; set; }
        public ChangePriorityEventArgs(object control,string type, int priority)
        {
            Type = type;
            Priority = priority;
            Control = control;
        }
    }

    public delegate void HideItemEventHandler(HideItemEventArgs arg);
    public class HideItemEventArgs : EventArgs
    {
        public Control Control { get; set; }
        public HideItemEventArgs(Control control)
        {
            Control = control;
        }
    }

    #endregion


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
    public delegate void AddNewProjectAttachmentEventHandler();


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
    public delegate void UpdateCurrentTaskViewEventHandler(UpdateCurrentTaskViewEventArgs args);
    public class UpdateCurrentTaskViewEventArgs : EventArgs
    {
        public TaskView TaskView { get; set; }
        public UpdateCurrentTaskViewEventArgs(TaskView tv)
        {
            TaskView = tv;
        }
    }

    public delegate void PriorityChangedEventHandler(PriorityChangedEventArgs args);
    public class PriorityChangedEventArgs : EventArgs
    {
        public TaskView TaskView { get; set; }
        public int Priority { get; set; }
        public PriorityChangedEventArgs(TaskView tv, int priority)
        {
            TaskView = tv;
            Priority = priority;
        }
    }


    public delegate void TaskRenamedEventHandler(TaskRenamedEventArgs args);
    public class TaskRenamedEventArgs : EventArgs
    {
        public TaskView TaskView { get; set; }
        public TaskRenamedEventArgs(TaskView tv) { TaskView = tv; }
    }


    public delegate void TaskDueDateChangedEventHandler(DueDateChangedEventArgs args);
    public class DueDateChangedEventArgs : EventArgs
    {
        public TaskView TaskView { get; set; }
        public string DueDate { get; set; }
        public DueDateChangedEventArgs(TaskView tv, string date) { 
            TaskView = tv;
            DueDate = date;
        }
    }

    public delegate void CustomCBcheckedChangedEventHandler(CustomCBcheckedChangedEventArgs args);
    public class CustomCBcheckedChangedEventArgs : EventArgs
    {
        public CustomRadioButton CRB { get; set; }
        public CustomCBcheckedChangedEventArgs(CustomRadioButton crb)
        {
            CRB = crb;
        }
    }

    public delegate void TaskCompletedEventHandler(TaskCompletedEventArgs args);
    public class TaskCompletedEventArgs : EventArgs
    {
        public TaskView TV { get; set; }
        public TaskCompletedEventArgs(TaskView tv)
        {
            TV = tv;
        }
    }

    public delegate void TaskModifierEventHandler(TaskModifiedEventArgs args);
    public class TaskModifiedEventArgs : EventArgs
    {
        public TaskView TV { get; set; }
        public TaskModifiedEventArgs(TaskView tv)
        {
            TV = tv;
        }
    }

    #endregion

    #region SubTask
    public delegate void SubTaskCompletedEventHandler(SubTaskCompletedEventArgs args);
    public class SubTaskCompletedEventArgs : EventArgs
    {
        public SubTaskView STV { get; set; }
        public SubTaskCompletedEventArgs(SubTaskView stv)
        {
            STV = stv;
        }
    }

    public delegate void UpdateSubTaskViewEventHandler(UpdateSubTaskViewEventArgs arg);
    public class UpdateSubTaskViewEventArgs : EventArgs
    {
        public SubTaskView SubTaskView { get; set; }
        public UpdateSubTaskViewEventArgs(SubTaskView subtaskview)
        {
            SubTaskView = subtaskview;
        }
    }

    public delegate void NewSubTaskViewEventHandler(SubTaskDeletedEventArgs arg);
    public delegate void SubTaskDeletedEventHandler(SubTaskDeletedEventArgs arg);
    public class SubTaskDeletedEventArgs : EventArgs
    {
        public SubTaskView STV { get; set; }
        public SubTaskDeletedEventArgs(SubTaskView stv)
        {
            STV = stv;
        }
    }

    public delegate void UpdateSubTaskViewCompleteCounterEventHandler(UpdateSubTaskViewCompleteCounterEventArgs arg);
    public class UpdateSubTaskViewCompleteCounterEventArgs : EventArgs
    {
        public string ParentProjectID { get; set; }
        public string ParentTaskID { get; set; }
        public UpdateSubTaskViewCompleteCounterEventArgs(string parentProjectID, string parentTaskID)
        {
            ParentProjectID = parentProjectID;
            ParentTaskID = parentTaskID;
        }
    }
    #endregion

    #region Attachments

    public delegate void AttachmentRemovedEventHandler(AttachmentRemovedEventArgs arg);
    public class AttachmentRemovedEventArgs : EventArgs
    {
        public UCAttachmentView Attachment { get; set; }
        public AttachmentRemovedEventArgs(UCAttachmentView attachment)
        {
            Attachment = attachment;
        }
    }
    #endregion

    public enum PriorityCodes
    {
        VeryLow,
        Low,
        Medium,
        High,
        Urgent,
        OnHold,
        Waiting,
        Done
    };

}
