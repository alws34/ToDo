
namespace DoYourTasks.UserControls
{
    partial class UCAttachmentView
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
            this.lblAttachemtnName = new System.Windows.Forms.Label();
            this.btnOpenAttachment = new DoYourTasks.UserControls.CustomButtonV2();
            this.lblAttachmentType = new System.Windows.Forms.Label();
            this.btnDelete = new DoYourTasks.UserControls.CustomButtonV2();
            this.btnOpenDir = new DoYourTasks.UserControls.CustomButtonV2();
            this.lblAddedOn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAttachemtnName
            // 
            this.lblAttachemtnName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblAttachemtnName.ForeColor = System.Drawing.Color.White;
            this.lblAttachemtnName.Location = new System.Drawing.Point(12, 11);
            this.lblAttachemtnName.MaximumSize = new System.Drawing.Size(230, 20);
            this.lblAttachemtnName.Name = "lblAttachemtnName";
            this.lblAttachemtnName.Size = new System.Drawing.Size(194, 20);
            this.lblAttachemtnName.TabIndex = 10;
            this.lblAttachemtnName.Text = "Attachment Name";
            this.lblAttachemtnName.MouseEnter += new System.EventHandler(this.lblAttachemtnName_MouseEnter);
            // 
            // btnOpenAttachment
            // 
            this.btnOpenAttachment.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenAttachment.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnOpenAttachment.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnOpenAttachment.BorderRadius = 0;
            this.btnOpenAttachment.BorderSize = 0;
            this.btnOpenAttachment.FlatAppearance.BorderSize = 0;
            this.btnOpenAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenAttachment.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenAttachment.ForeColor = System.Drawing.Color.White;
            this.btnOpenAttachment.Location = new System.Drawing.Point(252, 1);
            this.btnOpenAttachment.Name = "btnOpenAttachment";
            this.btnOpenAttachment.Size = new System.Drawing.Size(87, 24);
            this.btnOpenAttachment.TabIndex = 11;
            this.btnOpenAttachment.Text = "Open File";
            this.btnOpenAttachment.TextColor = System.Drawing.Color.White;
            this.btnOpenAttachment.UseVisualStyleBackColor = false;
            this.btnOpenAttachment.Click += new System.EventHandler(this.btnOpenAttachment_Click);
            // 
            // lblAttachmentType
            // 
            this.lblAttachmentType.AutoSize = true;
            this.lblAttachmentType.BackColor = System.Drawing.Color.Transparent;
            this.lblAttachmentType.ForeColor = System.Drawing.Color.White;
            this.lblAttachmentType.Location = new System.Drawing.Point(13, 35);
            this.lblAttachmentType.Name = "lblAttachmentType";
            this.lblAttachmentType.Size = new System.Drawing.Size(56, 13);
            this.lblAttachmentType.TabIndex = 12;
            this.lblAttachmentType.Tag = "File Type: ";
            this.lblAttachmentType.Text = "File Type: ";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnDelete.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDelete.BorderRadius = 0;
            this.btnDelete.BorderSize = 0;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(354, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(21, 70);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "X";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenDir.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnOpenDir.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnOpenDir.BorderRadius = 0;
            this.btnOpenDir.BorderSize = 0;
            this.btnOpenDir.FlatAppearance.BorderSize = 0;
            this.btnOpenDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDir.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnOpenDir.ForeColor = System.Drawing.Color.White;
            this.btnOpenDir.Location = new System.Drawing.Point(228, 24);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(124, 24);
            this.btnOpenDir.TabIndex = 14;
            this.btnOpenDir.Text = "Open Directory";
            this.btnOpenDir.TextColor = System.Drawing.Color.White;
            this.btnOpenDir.UseVisualStyleBackColor = false;
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // lblAddedOn
            // 
            this.lblAddedOn.AutoSize = true;
            this.lblAddedOn.BackColor = System.Drawing.Color.Transparent;
            this.lblAddedOn.ForeColor = System.Drawing.Color.White;
            this.lblAddedOn.Location = new System.Drawing.Point(13, 52);
            this.lblAddedOn.Name = "lblAddedOn";
            this.lblAddedOn.Size = new System.Drawing.Size(58, 13);
            this.lblAddedOn.TabIndex = 15;
            this.lblAddedOn.Tag = "Added On:";
            this.lblAddedOn.Text = "Added On:";
            // 
            // UCAttachmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.Controls.Add(this.lblAddedOn);
            this.Controls.Add(this.btnOpenDir);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblAttachmentType);
            this.Controls.Add(this.btnOpenAttachment);
            this.Controls.Add(this.lblAttachemtnName);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximumSize = new System.Drawing.Size(375, 70);
            this.MinimumSize = new System.Drawing.Size(375, 70);
            this.Name = "UCAttachmentView";
            this.Size = new System.Drawing.Size(375, 70);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAttachemtnName;
        private CustomButtonV2 btnOpenAttachment;
        private System.Windows.Forms.Label lblAttachmentType;
        private CustomButtonV2 btnDelete;
        private CustomButtonV2 btnOpenDir;
        private System.Windows.Forms.Label lblAddedOn;
    }
}
