using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace DoYourTasks.UserControls
{
    public partial class UCAttachmentView : UserControl
    {
        private ToolTip toolTip;
        private Color originalBackColor;
        public event AttachmentRemovedEventHandler AttachemntRemoved;
        public Attachment Attachment { get; set; }
        public string AttachmentID { get; set; }
        public UCAttachmentView(Attachment attachment)
        {
            InitializeComponent();
            toolTip = new ToolTip();
            lblAttachemtnName.Text = $"{attachment.FileName}{attachment.FileType}";
            lblAttachemtnName.Tag = attachment.FilePath;
            lblAttachmentType.Text = $"{lblAttachmentType.Tag} {attachment.FileType} file";
            originalBackColor = BackColor;
            AttachmentID = attachment.AttachmentID;
            Attachment = attachment;


            if (string.IsNullOrEmpty(attachment.GetAddedOn()))
                attachment.SetAddedOn(DateTime.Now.ToString("dd/MM/yy"));
            lblAddedOn.Text = $"{lblAddedOn.Tag} {attachment.GetAddedOn()}";
        }

        private void lblAttachemtnName_MouseEnter(object sender, EventArgs e)
        {
            toolTip.SetToolTip(lblAttachemtnName, lblAttachemtnName.Text);
        }

        private void btnOpenAttachment_Click(object sender, EventArgs e)
        {
            string arg = "/C \"" + lblAttachemtnName.Tag.ToString() + "\"";
            RunProccess(arg);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            AttachemntRemoved.Invoke(new AttachmentRemovedEventArgs(this));
            Parent.Refresh();
            Dispose();
        }

        private void RunProccess(string argument) {
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                Arguments = argument,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            Process process = new Process()
            {
                StartInfo = startInfo
            };
            process.Start();

        }

        private void btnOpenDir_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(lblAttachemtnName.Tag.ToString());
            string arg = "/C explorer \"" + path + "\"";
            RunProccess(arg);
        }
    }
}
