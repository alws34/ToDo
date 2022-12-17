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
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlIndicator = new System.Windows.Forms.Panel();
            this.btnEditListName = new DoYourTasks.UserControls.CustomButtonV2();
            this.customTextBox = new DoYourTasks.UserControls.CustomControls.CustomTextBox();
            this.btnDelete = new DoYourTasks.UserControls.CustomButtonV2();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(51, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(93, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "TaskName";
            this.lblName.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // pnlIndicator
            // 
            this.pnlIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(185)))), ((int)(((byte)(237)))));
            this.pnlIndicator.Location = new System.Drawing.Point(0, 15);
            this.pnlIndicator.Name = "pnlIndicator";
            this.pnlIndicator.Size = new System.Drawing.Size(5, 20);
            this.pnlIndicator.TabIndex = 3;
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
            this.btnEditListName.ForeColor = System.Drawing.Color.White;
            this.btnEditListName.Location = new System.Drawing.Point(3, 41);
            this.btnEditListName.Name = "btnEditListName";
            this.btnEditListName.Size = new System.Drawing.Size(57, 20);
            this.btnEditListName.TabIndex = 1;
            this.btnEditListName.Text = "Rename";
            this.btnEditListName.TextColor = System.Drawing.Color.White;
            this.btnEditListName.UseVisualStyleBackColor = false;
            this.btnEditListName.Click += new System.EventHandler(this.btnEditListName_Click);
            // 
            // customTextBox
            // 
            this.customTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.customTextBox.BorderSize = 2;
            this.customTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.customTextBox.Location = new System.Drawing.Point(53, 7);
            this.customTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.customTextBox.Name = "customTextBox";
            this.customTextBox.Padding = new System.Windows.Forms.Padding(7);
            this.customTextBox.Size = new System.Drawing.Size(213, 35);
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
            this.btnDelete.Location = new System.Drawing.Point(247, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(22, 27);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "X";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ProjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.Controls.Add(this.customTextBox);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.pnlIndicator);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnEditListName);
            this.Controls.Add(this.lblName);
            this.MaximumSize = new System.Drawing.Size(272, 60);
            this.MinimumSize = new System.Drawing.Size(272, 50);
            this.Name = "ProjectView";
            this.Size = new System.Drawing.Size(272, 60);
            this.Click += new System.EventHandler(this.ProjectView_GotFocus);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private CustomButtonV2 btnEditListName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlIndicator;
        private CustomControls.CustomTextBox customTextBox;
        private CustomButtonV2 btnDelete;
    }
}
