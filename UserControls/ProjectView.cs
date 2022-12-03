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
        #region Fields
        bool isIndicating = false;
        string id;
        #endregion

        #region Events
        public event SetProjectTasksViewEventHandler SetProjectTasksView;
        public event ProjectViewDeletedEventHandler ProjectViewDeleted;
        #endregion

        #region Properties
        public bool IsIndicating { get => isIndicating; set => isIndicating = value; }
        public string ID { get => id; set => id = value; }
        public List<ProjectTaskView> Tasks { get; set; }
        #endregion

        #region Constructors
        public ProjectView()
        {
            InitializeComponent();
            SetIndicator(false);
            EventSubscriber();
        }
        #endregion

        #region Methods
        private void EventSubscriber()
        {
            GotFocus += ProjectView_GotFocus;
            LostFocus += ProjectView_LostFocus;
            customTextBox.gotHidden += CustomTextBox_gotHidden;
        }

        public void SetIndicator(bool mode)
        {
            pnlIndicator.Hide();
            IsIndicating = mode;

            if (mode)
            {
                pnlIndicator.Show();
                IsIndicating = mode;
            }


        }

        public string GetProjName()
        {
            return lblName.Text;
        }
        #endregion

        #region Events
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
        #endregion
    }
}
