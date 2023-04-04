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
            this.pnlSave = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tbAddTask = new System.Windows.Forms.TextBox();
            this.lblCredits = new System.Windows.Forms.Label();
            this.pnlCreationDate = new System.Windows.Forms.Panel();
            this.lblCreationDate = new System.Windows.Forms.Label();
            this.flpProjects = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlTasksHeader = new System.Windows.Forms.Panel();
            this.comboBoxTaskPriority = new System.Windows.Forms.ComboBox();
            this.comboBoxProjectPriority = new System.Windows.Forms.ComboBox();
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
            this.btnAddNewList = new DoYourTasks.UserControls.MaterialRaisedButton();
            this.btnShowHiddenProjects = new DoYourTasks.UserControls.MaterialRaisedButton();
            this.btnSave = new DoYourTasks.UserControls.MaterialRaisedButton();
            this.btnShowHiddenTasks = new DoYourTasks.UserControls.MaterialRaisedButton();
            this.btnOptionsMenu = new DoYourTasks.UserControls.MaterialRaisedButton();
            this.btnSetBackGroundImage = new DoYourTasks.UserControls.MaterialRaisedButton();
            this.btnAddNotes = new DoYourTasks.UserControls.MaterialRaisedButton();
            this.btnAddAttachment = new DoYourTasks.UserControls.MaterialRaisedButton();
            this.pnlTop.SuspendLayout();
            this.pnlSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlMain.SuspendLayout();
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
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
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
            // tbAddTask
            // 
            this.tbAddTask.BackColor = System.Drawing.Color.DeepSkyBlue;
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
            this.pnlCreationDate.Controls.Add(this.lblCreationDate);
            this.pnlCreationDate.Location = new System.Drawing.Point(761, 697);
            this.pnlCreationDate.Name = "pnlCreationDate";
            this.pnlCreationDate.Size = new System.Drawing.Size(302, 41);
            this.pnlCreationDate.TabIndex = 13;
            // 
            // lblCreationDate
            // 
            this.lblCreationDate.AutoSize = true;
            this.lblCreationDate.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblCreationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
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
            this.flpProjects.Size = new System.Drawing.Size(303, 686);
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
            this.pnlTasksHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlTasksHeader.Controls.Add(this.btnShowHiddenProjects);
            this.pnlTasksHeader.Controls.Add(this.comboBoxTaskPriority);
            this.pnlTasksHeader.Controls.Add(this.comboBoxProjectPriority);
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
            // comboBoxTaskPriority
            // 
            this.comboBoxTaskPriority.FormattingEnabled = true;
            this.comboBoxTaskPriority.Location = new System.Drawing.Point(322, 67);
            this.comboBoxTaskPriority.Name = "comboBoxTaskPriority";
            this.comboBoxTaskPriority.Size = new System.Drawing.Size(121, 35);
            this.comboBoxTaskPriority.TabIndex = 15;
            this.comboBoxTaskPriority.Tag = "Task Priority";
            this.comboBoxTaskPriority.Text = "Task Priority";
            this.comboBoxTaskPriority.SelectedIndexChanged += new System.EventHandler(this.comboBoxTaskPriority_SelectedIndexChanged);
            // 
            // comboBoxProjectPriority
            // 
            this.comboBoxProjectPriority.FormattingEnabled = true;
            this.comboBoxProjectPriority.Location = new System.Drawing.Point(322, 38);
            this.comboBoxProjectPriority.Name = "comboBoxProjectPriority";
            this.comboBoxProjectPriority.Size = new System.Drawing.Size(121, 35);
            this.comboBoxProjectPriority.TabIndex = 14;
            this.comboBoxProjectPriority.Tag = "Project Priority";
            this.comboBoxProjectPriority.Text = "Project Priority";
            this.comboBoxProjectPriority.SelectedIndexChanged += new System.EventHandler(this.comboBoxProjectPriority_SelectedIndexChanged);
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
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
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
            this.lblProjectNotes.ForeColor = System.Drawing.Color.Black;
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
            this.tbProjectNotes.Enter += new System.EventHandler(this.tbProjectNotes_Enter);
            this.tbProjectNotes.Leave += new System.EventHandler(this.TbAddTask_LostFocus);
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
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
            this.lblSubtasksCommit.ForeColor = System.Drawing.Color.Black;
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
            this.lblProjName.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold);
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
            this.flpTaskOptions.Controls.Add(this.btnAddNotes);
            this.flpTaskOptions.Controls.Add(this.btnAddAttachment);
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
            this.tbAddSubTask.BackColor = System.Drawing.Color.DeepSkyBlue;
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
            this.tbNotes.Location = new System.Drawing.Point(3, 133);
            this.tbNotes.MaximumSize = new System.Drawing.Size(296, 50);
            this.tbNotes.MinimumSize = new System.Drawing.Size(296, 150);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNotes.Size = new System.Drawing.Size(296, 150);
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
            // btnAddNotes
            // 
            this.btnAddNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNotes.AutoSize = true;
            this.btnAddNotes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddNotes.Depth = 0;
            this.btnAddNotes.Icon = null;
            this.btnAddNotes.Location = new System.Drawing.Point(3, 49);
            this.btnAddNotes.MinimumSize = new System.Drawing.Size(292, 34);
            this.btnAddNotes.MouseState = DoYourTasks.MouseState.HOVER;
            this.btnAddNotes.Name = "btnAddNotes";
            this.btnAddNotes.Primary = true;
            this.btnAddNotes.Size = new System.Drawing.Size(403, 36);
            this.btnAddNotes.TabIndex = 15;
            this.btnAddNotes.Text = "(INVISIBLE) Add Task Note";
            this.btnAddNotes.UseVisualStyleBackColor = true;
            this.btnAddNotes.Visible = false;
            this.btnAddNotes.Click += new System.EventHandler(this.btnAddNotes_Click);
            // 
            // btnAddAttachment
            // 
            this.btnAddAttachment.AutoSize = true;
            this.btnAddAttachment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddAttachment.Depth = 0;
            this.btnAddAttachment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddAttachment.Icon = null;
            this.btnAddAttachment.Location = new System.Drawing.Point(3, 91);
            this.btnAddAttachment.MinimumSize = new System.Drawing.Size(292, 34);
            this.btnAddAttachment.MouseState = DoYourTasks.MouseState.HOVER;
            this.btnAddAttachment.Name = "btnAddAttachment";
            this.btnAddAttachment.Primary = true;
            this.btnAddAttachment.Size = new System.Drawing.Size(403, 36);
            this.btnAddAttachment.TabIndex = 18;
            this.btnAddAttachment.Text = "Add Attachment";
            this.btnAddAttachment.UseVisualStyleBackColor = true;
            this.btnAddAttachment.Click += new System.EventHandler(this.btnAddAttachment_Click);
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
        private  DoYourTasks.UserControls.MaterialRaisedButton btnAddNotes;
        private System.Windows.Forms.TextBox tbCommitMsg;
        private System.Windows.Forms.TextBox tbAddSubTask;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Panel pnlSave;
        private System.Windows.Forms.Label label1;
        private UserControls.MaterialRaisedButton btnAddAttachment;
        private System.Windows.Forms.Label lblSubtasksCommit;
        private UserControls.MaterialRaisedButton btnShowHiddenProjects;
        private UserControls.MaterialRaisedButton btnShowHiddenTasks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblProjectNotes;
        private System.Windows.Forms.TextBox tbProjectNotes;
        private System.Windows.Forms.FlowLayoutPanel flpProjectAttachments;
        private System.Windows.Forms.ComboBox comboBoxProjectPriority;
        private System.Windows.Forms.ComboBox comboBoxTaskPriority;
    }
}

