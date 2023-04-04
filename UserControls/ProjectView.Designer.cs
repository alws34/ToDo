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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlIndicator = new System.Windows.Forms.Panel();
            this.lblTaskCount = new System.Windows.Forms.Label();
            this.lblDrag = new System.Windows.Forms.Label();
            this.lblProjPriority = new System.Windows.Forms.Label();
            this.customTextBox = new DoYourTasks.UserControls.CustomControls.CustomTextBox();
            this.btnDelete = new DoYourTasks.UserControls.CustomButtonV2();
            this.btnEditListName = new DoYourTasks.UserControls.CustomButtonV2();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 32);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // pnlIndicator
            // 
            this.pnlIndicator.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.pnlIndicator.Location = new System.Drawing.Point(0, 16);
            this.pnlIndicator.Name = "pnlIndicator";
            this.pnlIndicator.Size = new System.Drawing.Size(5, 22);
            this.pnlIndicator.TabIndex = 3;
            // 
            // lblTaskCount
            // 
            this.lblTaskCount.AutoSize = true;
            this.lblTaskCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTaskCount.Location = new System.Drawing.Point(3, 84);
            this.lblTaskCount.Name = "lblTaskCount";
            this.lblTaskCount.Size = new System.Drawing.Size(141, 30);
            this.lblTaskCount.TabIndex = 8;
            this.lblTaskCount.Tag = "Tasks: 0/0";
            this.lblTaskCount.Text = "Tasks: 0/0";
            this.lblTaskCount.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // lblDrag
            // 
            this.lblDrag.AutoSize = true;
            this.lblDrag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDrag.Enabled = false;
            this.lblDrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblDrag.Location = new System.Drawing.Point(127, 81);
            this.lblDrag.Name = "lblDrag";
            this.lblDrag.Size = new System.Drawing.Size(265, 39);
            this.lblDrag.TabIndex = 11;
            this.lblDrag.Text = "Drag From Here";
            // 
            // lblProjPriority
            // 
            this.lblProjPriority.AutoEllipsis = true;
            this.lblProjPriority.AutoSize = true;
            this.lblProjPriority.BackColor = System.Drawing.Color.LimeGreen;
            this.lblProjPriority.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.lblProjPriority.ForeColor = System.Drawing.Color.Black;
            this.lblProjPriority.Location = new System.Drawing.Point(127, 52);
            this.lblProjPriority.Margin = new System.Windows.Forms.Padding(0);
            this.lblProjPriority.Name = "lblProjPriority";
            this.lblProjPriority.Size = new System.Drawing.Size(108, 54);
            this.lblProjPriority.TabIndex = 16;
            this.lblProjPriority.Tag = "";
            this.lblProjPriority.Text = "Low";
            this.lblProjPriority.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // customTextBox
            // 
            this.customTextBox.BackColor = System.Drawing.Color.LightGray;
            this.customTextBox.BorderColor = System.Drawing.Color.LightGray;
            this.customTextBox.BorderSize = 2;
            this.customTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customTextBox.ForeColor = System.Drawing.Color.Black;
            this.customTextBox.IsInEdit = false;
            this.customTextBox.Location = new System.Drawing.Point(53, 11);
            this.customTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.customTextBox.Name = "customTextBox";
            this.customTextBox.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.customTextBox.Size = new System.Drawing.Size(194, 38);
            this.customTextBox.TabIndex = 6;
            this.customTextBox.UnderlinedStyle = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnDelete.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDelete.BorderRadius = 0;
            this.btnDelete.BorderSize = 0;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(247, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(22, 29);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "X";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnEditListName.ForeColor = System.Drawing.Color.Black;
            this.btnEditListName.Location = new System.Drawing.Point(3, 50);
            this.btnEditListName.Name = "btnEditListName";
            this.btnEditListName.Size = new System.Drawing.Size(57, 22);
            this.btnEditListName.TabIndex = 1;
            this.btnEditListName.Text = "Rename";
            this.btnEditListName.TextColor = System.Drawing.Color.Black;
            this.btnEditListName.UseVisualStyleBackColor = false;
            this.btnEditListName.Click += new System.EventHandler(this.btnEditListName_Click);
            // 
            // ProjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.lblProjPriority);
            this.Controls.Add(this.lblDrag);
            this.Controls.Add(this.lblTaskCount);
            this.Controls.Add(this.customTextBox);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.pnlIndicator);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnEditListName);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximumSize = new System.Drawing.Size(270, 125);
            this.MinimumSize = new System.Drawing.Size(270, 125);
            this.Name = "ProjectView";
            this.Size = new System.Drawing.Size(270, 125);
            this.Click += new System.EventHandler(this.ProjectView_GotFocus);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButtonV2 btnEditListName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlIndicator;
        private CustomControls.CustomTextBox customTextBox;
        private CustomButtonV2 btnDelete;
        private System.Windows.Forms.Label lblTaskCount;
        private System.Windows.Forms.Label lblDrag;
        private System.Windows.Forms.Label lblProjPriority;
    }
}