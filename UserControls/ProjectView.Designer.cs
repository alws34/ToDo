namespace DoYourTasks.UserControls
{
    partial class ProjectView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectView));
            this.lblTaskCount = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlPB = new System.Windows.Forms.Panel();
            this.pbDeleteProject = new System.Windows.Forms.PictureBox();
            this.lblProjPriority = new System.Windows.Forms.Label();
            this.lblDrag = new System.Windows.Forms.Label();
            this.pnlIndicator = new System.Windows.Forms.Panel();
            this.ctbProjectName = new DoYourTasks.UserControls.CustomControls.CustomTextBox();
            this.btnEditListName = new DoYourTasks.UserControls.CustomButtonV2();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlPB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDeleteProject)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTaskCount
            // 
            this.lblTaskCount.AutoSize = true;
            this.lblTaskCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTaskCount.ForeColor = System.Drawing.Color.Black;
            this.lblTaskCount.Location = new System.Drawing.Point(3, 83);
            this.lblTaskCount.Name = "lblTaskCount";
            this.lblTaskCount.Size = new System.Drawing.Size(79, 16);
            this.lblTaskCount.TabIndex = 8;
            this.lblTaskCount.Tag = "Tasks: 0/0";
            this.lblTaskCount.Text = "Tasks: 0/0";
            this.lblTaskCount.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 32);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // pnlPB
            // 
            this.pnlPB.Controls.Add(this.pbDeleteProject);
            this.pnlPB.Location = new System.Drawing.Point(226, 7);
            this.pnlPB.Name = "pnlPB";
            this.pnlPB.Size = new System.Drawing.Size(41, 33);
            this.pnlPB.TabIndex = 18;
            this.pnlPB.MouseEnter += new System.EventHandler(this.pbDeleteProject_MouseEnter);
            // 
            // pbDeleteProject
            // 
            this.pbDeleteProject.Enabled = false;
            this.pbDeleteProject.Image = global::DoYourTasks.Properties.Resources._29_cross_solid;
            this.pbDeleteProject.Location = new System.Drawing.Point(4, 3);
            this.pbDeleteProject.Name = "pbDeleteProject";
            this.pbDeleteProject.Size = new System.Drawing.Size(34, 27);
            this.pbDeleteProject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDeleteProject.TabIndex = 17;
            this.pbDeleteProject.TabStop = false;
            this.pbDeleteProject.Click += new System.EventHandler(this.btnDelete_Click);
            this.pbDeleteProject.MouseLeave += new System.EventHandler(this.pbDeleteProject_MouseLeave);
            // 
            // lblProjPriority
            // 
            this.lblProjPriority.AutoEllipsis = true;
            this.lblProjPriority.AutoSize = true;
            this.lblProjPriority.BackColor = System.Drawing.Color.LimeGreen;
            this.lblProjPriority.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.lblProjPriority.ForeColor = System.Drawing.Color.Black;
            this.lblProjPriority.Location = new System.Drawing.Point(127, 57);
            this.lblProjPriority.Margin = new System.Windows.Forms.Padding(0);
            this.lblProjPriority.Name = "lblProjPriority";
            this.lblProjPriority.Size = new System.Drawing.Size(47, 23);
            this.lblProjPriority.TabIndex = 16;
            this.lblProjPriority.Tag = "";
            this.lblProjPriority.Text = "Low";
            this.lblProjPriority.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // lblDrag
            // 
            this.lblDrag.AutoSize = true;
            this.lblDrag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDrag.Enabled = false;
            this.lblDrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblDrag.ForeColor = System.Drawing.Color.Black;
            this.lblDrag.Location = new System.Drawing.Point(127, 83);
            this.lblDrag.Name = "lblDrag";
            this.lblDrag.Size = new System.Drawing.Size(140, 22);
            this.lblDrag.TabIndex = 11;
            this.lblDrag.Text = "Drag From Here";
            // 
            // pnlIndicator
            // 
            this.pnlIndicator.BackColor = System.Drawing.Color.SlateBlue;
            this.pnlIndicator.Location = new System.Drawing.Point(0, 12);
            this.pnlIndicator.Name = "pnlIndicator";
            this.pnlIndicator.Size = new System.Drawing.Size(5, 22);
            this.pnlIndicator.TabIndex = 3;
            // 
            // ctbProjectName
            // 
            this.ctbProjectName.BackColor = System.Drawing.Color.Transparent;
            this.ctbProjectName.BorderColor = System.Drawing.Color.Transparent;
            this.ctbProjectName.BorderSize = 2;
            this.ctbProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctbProjectName.ForeColor = System.Drawing.Color.White;
            this.ctbProjectName.IsInEdit = false;
            this.ctbProjectName.Location = new System.Drawing.Point(44, 6);
            this.ctbProjectName.Margin = new System.Windows.Forms.Padding(5);
            this.ctbProjectName.Name = "ctbProjectName";
            this.ctbProjectName.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.ctbProjectName.Size = new System.Drawing.Size(178, 34);
            this.ctbProjectName.TabIndex = 6;
            this.ctbProjectName.UnderlinedStyle = false;
            // 
            // btnEditListName
            // 
            this.btnEditListName.BackColor = System.Drawing.Color.Transparent;
            this.btnEditListName.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnEditListName.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEditListName.BorderRadius = 0;
            this.btnEditListName.BorderSize = 0;
            this.btnEditListName.FlatAppearance.BorderSize = 0;
            this.btnEditListName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditListName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnEditListName.ForeColor = System.Drawing.Color.Black;
            this.btnEditListName.Location = new System.Drawing.Point(0, 40);
            this.btnEditListName.Name = "btnEditListName";
            this.btnEditListName.Size = new System.Drawing.Size(60, 22);
            this.btnEditListName.TabIndex = 1;
            this.btnEditListName.Text = "Rename";
            this.btnEditListName.TextColor = System.Drawing.Color.Black;
            this.btnEditListName.UseVisualStyleBackColor = false;
            this.btnEditListName.Click += new System.EventHandler(this.btnEditListName_Click);
            // 
            // ProjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.ctbProjectName);
            this.Controls.Add(this.pnlIndicator);
            this.Controls.Add(this.lblDrag);
            this.Controls.Add(this.btnEditListName);
            this.Controls.Add(this.lblProjPriority);
            this.Controls.Add(this.lblTaskCount);
            this.Controls.Add(this.pnlPB);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximumSize = new System.Drawing.Size(270, 105);
            this.MinimumSize = new System.Drawing.Size(270, 105);
            this.Name = "ProjectView";
            this.Size = new System.Drawing.Size(270, 105);
            this.Click += new System.EventHandler(this.ProjectView_GotFocus);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlPB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDeleteProject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomButtonV2 btnEditListName;
        private System.Windows.Forms.Label lblTaskCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlPB;
        private System.Windows.Forms.PictureBox pbDeleteProject;
        private System.Windows.Forms.Label lblProjPriority;
        private System.Windows.Forms.Label lblDrag;
        private System.Windows.Forms.Panel pnlIndicator;
        private CustomControls.CustomTextBox ctbProjectName;
    }
}