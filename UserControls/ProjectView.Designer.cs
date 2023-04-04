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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlIndicator = new System.Windows.Forms.Panel();
            this.lblTaskCount = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblVeryLow = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDoneTaskCount = new System.Windows.Forms.Label();
            this.lblVeryLowTaskCount = new System.Windows.Forms.Label();
            this.lblLowTaskCount = new System.Windows.Forms.Label();
            this.lblMediumTaskCount = new System.Windows.Forms.Label();
            this.lblHighTaskCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUrgentTaskCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWaitingTaskCount = new System.Windows.Forms.Label();
            this.lblDontProceedTaskCount = new System.Windows.Forms.Label();
            this.lblDrag = new System.Windows.Forms.Label();
            this.lblProjPriority = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnProjPriority = new DoYourTasks.UserControls.CustomButtonV2();
            this.btnAddProjectAttachment = new DoYourTasks.UserControls.CustomButtonV2();
            this.btnHideProject = new DoYourTasks.UserControls.CustomButtonV2();
            this.customTextBox = new DoYourTasks.UserControls.CustomControls.CustomTextBox();
            this.btnDelete = new DoYourTasks.UserControls.CustomButtonV2();
            this.btnEditListName = new DoYourTasks.UserControls.CustomButtonV2();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 32);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // pnlIndicator
            // 
            this.pnlIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(185)))), ((int)(((byte)(237)))));
            this.pnlIndicator.Location = new System.Drawing.Point(0, 16);
            this.pnlIndicator.Name = "pnlIndicator";
            this.pnlIndicator.Size = new System.Drawing.Size(5, 22);
            this.pnlIndicator.TabIndex = 3;
            // 
            // lblTaskCount
            // 
            this.lblTaskCount.AutoSize = true;
            this.lblTaskCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTaskCount.Location = new System.Drawing.Point(3, 84);
            this.lblTaskCount.Name = "lblTaskCount";
            this.lblTaskCount.Size = new System.Drawing.Size(79, 16);
            this.lblTaskCount.TabIndex = 8;
            this.lblTaskCount.Tag = "Tasks: 0/0";
            this.lblTaskCount.Text = "Tasks: 0/0";
            this.lblTaskCount.Click += new System.EventHandler(this.ProjectView_GotFocus);
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
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUrgentTaskCount, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblWaitingTaskCount, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDontProceedTaskCount, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 103);
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
            this.tableLayoutPanel1.TabIndex = 10;
            this.tableLayoutPanel1.Click += new System.EventHandler(this.ProjectView_GotFocus);
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
            this.lblVeryLow.Click += new System.EventHandler(this.ProjectView_GotFocus);
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
            this.label5.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // lblDoneTaskCount
            // 
            this.lblDoneTaskCount.AutoEllipsis = true;
            this.lblDoneTaskCount.AutoSize = true;
            this.lblDoneTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblDoneTaskCount.Location = new System.Drawing.Point(92, 155);
            this.lblDoneTaskCount.Name = "lblDoneTaskCount";
            this.lblDoneTaskCount.Size = new System.Drawing.Size(18, 19);
            this.lblDoneTaskCount.TabIndex = 23;
            this.lblDoneTaskCount.Tag = "";
            this.lblDoneTaskCount.Text = "0";
            this.lblDoneTaskCount.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // lblVeryLowTaskCount
            // 
            this.lblVeryLowTaskCount.AutoEllipsis = true;
            this.lblVeryLowTaskCount.AutoSize = true;
            this.lblVeryLowTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblVeryLowTaskCount.Location = new System.Drawing.Point(92, 89);
            this.lblVeryLowTaskCount.Name = "lblVeryLowTaskCount";
            this.lblVeryLowTaskCount.Size = new System.Drawing.Size(18, 19);
            this.lblVeryLowTaskCount.TabIndex = 17;
            this.lblVeryLowTaskCount.Tag = "";
            this.lblVeryLowTaskCount.Text = "0";
            this.lblVeryLowTaskCount.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // lblLowTaskCount
            // 
            this.lblLowTaskCount.AutoEllipsis = true;
            this.lblLowTaskCount.AutoSize = true;
            this.lblLowTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblLowTaskCount.Location = new System.Drawing.Point(92, 67);
            this.lblLowTaskCount.Name = "lblLowTaskCount";
            this.lblLowTaskCount.Size = new System.Drawing.Size(18, 19);
            this.lblLowTaskCount.TabIndex = 12;
            this.lblLowTaskCount.Tag = "";
            this.lblLowTaskCount.Text = "0";
            this.lblLowTaskCount.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // lblMediumTaskCount
            // 
            this.lblMediumTaskCount.AutoEllipsis = true;
            this.lblMediumTaskCount.AutoSize = true;
            this.lblMediumTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblMediumTaskCount.Location = new System.Drawing.Point(92, 45);
            this.lblMediumTaskCount.Name = "lblMediumTaskCount";
            this.lblMediumTaskCount.Size = new System.Drawing.Size(18, 19);
            this.lblMediumTaskCount.TabIndex = 13;
            this.lblMediumTaskCount.Tag = "";
            this.lblMediumTaskCount.Text = "0";
            this.lblMediumTaskCount.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // lblHighTaskCount
            // 
            this.lblHighTaskCount.AutoEllipsis = true;
            this.lblHighTaskCount.AutoSize = true;
            this.lblHighTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblHighTaskCount.Location = new System.Drawing.Point(92, 23);
            this.lblHighTaskCount.Name = "lblHighTaskCount";
            this.lblHighTaskCount.Size = new System.Drawing.Size(18, 19);
            this.lblHighTaskCount.TabIndex = 14;
            this.lblHighTaskCount.Tag = "";
            this.lblHighTaskCount.Text = "0";
            this.lblHighTaskCount.Click += new System.EventHandler(this.ProjectView_GotFocus);
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
            this.label4.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 10;
            this.label1.Tag = "";
            this.label1.Text = "Low";
            this.label1.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Blue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 21);
            this.label2.TabIndex = 11;
            this.label2.Tag = "";
            this.label2.Text = "Med";
            this.label2.Click += new System.EventHandler(this.ProjectView_GotFocus);
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
            this.label6.Click += new System.EventHandler(this.ProjectView_GotFocus);
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
            this.label7.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // lblUrgentTaskCount
            // 
            this.lblUrgentTaskCount.AutoSize = true;
            this.lblUrgentTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblUrgentTaskCount.Location = new System.Drawing.Point(92, 1);
            this.lblUrgentTaskCount.Name = "lblUrgentTaskCount";
            this.lblUrgentTaskCount.Size = new System.Drawing.Size(18, 19);
            this.lblUrgentTaskCount.TabIndex = 25;
            this.lblUrgentTaskCount.Text = "0";
            this.lblUrgentTaskCount.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Orange;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 21);
            this.label3.TabIndex = 18;
            this.label3.Tag = "";
            this.label3.Text = "Waiting";
            this.label3.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // lblWaitingTaskCount
            // 
            this.lblWaitingTaskCount.AutoEllipsis = true;
            this.lblWaitingTaskCount.AutoSize = true;
            this.lblWaitingTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblWaitingTaskCount.Location = new System.Drawing.Point(92, 133);
            this.lblWaitingTaskCount.Name = "lblWaitingTaskCount";
            this.lblWaitingTaskCount.Size = new System.Drawing.Size(18, 19);
            this.lblWaitingTaskCount.TabIndex = 19;
            this.lblWaitingTaskCount.Tag = "";
            this.lblWaitingTaskCount.Text = "0";
            this.lblWaitingTaskCount.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // lblDontProceedTaskCount
            // 
            this.lblDontProceedTaskCount.AutoEllipsis = true;
            this.lblDontProceedTaskCount.AutoSize = true;
            this.lblDontProceedTaskCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblDontProceedTaskCount.Location = new System.Drawing.Point(92, 111);
            this.lblDontProceedTaskCount.Name = "lblDontProceedTaskCount";
            this.lblDontProceedTaskCount.Size = new System.Drawing.Size(18, 19);
            this.lblDontProceedTaskCount.TabIndex = 21;
            this.lblDontProceedTaskCount.Tag = "";
            this.lblDontProceedTaskCount.Text = "0";
            this.lblDontProceedTaskCount.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // lblDrag
            // 
            this.lblDrag.AutoSize = true;
            this.lblDrag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDrag.Enabled = false;
            this.lblDrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblDrag.Location = new System.Drawing.Point(127, 81);
            this.lblDrag.Name = "lblDrag";
            this.lblDrag.Size = new System.Drawing.Size(140, 22);
            this.lblDrag.TabIndex = 11;
            this.lblDrag.Text = "Drag From Here";
            // 
            // lblProjPriority
            // 
            this.lblProjPriority.AutoEllipsis = true;
            this.lblProjPriority.AutoSize = true;
            this.lblProjPriority.BackColor = System.Drawing.Color.LimeGreen;
            this.lblProjPriority.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.lblProjPriority.ForeColor = System.Drawing.Color.Black;
            this.lblProjPriority.Location = new System.Drawing.Point(127, 52);
            this.lblProjPriority.Margin = new System.Windows.Forms.Padding(0);
            this.lblProjPriority.Name = "lblProjPriority";
            this.lblProjPriority.Size = new System.Drawing.Size(56, 27);
            this.lblProjPriority.TabIndex = 16;
            this.lblProjPriority.Tag = "";
            this.lblProjPriority.Text = "Low";
            this.lblProjPriority.Click += new System.EventHandler(this.ProjectView_GotFocus);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnProjPriority);
            this.flowLayoutPanel1.Controls.Add(this.btnAddProjectAttachment);
            this.flowLayoutPanel1.Controls.Add(this.btnHideProject);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(129, 177);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(140, 100);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // btnProjPriority
            // 
            this.btnProjPriority.BackColor = System.Drawing.Color.Transparent;
            this.btnProjPriority.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnProjPriority.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnProjPriority.BorderRadius = 0;
            this.btnProjPriority.BorderSize = 0;
            this.btnProjPriority.FlatAppearance.BorderSize = 0;
            this.btnProjPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjPriority.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjPriority.ForeColor = System.Drawing.Color.Black;
            this.btnProjPriority.Location = new System.Drawing.Point(3, 3);
            this.btnProjPriority.Name = "btnProjPriority";
            this.btnProjPriority.Size = new System.Drawing.Size(140, 29);
            this.btnProjPriority.TabIndex = 17;
            this.btnProjPriority.Text = "change Project Priority";
            this.btnProjPriority.TextColor = System.Drawing.Color.Black;
            this.btnProjPriority.UseVisualStyleBackColor = false;
            this.btnProjPriority.Click += new System.EventHandler(this.btnProjPriority_Click);
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
            this.btnAddProjectAttachment.Location = new System.Drawing.Point(3, 38);
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
            this.btnHideProject.Location = new System.Drawing.Point(3, 73);
            this.btnHideProject.Name = "btnHideProject";
            this.btnHideProject.Size = new System.Drawing.Size(137, 29);
            this.btnHideProject.TabIndex = 20;
            this.btnHideProject.Text = "Hide Project";
            this.btnHideProject.TextColor = System.Drawing.Color.Black;
            this.btnHideProject.UseVisualStyleBackColor = false;
            this.btnHideProject.Click += new System.EventHandler(this.btnHideProject_Click);
            // 
            // customTextBox
            // 
            this.customTextBox.BackColor = System.Drawing.Color.LightGray;
            this.customTextBox.BorderColor = System.Drawing.Color.LightGray;
            this.customTextBox.BorderSize = 2;
            this.customTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customTextBox.ForeColor = System.Drawing.Color.Black;
            this.customTextBox.IsInEdit = false;
            this.customTextBox.Location = new System.Drawing.Point(53, 11);
            this.customTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.customTextBox.Name = "customTextBox";
            this.customTextBox.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.customTextBox.Size = new System.Drawing.Size(194, 38);
            this.customTextBox.TabIndex = 6;
            this.customTextBox.UnderlinedStyle = false;
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
            this.btnDelete.Location = new System.Drawing.Point(247, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(22, 29);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "X";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnEditListName.ForeColor = System.Drawing.Color.Black;
            this.btnEditListName.Location = new System.Drawing.Point(3, 50);
            this.btnEditListName.Name = "btnEditListName";
            this.btnEditListName.Size = new System.Drawing.Size(57, 22);
            this.btnEditListName.TabIndex = 1;
            this.btnEditListName.Text = "Rename";
            this.btnEditListName.TextColor = System.Drawing.Color.Black;
            this.btnEditListName.UseVisualStyleBackColor = false;
            this.btnEditListName.Click += new System.EventHandler(this.btnEditListName_Click);
            // 
            // ProjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblProjPriority);
            this.Controls.Add(this.lblDrag);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblTaskCount);
            this.Controls.Add(this.customTextBox);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.pnlIndicator);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnEditListName);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximumSize = new System.Drawing.Size(272, 280);
            this.MinimumSize = new System.Drawing.Size(272, 103);
            this.Name = "ProjectView";
            this.Size = new System.Drawing.Size(272, 103);
            this.Click += new System.EventHandler(this.ProjectView_GotFocus);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomButtonV2 btnEditListName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlIndicator;
        private CustomControls.CustomTextBox customTextBox;
        private CustomButtonV2 btnDelete;
        private System.Windows.Forms.Label lblTaskCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLowTaskCount;
        private System.Windows.Forms.Label lblMediumTaskCount;
        private System.Windows.Forms.Label lblHighTaskCount;
        private System.Windows.Forms.Label lblDrag;
        private CustomButtonV2 btnProjPriority;
        private System.Windows.Forms.Label lblProjPriority;
        private CustomButtonV2 btnAddProjectAttachment;
        private CustomButtonV2 btnHideProject;
        private System.Windows.Forms.Label lblVeryLow;
        private System.Windows.Forms.Label lblVeryLowTaskCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblWaitingTaskCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDontProceedTaskCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDoneTaskCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblUrgentTaskCount;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
