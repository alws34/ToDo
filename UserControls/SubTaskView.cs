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
        #endregion CustomEvents

        #region Properties
        public string SubTaskID { get; set; }
        public string ParentTaskID { get; set; }
        public string ParentProjectID { get; set; }
        public bool IsCompleted { get; set; }
        private Theme Theme { get; set; }
        #endregion Properties

        #region Fields
        Color StartBackColor;
        Color StartForeColor;
        ToolTip toolTip;
        #endregion Fields

        #region Constructors
        public SubTaskView(string parent_id, string id, string parentProjectID, string subTaskName, string createdAt, Theme theme)
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
            StartForeColor = ForeColor;
            toolTip = new ToolTip();
            Theme = theme;
            ctbTaskName.BackColor = Color.Transparent;
            ctbTaskName.SetTBBackColor(StartBackColor);
        }

        #endregion Constructors

        #region Getters
        public string GetName()
        {
            return customRadioButtonTaskName.Text;
        }
        public bool GetCheckedState()
        {
            return customRadioButtonTaskName.Checked;
        }

        public string GetSubTaskID() { return SubTaskID; }

        public string GetTaskID()
        {
            return GetParentTaskID();
        }

        public string GetParentTaskID()
        {
            return ParentTaskID;
        }

        public string GetParentProjectID()
        {
            return ParentProjectID;
        }
        #endregion Getters

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
            ctbTaskName.SetText(newName);
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
            //customRadioButtonTaskName.ForeColor = customRadioButtonTaskName.CheckedColor;
            customRadioButtonTaskName.BackColor = Color.Gainsboro;
            customRadioButtonTaskName.isSelected = true;

            if (!ctbTaskName.GetIsInEdit())
                ctbTaskName.BorderColor = Color.Gainsboro;

            ctbTaskName.SetTBBackColor(Color.Gainsboro);
            ctbTaskName.SetTBForeColor(Color.Black);

            ctbTaskName.ForeColor = Color.Black;
            ctbTaskName.BackColor = Color.Gainsboro;
            ctbTaskName.BorderColor = Color.Gainsboro;
      
            btnDelete.BackColor = Color.Gainsboro; ;
            btnDelete.ForeColor = Color.Black;

            btnEditTaskName.ForeColor = Color.Black; ;
            btnEditTaskName.BackColor = Color.Gainsboro;

            lblDateCreated.ForeColor = Color.Gainsboro; ;
            lblDateCreated.BackColor = Color.Gainsboro;

            BackColor = Color.Gainsboro;
            toolTip.SetToolTip(this.ctbTaskName, this.ctbTaskName.Text);
        }

        private void customRadioButtonTaskName_MouseLeave(object sender, EventArgs e)
        {
            //customRadioButtonTaskName.ForeColor = StartForeColor;
            //customRadioButtonTaskName.BackColor = StartBackColor;
            //customRadioButtonTaskName.isSelected = false;

            //ctbTaskName.SetTBBackColor(StartBackColor);
            //ctbTaskName.SetTBForeColor(StartForeColor);
            //ctbTaskName.BackColor = StartBackColor;
            //ctbTaskName.ForeColor = StartBackColor;


            //if (!ctbTaskName.GetIsInEdit())
            //    ctbTaskName.BorderColor = StartBackColor;
            //ctbTaskName.SetTBBackColor(StartBackColor);

            //BackColor = StartBackColor;
            SetTheme(Theme);
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
       
        private void btnEditTaskName_Click(object sender, EventArgs e)
        {
            ctbTaskName.SetIsInEdit(true);
        }

        private void SubTaskView_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            c.DoDragDrop(c, DragDropEffects.Move);
        }

        public void SetTheme(Theme theme)
        {
            Theme = theme;
            BackColor = theme.BackColor;
            ForeColor = theme.ForeColor;
            
            StartBackColor = BackColor;
            StartForeColor = ForeColor;

            lblDateCreated.BackColor = BackColor;
            lblDateCreated.ForeColor = ForeColor;

            btnEditTaskName.BackColor = BackColor;
            btnEditTaskName.ForeColor = ForeColor;

            btnDelete.BackColor = BackColor;
            btnDelete.ForeColor = ForeColor;

            ctbTaskName.BackColor = BackColor;
            ctbTaskName.ForeColor = ForeColor;
            ctbTaskName.BorderColor = BackColor;
            ctbTaskName.SetTBBackColor(BackColor);
            ctbTaskName.SetTBForeColor(ForeColor);

            customRadioButtonTaskName.BackColor = BackColor;
            customRadioButtonTaskName.ForeColor = ForeColor;

            btnEditTaskName.ForeColor= ForeColor;
            btnEditTaskName.BackColor= BackColor;

            lblDateCreated.ForeColor= ForeColor;
            lblDateCreated.BackColor= BackColor;
        }
        #endregion Events
    }
}
