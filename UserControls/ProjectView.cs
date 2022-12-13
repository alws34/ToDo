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
        public event SetProjectViewEventHandler SetProjectView;
        public event ProjectViewDeletedEventHandler ProjectViewDeleted;
        public event ProjectViewRenamedEventHandler ProjectViewRenamed;

        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public bool IsIndicating { get; set; }

        public ProjectView(string projectID)
        {
            InitializeComponent();
            SetIndicator(false);
            EventSubscriber();
            Name = "ProjectView";
            ProjectID = projectID;
        }

        private void EventSubscriber()
        {
            GotFocus += ProjectView_GotFocus;
            LostFocus += ProjectView_LostFocus;
            customTextBox.gotHidden += CustomTextBox_gotHidden;
        }

        public void SetIndicator(bool mode)
        {//this can be replaced with "visible"
            pnlIndicator.Hide();
            IsIndicating = mode;

            if (mode)
            {
                pnlIndicator.Show();
                IsIndicating = mode;
            }
        }
        public bool GetIndicator()
        {
            return IsIndicating;
        }

        public string GetProjName()
        {
            return lblName.Text;
        }

        public void SetProjectName(string text)
        {
            lblName.Text = text;
            ProjectViewRenamed.Invoke(new RenameProjectEventArgs(ProjectID, customTextBox.GetText()));
        }
   
        
        #region Events
        private void CustomTextBox_gotHidden(bool isHidden, EventArgs arg)
        {
            SetProjectName(customTextBox.GetText());
        }

        private void ProjectView_LostFocus(object sender, EventArgs e)
        {
            SetIndicator(false);
        }

        private void ProjectView_GotFocus(object sender, EventArgs e)
        {
            SetProjectView.Invoke(new SetProjectViewEventArgs(this));
        }

        private void custombuttonDelete_Click(object sender, EventArgs e)
        {
            ProjectViewDeleted.Invoke(new ProjectViewDeletedEventArgs(this));
        }

        private void btnEditListName_Click(object sender, EventArgs e)
        {
            customTextBox.ResetText();
            customTextBox.Show();
        }
        #endregion
    }
}
