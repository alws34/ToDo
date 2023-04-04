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
    public partial class SubTaskView : UserControl, IViewable
    {
        #region CustomEvents
        public event SubTaskCompletedEventHandler SubTaskCompleted;
        public event SubTaskDeletedEventHandler SubTaskDeleted;
        #endregion

        #region Properties
        public string SubTaskID { get; set; }
        public string ParentTaskID { get; set; }
        public string ParentProjectID { get; set; }
        public bool IsCompleted { get; set; }
        #endregion

        #region Fields
        Color StartBackColor;
        ToolTip toolTip;
        #endregion

        #region Constructors
        public SubTaskView(string parent_id, string id,string parentProjectID, string subTaskName, string createdAt)
        {
            InitializeComponent();
            ParentTaskID = parent_id;
            ParentProjectID = parentProjectID;
            SubTaskID = id;
            Name = "SubTaskView";
            Rename(subTaskName);
            EventSubscriber();
            lblDateCreated.Text += createdAt;
            ForeColor = Color.White;
            StartBackColor = BackColor;
            toolTip = new ToolTip();
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

        public string GetParentTaskID()
        {
            return ParentTaskID;
        }
        public string GetParentProjectID()
        {
            return ParentProjectID;
        }
        #endregion

        #region Setters
        public void SetCheckedState(bool value)
        {
            customRadioButtonTaskName.Checked = value;
        }
        #endregion

        #region Modifiers
        private void EventSubscriber()
        {
            customRadioButtonTaskName.customCheckedChanged += CustomRadioButtonTaskName_checkedChanged;
        }
        public void Rename(string newName)
        {
            //customRadioButtonTaskName.Rename(newName);
            ctbTaskName.SetText(newName);
            //var textsize = TextRenderer.MeasureText(ctbTaskName.Text, ctbTaskName.Font);
            //ctbTaskName.Left = 0;
            //ctbTaskName.Width = textsize.Width;
            ctbTaskName.Visible = true;

        }
        public void Delete()
        {
            SubTaskDeleted.Invoke(new SubTaskDeletedEventArgs(this));
        }
        #endregion

        #region Events

        private void customRadioButtonTaskName_MouseEnter(object sender, EventArgs e)
        {
            customRadioButtonTaskName.ForeColor = customRadioButtonTaskName.CheckedColor;
            customRadioButtonTaskName.BackColor = Color.Gainsboro;
            customRadioButtonTaskName.isSelected = true;
            
            if (!ctbTaskName.GetIsInEdit())
                ctbTaskName.BorderColor = Color.Gainsboro;

            ctbTaskName.SetTBBackColor(Color.Gainsboro);
            ctbTaskName.SetTBForeColor(Color.Black);

            ctbTaskName.ForeColor = Color.Black;
            ctbTaskName.BackColor = Color.Gainsboro;

            //ctbTaskName.ForeColor = customRadioButtonTaskName.CheckedColor;
            //ctbTaskName.BackColor = Color.Gainsboro;

            BackColor = Color.Gainsboro;
            toolTip.SetToolTip(this.ctbTaskName, this.ctbTaskName.Text);
        }

        private void customRadioButtonTaskName_MouseLeave(object sender, EventArgs e)
        {
            customRadioButtonTaskName.ForeColor = Color.White;
            customRadioButtonTaskName.BackColor = StartBackColor;
            customRadioButtonTaskName.isSelected = false;

            ctbTaskName.SetTBBackColor(StartBackColor);
            ctbTaskName.SetTBForeColor(Color.White);
            ctbTaskName.BackColor = StartBackColor;
            ctbTaskName.ForeColor = Color.White;


            if (!ctbTaskName.GetIsInEdit())
                ctbTaskName.BorderColor = StartBackColor;
            ctbTaskName.SetTBBackColor(StartBackColor);

            BackColor = StartBackColor;
        }
        private void CustomRadioButtonTaskName_checkedChanged(CustomCBcheckedChangedEventArgs arg)
        {
            IsCompleted = arg.CRB.Checked; // set the current state of the Radiobutton.
           
            SetCheckedState(arg.CRB.Checked);
            SubTaskCompleted.Invoke(new SubTaskCompletedEventArgs(this));
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            SubTaskDeleted.Invoke(new SubTaskDeletedEventArgs(this));
            Dispose();
        }

        private void customRadioButtonTaskName_CheckedChanged(object sender, EventArgs e)
        {

        }

        public string GetID()
        {
            return SubTaskID;
        }
        #endregion

        private void btnEditTaskName_Click(object sender, EventArgs e)
        {
            ctbTaskName.SetIsInEdit(true);
        }

        private void SubTaskView_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            c.DoDragDrop(c, DragDropEffects.Move);
        }

        public string GetTaskID()
        {
            return "";
            //throw new NotImplementedException();
        }
    }
}
