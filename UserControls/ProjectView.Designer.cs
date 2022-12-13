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
            this.btnEditListName = new DoYourTasks.UserControls.CustomButtonV2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlIndicator = new System.Windows.Forms.Panel();
            this.custombuttonDelete = new DoYourTasks.UserControls.CustomButtonV2();
            this.customTextBox = new DoYourTasks.UserControls.CustomControls.CustomTextBox();
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
            this.btnEditListName.Location = new System.Drawing.Point(159, 11);
            this.btnEditListName.Name = "btnEditListName";
            this.btnEditListName.Size = new System.Drawing.Size(57, 29);
            this.btnEditListName.TabIndex = 1;
            this.btnEditListName.Text = "Rename";
            this.btnEditListName.TextColor = System.Drawing.Color.White;
            this.btnEditListName.UseVisualStyleBackColor = false;
            this.btnEditListName.Click += new System.EventHandler(this.btnEditListName_Click);
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
            // custombuttonDelete
            // 
            this.custombuttonDelete.BackColor = System.Drawing.Color.Transparent;
            this.custombuttonDelete.BackgroundColor = System.Drawing.Color.Transparent;
            this.custombuttonDelete.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.custombuttonDelete.BorderRadius = 0;
            this.custombuttonDelete.BorderSize = 0;
            this.custombuttonDelete.FlatAppearance.BorderSize = 0;
            this.custombuttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.custombuttonDelete.ForeColor = System.Drawing.Color.White;
            this.custombuttonDelete.Location = new System.Drawing.Point(222, 11);
            this.custombuttonDelete.Name = "custombuttonDelete";
            this.custombuttonDelete.Size = new System.Drawing.Size(55, 29);
            this.custombuttonDelete.TabIndex = 4;
            this.custombuttonDelete.Text = "Delete";
            this.custombuttonDelete.TextColor = System.Drawing.Color.White;
            this.custombuttonDelete.UseVisualStyleBackColor = false;
            this.custombuttonDelete.Click += new System.EventHandler(this.custombuttonDelete_Click);
            // 
            // customTextBox
            // 
            this.customTextBox.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.customTextBox.BorderSize = 2;
            this.customTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.customTextBox.Location = new System.Drawing.Point(13, 7);
            this.customTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.customTextBox.Name = "customTextBox";
            this.customTextBox.Padding = new System.Windows.Forms.Padding(7);
            this.customTextBox.Size = new System.Drawing.Size(254, 35);
            this.customTextBox.TabIndex = 5;
            this.customTextBox.UnderlinedStyle = false;
            // 
            // ProjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.Controls.Add(this.customTextBox);
            this.Controls.Add(this.custombuttonDelete);
            this.Controls.Add(this.pnlIndicator);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnEditListName);
            this.Controls.Add(this.lblName);
            this.Name = "ProjectView";
            this.Size = new System.Drawing.Size(272, 50);
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
        private CustomButtonV2 custombuttonDelete;
        private CustomControls.CustomTextBox customTextBox;
    }
}
