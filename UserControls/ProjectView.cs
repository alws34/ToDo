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
        public event SetProjectTasksViewEventHandler SetProjectTasksView;
        public event ProjectViewDeletedEventHandler ProjectViewDeleted;

        public string ID { get; set; }
        public string ProjectName { get; set; }

        public ProjectView(string projectID)
        {
            InitializeComponent();
            SetIndicator(false);
            EventSubscriber();

            ID = projectID;
        }

        private void EventSubscriber()
        {
            GotFocus += ProjectView_GotFocus;
            LostFocus += ProjectView_LostFocus;
            customTextBox.gotHidden += CustomTextBox_gotHidden;
        }

        public void SetIndicator(bool mode)
        {
            pnlIndicator.Hide();
            pc.IsIndicating = mode;

            if (mode)
            {
                pnlIndicator.Show();
                pc.IsIndicating = mode;
            }
        }

        public string GetProjName()
        {
            return lblName.Text;
        }

        private void CustomTextBox_gotHidden(bool isHidden, EventArgs arg)
        {
            lblName.Text = customTextBox.GetText();
        }

        private void ProjectView_LostFocus(object sender, EventArgs e)
        {
            SetIndicator(false);
        }

        private void ProjectView_GotFocus(object sender, EventArgs e)
        {
            SetProjectTasksView.Invoke(new SetProjectTasksViewEventArgs(this));
        }

        private void custombuttonDelete_Click(object sender, EventArgs e)
        {
            ProjectViewDeleted.Invoke(new ProjectViewDeletedEventHandlerArgs(this));
        }

        private void btnEditListName_Click(object sender, EventArgs e)
        {
            customTextBox.ResetText();
            customTextBox.Show();
            //delegate to main to change the list's name in object
        }

    }
}
