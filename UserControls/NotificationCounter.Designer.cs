namespace DoYourTasks.UserControls
{
    partial class NotificationCounter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationCounter));
            this.pbNotificationImage = new System.Windows.Forms.PictureBox();
            this.lblNotificationCounter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbNotificationImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbNotificationImage
            // 
            this.pbNotificationImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbNotificationImage.Image = ((System.Drawing.Image)(resources.GetObject("pbNotificationImage.Image")));
            this.pbNotificationImage.Location = new System.Drawing.Point(0, 0);
            this.pbNotificationImage.Name = "pbNotificationImage";
            this.pbNotificationImage.Size = new System.Drawing.Size(96, 73);
            this.pbNotificationImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNotificationImage.TabIndex = 0;
            this.pbNotificationImage.TabStop = false;
            // 
            // lblNotificationCounter
            // 
            this.lblNotificationCounter.AutoSize = true;
            this.lblNotificationCounter.BackColor = System.Drawing.Color.Transparent;
            this.lblNotificationCounter.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblNotificationCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNotificationCounter.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblNotificationCounter.Location = new System.Drawing.Point(70, 0);
            this.lblNotificationCounter.Name = "lblNotificationCounter";
            this.lblNotificationCounter.Size = new System.Drawing.Size(26, 29);
            this.lblNotificationCounter.TabIndex = 1;
            this.lblNotificationCounter.Text = "0";
            // 
            // NotificationCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNotificationCounter);
            this.Controls.Add(this.pbNotificationImage);
            this.Name = "NotificationCounter";
            this.Size = new System.Drawing.Size(96, 73);
            ((System.ComponentModel.ISupportInitialize)(this.pbNotificationImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbNotificationImage;
        private System.Windows.Forms.Label lblNotificationCounter;
    }
}
