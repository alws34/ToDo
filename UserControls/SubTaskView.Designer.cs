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
            this.customRadioButtonTaskName = new DoYourTasks.UserControls.CustomRadioButton();
            this.btnDelete = new DoYourTasks.UserControls.CustomButtonV2();
            this.lblSubTaskName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // customRadioButtonTaskName
            // 
            this.customRadioButtonTaskName.AutoSize = true;
            this.customRadioButtonTaskName.BackColor = System.Drawing.Color.White;
            this.customRadioButtonTaskName.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.customRadioButtonTaskName.Font = new System.Drawing.Font("Arial", 14F);
            this.customRadioButtonTaskName.ForeColor = System.Drawing.Color.White;
            this.customRadioButtonTaskName.Location = new System.Drawing.Point(3, 3);
            this.customRadioButtonTaskName.MinimumSize = new System.Drawing.Size(0, 21);
            this.customRadioButtonTaskName.Name = "customRadioButtonTaskName";
            this.customRadioButtonTaskName.Size = new System.Drawing.Size(30, 21);
            this.customRadioButtonTaskName.TabIndex = 1;
            this.customRadioButtonTaskName.TabStop = true;
            this.customRadioButtonTaskName.UnCheckedColor = System.Drawing.Color.Gray;
            this.customRadioButtonTaskName.UseVisualStyleBackColor = true;
            this.customRadioButtonTaskName.CheckedChanged += new System.EventHandler(this.customRadioButtonTaskName_CheckedChanged);
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
            this.btnDelete.Location = new System.Drawing.Point(275, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(22, 27);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "X";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblSubTaskName
            // 
            this.lblSubTaskName.AutoSize = true;
            this.lblSubTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTaskName.ForeColor = System.Drawing.Color.White;
            this.lblSubTaskName.Location = new System.Drawing.Point(38, 5);
            this.lblSubTaskName.Name = "lblSubTaskName";
            this.lblSubTaskName.Size = new System.Drawing.Size(97, 20);
            this.lblSubTaskName.TabIndex = 4;
            this.lblSubTaskName.Text = "lblSubTask";
            // 
            // SubTaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblSubTaskName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.customRadioButtonTaskName);
            this.Name = "SubTaskView";
            this.Size = new System.Drawing.Size(300, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomRadioButton customRadioButtonTaskName;
        private CustomButtonV2 btnDelete;
        private System.Windows.Forms.Label lblSubTaskName;
    }
}
