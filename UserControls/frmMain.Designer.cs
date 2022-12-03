namespace DoYourTasks
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxAddSubTask = new System.Windows.Forms.TextBox();
            this.tlpTaskProperties = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddDueDate = new DoYourTasks.UserControls.CustomButtonV2();
            this.btnReminder = new DoYourTasks.UserControls.CustomButtonV2();
            this.btnRepeat = new DoYourTasks.UserControls.CustomButtonV2();
            this.tlpSubTasks = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbAddTask = new System.Windows.Forms.TextBox();
            this.lblProjName = new System.Windows.Forms.Label();
            this.tlpTasks = new System.Windows.Forms.TableLayoutPanel();
            this.tlpProjects = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAddNewList = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tlpTaskProperties.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Red;
            this.pnlTop.Controls.Add(this.btnNormal);
            this.pnlTop.Controls.Add(this.btnMinimizar);
            this.pnlTop.Controls.Add(this.btnCerrar);
            this.pnlTop.Controls.Add(this.btnMaximizar);
            this.pnlTop.Location = new System.Drawing.Point(2, -1);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1065, 49);
            this.pnlTop.TabIndex = 11;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            // 
            // btnNormal
            // 
            this.btnNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNormal.FlatAppearance.BorderSize = 0;
            this.btnNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNormal.Image = ((System.Drawing.Image)(resources.GetObject("btnNormal.Image")));
            this.btnNormal.Location = new System.Drawing.Point(975, 1);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(43, 34);
            this.btnNormal.TabIndex = 6;
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Visible = false;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(926, 1);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(43, 34);
            this.btnMinimizar.TabIndex = 5;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1019, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(39, 30);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.FlatAppearance.BorderSize = 0;
            this.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(975, 1);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(43, 36);
            this.btnMaximizar.TabIndex = 7;
            this.btnMaximizar.UseVisualStyleBackColor = true;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.BackColor = System.Drawing.Color.DimGray;
            this.pnlMain.Controls.Add(this.btnAddNewList);
            this.pnlMain.Controls.Add(this.panel3);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.tlpProjects);
            this.pnlMain.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlMain.Location = new System.Drawing.Point(2, 38);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1065, 711);
            this.pnlMain.TabIndex = 13;
            this.pnlMain.Click += new System.EventHandler(this.panel1_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.textBoxAddSubTask);
            this.panel3.Controls.Add(this.tlpTaskProperties);
            this.panel3.Controls.Add(this.tlpSubTasks);
            this.panel3.Location = new System.Drawing.Point(762, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(303, 655);
            this.panel3.TabIndex = 10;
            // 
            // textBoxAddSubTask
            // 
            this.textBoxAddSubTask.Location = new System.Drawing.Point(3, 370);
            this.textBoxAddSubTask.Multiline = true;
            this.textBoxAddSubTask.Name = "textBoxAddSubTask";
            this.textBoxAddSubTask.Size = new System.Drawing.Size(297, 41);
            this.textBoxAddSubTask.TabIndex = 14;
            this.textBoxAddSubTask.Text = "Add new sub task";
            this.textBoxAddSubTask.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbAddTask_KeyUp);
            // 
            // tlpTaskProperties
            // 
            this.tlpTaskProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tlpTaskProperties.AutoScroll = true;
            this.tlpTaskProperties.AutoSize = true;
            this.tlpTaskProperties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpTaskProperties.ColumnCount = 1;
            this.tlpTaskProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTaskProperties.Controls.Add(this.btnAddDueDate, 0, 0);
            this.tlpTaskProperties.Controls.Add(this.btnReminder, 0, 1);
            this.tlpTaskProperties.Controls.Add(this.btnRepeat, 0, 2);
            this.tlpTaskProperties.Location = new System.Drawing.Point(3, 238);
            this.tlpTaskProperties.Name = "tlpTaskProperties";
            this.tlpTaskProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tlpTaskProperties.RowCount = 3;
            this.tlpTaskProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTaskProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTaskProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpTaskProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTaskProperties.Size = new System.Drawing.Size(299, 126);
            this.tlpTaskProperties.TabIndex = 13;
            // 
            // btnAddDueDate
            // 
            this.btnAddDueDate.BackColor = System.Drawing.Color.Transparent;
            this.btnAddDueDate.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAddDueDate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAddDueDate.BorderRadius = 0;
            this.btnAddDueDate.BorderSize = 0;
            this.btnAddDueDate.FlatAppearance.BorderSize = 0;
            this.btnAddDueDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDueDate.ForeColor = System.Drawing.Color.White;
            this.btnAddDueDate.Location = new System.Drawing.Point(6, 6);
            this.btnAddDueDate.Name = "btnAddDueDate";
            this.btnAddDueDate.Size = new System.Drawing.Size(287, 30);
            this.btnAddDueDate.TabIndex = 1;
            this.btnAddDueDate.Text = "Add Due Date";
            this.btnAddDueDate.TextColor = System.Drawing.Color.White;
            this.btnAddDueDate.UseVisualStyleBackColor = false;
            // 
            // btnReminder
            // 
            this.btnReminder.BackColor = System.Drawing.Color.Transparent;
            this.btnReminder.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnReminder.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnReminder.BorderRadius = 0;
            this.btnReminder.BorderSize = 0;
            this.btnReminder.FlatAppearance.BorderSize = 0;
            this.btnReminder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReminder.ForeColor = System.Drawing.Color.White;
            this.btnReminder.Location = new System.Drawing.Point(6, 46);
            this.btnReminder.Name = "btnReminder";
            this.btnReminder.Size = new System.Drawing.Size(287, 30);
            this.btnReminder.TabIndex = 2;
            this.btnReminder.Text = "RemindMe";
            this.btnReminder.TextColor = System.Drawing.Color.White;
            this.btnReminder.UseVisualStyleBackColor = false;
            // 
            // btnRepeat
            // 
            this.btnRepeat.BackColor = System.Drawing.Color.Transparent;
            this.btnRepeat.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnRepeat.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnRepeat.BorderRadius = 0;
            this.btnRepeat.BorderSize = 0;
            this.btnRepeat.FlatAppearance.BorderSize = 0;
            this.btnRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepeat.ForeColor = System.Drawing.Color.White;
            this.btnRepeat.Location = new System.Drawing.Point(6, 86);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(287, 30);
            this.btnRepeat.TabIndex = 0;
            this.btnRepeat.Text = "Repeat";
            this.btnRepeat.TextColor = System.Drawing.Color.White;
            this.btnRepeat.UseVisualStyleBackColor = false;
            // 
            // tlpSubTasks
            // 
            this.tlpSubTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tlpSubTasks.AutoScroll = true;
            this.tlpSubTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpSubTasks.ColumnCount = 1;
            this.tlpSubTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSubTasks.Location = new System.Drawing.Point(3, 2);
            this.tlpSubTasks.Name = "tlpSubTasks";
            this.tlpSubTasks.RowCount = 1;
            this.tlpSubTasks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSubTasks.Size = new System.Drawing.Size(298, 230);
            this.tlpSubTasks.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.tbAddTask);
            this.panel2.Controls.Add(this.lblProjName);
            this.panel2.Controls.Add(this.tlpTasks);
            this.panel2.Location = new System.Drawing.Point(309, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 702);
            this.panel2.TabIndex = 8;
            // 
            // tbAddTask
            // 
            this.tbAddTask.Location = new System.Drawing.Point(1, 660);
            this.tbAddTask.Multiline = true;
            this.tbAddTask.Name = "tbAddTask";
            this.tbAddTask.Size = new System.Drawing.Size(447, 37);
            this.tbAddTask.TabIndex = 5;
            this.tbAddTask.Tag = "";
            this.tbAddTask.Text = "Add new task";
            this.tbAddTask.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbAddTask_KeyUp);
            this.tbAddTask.Leave += new System.EventHandler(this.tbAddTask_Leave);
            // 
            // lblProjName
            // 
            this.lblProjName.AutoSize = true;
            this.lblProjName.BackColor = System.Drawing.Color.Transparent;
            this.lblProjName.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(140)))), ((int)(((byte)(222)))));
            this.lblProjName.Location = new System.Drawing.Point(4, 11);
            this.lblProjName.Name = "lblProjName";
            this.lblProjName.Size = new System.Drawing.Size(191, 42);
            this.lblProjName.TabIndex = 3;
            this.lblProjName.Text = "ProjName";
            // 
            // tlpTasks
            // 
            this.tlpTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tlpTasks.AutoScroll = true;
            this.tlpTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpTasks.ColumnCount = 1;
            this.tlpTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTasks.Location = new System.Drawing.Point(1, 89);
            this.tlpTasks.MinimumSize = new System.Drawing.Size(300, 450);
            this.tlpTasks.Name = "tlpTasks";
            this.tlpTasks.RowCount = 1;
            this.tlpTasks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTasks.Size = new System.Drawing.Size(447, 567);
            this.tlpTasks.TabIndex = 2;
            // 
            // tlpProjects
            // 
            this.tlpProjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tlpProjects.ColumnCount = 1;
            this.tlpProjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProjects.Location = new System.Drawing.Point(3, 2);
            this.tlpProjects.Name = "tlpProjects";
            this.tlpProjects.RowCount = 1;
            this.tlpProjects.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.81098F));
            this.tlpProjects.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.18903F));
            this.tlpProjects.Size = new System.Drawing.Size(304, 656);
            this.tlpProjects.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Depth = 0;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(392, 1);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(55, 36);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddNewList
            // 
            this.btnAddNewList.AutoSize = true;
            this.btnAddNewList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddNewList.Depth = 0;
            this.btnAddNewList.Icon = null;
            this.btnAddNewList.Location = new System.Drawing.Point(3, 664);
            this.btnAddNewList.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddNewList.Name = "btnAddNewList";
            this.btnAddNewList.Primary = true;
            this.btnAddNewList.Size = new System.Drawing.Size(144, 36);
            this.btnAddNewList.TabIndex = 11;
            this.btnAddNewList.Text = "Add New Project";
            this.btnAddNewList.UseVisualStyleBackColor = true;
            this.btnAddNewList.Click += new System.EventHandler(this.btnNewList_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1069, 761);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1085, 800);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "frmMain";
            this.Text = "ToDo";
            this.pnlTop.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tlpTaskProperties.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblProjName;
        private System.Windows.Forms.TableLayoutPanel tlpTasks;
        private System.Windows.Forms.TableLayoutPanel tlpProjects;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tlpSubTasks;
        private System.Windows.Forms.TableLayoutPanel tlpTaskProperties;
        private DoYourTasks.UserControls.CustomButtonV2 btnReminder;
        private DoYourTasks.UserControls.CustomButtonV2 btnRepeat;
        private UserControls.CustomButtonV2 btnAddDueDate;
        private System.Windows.Forms.TextBox tbAddTask;
        private System.Windows.Forms.TextBox textBoxAddSubTask;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddNewList;
    }
}

