using DoYourTasks.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DoYourTasks.Utils;

namespace DoYourTasks
{
    public partial class NotificationView : UserControl
    {

        public event NotificationDeletedEventHandler NotificationDeleted;
        public NotificationView(string title, string message, NotificationType type)
        {
            InitializeComponent();

            lblMessage.Text = message;
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yy HH:mm tt");

            switch (type) {
                case NotificationType.Success:
                    pictureBox1.Image = Resources.success_png;
                    BackColor = Color.Green;
                    break;
                case NotificationType.Error:
                    pictureBox1.Image = Resources.Error_png;
                    BackColor = Color.DarkRed;
                    break;
                case NotificationType.Question:
                    pictureBox1.Image = Resources.question_png;
                    BackColor = Color.Blue;
                    break;
                case NotificationType.Warning:
                    pictureBox1.Image = Resources.warning_png;
                    BackColor = Color.Orange;
                    break;
                case NotificationType.Info:
                    pictureBox1.Image = Resources.info_png;
                    BackColor = Color.Cyan;
                    break;
            }
            BackColor = Color.FromArgb(60, BackColor);
            ForeColor = Color.Black;
        }
        public static void WrapLabelText(System.Windows.Forms.Label label)
        {
            // Create a graphics object to measure the size of the text
            using (Graphics g = label.CreateGraphics())
            {
                // Get the size of the text
                SizeF size = g.MeasureString(label.Text, label.Font);

                // Check if the size of the text is greater than the size of the label
                if (size.Width > label.ClientSize.Width || size.Height > label.ClientSize.Height)
                {
                    // Calculate the new font size based on the length of the text
                    float fontSize = label.Font.Size * label.ClientSize.Width / size.Width;

                    // Set the new font size
                    label.Font = new Font(label.Font.FontFamily, fontSize);

                    // Get the new size of the text
                    size = g.MeasureString(label.Text, label.Font);

                    // Resize the label to fit the text
                    label.Size = new Size((int)size.Width + 1, (int)size.Height + 1);
                }
            }
        }

        private void lblDelete_Click(object sender, EventArgs e)
        {
            NotificationDeleted.Invoke();
            Dispose();
        }

        private void lblMessage_MouseEnter(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(lblMessage, lblMessage.Text);
        }
    }
}
