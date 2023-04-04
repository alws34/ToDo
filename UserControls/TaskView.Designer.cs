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
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.flpAttachments = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSubTasks = new System.Windows.Forms.Label();
            this.lblAttachments = new System.Windows.Forms.Label();
            this.lblAttachmentsCount = new System.Windows.Forms.Label();
            this.tblLayoutTaskData = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPriority = new System.Windows.Forms.Panel();
            this.lblPriorityLvl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateCompleted = new System.Windows.Forms.Label();
            this.lblCompletedOn = new System.Windows.Forms.Label();
            this.lblCreatedAtVal = new System.Windows.Forms.Label();
            this.lblDueDateVal = new System.Windows.Forms.Label();
            this.flpTaskOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblDrag = new System.Windows.Forms.Label();
            this.btnHideTask = new DoYourTasks.UserControls.CustomButtonV2();
            this.btnAddDueDate = new DoYourTasks.UserControls.CustomButtonV2();
            this.btnRemoveDueDate = new DoYourTasks.UserControls.CustomButtonV2();
            this.btnChangePriority = new DoYourTasks.UserControls.CustomButtonV2();
            this.ctbTaskName = new DoYourTasks.UserControls.CustomControls.CustomTextBox();
            this.btnEditTaskName = new DoYourTasks.UserControls.CustomButtonV2();
            this.btnDelete = new DoYourTasks.UserControls.CustomButtonV2();
            this.customRadioButtonTaskName = new DoYourTasks.UserControls.CustomRadioButton();
            this.pnlColorIndicator.SuspendLayout();
            this.tblLayoutTaskData.SuspendLayout();
            this.pnlPriority.SuspendLayout();
            this.flpTaskOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlColorIndicator
            // 
            this.pnlColorIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlColorIndicator.BackColor = System.Drawing.Color.LightGray;
            this.pnlColorIndicator.Controls.Add(this.ctbTaskName);
            this.pnlColorIndicator.Controls.Add(this.btnEditTaskName);
            this.pnlColorIndicator.Controls.Add(this.btnDelete);
            this.pnlColorIndicator.Controls.Add(this.customRadioButtonTaskName);
            this.pnlColorIndicator.ForeColor = System.Drawing.Color.Transparent;
            this.pnlColorIndicator.Location = new System.Drawing.Point(4, 4);
            this.pnlColorIndicator.MaximumSize = new System.Drawing.Size(410, 52);
            this.pnlColorIndicator.MinimumSize = new System.Drawing.Size(410, 52);
            this.pnlColorIndicator.Name = "pnlColorIndicator";
            this.pnlColorIndicator.Size = new System.Drawing.Size(410, 52);
            this.pnlColorIndicator.TabIndex = 0;
            this.pnlColorIndicator.Click += new System.EventHandler(this.TaskView_Click);
            this.pnlColorIndicator.MouseEnter += new System.EventHandler(this.pnlColorIndicator_MouseEnter);
            this.pnlColorIndicator.MouseLeave += new System.EventHandler(this.pnlColorIndicator_MouseLeave);
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.ForeColor = System.Drawing.Color.Black;
            this.lblDueDate.Location = new System.Drawing.Point(3, 72);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(60, 16);
            this.lblDueDate.TabIndex = 6;
            this.lblDueDate.Text = "Due to: ";
            this.lblDueDate.Click += new System.EventHandler(this.TaskView_Click);
            // 
            // lblCompletedSubTasks
            // 
            this.lblCompletedSubTasks.AutoSize = true;
            this.lblCompletedSubTasks.BackColor = System.Drawing.Color.Transparent;
            this.lblCompletedSubTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletedSubTasks.ForeColor = System.Drawing.Color.Black;
            this.lblCompletedSubTasks.Location = new System.Drawing.Point(120, 24);
            this.lblCompletedSubTasks.Name = "lblCompletedSubTasks";
            this.lblCompletedSubTasks.Size = new System.Drawing.Size(28, 16);
            this.lblCompletedSubTasks.TabIndex = 3;
            this.lblCompletedSubTasks.Text = "0/0";
            this.lblCompletedSubTasks.Click += new System.EventHandler(this.TaskView_Click);
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.AutoSize = true;
            this.lblCreatedAt.BackColor = System.Drawing.Color.Transparent;
            this.lblCreatedAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedAt.ForeColor = System.Drawing.Color.Black;
            this.lblCreatedAt.Location = new System.Drawing.Point(3, 97);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(83, 16);
            this.lblCreatedAt.TabIndex = 10;
            this.lblCreatedAt.Tag = "Created at:";
            this.lblCreatedAt.Text = "Created at:";
            this.lblCreatedAt.Click += new System.EventHandler(this.TaskView_Click);
            // 
            // flpAttachments
            // 
            this.flpAttachments.AutoScroll = true;
            this.flpAttachments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.flpAttachments.Location = new System.Drawing.Point(2, 248);
            this.flpAttachments.MaximumSize = new System.Drawing.Size(410, 264);
            this.flpAttachments.MinimumSize = new System.Drawing.Size(412, 264);
            this.flpAttachments.Name = "flpAttachments";
            this.flpAttachments.Size = new System.Drawing.Size(412, 264);
            this.flpAttachments.TabIndex = 1;
            // 
            // lblSubTasks
            // 
            this.lblSubTasks.AutoSize = true;
            this.lblSubTasks.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTasks.ForeColor = System.Drawing.Color.Black;
            this.lblSubTasks.Location = new System.Drawing.Point(3, 24);
            this.lblSubTasks.Name = "lblSubTasks";
            this.lblSubTasks.Size = new System.Drawing.Size(85, 16);
            this.lblSubTasks.TabIndex = 4;
            this.lblSubTasks.Text = "Sub Tasks:";
            this.lblSubTasks.Click += new System.EventHandler(this.TaskView_Click);
            // 
            // lblAttachments
            // 
            this.lblAttachments.AutoSize = true;
            this.lblAttachments.BackColor = System.Drawing.Color.Transparent;
            this.lblAttachments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttachments.ForeColor = System.Drawing.Color.Black;
            this.lblAttachments.Location = new System.Drawing.Point(3, 47);
            this.lblAttachments.Name = "lblAttachments";
            this.lblAttachments.Size = new System.Drawing.Size(95, 16);
            this.lblAttachments.TabIndex = 11;
            this.lblAttachments.Text = "Attachments:";
            this.lblAttachments.Click += new System.EventHandler(this.TaskView_Click);
            // 
            // lblAttachmentsCount
            // 
            this.lblAttachmentsCount.AutoSize = true;
            this.lblAttachmentsCount.BackColor = System.Drawing.Color.Transparent;
            this.lblAttachmentsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttachmentsCount.ForeColor = System.Drawing.Color.Black;
            this.lblAttachmentsCount.Location = new System.Drawing.Point(120, 47);
            this.lblAttachmentsCount.Name = "lblAttachmentsCount";
            this.lblAttachmentsCount.Size = new System.Drawing.Size(15, 16);
            this.lblAttachmentsCount.TabIndex = 12;
            this.lblAttachmentsCount.Text = "0";
            this.lblAttachmentsCount.Click += new System.EventHandler(this.TaskView_Click);
            // 
            // tblLayoutTaskData
            // 
            this.tblLayoutTaskData.ColumnCount = 2;
            this.tblLayoutTaskData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.48669F));
            this.tblLayoutTaskData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.51331F));
            this.tblLayoutTaskData.Controls.Add(this.pnlPriority, 1, 0);
            this.tblLayoutTaskData.Controls.Add(this.lblCompletedSubTasks, 1, 1);
            this.tblLayoutTaskData.Controls.Add(this.label1, 0, 0);
            this.tblLayoutTaskData.Controls.Add(this.lblDateCompleted, 0, 5);
            this.tblLayoutTaskData.Controls.Add(this.lblCreatedAt, 0, 4);
            this.tblLayoutTaskData.Controls.Add(this.lblDueDate, 0, 3);
            this.tblLayoutTaskData.Controls.Add(this.lblAttachments, 0, 2);
            this.tblLayoutTaskData.Controls.Add(this.lblSubTasks, 0, 1);
            this.tblLayoutTaskData.Controls.Add(this.lblCompletedOn, 1, 5);
            this.tblLayoutTaskData.Controls.Add(this.lblCreatedAtVal, 1, 4);
            this.tblLayoutTaskData.Controls.Add(this.lblDueDateVal, 1, 3);
            this.tblLayoutTaskData.Controls.Add(this.lblAttachmentsCount, 1, 2);
            this.tblLayoutTaskData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tblLayoutTaskData.Location = new System.Drawing.Point(3, 62);
            this.tblLayoutTaskData.Name = "tblLayoutTaskData";
            this.tblLayoutTaskData.RowCount = 6;
            this.tblLayoutTaskData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tblLayoutTaskData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tblLayoutTaskData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tblLayoutTaskData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tblLayoutTaskData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tblLayoutTaskData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblLayoutTaskData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tblLayoutTaskData.Size = new System.Drawing.Size(263, 152);
            this.tblLayoutTaskData.TabIndex = 13;
            this.tblLayoutTaskData.Click += new System.EventHandler(this.TaskView_Click);
            // 
            // pnlPriority
            // 
            this.pnlPriority.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pnlPriority.Controls.Add(this.lblPriorityLvl);
            this.pnlPriority.Location = new System.Drawing.Point(120, 3);
            this.pnlPriority.Name = "pnlPriority";
            this.pnlPriority.Size = new System.Drawing.Size(140, 18);
            this.pnlPriority.TabIndex = 16;
            this.pnlPriority.Click += new System.EventHandler(this.TaskView_Click);
            // 
            // lblPriorityLvl
            // 
            this.lblPriorityLvl.AutoEllipsis = true;
            this.lblPriorityLvl.AutoSize = true;
            this.lblPriorityLvl.BackColor = System.Drawing.Color.Transparent;
            this.lblPriorityLvl.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblPriorityLvl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriorityLvl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPriorityLvl.Location = new System.Drawing.Point(0, 0);
            this.lblPriorityLvl.Name = "lblPriorityLvl";
            this.lblPriorityLvl.Size = new System.Drawing.Size(34, 16);
            this.lblPriorityLvl.TabIndex = 17;
            this.lblPriorityLvl.Tag = "";
            this.lblPriorityLvl.Text = "Low";
            this.lblPriorityLvl.Click += new System.EventHandler(this.TaskView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 15;
            this.label1.Tag = "Priority:";
            this.label1.Text = "Priority:";
            this.label1.Click += new System.EventHandler(this.TaskView_Click);
            // 
            // lblDateCompleted
            // 
            this.lblDateCompleted.AutoSize = true;
            this.lblDateCompleted.BackColor = System.Drawing.Color.Transparent;
            this.lblDateCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateCompleted.ForeColor = System.Drawing.Color.Black;
            this.lblDateCompleted.Location = new System.Drawing.Point(3, 121);
            this.lblDateCompleted.Name = "lblDateCompleted";
            this.lblDateCompleted.Size = new System.Drawing.Size(109, 16);
            this.lblDateCompleted.TabIndex = 17;
            this.lblDateCompleted.Tag = "Completed On:";
            this.lblDateCompleted.Text = "Completed On:";
            this.lblDateCompleted.Click += new System.EventHandler(this.TaskView_Click);
            // 
            // lblCompletedOn
            // 
            this.lblCompletedOn.AutoSize = true;
            this.lblCompletedOn.BackColor = System.Drawing.Color.Transparent;
            this.lblCompletedOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompletedOn.ForeColor = System.Drawing.Color.Black;
            this.lblCompletedOn.Location = new System.Drawing.Point(120, 121);
            this.lblCompletedOn.Name = "lblCompletedOn";
            this.lblCompletedOn.Size = new System.Drawing.Size(139, 31);
            this.lblCompletedOn.TabIndex = 18;
            this.lblCompletedOn.Text = "                                                ";
            this.lblCompletedOn.Click += new System.EventHandler(this.TaskView_Click);
            // 
            // lblCreatedAtVal
            // 
            this.lblCreatedAtVal.AutoSize = true;
            this.lblCreatedAtVal.BackColor = System.Drawing.Color.Transparent;
            this.lblCreatedAtVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedAtVal.ForeColor = System.Drawing.Color.Black;
            this.lblCreatedAtVal.Location = new System.Drawing.Point(120, 97);
            this.lblCreatedAtVal.Name = "lblCreatedAtVal";
            this.lblCreatedAtVal.Size = new System.Drawing.Size(139, 24);
            this.lblCreatedAtVal.TabIndex = 14;
            this.lblCreatedAtVal.Text = "                                                ";
            this.lblCreatedAtVal.Click += new System.EventHandler(this.TaskView_Click);
            // 
            // lblDueDateVal
            // 
            this.lblDueDateVal.AutoSize = true;
            this.lblDueDateVal.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDateVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDateVal.ForeColor = System.Drawing.Color.Black;
            this.lblDueDateVal.Location = new System.Drawing.Point(120, 72);
            this.lblDueDateVal.Name = "lblDueDateVal";
            this.lblDueDateVal.Size = new System.Drawing.Size(139, 25);
            this.lblDueDateVal.TabIndex = 13;
            this.lblDueDateVal.Text = "                                              ";
            this.lblDueDateVal.Click += new System.EventHandler(this.TaskView_Click);
            // 
            // flpTaskOptions
            // 
            this.flpTaskOptions.Controls.Add(this.btnAddDueDate);
            this.flpTaskOptions.Controls.Add(this.dateTimePicker1);
            this.flpTaskOptions.Controls.Add(this.btnRemoveDueDate);
            this.flpTaskOptions.Controls.Add(this.btnChangePriority);
            this.flpTaskOptions.Location = new System.Drawing.Point(267, 114);
            this.flpTaskOptions.Name = "flpTaskOptions";
            this.flpTaskOptions.Size = new System.Drawing.Size(145, 128);
            this.flpTaskOptions.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(139, 20);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // lblDrag
            // 
            this.lblDrag.AutoSize = true;
            this.lblDrag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDrag.Enabled = false;
            this.lblDrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblDrag.ForeColor = System.Drawing.Color.White;
            this.lblDrag.Location = new System.Drawing.Point(270, 86);
            this.lblDrag.Name = "lblDrag";
            this.lblDrag.Size = new System.Drawing.Size(140, 22);
            this.lblDrag.TabIndex = 15;
            this.lblDrag.Text = "Drag From Here";
            // 
            // btnHideTask
            // 
            this.btnHideTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHideTask.BackColor = System.Drawing.Color.Transparent;
            this.btnHideTask.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnHideTask.BorderColor = System.Drawing.Color.Black;
            this.btnHideTask.BorderRadius = 0;
            this.btnHideTask.BorderSize = 1;
            this.btnHideTask.FlatAppearance.BorderSize = 0;
            this.btnHideTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHideTask.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnHideTask.ForeColor = System.Drawing.Color.Black;
            this.btnHideTask.Location = new System.Drawing.Point(3, 219);
            this.btnHideTask.Name = "btnHideTask";
            this.btnHideTask.Size = new System.Drawing.Size(86, 26);
            this.btnHideTask.TabIndex = 16;
            this.btnHideTask.Text = "Hide Task";
            this.btnHideTask.TextColor = System.Drawing.Color.Black;
            this.btnHideTask.UseVisualStyleBackColor = false;
            this.btnHideTask.Click += new System.EventHandler(this.btnHideTask_Click);
            // 
            // btnAddDueDate
            // 
            this.btnAddDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDueDate.BackColor = System.Drawing.Color.Transparent;
            this.btnAddDueDate.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAddDueDate.BorderColor = System.Drawing.Color.Black;
            this.btnAddDueDate.BorderRadius = 0;
            this.btnAddDueDate.BorderSize = 1;
            this.btnAddDueDate.FlatAppearance.BorderSize = 0;
            this.btnAddDueDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDueDate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddDueDate.ForeColor = System.Drawing.Color.Black;
            this.btnAddDueDate.Location = new System.Drawing.Point(3, 3);
            this.btnAddDueDate.Name = "btnAddDueDate";
            this.btnAddDueDate.Size = new System.Drawing.Size(138, 26);
            this.btnAddDueDate.TabIndex = 11;
            this.btnAddDueDate.Text = "Set Due Date";
            this.btnAddDueDate.TextColor = System.Drawing.Color.Black;
            this.btnAddDueDate.UseVisualStyleBackColor = false;
            this.btnAddDueDate.Click += new System.EventHandler(this.btnAddDueDate_Click);
            // 
            // btnRemoveDueDate
            // 
            this.btnRemoveDueDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveDueDate.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveDueDate.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnRemoveDueDate.BorderColor = System.Drawing.Color.Black;
            this.btnRemoveDueDate.BorderRadius = 0;
            this.btnRemoveDueDate.BorderSize = 1;
            this.btnRemoveDueDate.FlatAppearance.BorderSize = 0;
            this.btnRemoveDueDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveDueDate.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btnRemoveDueDate.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveDueDate.Location = new System.Drawing.Point(3, 61);
            this.btnRemoveDueDate.Name = "btnRemoveDueDate";
            this.btnRemoveDueDate.Size = new System.Drawing.Size(139, 26);
            this.btnRemoveDueDate.TabIndex = 13;
            this.btnRemoveDueDate.Text = "Remove Due Date";
            this.btnRemoveDueDate.TextColor = System.Drawing.Color.Black;
            this.btnRemoveDueDate.UseVisualStyleBackColor = false;
            this.btnRemoveDueDate.Click += new System.EventHandler(this.btnRemoveDueDate_Click);
            // 
            // btnChangePriority
            // 
            this.btnChangePriority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangePriority.BackColor = System.Drawing.Color.Transparent;
            this.btnChangePriority.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnChangePriority.BorderColor = System.Drawing.Color.Black;
            this.btnChangePriority.BorderRadius = 0;
            this.btnChangePriority.BorderSize = 1;
            this.btnChangePriority.FlatAppearance.BorderSize = 0;
            this.btnChangePriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePriority.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnChangePriority.ForeColor = System.Drawing.Color.Black;
            this.btnChangePriority.Location = new System.Drawing.Point(3, 93);
            this.btnChangePriority.Name = "btnChangePriority";
            this.btnChangePriority.Size = new System.Drawing.Size(139, 26);
            this.btnChangePriority.TabIndex = 14;
            this.btnChangePriority.Text = "Change Priority";
            this.btnChangePriority.TextColor = System.Drawing.Color.Black;
            this.btnChangePriority.UseVisualStyleBackColor = false;
            this.btnChangePriority.Click += new System.EventHandler(this.btnChangePriority_Click);
            // 
            // ctbTaskName
            // 
            this.ctbTaskName.BackColor = System.Drawing.Color.LightGray;
            this.ctbTaskName.BorderColor = System.Drawing.Color.LightGray;
            this.ctbTaskName.BorderSize = 2;
            this.ctbTaskName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.ctbTaskName.ForeColor = System.Drawing.Color.DimGray;
            this.ctbTaskName.IsInEdit = false;
            this.ctbTaskName.Location = new System.Drawing.Point(26, 6);
            this.ctbTaskName.Margin = new System.Windows.Forms.Padding(5);
            this.ctbTaskName.Name = "ctbTaskName";
            this.ctbTaskName.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.ctbTaskName.Size = new System.Drawing.Size(329, 38);
            this.ctbTaskName.TabIndex = 8;
            this.ctbTaskName.UnderlinedStyle = false;
            this.ctbTaskName.Visible = false;
            this.ctbTaskName.Click += new System.EventHandler(this.TaskView_Click);
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
            this.btnEditTaskName.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditTaskName.ForeColor = System.Drawing.Color.White;
            this.btnEditTaskName.Location = new System.Drawing.Point(363, 23);
            this.btnEditTaskName.Name = "btnEditTaskName";
            this.btnEditTaskName.Size = new System.Drawing.Size(46, 26);
            this.btnEditTaskName.TabIndex = 7;
            this.btnEditTaskName.Text = "Edit";
            this.btnEditTaskName.TextColor = System.Drawing.Color.White;
            this.btnEditTaskName.UseVisualStyleBackColor = false;
            this.btnEditTaskName.Click += new System.EventHandler(this.btnEditTaskName_Click);
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
            this.btnDelete.Location = new System.Drawing.Point(375, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(22, 29);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "X";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // customRadioButtonTaskName
            // 
            this.customRadioButtonTaskName.AutoSize = true;
            this.customRadioButtonTaskName.BackColor = System.Drawing.Color.LightGray;
            this.customRadioButtonTaskName.CheckedColor = System.Drawing.Color.MediumSlateBlue;
            this.customRadioButtonTaskName.Font = new System.Drawing.Font("Arial", 14F);
            this.customRadioButtonTaskName.ForeColor = System.Drawing.Color.White;
            this.customRadioButtonTaskName.Location = new System.Drawing.Point(3, 13);
            this.customRadioButtonTaskName.MinimumSize = new System.Drawing.Size(0, 23);
            this.customRadioButtonTaskName.Name = "customRadioButtonTaskName";
            this.customRadioButtonTaskName.Size = new System.Drawing.Size(30, 23);
            this.customRadioButtonTaskName.TabIndex = 4;
            this.customRadioButtonTaskName.TabStop = true;
            this.customRadioButtonTaskName.UnCheckedColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.customRadioButtonTaskName.UseVisualStyleBackColor = false;
            // 
            // TaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.btnHideTask);
            this.Controls.Add(this.lblDrag);
            this.Controls.Add(this.flpTaskOptions);
            this.Controls.Add(this.tblLayoutTaskData);
            this.Controls.Add(this.flpAttachments);
            this.Controls.Add(this.pnlColorIndicator);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximumSize = new System.Drawing.Size(415, 515);
            this.MinimumSize = new System.Drawing.Size(415, 110);
            this.Name = "TaskView";
            this.Size = new System.Drawing.Size(415, 110);
            this.Click += new System.EventHandler(this.TaskView_Click);
            this.pnlColorIndicator.ResumeLayout(false);
            this.pnlColorIndicator.PerformLayout();
            this.tblLayoutTaskData.ResumeLayout(false);
            this.tblLayoutTaskData.PerformLayout();
            this.pnlPriority.ResumeLayout(false);
            this.pnlPriority.PerformLayout();
            this.flpTaskOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlColorIndicator;
        private System.Windows.Forms.Label lblCompletedSubTasks;
        private CustomRadioButton customRadioButtonTaskName;
        private CustomButtonV2 btnDelete;
        private System.Windows.Forms.Label lblDueDate;
        private CustomControls.CustomTextBox ctbTaskName;
        private CustomButtonV2 btnEditTaskName;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.FlowLayoutPanel flpAttachments;
        private System.Windows.Forms.Label lblSubTasks;
        private System.Windows.Forms.Label lblAttachments;
        private System.Windows.Forms.Label lblAttachmentsCount;
        private System.Windows.Forms.TableLayoutPanel tblLayoutTaskData;
        private System.Windows.Forms.Label lblDueDateVal;
        private System.Windows.Forms.Label lblCreatedAtVal;
        private System.Windows.Forms.FlowLayoutPanel flpTaskOptions;
        private CustomButtonV2 btnAddDueDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private CustomButtonV2 btnRemoveDueDate;
        private System.Windows.Forms.Label label1;
        private CustomButtonV2 btnChangePriority;
        private System.Windows.Forms.Panel pnlPriority;
        private System.Windows.Forms.Label lblPriorityLvl;
        private System.Windows.Forms.Label lblDateCompleted;
        private System.Windows.Forms.Label lblDrag;
        private System.Windows.Forms.Label lblCompletedOn;
        private CustomButtonV2 btnHideTask;
    }
}
