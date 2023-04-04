using DoYourTasks.UserControls.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoYourTasks.UserControls
{
    public partial class ProjectView : UserControl
    {
        #region CustomEvents
        public event SetProjectViewEventHandler SetProjectView;
        public event ProjectViewDeletedEventHandler ProjectViewDeleted;
        public event ProjectViewRenamedEventHandler ProjectViewRenamed;
        public event ChangePriorityEventHandler ChangePriority;
        public event HideItemEventHandler HideProject;
        public event AddNewProjectAttachmentEventHandler AddAttachment;

        #endregion

        #region Properties
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public bool IsIndicating { get; set; }
        public bool IsHidden { get; set; }
        public string ProjectBackGroundImagePath { get; set; }
        #endregion

        #region Fields
        private bool isInEditMode = false;
        private enum ProjectPriorities
        {
            VeryLow,
            Low,
            Medium,
            High,
            Urgent,
            OnHold,
            Waiting,
            Done
        }

        #endregion

        #region Constructors
        public ProjectView(string projectID, bool isNew = true)
        {
            InitializeComponent();
            Name = "ProjectView";

            SetIndicator(false);
            EventSubscriber();
            ProjectID = projectID;
            isInEditMode = isNew;
            IsHidden = false;
            if (!isNew)
            {
                HideTB();
            }
        }
        #endregion

        #region Getters
        public string GetProjectID() { return ProjectID; }
        public CustomTextBox GetCurrentCustomTextBox()
        {
            return customTextBox.GetCurrentCustomTextBox();
        }

        public bool GetIsInEditMode()
        {
            return isInEditMode;
        }

        public string GetBackGroundImage()
        {
            return ProjectBackGroundImagePath;
        }

        public bool GetIndicator()
        {
            return IsIndicating;
        }

        public string GetProjectName()
        {
            return customTextBox.Text;
        }
        #endregion

        #region Setters

        public void SetIndicator(bool mode)
        {
            IsIndicating = mode;

            if (mode)
            {
                pnlIndicator.Show();
                btnEditListName.Show();
                while (Height < MaximumSize.Height)
                    Height += 20;
                //Height = MaximumSize.Height;
            }
            else
            {
                pnlIndicator.Hide();
                btnEditListName.Hide();
                while (Height > MaximumSize.Height)
                    Height -= 20;
                //Height = MaximumSize.Height;
            }

        }


        public void SetPriority(int priority = 0, bool isNew = false)
        {
            switch (priority)
            {
                case (int)ProjectPriorities.VeryLow:
                    if (!isNew)//loaing from saved data
                    {
                        lblProjPriority.BackColor = Color.Cyan;
                        lblProjPriority.ForeColor = Color.Black;
                        lblProjPriority.Text = "Very Low";//current
                        priority = (int)ProjectPriorities.Done;//loop (previous)
                    }
                    else
                    {
                        SetPriority((int)ProjectPriorities.Low);//Next
                    }
                    break;
                case (int)ProjectPriorities.Low:
                    if (!isNew)//loaing from saved data
                    {
                        lblProjPriority.BackColor = Color.DeepSkyBlue;
                        lblProjPriority.ForeColor = Color.Black;
                        lblProjPriority.Text = "Low";
                        priority = (int)ProjectPriorities.VeryLow;
                    }
                    else
                    {
                        SetPriority((int)ProjectPriorities.Medium);
                    }
                    break;
                case (int)ProjectPriorities.Medium:
                    if (!isNew)//loaing from saved data
                    {
                        lblProjPriority.BackColor = Color.Blue;
                        lblProjPriority.ForeColor = Color.White;
                        lblProjPriority.Text = "Medium";
                        priority = (int)ProjectPriorities.Low;
                    }
                    else
                    {
                        SetPriority((int)ProjectPriorities.High);
                    }
                    break;
                case (int)ProjectPriorities.High:
                    if (!isNew)//loaing from saved data
                    {
                        lblProjPriority.BackColor = Color.Yellow;
                        lblProjPriority.ForeColor = Color.Black;
                        lblProjPriority.Text = "High";
                        priority = (int)ProjectPriorities.Medium;
                    }
                    else
                    {
                        SetPriority((int)ProjectPriorities.Urgent);
                    }
                    break;
                case (int)ProjectPriorities.Urgent:
                    if (!isNew)//loaing from saved data
                    {
                        lblProjPriority.BackColor = Color.Red;
                        lblProjPriority.ForeColor = Color.Yellow;
                        lblProjPriority.Text = "Urgent";
                        priority = (int)ProjectPriorities.High;
                    }
                    else
                    {
                        SetPriority((int)ProjectPriorities.OnHold);
                    }
                    break;
                case (int)ProjectPriorities.OnHold:
                    if (!isNew)//loaing from saved data
                    {
                        lblProjPriority.BackColor = Color.Black;
                        lblProjPriority.ForeColor = Color.White;
                        lblProjPriority.Text = "On Hold";
                        priority = (int)ProjectPriorities.Urgent;
                    }
                    else
                    {
                        SetPriority((int)ProjectPriorities.Waiting);
                    }
                    break;
                case (int)ProjectPriorities.Waiting:
                    if (!isNew)//loaing from saved data
                    {
                        lblProjPriority.BackColor = Color.Orange;
                        lblProjPriority.ForeColor = Color.Black;
                        lblProjPriority.Text = "Waiting";
                        priority = (int)ProjectPriorities.OnHold;
                    }
                    else
                    {
                        SetPriority((int)ProjectPriorities.Done);
                    }
                    break;
                case (int)ProjectPriorities.Done:
                    if (!isNew)//loaing from saved data
                    {
                        lblProjPriority.BackColor = Color.Green;
                        lblProjPriority.ForeColor = Color.White;
                        lblProjPriority.Text = "Done";
                        priority = (int)ProjectPriorities.OnHold;
                    }
                    else
                    {
                        SetPriority((int)ProjectPriorities.VeryLow);
                    }
                    break;
            }//switch
            ChangePriority.Invoke(new ChangePriorityEventArgs(this, "project", priority));
        }

        public bool GetIsHidden()
        {
            return IsHidden;
        }

        public void SetHidden(bool isHidden)
        {
            IsHidden = isHidden;
        }



        public void SetIsInEditMode(bool mode)
        {
            isInEditMode = mode;
            customTextBox.SetIsInEdit(mode);
        }

        public void SetTasksLabel(string tasks)
        {
            lblTaskCount.Text = tasks;
            lblTaskCount.Visible = true;
        }

        public void SetBackGroundImage(string imagePath)
        {
            ProjectBackGroundImagePath = imagePath;
        }

        public void Rename(string text)
        {
            customTextBox.Text = text;
            customTextBox.SetText(text);
            //customTextBox.Show();
            //customTextBox.Visible = true;
            ProjectViewRenamed.Invoke(new RenameProjectEventArgs(ProjectID, customTextBox.GetText()));
            HideTB();
        }

        public void HideTB()
        {
            //customTextBox.Hide();
            SetIsInEditMode(false);
        }
        #endregion

        #region Events
        private void EventSubscriber()
        {
            GotFocus += ProjectView_GotFocus;
            LostFocus += ProjectView_LostFocus;
            customTextBox.gotHidden += CustomTextBox_gotHidden;
        }

        private void CustomTextBox_gotHidden(bool isHidden, EventArgs arg)
        {
            string text = customTextBox.GetText();

            if (!string.IsNullOrEmpty(text))
            {
                Rename(text);
                SetProjectView.Invoke(new SetProjectViewEventArgs(this));
                Height = MaximumSize.Height;
                btnEditListName.Show();
                SetIsInEditMode(false);
            }
            else
                return;
        }

        private void ProjectView_LostFocus(object sender, EventArgs e)
        {
            SetIndicator(false);
        }

        private void ProjectView_GotFocus(object sender, EventArgs e)
        {
            SetProjectView.Invoke(new SetProjectViewEventArgs(this));
        }

        private void btnEditListName_Click(object sender, EventArgs e)
        {
            //customTextBox.ResetText();
            btnEditListName.Hide();
            Height = MinimumSize.Height;
            customTextBox.Show();
            SetIsInEditMode(true);
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to delete this Project?\nThis cannot be reversed!", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
                ProjectViewDeleted.Invoke(new ProjectViewDeletedEventArgs(this));
            else
                return;
        }




        public void btnAddProjectAttachment_Click()
        {
            AddAttachment.Invoke();
        }

        //private void SetHideButtonText(string text) { btnHideProject.Text = text; }

        public void btnHideProject_Click()
        {
            IsHidden = !IsHidden;

            //if (GetIsHidden())
            //SetHideButtonText("Show Project");
            //else
            //SetHideButtonText("Hide Project");

            HideProject.Invoke(new HideItemEventArgs(this));
        }

        //private void comboBoxChangePriority_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int priority = 0;

        //    switch (comboBoxChangePriority.SelectedItem.ToString())
        //    {
        //        case "On Hold":
        //            priority = (int)PriorityCodes.OnHold;
        //            break;
        //        case "Very Low":
        //            priority = (int)PriorityCodes.VeryLow;
        //            break;
        //        case "Low":
        //            priority = (int)PriorityCodes.Low;
        //            break;
        //        case "Medium":
        //            priority = (int)PriorityCodes.Medium;
        //            break;
        //        case "High":
        //            priority = (int)PriorityCodes.High;
        //            break;
        //        case "Urgent":
        //            priority = (int)PriorityCodes.Urgent;
        //            break;
        //        case "Waiting":
        //            priority = (int)PriorityCodes.Waiting;
        //            break;
        //        case "Done":
        //            priority = (int)PriorityCodes.Done;
        //            break;
        //    }
        //    SetPriority(priority);
        //}

        public string GetProjectPrioritySTR()
        {
            return lblProjPriority.Text;
        }
    }
}