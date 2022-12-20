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
            this.btnAddNewList = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlTasksHeader = new System.Windows.Forms.Panel();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.btnSetBackGroundImage = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnOptionsMenu = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblProjName = new System.Windows.Forms.Label();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.flpTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flpTaskOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddNotes = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAddDueDate_ = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tbAddSubTask = new System.Windows.Forms.TextBox();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.flpSubTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.DueDatePicker = new DoYourTasks.RJDatePicker();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlCreationDate.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTasksHeader.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flpTaskOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.OrangeRed;
            this.pnlTop.Controls.Add(this.pbLogo);
            this.pnlTop.Controls.Add(this.btnNormal);
            this.pnlTop.Controls.Add(this.btnMinimizar);
            this.pnlTop.Controls.Add(this.btnCerrar);
            this.pnlTop.Controls.Add(this.btnMaximizar);
            this.pnlTop.Location = new System.Drawing.Point(1, 1);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1420, 60);
            this.pnlTop.TabIndex = 11;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbLogo.InitialImage")));
            this.pbLogo.Location = new System.Drawing.Point(5, 2);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(47, 43);
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
            this.btnNormal.Location = new System.Drawing.Point(1300, 1);
            this.btnNormal.Margin = new System.Windows.Forms.Padding(4);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(57, 42);
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
            this.btnMinimizar.Location = new System.Drawing.Point(1235, 1);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(57, 42);
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
            this.btnCerrar.Location = new System.Drawing.Point(1359, 4);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(52, 37);
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
            this.btnMaximizar.Location = new System.Drawing.Point(1300, 1);
            this.btnMaximizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(57, 44);
            this.btnMaximizar.TabIndex = 7;
            this.btnMaximizar.UseVisualStyleBackColor = true;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.tbAddTask);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Controls.Add(this.lblCredits);
            this.pnlMain.Controls.Add(this.pnlCreationDate);
            this.pnlMain.Controls.Add(this.flpProjects);
            this.pnlMain.Controls.Add(this.btnAddNewList);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.panel3);
            this.pnlMain.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlMain.Location = new System.Drawing.Point(1, 3);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.MinimumSize = new System.Drawing.Size(1420, 884);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1423, 884);
            this.pnlMain.TabIndex = 13;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // tbAddTask
            // 
            this.tbAddTask.BackColor = System.Drawing.SystemColors.Window;
            this.tbAddTask.Location = new System.Drawing.Point(412, 812);
            this.tbAddTask.Margin = new System.Windows.Forms.Padding(4);
            this.tbAddTask.MaximumSize = new System.Drawing.Size(599, 48);
            this.tbAddTask.MinimumSize = new System.Drawing.Size(599, 48);
            this.tbAddTask.Multiline = true;
            this.tbAddTask.Name = "tbAddTask";
            this.tbAddTask.Size = new System.Drawing.Size(599, 48);
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
            this.lblCredits.Location = new System.Drawing.Point(4, 866);
            this.lblCredits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(99, 12);
            this.lblCredits.TabIndex = 1;
            this.lblCredits.Text = "Created by: alws34";
            // 
            // pnlCreationDate
            // 
            this.pnlCreationDate.Controls.Add(this.lblCreationDate);
            this.pnlCreationDate.Location = new System.Drawing.Point(1015, 812);
            this.pnlCreationDate.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCreationDate.Name = "pnlCreationDate";
            this.pnlCreationDate.Size = new System.Drawing.Size(403, 50);
            this.pnlCreationDate.TabIndex = 13;
            // 
            // lblCreationDate
            // 
            this.lblCreationDate.AutoSize = true;
            this.lblCreationDate.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblCreationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.lblCreationDate.Location = new System.Drawing.Point(4, 11);
            this.lblCreationDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreationDate.Name = "lblCreationDate";
            this.lblCreationDate.Size = new System.Drawing.Size(175, 29);
            this.lblCreationDate.TabIndex = 0;
            this.lblCreationDate.Text = "Creation Date:";
            this.lblCreationDate.Visible = false;
            // 
            // flpProjects
            // 
            this.flpProjects.AutoScroll = true;
            this.flpProjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.flpProjects.Location = new System.Drawing.Point(5, 65);
            this.flpProjects.Margin = new System.Windows.Forms.Padding(4);
            this.flpProjects.Name = "flpProjects";
            this.flpProjects.Size = new System.Drawing.Size(404, 745);
            this.flpProjects.TabIndex = 12;
            this.flpProjects.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flpProjects_ControlAdded);
            // 
            // btnAddNewList
            // 
            this.btnAddNewList.AutoSize = true;
            this.btnAddNewList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddNewList.Depth = 0;
            this.btnAddNewList.Icon = null;
            this.btnAddNewList.Location = new System.Drawing.Point(5, 812);
            this.btnAddNewList.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNewList.MinimumSize = new System.Drawing.Size(404, 50);
            this.btnAddNewList.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddNewList.Name = "btnAddNewList";
            this.btnAddNewList.Primary = true;
            this.btnAddNewList.Size = new System.Drawing.Size(404, 50);
            this.btnAddNewList.TabIndex = 11;
            this.btnAddNewList.Text = "Add New Project";
            this.btnAddNewList.UseVisualStyleBackColor = true;
            this.btnAddNewList.Click += new System.EventHandler(this.btnNewList_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlTasksHeader);
            this.panel2.Controls.Add(this.flpTasks);
            this.panel2.Location = new System.Drawing.Point(412, 65);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 745);
            this.panel2.TabIndex = 8;
            // 
            // pnlTasksHeader
            // 
            this.pnlTasksHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlTasksHeader.Controls.Add(this.pnlOptions);
            this.pnlTasksHeader.Controls.Add(this.btnOptionsMenu);
            this.pnlTasksHeader.Controls.Add(this.lblProjName);
            this.pnlTasksHeader.Controls.Add(this.btnSave);
            this.pnlTasksHeader.Location = new System.Drawing.Point(4, 2);
            this.pnlTasksHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTasksHeader.MaximumSize = new System.Drawing.Size(593, 492);
            this.pnlTasksHeader.MinimumSize = new System.Drawing.Size(593, 55);
            this.pnlTasksHeader.Name = "pnlTasksHeader";
            this.pnlTasksHeader.Size = new System.Drawing.Size(593, 55);
            this.pnlTasksHeader.TabIndex = 0;
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(181)))), ((int)(((byte)(181)))));
            this.pnlOptions.Controls.Add(this.btnSetBackGroundImage);
            this.pnlOptions.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlOptions.Location = new System.Drawing.Point(175, 59);
            this.pnlOptions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(323, 410);
            this.pnlOptions.TabIndex = 8;
            // 
            // btnSetBackGroundImage
            // 
            this.btnSetBackGroundImage.AutoSize = true;
            this.btnSetBackGroundImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSetBackGroundImage.Depth = 0;
            this.btnSetBackGroundImage.Icon = null;
            this.btnSetBackGroundImage.Location = new System.Drawing.Point(51, 4);
            this.btnSetBackGroundImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetBackGroundImage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSetBackGroundImage.Name = "btnSetBackGroundImage";
            this.btnSetBackGroundImage.Primary = true;
            this.btnSetBackGroundImage.Size = new System.Drawing.Size(207, 36);
            this.btnSetBackGroundImage.TabIndex = 7;
            this.btnSetBackGroundImage.Text = "Choose Background";
            this.btnSetBackGroundImage.UseVisualStyleBackColor = true;
            this.btnSetBackGroundImage.Click += new System.EventHandler(this.btnSetBackGroundImage_Click);
            // 
            // btnOptionsMenu
            // 
            this.btnOptionsMenu.AutoSize = true;
            this.btnOptionsMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOptionsMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnOptionsMenu.Depth = 0;
            this.btnOptionsMenu.Icon = global::DoYourTasks.Properties.Resources.icons8_menu_40;
            this.btnOptionsMenu.ImageKey = "(none)";
            this.btnOptionsMenu.Location = new System.Drawing.Point(439, 7);
            this.btnOptionsMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnOptionsMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOptionsMenu.Name = "btnOptionsMenu";
            this.btnOptionsMenu.Primary = true;
            this.btnOptionsMenu.Size = new System.Drawing.Size(44, 36);
            this.btnOptionsMenu.TabIndex = 7;
            this.btnOptionsMenu.UseVisualStyleBackColor = false;
            this.btnOptionsMenu.Click += new System.EventHandler(this.btnOptionsMenu_Click);
            // 
            // lblProjName
            // 
            this.lblProjName.AutoSize = true;
            this.lblProjName.BackColor = System.Drawing.Color.Transparent;
            this.lblProjName.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(140)))), ((int)(((byte)(222)))));
            this.lblProjName.Location = new System.Drawing.Point(4, 2);
            this.lblProjName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProjName.Name = "lblProjName";
            this.lblProjName.Size = new System.Drawing.Size(239, 54);
            this.lblProjName.TabIndex = 3;
            this.lblProjName.Text = "ProjName";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Depth = 0;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(505, 7);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(65, 36);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // flpTasks
            // 
            this.flpTasks.AutoScroll = true;
            this.flpTasks.BackColor = System.Drawing.Color.Transparent;
            this.flpTasks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flpTasks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpTasks.Location = new System.Drawing.Point(0, 61);
            this.flpTasks.Margin = new System.Windows.Forms.Padding(4);
            this.flpTasks.MaximumSize = new System.Drawing.Size(600, 745);
            this.flpTasks.MinimumSize = new System.Drawing.Size(600, 314);
            this.flpTasks.Name = "flpTasks";
            this.flpTasks.Size = new System.Drawing.Size(600, 684);
            this.flpTasks.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.DueDatePicker);
            this.panel3.Controls.Add(this.flpTaskOptions);
            this.panel3.Controls.Add(this.flpSubTasks);
            this.panel3.Location = new System.Drawing.Point(1013, 65);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(404, 745);
            this.panel3.TabIndex = 10;
            // 
            // flpTaskOptions
            // 
            this.flpTaskOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpTaskOptions.Controls.Add(this.btnAddNotes);
            this.flpTaskOptions.Controls.Add(this.materialRaisedButton1);
            this.flpTaskOptions.Controls.Add(this.btnAddDueDate_);
            this.flpTaskOptions.Controls.Add(this.tbAddSubTask);
            this.flpTaskOptions.Controls.Add(this.tbNotes);
            this.flpTaskOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTaskOptions.Location = new System.Drawing.Point(5, 442);
            this.flpTaskOptions.Margin = new System.Windows.Forms.Padding(4);
            this.flpTaskOptions.MinimumSize = new System.Drawing.Size(350, 42);
            this.flpTaskOptions.Name = "flpTaskOptions";
            this.flpTaskOptions.Size = new System.Drawing.Size(397, 245);
            this.flpTaskOptions.TabIndex = 15;
            // 
            // btnAddNotes
            // 
            this.btnAddNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNotes.AutoSize = true;
            this.btnAddNotes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddNotes.Depth = 0;
            this.btnAddNotes.Icon = null;
            this.btnAddNotes.Location = new System.Drawing.Point(4, 4);
            this.btnAddNotes.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNotes.MinimumSize = new System.Drawing.Size(389, 42);
            this.btnAddNotes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddNotes.Name = "btnAddNotes";
            this.btnAddNotes.Primary = true;
            this.btnAddNotes.Size = new System.Drawing.Size(393, 42);
            this.btnAddNotes.TabIndex = 15;
            this.btnAddNotes.Text = "Add Task Note";
            this.btnAddNotes.UseVisualStyleBackColor = true;
            this.btnAddNotes.Click += new System.EventHandler(this.btnAddNotes_Click);
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.AutoSize = true;
            this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialRaisedButton1.Icon = null;
            this.materialRaisedButton1.Location = new System.Drawing.Point(4, 48);
            this.materialRaisedButton1.Margin = new System.Windows.Forms.Padding(4);
            this.materialRaisedButton1.MinimumSize = new System.Drawing.Size(350, 42);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(393, 42);
            this.materialRaisedButton1.TabIndex = 16;
            this.materialRaisedButton1.Text = "Remind Me";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Visible = false;
            // 
            // btnAddDueDate_
            // 
            this.btnAddDueDate_.AutoSize = true;
            this.btnAddDueDate_.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddDueDate_.Depth = 0;
            this.btnAddDueDate_.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddDueDate_.Icon = null;
            this.btnAddDueDate_.Location = new System.Drawing.Point(4, 92);
            this.btnAddDueDate_.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddDueDate_.MinimumSize = new System.Drawing.Size(389, 42);
            this.btnAddDueDate_.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddDueDate_.Name = "btnAddDueDate_";
            this.btnAddDueDate_.Primary = true;
            this.btnAddDueDate_.Size = new System.Drawing.Size(393, 42);
            this.btnAddDueDate_.TabIndex = 17;
            this.btnAddDueDate_.Text = "Add Due Date";
            this.btnAddDueDate_.UseVisualStyleBackColor = true;
            // 
            // tbAddSubTask
            // 
            this.tbAddSubTask.BackColor = System.Drawing.SystemColors.Window;
            this.tbAddSubTask.Location = new System.Drawing.Point(4, 136);
            this.tbAddSubTask.Margin = new System.Windows.Forms.Padding(4);
            this.tbAddSubTask.MaximumSize = new System.Drawing.Size(393, 48);
            this.tbAddSubTask.MinimumSize = new System.Drawing.Size(393, 48);
            this.tbAddSubTask.Multiline = true;
            this.tbAddSubTask.Name = "tbAddSubTask";
            this.tbAddSubTask.Size = new System.Drawing.Size(393, 48);
            this.tbAddSubTask.TabIndex = 14;
            this.tbAddSubTask.Tag = "Add new sub task";
            this.tbAddSubTask.Text = "Add new sub task";
            this.tbAddSubTask.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbAddTask_KeyUp);
            this.tbAddSubTask.Leave += new System.EventHandler(this.tbAddTask_Leave);
            // 
            // tbNotes
            // 
            this.tbNotes.BackColor = System.Drawing.SystemColors.Window;
            this.tbNotes.Location = new System.Drawing.Point(4, 192);
            this.tbNotes.Margin = new System.Windows.Forms.Padding(4);
            this.tbNotes.MaximumSize = new System.Drawing.Size(393, 48);
            this.tbNotes.MinimumSize = new System.Drawing.Size(393, 48);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbNotes.Size = new System.Drawing.Size(393, 48);
            this.tbNotes.TabIndex = 16;
            this.tbNotes.Tag = "Add New Note";
            this.tbNotes.Text = "Add New Note";
            this.tbNotes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbAddTask_KeyUp);
            this.tbNotes.Leave += new System.EventHandler(this.tbAddTask_Leave);
            // 
            // flpSubTasks
            // 
            this.flpSubTasks.AutoScroll = true;
            this.flpSubTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.flpSubTasks.Location = new System.Drawing.Point(4, 4);
            this.flpSubTasks.Margin = new System.Windows.Forms.Padding(4);
            this.flpSubTasks.Name = "flpSubTasks";
            this.flpSubTasks.Size = new System.Drawing.Size(397, 434);
            this.flpSubTasks.TabIndex = 15;
            // 
            // DueDatePicker
            // 
            this.DueDatePicker.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.DueDatePicker.BorderSize = 0;
            this.DueDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.DueDatePicker.Location = new System.Drawing.Point(5, 695);
            this.DueDatePicker.Margin = new System.Windows.Forms.Padding(4);
            this.DueDatePicker.MinimumSize = new System.Drawing.Size(4, 35);
            this.DueDatePicker.Name = "DueDatePicker";
            this.DueDatePicker.Size = new System.Drawing.Size(396, 35);
            this.DueDatePicker.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.DueDatePicker.TabIndex = 18;
            this.DueDatePicker.TextColor = System.Drawing.Color.White;
            this.DueDatePicker.Value = new System.DateTime(2022, 12, 17, 13, 3, 50, 0);
            this.DueDatePicker.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1447, 935);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1447, 985);
            this.MinimumSize = new System.Drawing.Size(400, 369);
            this.Name = "frmMain";
            this.Text = "ToDo";
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlCreationDate.ResumeLayout(false);
            this.pnlCreationDate.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlTasksHeader.ResumeLayout(false);
            this.pnlTasksHeader.PerformLayout();
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
        private MaterialSkin.Controls.MaterialRaisedButton btnAddNewList;
        private System.Windows.Forms.FlowLayoutPanel flpProjects;
        private System.Windows.Forms.FlowLayoutPanel flpSubTasks;
        private System.Windows.Forms.Panel pnlCreationDate;
        private System.Windows.Forms.Label lblCreationDate;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.FlowLayoutPanel flpTasks;
        private System.Windows.Forms.Panel pnlTasksHeader;
        private System.Windows.Forms.Label lblProjName;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private MaterialSkin.Controls.MaterialRaisedButton btnOptionsMenu;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.TextBox tbAddTask;
        private MaterialSkin.Controls.MaterialRaisedButton btnSetBackGroundImage;
        private System.Windows.Forms.FlowLayoutPanel flpTaskOptions;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddNotes;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddDueDate_;
        private System.Windows.Forms.TextBox tbAddSubTask;
        private System.Windows.Forms.TextBox tbNotes;
        private RJDatePicker DueDatePicker;
    }
}

