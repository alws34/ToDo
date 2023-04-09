using DoYourTasks.Properties;
using DoYourTasks.UserControls.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Xaml.Controls;

namespace DoYourTasks.UserControls
{
    public partial class ProjectView : System.Windows.Forms.UserControl
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
        private Timer isExitAnimating = new Timer() { Interval = 2500 };
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
        public ProjectView(string projectID, Theme theme, bool isNew = true)
        {
            InitializeComponent();

            Name = "ProjectView";

            SetIndicator(false);
            EventSubscriber();
            ProjectID = projectID;
            isInEditMode = isNew;
            IsHidden = false;
            if (!isNew)
                HideTB();

            isExitAnimating.Tick += IsExitAnimating_Tick; // exit button (gif) "animation" control

            //SetTheme(theme);

        }
        #endregion

        #region Getters

        public string GetProjectPrioritySTR() { return lblProjPriority.Text; }

        public string GetProjectID() { return ProjectID; }

        public CustomTextBox GetCurrentCustomTextBox() { return ctbProjectName.GetCurrentCustomTextBox(); }

        public bool GetIsInEditMode() { return isInEditMode; }

        public string GetBackGroundImage() { return ProjectBackGroundImagePath; }

        public bool GetIndicator() { return IsIndicating; }

        public string GetProjectName() { return ctbProjectName.Text; }
        #endregion

        #region Setters
        public void SetTheme(Theme theme)
        {

            BackColor = theme.BackColor;
            ForeColor = theme.ForeColor;

            btnEditListName.ForeColor = ForeColor;
            lblTaskCount.ForeColor = ForeColor;

            btnEditListName.BackColor = BackColor;
            btnEditListName.ForeColor = ForeColor;

            ctbProjectName.BackColor = BackColor;
            ctbProjectName.BorderColor = BackColor;
            ctbProjectName.SetTBBackColor(BackColor);
            ctbProjectName.SetTBForeColor(ForeColor);
        }

        public void SetImages(bool mode)
        {
            if (mode)
            {
                pbDeleteProject.Image = Resources._39_trash_solid_black;
            }
            else
                pbDeleteProject.Image = Resources._39_trash_solid_white;
        }
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
            if (ChangePriority != null)
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
            ctbProjectName.SetIsInEdit(mode);
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
            ctbProjectName.Text = text;
            ctbProjectName.SetText(text);
            //customTextBox.Show();
            //customTextBox.Visible = true;
            ProjectViewRenamed.Invoke(new RenameProjectEventArgs(ProjectID, ctbProjectName.GetText()));
            HideTB();
        }

        public void HideTB()
        {
            //customTextBox.Hide();
            SetIsInEditMode(false);
        }
        #endregion

        #region Events
        private void IsExitAnimating_Tick(object sender, EventArgs e)
        {
            pbDeleteProject.Enabled = false;
            pbDeleteProject.Image = pbDeleteProject.Image;
        }

        private void pbDeleteProject_MouseEnter(object sender, EventArgs e)
        {
            if (!pbDeleteProject.Enabled)
                pbDeleteProject.Enabled = true;
            isExitAnimating.Enabled = true;
        }

        private void pbDeleteProject_MouseLeave(object sender, EventArgs e)
        {
            this.pbDeleteProject.Enabled = false;
        }

        private void EventSubscriber()
        {
            GotFocus += ProjectView_GotFocus;
            LostFocus += ProjectView_LostFocus;
            ctbProjectName.gotHidden += CustomTextBox_gotHidden;
        }

        private void CustomTextBox_gotHidden(bool isHidden, EventArgs arg)
        {
            string text = ctbProjectName.GetText();

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
            ctbProjectName.Show();
            SetIsInEditMode(true);
        }

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

        public void btnHideProject_Click()
        {
            IsHidden = !IsHidden;
            HideProject.Invoke(new HideItemEventArgs(this));
        }

        #endregion Events
    }
}