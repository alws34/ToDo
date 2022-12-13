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
    public partial class SubTaskView : UserControl, IViewAble
    {
        #region Properties
        public string SubTaskID { get; set; }
        public string TaskID { get; set; }
        #endregion

        #region Constructors
        public SubTaskView(string parent_id, string id, string subTaskName)
        {
            InitializeComponent();
            EventSubscriber();
            TaskID = parent_id;
            SubTaskID = id;
            Name = "SubTaskView";
            Rename(subTaskName);
        }
        #endregion

        #region Getters
        public string GetName()
        {
            return customRadioButtonTaskName.Text;
        }
        public bool GetCheckedState()
        {
            return customRadioButtonTaskName.Checked;
        }
        #endregion

        #region Setters
        public void SetSubTaskText(string text)
        {
            //customTextBox.SetText(text);
        }
        public void SetCheckedState(bool value)
        {
            customRadioButtonTaskName.Checked = value;
        }
        #endregion

        #region Modifiers
        private void EventSubscriber()
        {
            //customTextBox.SetTextBoxColor(Color.Transparent, Color.White);
            //customTextBox.SetTextBoxState();
            //customTextBox.gotHidden += CustomTextBox_gotHidden;
        }
        public void Rename(string newName)
        {

            lblSubTaskName.Text = newName;
        }
        public void Delete()
        {
            //
        }
        #endregion

        #region Events
        private void CustomTextBox_gotHidden(bool isHidden, EventArgs arg)
        {
            //throw new NotImplementedException();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void customRadioButtonTaskName_CheckedChanged(object sender, EventArgs e)
        {

        }

        public string GetID()
        {
            throw new NotImplementedException();
        }

        public string GetParentID()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
