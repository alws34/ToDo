using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoYourTasks
{
    public partial class NotificationView : UserControl
    {
        public NotificationView()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(50, BackColor);
        }
    }
}
