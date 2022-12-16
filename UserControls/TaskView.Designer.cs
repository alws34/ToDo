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
            this.btnDelete = new DoYourTasks.UserControls.CustomButtonV2();
            this.lblCompletedSubTasks = new System.Windows.Forms.Label();
            this.customRadioButtonTaskName = new DoYourTasks.UserControls.CustomRadioButton();
            this.pnlColorIndicator.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlColorIndicator
            // 
            this.pnlColorIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlColorIndicator.BackColor = System.Drawing.Color.Transparent;
            this.pnlColorIndicator.Controls.Add(this.btnDelete);
            this.pnlColorIndicator.Controls.Add(this.lblCompletedSubTasks);
            this.pnlColorIndicator.Controls.Add(this.customRadioButtonTaskName);
            this.pnlColorIndicator.ForeColor = System.Drawing.Color.Transparent;
            this.pnlColorIndicator.Location = new System.Drawing.Point(4, 4);
            this.pnlColorIndicator.Name = "pnlColorIndicator";
            this.pnlColorIndicator.Size = new System.Drawing.Size(410, 48);
            this.pnlColorIndicator.TabIndex = 0;
            this.pnlColorIndicator.Click += new System.EventHandler(this.TaskView_Click);
            this.pnlColorIndicator.MouseEnter += new System.EventHandler(this.pnlColorIndicator_MouseEnter);
            this.pnlColorIndicator.MouseLeave += new System.EventHandler(this.pnlColorIndicator_MouseLeave);
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
            this.btnDelete.Location = new System.Drawing.Point(385, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(22, 27);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "X";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblCompletedSubTasks
            // 
            this.lblCompletedSubTasks.AutoSize = true;
            this.lblCompletedSubTasks.BackColor = System.Drawing.Color.Transparent;
            this.lblCompletedSubTasks.ForeColor = System.Drawing.Color.White;
            this.lblCompletedSubTasks.Location = new System.Drawing.Point(31, 26);
            this.lblCompletedSubTasks.Name = "lblCompletedSubTasks";
            this.lblCompletedSubTasks.Size = new System.Drawing.Size(24, 13);
            this.lblCompletedSubTasks.TabIndex = 3;
            this.lblCompletedSubTasks.Text = "0/0";
            // 
            // customRadioButtonTaskName
            // 
            this.customRadioButtonTaskName.AutoSize = true;
            this.customRadioButtonTaskName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(56)))), ((int)(((byte)(57)))));
            this.customRadioButtonTaskName.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.customRadioButtonTaskName.Font = new System.Drawing.Font("Arial", 14F);
            this.customRadioButtonTaskName.ForeColor = System.Drawing.Color.White;
            this.customRadioButtonTaskName.Location = new System.Drawing.Point(3, 3);
            this.customRadioButtonTaskName.MinimumSize = new System.Drawing.Size(0, 21);
            this.customRadioButtonTaskName.Name = "customRadioButtonTaskName";
            this.customRadioButtonTaskName.Size = new System.Drawing.Size(81, 26);
            this.customRadioButtonTaskName.TabIndex = 4;
            this.customRadioButtonTaskName.TabStop = true;
            this.customRadioButtonTaskName.Text = "CRB";
            this.customRadioButtonTaskName.UnCheckedColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.customRadioButtonTaskName.UseVisualStyleBackColor = true;
            // 
            // TaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(56)))), ((int)(((byte)(57)))));
            this.Controls.Add(this.pnlColorIndicator);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "TaskView";
            this.Size = new System.Drawing.Size(420, 57);
            this.Click += new System.EventHandler(this.TaskView_Click);
            this.pnlColorIndicator.ResumeLayout(false);
            this.pnlColorIndicator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlColorIndicator;
        private System.Windows.Forms.Label lblCompletedSubTasks;
        private CustomRadioButton customRadioButtonTaskName;
        private CustomButtonV2 btnDelete;
    }
}
