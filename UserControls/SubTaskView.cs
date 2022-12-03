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
    public partial class SubTaskView : UserControl
    {

        public string ID { get; set; }
        public string ParentID { get; set; }
        public SubTask SubTask { get; set; }

        public SubTaskView()
        {
            InitializeComponent();
            EventSubscriber();
        }

        public void SetSubTaskText(string text)
        {
            customTextBox.SetText(text);
        }

        private void EventSubscriber() {
            customTextBox.SetTextBoxColor(Color.Transparent, Color.White);
            customTextBox.SetTextBoxState();
            customTextBox.gotHidden += CustomTextBox_gotHidden;
        }

        #region Events
        private void CustomTextBox_gotHidden(bool isHidden, EventArgs arg)
        {
            //throw new NotImplementedException();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void customRadioButtonTaskName_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
