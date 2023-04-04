﻿namespace DoYourTasks
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
            this.pnlSave = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxChangePriority = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblVeryLow = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDoneTaskCount = new System.Windows.Forms.Label();
            this.lblVeryLowTaskCount = new System.Windows.Forms.Label();
            this.lblLowTaskCount = new System.Windows.Forms.Label();
            this.lblMediumTaskCount = new System.Windows.Forms.Label();
            this.lblHighTaskCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUrgentTaskCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblWaitingTaskCount = new System.Windows.Forms.Label();
            this.lblDontProceedTaskCount = new System.Windows.Forms.Label();
            this.tbAddTask = new System.Windows.Forms.TextBox();
            this.lblCredits = new System.Windows.Forms.Label();
            this.pnlCreationDate = new System.Windows.Forms.Panel();
            this.lblCreationDate = new System.Windows.Forms.Label();
            this.flpProjects = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlTasksHeader = new System.Windows.Forms.Panel();
            this.comboBoxFilterTaskPriority = new System.Windows.Forms.ComboBox();
            this.comboBoxFilterProjectPriority = new System.Windows.Forms.ComboBox();
            this.flpProjectAttachments = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProjectNotes = new System.Windows.Forms.Label();
            this.tbProjectNotes = new System.Windows.Forms.TextBox();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.lblSubtasksCommit = new System.Windows.Forms.Label();
            this.tbCommitMsg = new System.Windows.Forms.TextBox();
            this.lblProjName = new System.Windows.Forms.Label();
            this.flpTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flpTaskOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.tbAddSubTask = new System.Windows.Forms.TextBox();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.flpSubTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddProjectAttachment = new DoYourTasks.UserControls.CustomButtonV2();
            this.btnHideProject = new DoYourTasks.UserControls.CustomButtonV2();
            this.btnAddNewList = new DoYourTasks.UserControls.MaterialRaisedButton();
            this.btnShowHiddenProjects = new DoYourTasks.UserControls.MaterialRaisedButton();
            this.btnSave = new DoYourTasks.UserControls.MaterialRaisedButton();
            this.btnShowHiddenTasks = new DoYourTasks.UserControls.MaterialRaisedButton();
            this.btnOptionsMenu = new DoYourTasks.UserControls.MaterialRaisedButton();
            this.btnSetBackGroundImage = new DoYourTasks.UserControls.MaterialRaisedButton();
            this.pnlTop.SuspendLayout();
            this.pnlSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlCreationDate.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTasksHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flpTaskOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pnlTop.Controls.Add(this.pnlSave);
            this.pnlTop.Controls.Add(this.pbLogo);
            this.pnlTop.Controls.Add(this.btnNormal);
            this.pnlTop.Controls.Add(this.btnMinimizar);
            this.pnlTop.Controls.Add(this.btnCerrar);
            this.pnlTop.Controls.Add(this.btnMaximizar);
            this.pnlTop.Location = new System.Drawing.Point(2, -1);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1065, 41);
            this.pnlTop.TabIndex = 11;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            // 
            // pnlSave
            // 
            this.pnlSave.BackColor = System.Drawing.Color.Transparent;
            this.pnlSave.Controls.Add(this.label1);
            this.pnlSave.Location = new System.Drawing.Point(45, 5);
            this.pnlSave.Name = "pnlSave";
            this.pnlSave.Size = new System.Drawing.Size(166, 30);
            this.pnlSave.TabIndex = 9;
            this.pnlSave.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saved Successfully";
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.InitialImage")));
            this.pbLogo.Location = new System.Drawing.Point(4, 2);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(35, 35);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 8;
            this.pbLogo.TabStop = false;
            this.pbLogo.Click += new System.EventHandler(this.pbLogo_Click);
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
            this.btnCerrar.Click += new System.EventHandler(this.pbLogo_Click);
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
            this.pnlMain.BackColor = System.Drawing.Color.LightGray;
            this.pnlMain.Controls.Add(this.pnlStats);
            this.pnlMain.Controls.Add(this.btnAddNewList);
            this.pnlMain.Controls.Add(this.tbAddTask);
            this.pnlMain.Controls.Add(this.lblCredits);
            this.pnlMain.Controls.Add(this.pnlCreationDate);
            this.pnlMain.Controls.Add(this.flpProjects);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.panel3);
            this.pnlMain.Font = new System.Drawing.Font("Arial", 9F);
            this.pnlMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlMain.Location = new System.Drawing.Point(2, 38);
            this.pnlMain.MaximumSize = new System.Drawing.Size(1065, 795);
            this.pnlMain.MinimumSize = new System.Drawing.Size(1065, 795);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1065, 795);
            this.pnlMain.TabIndex = 13;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlStats
            // 
            this.pnlStats.Controls.Add(this.flowLayoutPanel1);
            this.pnlStats.Controls.Add(this.tableLayoutPanel1);
            this.pnlStats.Location = new System.Drawing.Point(0, 483);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(307, 205);
            this.pnlStats.TabIndex = 15;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.comboBoxChangePriority);
            this.flowLayoutPanel1.Controls.Add(this.btnAddProjectAttachment);
            this.flowLayoutPanel1.Controls.Add(this.btnHideProject);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(163, 87);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(140, 114);
            this.flowLayoutPanel1.TabIndex = 22;
            // 
            // comboBoxChangePriority
            // 
            this.comboBoxChangePriority.FormattingEnabled = true;
            this.comboBoxChangePriority.Location = new System.Drawing.Point(3, 3);
            this.comboBoxChangePriority.Name = "comboBoxChangePriority";
            this.comboBoxChangePriority.Size = new System.Drawing.Size(137, 35);
            this.comboBoxChangePriority.TabIndex = 21;
            this.comboBoxChangePriority.SelectedIndexChanged += new System.EventHandler(this.comboBoxProjectPriority_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.95082F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.04918F));
            this.tableLayoutPanel1.Controls.Add(this.lblVeryLow, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblDoneTaskCount, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblVeryLowTaskCount, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblLowTaskCount, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblMediumTaskCount, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblHighTaskCount, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUrgentTaskCount, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblWaitingTaskCount, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDontProceedTaskCount, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(123, 177);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // lblVeryLow
            // 
            this.lblVeryLow.AutoEllipsis = true;
            this.lblVeryLow.AutoSize = true;
            this.lblVeryLow.BackColor = System.Drawing.Color.Cyan;
            this.lblVeryLow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVeryLow.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblVeryLow.ForeColor = System.Drawing.Color.Black;
            this.lblVeryLow.Location = new System.Drawing.Point(4, 89);
            this.lblVeryLow.Name = "lblVeryLow";
            this.lblVeryLow.Size = new System.Drawing.Size(81, 21);
            this.lblVeryLow.TabIndex = 16;
            this.lblVeryLow.Tag = "";
            this.lblVeryLow.Text = "Very Low";
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Green;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 21);
            this.label5.TabIndex = 22;
            this.label5.Tag = "";
            this.label5.Text = "Done";
            // 
            // lblDoneTaskCount
            // 
            this.lblDoneTaskCount.AutoEllipsis = true;
            this.lblDoneTaskCount.AutoSize = true;
            this.lblDoneTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblDoneTaskCount.Location = new System.Drawing.Point(92, 155);
            this.lblDoneTaskCount.Name = "lblDoneTaskCount";
            this.lblDoneTaskCount.Size = new System.Drawing.Size(27, 21);
            this.lblDoneTaskCount.TabIndex = 23;
            this.lblDoneTaskCount.Tag = "";
            this.lblDoneTaskCount.Text = "0";
            // 
            // lblVeryLowTaskCount
            // 
            this.lblVeryLowTaskCount.AutoEllipsis = true;
            this.lblVeryLowTaskCount.AutoSize = true;
            this.lblVeryLowTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblVeryLowTaskCount.Location = new System.Drawing.Point(92, 89);
            this.lblVeryLowTaskCount.Name = "lblVeryLowTaskCount";
            this.lblVeryLowTaskCount.Size = new System.Drawing.Size(27, 21);
            this.lblVeryLowTaskCount.TabIndex = 17;
            this.lblVeryLowTaskCount.Tag = "";
            this.lblVeryLowTaskCount.Text = "0";
            // 
            // lblLowTaskCount
            // 
            this.lblLowTaskCount.AutoEllipsis = true;
            this.lblLowTaskCount.AutoSize = true;
            this.lblLowTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblLowTaskCount.Location = new System.Drawing.Point(92, 67);
            this.lblLowTaskCount.Name = "lblLowTaskCount";
            this.lblLowTaskCount.Size = new System.Drawing.Size(27, 21);
            this.lblLowTaskCount.TabIndex = 12;
            this.lblLowTaskCount.Tag = "";
            this.lblLowTaskCount.Text = "0";
            // 
            // lblMediumTaskCount
            // 
            this.lblMediumTaskCount.AutoEllipsis = true;
            this.lblMediumTaskCount.AutoSize = true;
            this.lblMediumTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblMediumTaskCount.Location = new System.Drawing.Point(92, 45);
            this.lblMediumTaskCount.Name = "lblMediumTaskCount";
            this.lblMediumTaskCount.Size = new System.Drawing.Size(27, 21);
            this.lblMediumTaskCount.TabIndex = 13;
            this.lblMediumTaskCount.Tag = "";
            this.lblMediumTaskCount.Text = "0";
            // 
            // lblHighTaskCount
            // 
            this.lblHighTaskCount.AutoEllipsis = true;
            this.lblHighTaskCount.AutoSize = true;
            this.lblHighTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblHighTaskCount.Location = new System.Drawing.Point(92, 23);
            this.lblHighTaskCount.Name = "lblHighTaskCount";
            this.lblHighTaskCount.Size = new System.Drawing.Size(27, 21);
            this.lblHighTaskCount.TabIndex = 14;
            this.lblHighTaskCount.Tag = "";
            this.lblHighTaskCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 21);
            this.label4.TabIndex = 20;
            this.label4.Tag = "";
            this.label4.Text = "On Hold";
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 21);
            this.label2.TabIndex = 10;
            this.label2.Tag = "";
            this.label2.Text = "Low";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Blue;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 21);
            this.label3.TabIndex = 11;
            this.label3.Tag = "";
            this.label3.Text = "Med";
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Yellow;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(4, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 21);
            this.label6.TabIndex = 15;
            this.label6.Tag = "";
            this.label6.Text = "High";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Red;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(4, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 21);
            this.label7.TabIndex = 24;
            this.label7.Text = "Urgent";
            // 
            // lblUrgentTaskCount
            // 
            this.lblUrgentTaskCount.AutoSize = true;
            this.lblUrgentTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblUrgentTaskCount.Location = new System.Drawing.Point(92, 1);
            this.lblUrgentTaskCount.Name = "lblUrgentTaskCount";
            this.lblUrgentTaskCount.Size = new System.Drawing.Size(27, 21);
            this.lblUrgentTaskCount.TabIndex = 25;
            this.lblUrgentTaskCount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoEllipsis = true;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Orange;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(4, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 21);
            this.label8.TabIndex = 18;
            this.label8.Tag = "";
            this.label8.Text = "Waiting";
            // 
            // lblWaitingTaskCount
            // 
            this.lblWaitingTaskCount.AutoEllipsis = true;
            this.lblWaitingTaskCount.AutoSize = true;
            this.lblWaitingTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblWaitingTaskCount.Location = new System.Drawing.Point(92, 133);
            this.lblWaitingTaskCount.Name = "lblWaitingTaskCount";
            this.lblWaitingTaskCount.Size = new System.Drawing.Size(27, 21);
            this.lblWaitingTaskCount.TabIndex = 19;
            this.lblWaitingTaskCount.Tag = "";
            this.lblWaitingTaskCount.Text = "0";
            // 
            // lblDontProceedTaskCount
            // 
            this.lblDontProceedTaskCount.AutoEllipsis = true;
            this.lblDontProceedTaskCount.AutoSize = true;
            this.lblDontProceedTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblDontProceedTaskCount.Location = new System.Drawing.Point(92, 111);
            this.lblDontProceedTaskCount.Name = "lblDontProceedTaskCount";
            this.lblDontProceedTaskCount.Size = new System.Drawing.Size(27, 21);
            this.lblDontProceedTaskCount.TabIndex = 21;
            this.lblDontProceedTaskCount.Tag = "";
            this.lblDontProceedTaskCount.Text = "0";
            // 
            // tbAddTask
            // 
            this.tbAddTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(140)))), ((int)(((byte)(222)))));
            this.tbAddTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbAddTask.Location = new System.Drawing.Point(309, 697);
            this.tbAddTask.MaximumSize = new System.Drawing.Size(450, 40);
            this.tbAddTask.MinimumSize = new System.Drawing.Size(450, 40);
            this.tbAddTask.Multiline = true;
            this.tbAddTask.Name = "tbAddTask";
            this.tbAddTask.Size = new System.Drawing.Size(450, 40);
            this.tbAddTask.TabIndex = 14;
            this.tbAddTask.Tag = "Add new task";
            this.tbAddTask.Text = "Add new task";
            this.tbAddTask.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbAddTask_KeyUp);
            this.tbAddTask.Leave += new System.EventHandler(this.tbAddTask_Leave);
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold);
            this.lblCredits.ForeColor = System.Drawing.Color.Gray;
            this.lblCredits.Location = new System.Drawing.Point(3, 743);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(151, 19);
            this.lblCredits.TabIndex = 1;
            this.lblCredits.Text = "Created By alws34";
            this.lblCredits.Visible = false;
            // 
            // pnlCreationDate
            // 
            this.pnlCreationDate.BackColor = System.Drawing.Color.Transparent;
            this.pnlCreationDate.Controls.Add(this.lblCreationDate);
            this.pnlCreationDate.Location = new System.Drawing.Point(761, 697);
            this.pnlCreationDate.Name = "pnlCreationDate";
            this.pnlCreationDate.Size = new System.Drawing.Size(302, 41);
            this.pnlCreationDate.TabIndex = 13;
            // 
            // lblCreationDate
            // 
            this.lblCreationDate.AutoSize = true;
            this.lblCreationDate.BackColor = System.Drawing.Color.Transparent;
            this.lblCreationDate.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblCreationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(140)))), ((int)(((byte)(222)))));
            this.lblCreationDate.Location = new System.Drawing.Point(3, 9);
            this.lblCreationDate.Name = "lblCreationDate";
            this.lblCreationDate.Size = new System.Drawing.Size(280, 45);
            this.lblCreationDate.TabIndex = 0;
            this.lblCreationDate.Text = "Creation Date:";
            this.lblCreationDate.Visible = false;
            // 
            // flpProjects
            // 
            this.flpProjects.AllowDrop = true;
            this.flpProjects.AutoScroll = true;
            this.flpProjects.BackColor = System.Drawing.Color.Transparent;
            this.flpProjects.Location = new System.Drawing.Point(4, 5);
            this.flpProjects.Name = "flpProjects";
            this.flpProjects.Size = new System.Drawing.Size(303, 472);
            this.flpProjects.TabIndex = 12;
            this.flpProjects.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flpProjects_ControlAdded);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.pnlTasksHeader);
            this.panel2.Controls.Add(this.flpTasks);
            this.panel2.Location = new System.Drawing.Point(309, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 686);
            this.panel2.TabIndex = 8;
            // 
            // pnlTasksHeader
            // 
            this.pnlTasksHeader.BackColor = System.Drawing.Color.LightGray;
            this.pnlTasksHeader.Controls.Add(this.btnShowHiddenProjects);
            this.pnlTasksHeader.Controls.Add(this.comboBoxFilterTaskPriority);
            this.pnlTasksHeader.Controls.Add(this.comboBoxFilterProjectPriority);
            this.pnlTasksHeader.Controls.Add(this.btnSave);
            this.pnlTasksHeader.Controls.Add(this.flpProjectAttachments);
            this.pnlTasksHeader.Controls.Add(this.panel1);
            this.pnlTasksHeader.Controls.Add(this.btnShowHiddenTasks);
            this.pnlTasksHeader.Controls.Add(this.btnOptionsMenu);
            this.pnlTasksHeader.Controls.Add(this.pnlOptions);
            this.pnlTasksHeader.Controls.Add(this.lblProjName);
            this.pnlTasksHeader.Location = new System.Drawing.Point(2, 3);
            this.pnlTasksHeader.MaximumSize = new System.Drawing.Size(445, 667);
            this.pnlTasksHeader.MinimumSize = new System.Drawing.Size(445, 90);
            this.pnlTasksHeader.Name = "pnlTasksHeader";
            this.pnlTasksHeader.Size = new System.Drawing.Size(445, 90);
            this.pnlTasksHeader.TabIndex = 0;
            // 
            // comboBoxFilterTaskPriority
            // 
            this.comboBoxFilterTaskPriority.FormattingEnabled = true;
            this.comboBoxFilterTaskPriority.Location = new System.Drawing.Point(322, 67);
            this.comboBoxFilterTaskPriority.Name = "comboBoxFilterTaskPriority";
            this.comboBoxFilterTaskPriority.Size = new System.Drawing.Size(121, 35);
            this.comboBoxFilterTaskPriority.TabIndex = 15;
            this.comboBoxFilterTaskPriority.Tag = "Task Priority";
            this.comboBoxFilterTaskPriority.Text = "Task Priority";
            this.comboBoxFilterTaskPriority.SelectedIndexChanged += new System.EventHandler(this.comboBoxTaskPriority_SelectedIndexChanged);
            // 
            // comboBoxFilterProjectPriority
            // 
            this.comboBoxFilterProjectPriority.FormattingEnabled = true;
            this.comboBoxFilterProjectPriority.Location = new System.Drawing.Point(322, 38);
            this.comboBoxFilterProjectPriority.Name = "comboBoxFilterProjectPriority";
            this.comboBoxFilterProjectPriority.Size = new System.Drawing.Size(121, 35);
            this.comboBoxFilterProjectPriority.TabIndex = 14;
            this.comboBoxFilterProjectPriority.Tag = "Project Priority";
            this.comboBoxFilterProjectPriority.Text = "Project Priority";
            this.comboBoxFilterProjectPriority.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilterProjectPriority_SelectedIndexChanged);
            // 
            // flpProjectAttachments
            // 
            this.flpProjectAttachments.Location = new System.Drawing.Point(4, 475);
            this.flpProjectAttachments.Name = "flpProjectAttachments";
            this.flpProjectAttachments.Size = new System.Drawing.Size(433, 189);
            this.flpProjectAttachments.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblProjectNotes);
            this.panel1.Controls.Add(this.tbProjectNotes);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(4, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 319);
            this.panel1.TabIndex = 12;
            // 
            // lblProjectNotes
            // 
            this.lblProjectNotes.AutoSize = true;
            this.lblProjectNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblProjectNotes.ForeColor = System.Drawing.Color.White;
            this.lblProjectNotes.Location = new System.Drawing.Point(3, 0);
            this.lblProjectNotes.Name = "lblProjectNotes";
            this.lblProjectNotes.Size = new System.Drawing.Size(180, 30);
            this.lblProjectNotes.TabIndex = 9;
            this.lblProjectNotes.Text = "Project Notes";
            // 
            // tbProjectNotes
            // 
            this.tbProjectNotes.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbProjectNotes.Location = new System.Drawing.Point(4, 17);
            this.tbProjectNotes.Multiline = true;
            this.tbProjectNotes.Name = "tbProjectNotes";
            this.tbProjectNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbProjectNotes.Size = new System.Drawing.Size(227, 299);
            this.tbProjectNotes.TabIndex = 8;
            this.tbProjectNotes.Tag = "No Project Notes";
            this.tbProjectNotes.Text = "No Project Notes";
            this.tbProjectNotes.TextChanged += new System.EventHandler(this.tbProjectNotes_TextChanged);
            this.tbProjectNotes.Enter += new System.EventHandler(this.tbProjectNotes_Enter);
            this.tbProjectNotes.Leave += new System.EventHandler(this.TbAddTask_LostFocus);
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.Color.Transparent;
            this.pnlOptions.Controls.Add(this.lblSubtasksCommit);
            this.pnlOptions.Controls.Add(this.tbCommitMsg);
            this.pnlOptions.Controls.Add(this.btnSetBackGroundImage);
            this.pnlOptions.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlOptions.Location = new System.Drawing.Point(244, 150);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(193, 319);
            this.pnlOptions.TabIndex = 8;
            // 
            // lblSubtasksCommit
            // 
            this.lblSubtasksCommit.AutoSize = true;
            this.lblSubtasksCommit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblSubtasksCommit.ForeColor = System.Drawing.Color.White;
            this.lblSubtasksCommit.Location = new System.Drawing.Point(3, 0);
            this.lblSubtasksCommit.Name = "lblSubtasksCommit";
            this.lblSubtasksCommit.Size = new System.Drawing.Size(289, 30);
            this.lblSubtasksCommit.TabIndex = 9;
            this.lblSubtasksCommit.Text = "Task Commit messge:";
            // 
            // tbCommitMsg
            // 
            this.tbCommitMsg.Location = new System.Drawing.Point(3, 19);
            this.tbCommitMsg.Multiline = true;
            this.tbCommitMsg.Name = "tbCommitMsg";
            this.tbCommitMsg.Size = new System.Drawing.Size(186, 297);
            this.tbCommitMsg.TabIndex = 8;
            // 
            // lblProjName
            // 
            this.lblProjName.AutoEllipsis = true;
            this.lblProjName.BackColor = System.Drawing.Color.Transparent;
            this.lblProjName.Font = new System.Drawing.Font("Arial", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(140)))), ((int)(((byte)(222)))));
            this.lblProjName.Location = new System.Drawing.Point(4, -1);
            this.lblProjName.MaximumSize = new System.Drawing.Size(320, 45);
            this.lblProjName.MinimumSize = new System.Drawing.Size(320, 45);
            this.lblProjName.Name = "lblProjName";
            this.lblProjName.Size = new System.Drawing.Size(320, 45);
            this.lblProjName.TabIndex = 3;
            this.lblProjName.Text = "ProjName";
            // 
            // flpTasks
            // 
            this.flpTasks.AllowDrop = true;
            this.flpTasks.AutoScroll = true;
            this.flpTasks.BackColor = System.Drawing.Color.Transparent;
            this.flpTasks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpTasks.Location = new System.Drawing.Point(0, 98);
            this.flpTasks.MaximumSize = new System.Drawing.Size(450, 605);
            this.flpTasks.MinimumSize = new System.Drawing.Size(450, 255);
            this.flpTasks.Name = "flpTasks";
            this.flpTasks.Size = new System.Drawing.Size(450, 588);
            this.flpTasks.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.flpTaskOptions);
            this.panel3.Controls.Add(this.flpSubTasks);
            this.panel3.Location = new System.Drawing.Point(760, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(305, 686);
            this.panel3.TabIndex = 10;
            // 
            // flpTaskOptions
            // 
            this.flpTaskOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpTaskOptions.Controls.Add(this.tbAddSubTask);
            this.flpTaskOptions.Controls.Add(this.tbNotes);
            this.flpTaskOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTaskOptions.Location = new System.Drawing.Point(3, 387);
            this.flpTaskOptions.MinimumSize = new System.Drawing.Size(286, 34);
            this.flpTaskOptions.Name = "flpTaskOptions";
            this.flpTaskOptions.Size = new System.Drawing.Size(302, 296);
            this.flpTaskOptions.TabIndex = 15;
            // 
            // tbAddSubTask
            // 
            this.tbAddSubTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(140)))), ((int)(((byte)(222)))));
            this.tbAddSubTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tbAddSubTask.Location = new System.Drawing.Point(3, 3);
            this.tbAddSubTask.MaximumSize = new System.Drawing.Size(296, 40);
            this.tbAddSubTask.MinimumSize = new System.Drawing.Size(296, 40);
            this.tbAddSubTask.Multiline = true;
            this.tbAddSubTask.Name = "tbAddSubTask";
            this.tbAddSubTask.Size = new System.Drawing.Size(296, 40);
            this.tbAddSubTask.TabIndex = 14;
            this.tbAddSubTask.Tag = "Add new sub task";
            this.tbAddSubTask.Text = "Add new sub task";
            this.tbAddSubTask.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbAddTask_KeyUp);
            this.tbAddSubTask.Leave += new System.EventHandler(this.tbAddTask_Leave);
            // 
            // tbNotes
            // 
            this.tbNotes.BackColor = System.Drawing.SystemColors.Window;
            this.tbNotes.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.tbNotes.Location = new System.Drawing.Point(3, 49);
            this.tbNotes.MaximumSize = new System.Drawing.Size(296, 230);
            this.tbNotes.MinimumSize = new System.Drawing.Size(296, 230);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNotes.Size = new System.Drawing.Size(296, 230);
            this.tbNotes.TabIndex = 16;
            this.tbNotes.Tag = "Add Notes";
            this.tbNotes.Text = "Add Notes";
            this.tbNotes.Visible = false;
            this.tbNotes.TextChanged += new System.EventHandler(this.tbNotes_TextChanged);
            this.tbNotes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbAddTask_KeyUp);
            this.tbNotes.Leave += new System.EventHandler(this.TbAddTask_LostFocus);
            // 
            // flpSubTasks
            // 
            this.flpSubTasks.AllowDrop = true;
            this.flpSubTasks.AutoScroll = true;
            this.flpSubTasks.BackColor = System.Drawing.Color.Transparent;
            this.flpSubTasks.Location = new System.Drawing.Point(3, 2);
            this.flpSubTasks.Name = "flpSubTasks";
            this.flpSubTasks.Size = new System.Drawing.Size(299, 382);
            this.flpSubTasks.TabIndex = 15;
            // 
            // btnAddProjectAttachment
            // 
            this.btnAddProjectAttachment.BackColor = System.Drawing.Color.Transparent;
            this.btnAddProjectAttachment.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAddProjectAttachment.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAddProjectAttachment.BorderRadius = 0;
            this.btnAddProjectAttachment.BorderSize = 0;
            this.btnAddProjectAttachment.FlatAppearance.BorderSize = 0;
            this.btnAddProjectAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProjectAttachment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProjectAttachment.ForeColor = System.Drawing.Color.Black;
            this.btnAddProjectAttachment.Location = new System.Drawing.Point(3, 44);
            this.btnAddProjectAttachment.Name = "btnAddProjectAttachment";
            this.btnAddProjectAttachment.Size = new System.Drawing.Size(137, 29);
            this.btnAddProjectAttachment.TabIndex = 19;
            this.btnAddProjectAttachment.Text = "Add  Attachment";
            this.btnAddProjectAttachment.TextColor = System.Drawing.Color.Black;
            this.btnAddProjectAttachment.UseVisualStyleBackColor = false;
            this.btnAddProjectAttachment.Click += new System.EventHandler(this.btnAddProjectAttachment_Click);
            // 
            // btnHideProject
            // 
            this.btnHideProject.BackColor = System.Drawing.Color.Transparent;
            this.btnHideProject.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnHideProject.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnHideProject.BorderRadius = 0;
            this.btnHideProject.BorderSize = 0;
            this.btnHideProject.FlatAppearance.BorderSize = 0;
            this.btnHideProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideProject.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHideProject.ForeColor = System.Drawing.Color.Black;
            this.btnHideProject.Location = new System.Drawing.Point(3, 79);
            this.btnHideProject.Name = "btnHideProject";
            this.btnHideProject.Size = new System.Drawing.Size(137, 29);
            this.btnHideProject.TabIndex = 20;
            this.btnHideProject.Text = "Hide Project";
            this.btnHideProject.TextColor = System.Drawing.Color.Black;
            this.btnHideProject.UseVisualStyleBackColor = false;
            this.btnHideProject.Click += new System.EventHandler(this.btnHideProject_Click);
            // 
            // btnAddNewList
            // 
            this.btnAddNewList.AutoSize = true;
            this.btnAddNewList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddNewList.Depth = 0;
            this.btnAddNewList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnAddNewList.Icon = null;
            this.btnAddNewList.Location = new System.Drawing.Point(5, 697);
            this.btnAddNewList.MinimumSize = new System.Drawing.Size(303, 41);
            this.btnAddNewList.MouseState = DoYourTasks.MouseState.HOVER;
            this.btnAddNewList.Name = "btnAddNewList";
            this.btnAddNewList.Primary = true;
            this.btnAddNewList.Size = new System.Drawing.Size(303, 41);
            this.btnAddNewList.TabIndex = 11;
            this.btnAddNewList.Text = "Add New Project";
            this.btnAddNewList.UseVisualStyleBackColor = true;
            this.btnAddNewList.Click += new System.EventHandler(this.btnNewList_Click);
            // 
            // btnShowHiddenProjects
            // 
            this.btnShowHiddenProjects.AutoSize = true;
            this.btnShowHiddenProjects.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShowHiddenProjects.Depth = 0;
            this.btnShowHiddenProjects.Icon = null;
            this.btnShowHiddenProjects.Location = new System.Drawing.Point(121, 47);
            this.btnShowHiddenProjects.MouseState = DoYourTasks.MouseState.HOVER;
            this.btnShowHiddenProjects.Name = "btnShowHiddenProjects";
            this.btnShowHiddenProjects.Primary = true;
            this.btnShowHiddenProjects.Size = new System.Drawing.Size(377, 36);
            this.btnShowHiddenProjects.TabIndex = 10;
            this.btnShowHiddenProjects.Text = "Show Hidden Projects";
            this.btnShowHiddenProjects.UseVisualStyleBackColor = true;
            this.btnShowHiddenProjects.Click += new System.EventHandler(this.btnShowHiddenProjects_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Depth = 0;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(379, 3);
            this.btnSave.MouseState = DoYourTasks.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(99, 36);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnShowHiddenTasks
            // 
            this.btnShowHiddenTasks.AutoSize = true;
            this.btnShowHiddenTasks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShowHiddenTasks.Depth = 0;
            this.btnShowHiddenTasks.Icon = null;
            this.btnShowHiddenTasks.Location = new System.Drawing.Point(4, 108);
            this.btnShowHiddenTasks.MouseState = DoYourTasks.MouseState.HOVER;
            this.btnShowHiddenTasks.Name = "btnShowHiddenTasks";
            this.btnShowHiddenTasks.Primary = true;
            this.btnShowHiddenTasks.Size = new System.Drawing.Size(321, 36);
            this.btnShowHiddenTasks.TabIndex = 11;
            this.btnShowHiddenTasks.Text = "Show Hidden Tasks";
            this.btnShowHiddenTasks.UseVisualStyleBackColor = true;
            this.btnShowHiddenTasks.Click += new System.EventHandler(this.btnShowHiddenTasks_Click);
            // 
            // btnOptionsMenu
            // 
            this.btnOptionsMenu.AutoSize = true;
            this.btnOptionsMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOptionsMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnOptionsMenu.Depth = 0;
            this.btnOptionsMenu.Icon = global::DoYourTasks.Properties.Resources.icons8_menu_30;
            this.btnOptionsMenu.ImageKey = "(none)";
            this.btnOptionsMenu.Location = new System.Drawing.Point(8, 47);
            this.btnOptionsMenu.MouseState = DoYourTasks.MouseState.HOVER;
            this.btnOptionsMenu.Name = "btnOptionsMenu";
            this.btnOptionsMenu.Primary = true;
            this.btnOptionsMenu.Size = new System.Drawing.Size(182, 36);
            this.btnOptionsMenu.TabIndex = 7;
            this.btnOptionsMenu.Text = "Project\r\nOptions";
            this.btnOptionsMenu.UseVisualStyleBackColor = false;
            this.btnOptionsMenu.Click += new System.EventHandler(this.btnOptionsMenu_Click);
            // 
            // btnSetBackGroundImage
            // 
            this.btnSetBackGroundImage.AutoSize = true;
            this.btnSetBackGroundImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSetBackGroundImage.Depth = 0;
            this.btnSetBackGroundImage.Icon = null;
            this.btnSetBackGroundImage.Location = new System.Drawing.Point(3, 0);
            this.btnSetBackGroundImage.MouseState = DoYourTasks.MouseState.HOVER;
            this.btnSetBackGroundImage.Name = "btnSetBackGroundImage";
            this.btnSetBackGroundImage.Primary = true;
            this.btnSetBackGroundImage.Size = new System.Drawing.Size(248, 36);
            this.btnSetBackGroundImage.TabIndex = 7;
            this.btnSetBackGroundImage.Text = "Choose Theme";
            this.btnSetBackGroundImage.UseVisualStyleBackColor = true;
            this.btnSetBackGroundImage.Visible = false;
            this.btnSetBackGroundImage.Click += new System.EventHandler(this.btnSetBackGroundImage_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1069, 793);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1085, 800);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "frmMain";
            this.Text = "ToDo";
            this.pnlTop.ResumeLayout(false);
            this.pnlSave.ResumeLayout(false);
            this.pnlSave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlCreationDate.ResumeLayout(false);
            this.pnlCreationDate.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlTasksHeader.ResumeLayout(false);
            this.pnlTasksHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.flpTaskOptions.ResumeLayout(false);
            this.flpTaskOptions.PerformLayout();
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
        private System.Windows.Forms.Panel panel3;
        private DoYourTasks.UserControls.CustomButtonV2 btnReminder;
        private DoYourTasks.UserControls.CustomButtonV2 btnRepeat;
        private UserControls.CustomButtonV2 btnAddDueDate;
        private  DoYourTasks.UserControls.MaterialRaisedButton btnAddNewList;
        private System.Windows.Forms.FlowLayoutPanel flpProjects;
        private System.Windows.Forms.FlowLayoutPanel flpSubTasks;
        private System.Windows.Forms.Panel pnlCreationDate;
        private System.Windows.Forms.Label lblCreationDate;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.FlowLayoutPanel flpTasks;
        private System.Windows.Forms.Panel pnlTasksHeader;
        private System.Windows.Forms.Label lblProjName;
        private  DoYourTasks.UserControls.MaterialRaisedButton btnSave;
        private  DoYourTasks.UserControls.MaterialRaisedButton btnOptionsMenu;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.TextBox tbAddTask;
        private  DoYourTasks.UserControls.MaterialRaisedButton btnSetBackGroundImage;
        private System.Windows.Forms.FlowLayoutPanel flpTaskOptions;
        private System.Windows.Forms.TextBox tbCommitMsg;
        private System.Windows.Forms.TextBox tbAddSubTask;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Panel pnlSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSubtasksCommit;
        private UserControls.MaterialRaisedButton btnShowHiddenProjects;
        private UserControls.MaterialRaisedButton btnShowHiddenTasks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProjectNotes;
        private System.Windows.Forms.TextBox tbProjectNotes;
        private System.Windows.Forms.FlowLayoutPanel flpProjectAttachments;
        private System.Windows.Forms.ComboBox comboBoxFilterProjectPriority;
        private System.Windows.Forms.ComboBox comboBoxFilterTaskPriority;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblVeryLow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDoneTaskCount;
        private System.Windows.Forms.Label lblVeryLowTaskCount;
        private System.Windows.Forms.Label lblLowTaskCount;
        private System.Windows.Forms.Label lblMediumTaskCount;
        private System.Windows.Forms.Label lblHighTaskCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblUrgentTaskCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblWaitingTaskCount;
        private System.Windows.Forms.Label lblDontProceedTaskCount;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxChangePriority;
        private UserControls.CustomButtonV2 btnAddProjectAttachment;
        private UserControls.CustomButtonV2 btnHideProject;
    }
}

