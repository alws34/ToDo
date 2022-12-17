using DoYourTasks.UserControls.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        #endregion

        #region Properties
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public bool IsIndicating { get; set; }
        public string ProjectBackGroundImagePath { get; set; }
        #endregion

        #region Fields
        private bool isInEditMode = false;
        #endregion

        #region Constructors
        public ProjectView(string projectID, bool isNew = true)
        {
            InitializeComponent();
            SetIndicator(false);
            EventSubscriber();
            Name = "ProjectView";
            ProjectID = projectID;
            isInEditMode = true;

            if (!isNew)
            {
                isInEditMode = false; 
                HideTB();
            }

        }
        #endregion

        #region Getters
        public CustomTextBox GetCurrentCustomTextBox()
        {
            return customTextBox.GetCurrentCustomTextBox();
        }

        public bool GetIsInEditMode() { 
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

        public string GetProjName()
        {
            return lblName.Text;
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
                Height = MaximumSize.Height;
            }
            else
            {
                pnlIndicator.Hide();
                btnEditListName.Hide();
                Height = MinimumSize.Height;
            }

        }
      
        public void SetIsInEditMode(bool mode)
        {
            isInEditMode = mode;
        }

        public void SetBackGroundImage(string imagePath)
        {
            ProjectBackGroundImagePath = imagePath;
        }

        public void Rename(string text)
        {
            lblName.Text = text;
            customTextBox.SetText(text);
            lblName.Show();
            lblName.Visible = true;
            ProjectViewRenamed.Invoke(new RenameProjectEventArgs(ProjectID, customTextBox.GetText()));
            HideTB();
        }

        public void HideTB()
        {
            customTextBox.Hide();
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
            customTextBox.ResetText();
            btnEditListName.Hide();
            Height = MinimumSize.Height;
            customTextBox.Show();
            SetIsInEditMode(true);
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProjectViewDeleted.Invoke(new ProjectViewDeletedEventArgs(this));
        }
    }
}
