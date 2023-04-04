namespace DoYourTasks.UserControls
{
    partial class SubTaskView
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
            this.label1 = new System.Windows.Forms.Label();
            this.ctbTaskName = new DoYourTasks.UserControls.CustomControls.CustomTextBox();
            this.customRadioButtonTaskName = new DoYourTasks.UserControls.CustomRadioButton();
            this.btnEditTaskName = new DoYourTasks.UserControls.CustomButtonV2();
            this.btnDelete = new DoYourTasks.UserControls.CustomButtonV2();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(130, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "Drag From Here";
            // 
            // ctbTaskName
            // 
            this.ctbTaskName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.ctbTaskName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.ctbTaskName.BorderSize = 2;
            this.ctbTaskName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.ctbTaskName.ForeColor = System.Drawing.Color.White;
            this.ctbTaskName.IsInEdit = false;
            this.ctbTaskName.Location = new System.Drawing.Point(29, 5);
            this.ctbTaskName.Margin = new System.Windows.Forms.Padding(5);
            this.ctbTaskName.MaximumSize = new System.Drawing.Size(205, 38);
            this.ctbTaskName.MinimumSize = new System.Drawing.Size(205, 38);
            this.ctbTaskName.Name = "ctbTaskName";
            this.ctbTaskName.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.ctbTaskName.Size = new System.Drawing.Size(205, 38);
            this.ctbTaskName.TabIndex = 9;
            this.ctbTaskName.UnderlinedStyle = false;
            this.ctbTaskName.Visible = false;
            // 
            // customRadioButtonTaskName
            // 
            this.customRadioButtonTaskName.AutoSize = true;
            this.customRadioButtonTaskName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.customRadioButtonTaskName.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.customRadioButtonTaskName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.customRadioButtonTaskName.ForeColor = System.Drawing.Color.White;
            this.customRadioButtonTaskName.Location = new System.Drawing.Point(3, 10);
            this.customRadioButtonTaskName.MaximumSize = new System.Drawing.Size(217, 28);
            this.customRadioButtonTaskName.MinimumSize = new System.Drawing.Size(0, 23);
            this.customRadioButtonTaskName.Name = "customRadioButtonTaskName";
            this.customRadioButtonTaskName.Size = new System.Drawing.Size(30, 26);
            this.customRadioButtonTaskName.TabIndex = 4;
            this.customRadioButtonTaskName.TabStop = true;
            this.customRadioButtonTaskName.UnCheckedColor = System.Drawing.Color.Gray;
            this.customRadioButtonTaskName.UseVisualStyleBackColor = false;
            this.customRadioButtonTaskName.MouseEnter += new System.EventHandler(this.customRadioButtonTaskName_MouseEnter);
            this.customRadioButtonTaskName.MouseLeave += new System.EventHandler(this.customRadioButtonTaskName_MouseLeave);
            // 
            // btnEditTaskName
            // 
            this.btnEditTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTaskName.BackColor = System.Drawing.Color.Transparent;
            this.btnEditTaskName.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnEditTaskName.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEditTaskName.BorderRadius = 0;
            this.btnEditTaskName.BorderSize = 0;
            this.btnEditTaskName.FlatAppearance.BorderSize = 0;
            this.btnEditTaskName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTaskName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnEditTaskName.ForeColor = System.Drawing.Color.White;
            this.btnEditTaskName.Location = new System.Drawing.Point(3, 75);
            this.btnEditTaskName.Name = "btnEditTaskName";
            this.btnEditTaskName.Size = new System.Drawing.Size(54, 26);
            this.btnEditTaskName.TabIndex = 8;
            this.btnEditTaskName.Text = "Edit";
            this.btnEditTaskName.TextColor = System.Drawing.Color.White;
            this.btnEditTaskName.UseVisualStyleBackColor = false;
            this.btnEditTaskName.Click += new System.EventHandler(this.btnEditTaskName_Click);
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
            this.btnDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(242, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(22, 29);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "X";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.BackColor = System.Drawing.Color.Transparent;
            this.lblDateCreated.Enabled = false;
            this.lblDateCreated.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblDateCreated.Location = new System.Drawing.Point(3, 48);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(198, 37);
            this.lblDateCreated.TabIndex = 11;
            this.lblDateCreated.Text = "Created At: ";
            // 
            // SubTaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.Controls.Add(this.lblDateCreated);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctbTaskName);
            this.Controls.Add(this.customRadioButtonTaskName);
            this.Controls.Add(this.btnEditTaskName);
            this.Controls.Add(this.btnDelete);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "SubTaskView";
            this.Size = new System.Drawing.Size(265, 104);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SubTaskView_MouseDown);
            this.MouseEnter += new System.EventHandler(this.customRadioButtonTaskName_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.customRadioButtonTaskName_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButtonV2 btnDelete;
        private CustomRadioButton customRadioButtonTaskName;
        private CustomButtonV2 btnEditTaskName;
        private CustomControls.CustomTextBox ctbTaskName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDateCreated;
    }
}
