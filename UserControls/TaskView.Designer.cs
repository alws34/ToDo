namespace DoYourTasks.UserControls
{
    partial class TaskView
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
            this.pnlColorIndicator = new System.Windows.Forms.Panel();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblCompletedSubTasks = new System.Windows.Forms.Label();
            this.btnDelete = new DoYourTasks.UserControls.CustomButtonV2();
            this.customRadioButtonTaskName = new DoYourTasks.UserControls.CustomRadioButton();
            this.pnlColorIndicator.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlColorIndicator
            // 
            this.pnlColorIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlColorIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.pnlColorIndicator.Controls.Add(this.lblDueDate);
            this.pnlColorIndicator.Controls.Add(this.btnDelete);
            this.pnlColorIndicator.Controls.Add(this.lblCompletedSubTasks);
            this.pnlColorIndicator.Controls.Add(this.customRadioButtonTaskName);
            this.pnlColorIndicator.ForeColor = System.Drawing.Color.Transparent;
            this.pnlColorIndicator.Location = new System.Drawing.Point(5, 5);
            this.pnlColorIndicator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlColorIndicator.Name = "pnlColorIndicator";
            this.pnlColorIndicator.Size = new System.Drawing.Size(547, 59);
            this.pnlColorIndicator.TabIndex = 0;
            this.pnlColorIndicator.Click += new System.EventHandler(this.TaskView_Click);
            this.pnlColorIndicator.MouseEnter += new System.EventHandler(this.pnlColorIndicator_MouseEnter);
            this.pnlColorIndicator.MouseLeave += new System.EventHandler(this.pnlColorIndicator_MouseLeave);
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDate.ForeColor = System.Drawing.Color.White;
            this.lblDueDate.Location = new System.Drawing.Point(339, 32);
            this.lblDueDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(52, 16);
            this.lblDueDate.TabIndex = 6;
            this.lblDueDate.Text = "Due to: ";
            this.lblDueDate.Visible = false;
            // 
            // lblCompletedSubTasks
            // 
            this.lblCompletedSubTasks.AutoSize = true;
            this.lblCompletedSubTasks.BackColor = System.Drawing.Color.Transparent;
            this.lblCompletedSubTasks.ForeColor = System.Drawing.Color.White;
            this.lblCompletedSubTasks.Location = new System.Drawing.Point(41, 32);
            this.lblCompletedSubTasks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompletedSubTasks.Name = "lblCompletedSubTasks";
            this.lblCompletedSubTasks.Size = new System.Drawing.Size(25, 16);
            this.lblCompletedSubTasks.TabIndex = 3;
            this.lblCompletedSubTasks.Text = "0/0";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnDelete.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDelete.BorderRadius = 0;
            this.btnDelete.BorderSize = 0;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(513, 11);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(29, 33);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "X";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // customRadioButtonTaskName
            // 
            this.customRadioButtonTaskName.AutoSize = true;
            this.customRadioButtonTaskName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.customRadioButtonTaskName.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.customRadioButtonTaskName.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.customRadioButtonTaskName.ForeColor = System.Drawing.Color.White;
            this.customRadioButtonTaskName.Location = new System.Drawing.Point(4, 4);
            this.customRadioButtonTaskName.Margin = new System.Windows.Forms.Padding(4);
            this.customRadioButtonTaskName.MaximumSize = new System.Drawing.Size(490, 0);
            this.customRadioButtonTaskName.MinimumSize = new System.Drawing.Size(0, 26);
            this.customRadioButtonTaskName.Name = "customRadioButtonTaskName";
            this.customRadioButtonTaskName.Size = new System.Drawing.Size(75, 26);
            this.customRadioButtonTaskName.TabIndex = 4;
            this.customRadioButtonTaskName.TabStop = true;
            this.customRadioButtonTaskName.Text = "CRB";
            this.customRadioButtonTaskName.UnCheckedColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.customRadioButtonTaskName.UseVisualStyleBackColor = false;
            this.customRadioButtonTaskName.MouseEnter += new System.EventHandler(this.customRadioButtonTaskName_MouseEnter);
            // 
            // TaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.Controls.Add(this.pnlColorIndicator);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TaskView";
            this.Size = new System.Drawing.Size(560, 70);
            this.Click += new System.EventHandler(this.TaskView_Click);
            this.MouseEnter += new System.EventHandler(this.TaskView_MouseEnter);
            this.pnlColorIndicator.ResumeLayout(false);
            this.pnlColorIndicator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlColorIndicator;
        private System.Windows.Forms.Label lblCompletedSubTasks;
        private CustomRadioButton customRadioButtonTaskName;
        private CustomButtonV2 btnDelete;
        private System.Windows.Forms.Label lblDueDate;
    }
}
