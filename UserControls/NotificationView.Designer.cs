namespace DoYourTasks
{
    partial class NotificationView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDelete = new System.Windows.Forms.Label();
            this.lblDateTime = new DoYourTasks.UserControls.MaterialLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.BackColor = System.Drawing.Color.Transparent;
            this.lblDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblDelete.Location = new System.Drawing.Point(225, 0);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(20, 19);
            this.lblDelete.TabIndex = 0;
            this.lblDelete.Text = "X";
            this.lblDelete.Click += new System.EventHandler(this.lblDelete_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Depth = 0;
            this.lblDateTime.Font = new System.Drawing.Font("Arial", 8F);
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDateTime.Location = new System.Drawing.Point(3, 0);
            this.lblDateTime.MouseState = DoYourTasks.MouseState.HOVER;
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(29, 14);
            this.lblDateTime.TabIndex = 1;
            this.lblDateTime.Text = "Date";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(193, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Arial", 10F);
            this.lblMessage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblMessage.Location = new System.Drawing.Point(3, 15);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(184, 72);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Message";
            this.lblMessage.MouseEnter += new System.EventHandler(this.lblMessage_MouseEnter);
            // 
            // NotificationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.lblDelete);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Name = "NotificationView";
            this.Size = new System.Drawing.Size(245, 90);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDelete;
        private UserControls.MaterialLabel lblDateTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMessage;
    }
}
