﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DoYourTasks.UserControls
{
    public partial class TaskView : UserControl, IViewable
    {
        #region CustomEvents
        public event UpdateCurrentTaskViewEventHandler UpdateTaskView;
        public event TaskCompletedEventHandler TaskCompleted;
        public event TaskModifierEventHandler TaskDeleted;
        public event TaskDueDateChangedEventHandler DueDateChanged;
        public event TaskRenamedEventHandler TaskRenamed;
        public event AttachmentRemovedEventHandler AttachemntRemoved;
        public event PriorityChangedEventHandler PriorityChanged;
        public event HideItemEventHandler HideTask;
        public event TaskModifierEventHandler AddTaskAttachment;

        #endregion

        #region Fields
        private Color startBackgroundColor;
        private bool isCompleted = false;
        public bool isHidden { get; set; }
        private Theme Theme { get; set; }
        private string taskID;
        private string parentProjectID;
        ToolTip toolTip = new ToolTip();
        int currentPriority = (int)PriorityCodes.Low;
        int nextPriority = (int)PriorityCodes.Medium;
        Utils.NotificationType notificationType = Utils.NotificationType.None;
        #endregion

        #region Constructors
        public TaskView(string taskName, string id, string parentProjectID, int priority, Theme theme)
        {
            InitializeComponent();
            SetBackColor();
            taskID = id;
            this.parentProjectID = parentProjectID;
            Rename(taskName);
            Name = "TaskView";
            SubscribeToEvents();
            SetDueDate("No Due Date");
            DoubleBuffered = true;
            SetPriority(priority);
            //lblTaskName.Location = new Point(40, 3);

            comboBoxChangePriority.Items.Add(PriorityCodes.VeryLow.ToString());
            comboBoxChangePriority.Items.Add(PriorityCodes.Low.ToString());
            comboBoxChangePriority.Items.Add(PriorityCodes.Medium.ToString());
            comboBoxChangePriority.Items.Add(PriorityCodes.High.ToString());
            comboBoxChangePriority.Items.Add(PriorityCodes.Urgent.ToString());
            comboBoxChangePriority.Items.Add(PriorityCodes.OnHold.ToString());
            comboBoxChangePriority.Items.Add(PriorityCodes.Waiting.ToString());
            comboBoxChangePriority.Items.Add(PriorityCodes.Done.ToString());
            comboBoxChangePriority.Text = "Set Task Priority";

            comboBoxChangePriority.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxChangePriority.AutoCompleteSource = AutoCompleteSource.ListItems;

            //Utils utils = new Utils();
            //utils.RoundCorners(this, null);
            SetTheme(theme);
        }

        #endregion

        #region Getters
        public bool GetDidNotify()
        {
            return pbStatus.Enabled;
        }


        public string GetDueDate()
        {
            if (!string.IsNullOrWhiteSpace(lblDueDateVal.Text))
                return lblDueDateVal.Text;
            return "No Due Date";

        }
        public string GetParentTaskID()
        {
            return parentProjectID;
        }

        public string GetName()
        {
            return ctbTaskName.GetText();
        }

        public string GetTaskID()
        {
            return taskID;
        }

        public string GetParentProjectID()
        {
            return parentProjectID;
        }
        public bool GetCheckedState()
        {
            return customRadioButtonTaskName.Checked;
        }
        public bool GetIsHidden()
        {
            return isHidden;
        }

        public Utils.NotificationType GetNotificationType() {

            return notificationType;
        }
        #endregion

        #region Setters

        public void SetPBStatus(Utils.NotificationType type)
        {
            Utils u = new Utils();
            notificationType = type;
            if (type == Utils.NotificationType.None)
            {
                pbStatus.Image = null;
                return;
            }

            pbStatus.Image = u.GetNotificationImages(type, Theme);
            if (!pbStatus.Enabled)
                pbStatus.Enabled = true;
        }

        private void SetIsHidden(bool mode) { isHidden = mode; }

        public void LoadTaskViewAttachments(List<Attachment> attachments)
        {
            flpAttachments.Controls.Clear();

            foreach (Attachment attachment in attachments)
            {
                UCAttachmentView uav = new UCAttachmentView(attachment);
                uav.AttachemntRemoved += AttachemntRemoved;
                flpAttachments.Controls.Add(uav);
            }

            SetAttachmentsCountLbl();
            ResizeAttachmentsFLP();
        }

        public void SetAttachmentsCountLbl()
        {
            lblAttachmentsCount.Text = flpAttachments.Controls.Count.ToString();
        }

        public void SetCompletedOn(string date) { lblCompletedOn.Text = date; }

        private void SetPriority(int priority)
        {
            switch (priority)
            {
                case (int)PriorityCodes.VeryLow:
                    currentPriority = (int)PriorityCodes.VeryLow;
                    pnlPriority.BackColor = Color.Cyan;
                    lblPriorityLvl.ForeColor = Color.Black;
                    lblPriorityLvl.Text = "Very Low";
                    break;
                case (int)PriorityCodes.Low:
                    currentPriority = (int)PriorityCodes.Low;
                    pnlPriority.BackColor = Color.DeepSkyBlue;
                    lblPriorityLvl.ForeColor = Color.Black;
                    lblPriorityLvl.Text = "Low";
                    break;
                case (int)PriorityCodes.Medium:
                    currentPriority = (int)PriorityCodes.Medium;
                    pnlPriority.BackColor = Color.Blue;
                    lblPriorityLvl.ForeColor = Color.White;
                    lblPriorityLvl.Text = "Medium";
                    break;
                case (int)PriorityCodes.High:
                    currentPriority = (int)PriorityCodes.High;
                    pnlPriority.BackColor = Color.Yellow;
                    lblPriorityLvl.ForeColor = Color.Black;
                    lblPriorityLvl.Text = "High";
                    break;
                case (int)PriorityCodes.Urgent:
                    currentPriority = (int)PriorityCodes.Urgent;
                    pnlPriority.BackColor = Color.Red;
                    pnlPriority.ForeColor = Color.Yellow;
                    lblPriorityLvl.Text = "Urgent";
                    break;
                case (int)PriorityCodes.OnHold:
                    currentPriority = (int)PriorityCodes.OnHold;
                    pnlPriority.BackColor = Color.Black;
                    lblPriorityLvl.ForeColor = Color.White;
                    lblPriorityLvl.Text = "On Hold";
                    break;
                case (int)PriorityCodes.Waiting:
                    currentPriority = (int)PriorityCodes.Waiting;
                    pnlPriority.BackColor = Color.Orange;
                    lblPriorityLvl.ForeColor = Color.White;
                    lblPriorityLvl.Text = "Waiting";
                    break;
                case (int)PriorityCodes.Done:
                    currentPriority = (int)PriorityCodes.Done;
                    pnlPriority.BackColor = Color.Green;
                    lblPriorityLvl.ForeColor = Color.White;
                    lblPriorityLvl.Text = "Done";
                    break;
            }
            if (PriorityChanged != null)
                PriorityChanged.Invoke(new PriorityChangedEventArgs(this, currentPriority));
        }

        public void SetDueDate(string Duedate)
        {
            lblDueDateVal.Show();
            lblDueDateVal.Text = $"{Duedate}";
            //DueDateChanged.BeginInvoke(new DueDateChangedEventArgs(null));
        }

        public void SetDateCreated(DateTime dateTime)
        {
            lblCreatedAtVal.Text = $"{dateTime.ToString("dd/MM/yy HH:mm tt")}";
            lblCreatedAtVal.Visible = true;

        }

        private void SetBackColor()
        {
            startBackgroundColor = customRadioButtonTaskName.BackColor;
        }

        //private void SetForeColor(Color color)
        //{
        //    customRadioButtonTaskName.ForeColor = color;
        //}

        public void SetCheckedState(bool mode)
        {
            customRadioButtonTaskName.Checked = mode;
        }


        private void SubscribeToEvents()
        {
            customRadioButtonTaskName.customCheckedChanged += CustomRadioButtonTaskName_checkedChanged;
            ctbTaskName.gotHidden += CtbTaskName_gotHidden; ;
        }

        private void CtbTaskName_gotHidden(bool isHidden, EventArgs arg)
        {
            //lblTaskName.Text = ctbTaskName.GetText();
            //lblTaskName.Visible = true;

            ctbTaskName.BorderColor = Color.FromArgb(71, 71, 71);
            TaskRenamed.Invoke(new TaskRenamedEventArgs(this));
        }
        #endregion

        #region Modifiers
        public void Rename(string newName)
        {
            ctbTaskName.SetText(newName);
            ctbTaskName.Visible = true;
        }

        public void Delete()
        {
            //throw new NotImplementedException();
        }

        public void SetTheme(Theme theme)
        {
            Theme = theme;
            BackColor = theme.BackColor;
            ForeColor = theme.ForeColor;

            lblPriority.BackColor = BackColor;
            lblSubTasks.BackColor = BackColor;
            lblAttachments.BackColor = BackColor;
            lblDueDate.BackColor = BackColor;
            lblCreatedAt.BackColor = BackColor;
            lblDateCompleted.BackColor = BackColor;
            lblCompletedSubTasks.BackColor = BackColor;
            lblAttachmentsCount.BackColor = BackColor;
            lblDueDateVal.BackColor = BackColor;
            lblCreatedAtVal.BackColor = BackColor;
            lblCompletedOn.BackColor = BackColor;
            btnHideTask.BackColor = BackColor;
            btnRemoveDueDate.BackColor = BackColor;
            btnRemoveDueDate.BorderColor = BackColor;
            lblSelectDueDate.BackColor = BackColor;
            btnAddAttachment.BackColor = BackColor;
            pnlColorIndicator.BackColor = BackColor;
            ctbTaskName.BackColor = BackColor;
            ctbTaskName.BorderColor = BackColor;
            ctbTaskName.SetTBBackColor(BackColor);
            customRadioButtonTaskName.BackColor = BackColor;
            flpAttachments.BackColor = BackColor;
            btnDelete.BackColor = BackColor;
            btnEditTaskName.BackColor = BackColor;

            ctbTaskName.ForeColor = ForeColor;
            ctbTaskName.SetTBForeColor(ForeColor);

            btnHideTask.BorderColor = ForeColor;
            btnRemoveDueDate.BorderColor = ForeColor;
            btnAddAttachment.BorderColor = ForeColor;
            btnEditTaskName.BorderColor = ForeColor;
            btnEditTaskName.ForeColor = ForeColor;
            btnDelete.ForeColor = ForeColor;
            lblPriority.ForeColor = ForeColor;
            lblSubTasks.ForeColor = ForeColor;
            lblAttachments.ForeColor = ForeColor;
            lblDueDate.ForeColor = ForeColor;
            lblCreatedAt.ForeColor = ForeColor;
            lblDateCompleted.ForeColor = ForeColor;
            lblCompletedSubTasks.ForeColor = ForeColor;
            lblAttachmentsCount.ForeColor = ForeColor;
            lblDueDateVal.ForeColor = ForeColor;
            lblCreatedAtVal.ForeColor = ForeColor;
            lblCompletedOn.ForeColor = ForeColor;
            btnHideTask.ForeColor = ForeColor;
            btnRemoveDueDate.ForeColor = ForeColor;
            lblSelectDueDate.ForeColor = ForeColor;
            btnAddAttachment.ForeColor = ForeColor;
            pnlColorIndicator.ForeColor = ForeColor;
            customRadioButtonTaskName.ForeColor = ForeColor;
            flpAttachments.ForeColor = ForeColor;

            SetPBStatus(GetNotificationType());
        }

        public void ResizeAttachmentsFLP()
        {
            //foreach (Control control in flpAttachments.Controls)
            //{
            //    if (control.GetType().Name == "UCAttachmentView")
            //    {
            //        //flpAttachments.Height += control.Height;
            //        //control.Visible = true;
            //        //Height += control.Height;
            //    }
            //}
            //Height -= 10;
            return;

        }
        #endregion

        #region Events
        private void comboBoxChangePriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            int priority = 0;

            switch (comboBoxChangePriority.SelectedItem.ToString())
            {
                case "On Hold":
                    priority = (int)PriorityCodes.OnHold;
                    break;
                case "Very Low":
                    priority = (int)PriorityCodes.VeryLow;
                    break;
                case "Low":
                    priority = (int)PriorityCodes.Low;
                    break;
                case "Medium":
                    priority = (int)PriorityCodes.Medium;
                    break;
                case "High":
                    priority = (int)PriorityCodes.High;
                    break;
                case "Urgent":
                    priority = (int)PriorityCodes.Urgent;
                    break;
                case "Waiting":
                    priority = (int)PriorityCodes.Waiting;
                    break;
                case "Done":
                    priority = (int)PriorityCodes.Done;
                    break;
            }
            SetPriority(priority);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to delete this task?\nThis cannot be reversed!", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
                TaskDeleted.Invoke(new TaskModifiedEventArgs(this));
        }

        private void CustomRadioButtonTaskName_checkedChanged(CustomCBcheckedChangedEventArgs arg)
        {
            SetCompleted(arg.CRB.Checked); // set the current state of the Radiobutton.
            TaskCompleted.Invoke(new TaskCompletedEventArgs(this));//let the main form know the task is completed.
        }

        private void TaskView_Click(object sender, EventArgs e)
        {
            UpdateTaskView.Invoke(new UpdateCurrentTaskViewEventArgs(this));
            SetAttachmentsCountLbl();
        }

        public void UpdateCompletedSubTasks(int completedSubtasks, int totalSubtasks)
        {
            lblCompletedSubTasks.Text = $"{completedSubtasks}/{totalSubtasks}";
        }

        public void SetCompleted(bool mode = false)
        {
            isCompleted = mode;
            customRadioButtonTaskName.Checked = mode;
            if (mode)
            {
                ctbTaskName.GetCurrentCustomTextBox().Font = new Font(ctbTaskName.Font.FontFamily, ctbTaskName.Font.Size, FontStyle.Strikeout);
                ctbTaskName.GetCurrentCustomTextBox().Refresh();
                SetPriority((int)PriorityCodes.Done);
                lblCompletedOn.Text = DateTime.Now.ToString("dd/MM/yy");
                SetPBStatus(Utils.NotificationType.Success);
            }
            else
            {
                ctbTaskName.GetCurrentCustomTextBox().Font = new Font(ctbTaskName.Font.FontFamily, ctbTaskName.Font.Size);
                lblCompletedOn.Text = "";
                SetPBStatus(Utils.NotificationType.None);
            }
            //customRadioButtonTaskName.Refresh();
        }

        private void pnlColorIndicator_MouseEnter(object sender, EventArgs e)
        {
            SetMouseOverTheme(Color.Gray, Color.Black);
        }

        private void pnlColorIndicator_MouseLeave(object sender, EventArgs e)
        {
            SetMouseOverTheme(Theme.BackColor, Theme.ForeColor);
        }

        private void SetMouseOverTheme(Color backcolor, Color forecolor)
        {
            pnlColorIndicator.BackColor = backcolor;
            customRadioButtonTaskName.BackColor = backcolor;
            ctbTaskName.SetTBBackColor(backcolor);
            ctbTaskName.BackColor = backcolor;

            if (!ctbTaskName.GetIsInEdit())
                ctbTaskName.BorderColor = backcolor;

            if(isCompleted)
                customRadioButtonTaskName.isSelected = true;

            btnDelete.BackColor = backcolor;
            btnEditTaskName.BackColor = backcolor;
            ctbTaskName.ForeColor = backcolor;
            ctbTaskName.SetTBForeColor(forecolor);
            btnEditTaskName.ForeColor = forecolor;
            btnDelete.ForeColor = forecolor;
        }

        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            AddTaskAttachment.Invoke(new TaskModifiedEventArgs(this));
        }

        private void dateTimePicker1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string dueDate = TaskDueDatePicker.Value.ToString("dd/MM/yy HH:mm tt");
                DueDateChanged.Invoke(new DueDateChangedEventArgs(this, dueDate));
                SetDueDate(dueDate);
            }
        }

        private void TaskDueDatePicker_MouseEnter(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(TaskDueDatePicker, "Press Enter to save");
        }

        private void btnEditTaskName_Click(object sender, EventArgs e)
        {
            //ctbTaskName.SetText(lblTaskName.Text);
            //ctbTaskName.Visible = true;
            //lblTaskName.Visible = false;
            ctbTaskName.BorderColor = Color.MediumSlateBlue;
            ctbTaskName.SetIsInEdit(true);
        }

        private void btnAddDueDate_Click(object sender, EventArgs e)
        {
            string dueDate = TaskDueDatePicker.Value.ToString("dd/MM/yyyy HH:mm tt");
            lblDueDateVal.Text = dueDate;
            DueDateChangedEventArgs args = new DueDateChangedEventArgs(this, dueDate);
            DueDateChanged.Invoke(args);
        }

        private void btnRemoveDueDate_Click(object sender, EventArgs e)
        {
            string dueDate = "No Due Date";
            lblDueDateVal.Text = dueDate;
            DueDateChangedEventArgs args = new DueDateChangedEventArgs(this, dueDate);
            DueDateChanged.Invoke(args);
        }

        private void btnChangePriority_Click(object sender, EventArgs e)
        {
            currentPriority++;
            if (currentPriority > (int)PriorityCodes.Done)
                currentPriority = (int)PriorityCodes.VeryLow;
            SetPriority(currentPriority);
        }

        private void btnHideTask_Click(object sender, EventArgs e)
        {
            SetIsHidden(!isHidden);

            if (GetIsHidden())
                btnHideTask.Text = "Show Task";
            else
                btnHideTask.Text = "Hide Task";

            HideTask.Invoke(new HideItemEventArgs(this));
        }

        public int GetAttachmentsCount()
        {
            return flpAttachments.Controls.Count;
        }

        #endregion
    }
}