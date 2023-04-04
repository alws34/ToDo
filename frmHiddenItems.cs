using DoYourTasks.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoYourTasks
{
    public partial class frmHiddenItems : Form
    {
        public frmHiddenItems(string title)
        {
            InitializeComponent();
            Text = title;
        }

        public void AddControls(List<Control> controls)
        {
            flowLayoutPanel1.Controls.AddRange(controls.ToArray());
        }

        public void AddControl(Control control)
        {
            flowLayoutPanel1.Controls.Add(control);
        }

        public void RemoveControl(Control c)
        {
            flowLayoutPanel1.Controls.Remove(c);
        }

        public void ClearItems()
        {
            flowLayoutPanel1.Controls.Clear();
        }

        private void frmHiddenItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void frmHiddenItems_Shown(object sender, EventArgs e)
        {
            CenterToParent();
        }

        public void SetChildIndex(Control c, int Index)
        {
            flowLayoutPanel1.Controls.SetChildIndex(c, Index);
        }
    }
}
