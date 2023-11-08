namespace PS_Digital_Audit
{
    partial class Import_Master_Data
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Import_Master_Data));
            this.GBSection = new System.Windows.Forms.GroupBox();
            this.cmbChecksheet = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.dtRevDate = new System.Windows.Forms.DateTimePicker();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_Position = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_IDNum = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.lblIDNum = new System.Windows.Forms.Label();
            this.lblLogout = new System.Windows.Forms.Label();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.btnEditMaster = new Finished_Good_Monitoring_System.JEButton();
            this.btnUploadMaster = new Finished_Good_Monitoring_System.JEButton();
            this.jeButton2 = new Finished_Good_Monitoring_System.JEButton();
            this.jeButton1 = new Finished_Good_Monitoring_System.JEButton();
            this.jeButton14 = new Finished_Good_Monitoring_System.JEButton();
            this.GBSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // GBSection
            // 
            this.GBSection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GBSection.BackColor = System.Drawing.Color.White;
            this.GBSection.Controls.Add(this.cmbChecksheet);
            this.GBSection.Controls.Add(this.dataGridView2);
            this.GBSection.Controls.Add(this.dataGridView1);
            this.GBSection.Controls.Add(this.label7);
            this.GBSection.Controls.Add(this.lblFileName);
            this.GBSection.Controls.Add(this.dtRevDate);
            this.GBSection.Controls.Add(this.btnUploadMaster);
            this.GBSection.Controls.Add(this.tbVersion);
            this.GBSection.Controls.Add(this.button6);
            this.GBSection.Controls.Add(this.label5);
            this.GBSection.Controls.Add(this.label4);
            this.GBSection.Controls.Add(this.label3);
            this.GBSection.Controls.Add(this.label2);
            this.GBSection.Controls.Add(this.jeButton2);
            this.GBSection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GBSection.Location = new System.Drawing.Point(290, 190);
            this.GBSection.Name = "GBSection";
            this.GBSection.Size = new System.Drawing.Size(981, 742);
            this.GBSection.TabIndex = 41;
            this.GBSection.TabStop = false;
            // 
            // cmbChecksheet
            // 
            this.cmbChecksheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbChecksheet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbChecksheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChecksheet.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChecksheet.FormattingEnabled = true;
            this.cmbChecksheet.Items.AddRange(new object[] {
            "QA",
            "PRINTER",
            "P-TOUCH",
            "TAPE CASSETTE",
            "INK CTG",
            "INK HEAD",
            "PCBA",
            "DE"});
            this.cmbChecksheet.Location = new System.Drawing.Point(359, 189);
            this.cmbChecksheet.Name = "cmbChecksheet";
            this.cmbChecksheet.Size = new System.Drawing.Size(304, 44);
            this.cmbChecksheet.TabIndex = 122;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(-319, 246);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(672, 231);
            this.dataGridView2.TabIndex = 47;
            this.dataGridView2.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(155, 491);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(672, 231);
            this.dataGridView1.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(107, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(233, 36);
            this.label7.TabIndex = 48;
            this.label7.Text = "Checksheet Name:";
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.Color.Maroon;
            this.lblFileName.Location = new System.Drawing.Point(356, 155);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(85, 18);
            this.lblFileName.TabIndex = 46;
            this.lblFileName.Text = "<File Name>";
            // 
            // dtRevDate
            // 
            this.dtRevDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtRevDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtRevDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRevDate.Location = new System.Drawing.Point(359, 351);
            this.dtRevDate.Name = "dtRevDate";
            this.dtRevDate.Size = new System.Drawing.Size(249, 38);
            this.dtRevDate.TabIndex = 44;
            this.dtRevDate.Value = new System.DateTime(2022, 6, 17, 0, 0, 0, 0);
            // 
            // tbVersion
            // 
            this.tbVersion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVersion.Location = new System.Drawing.Point(358, 273);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(305, 40);
            this.tbVersion.TabIndex = 12;
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(358, 107);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(305, 45);
            this.button6.TabIndex = 11;
            this.button6.Text = "Choose File";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.EnabledChanged += new System.EventHandler(this.button6_EnabledChanged);
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(158, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 36);
            this.label5.TabIndex = 9;
            this.label5.Text = "Revision Date:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(230, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 36);
            this.label4.TabIndex = 8;
            this.label4.Text = "Version:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(185, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 36);
            this.label3.TabIndex = 7;
            this.label3.Text = "File Upload:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(279, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(421, 59);
            this.label2.TabIndex = 6;
            this.label2.Text = "Import Master Data";
            // 
            // cmbModel
            // 
            this.cmbModel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Location = new System.Drawing.Point(389, 18);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(304, 41);
            this.cmbModel.TabIndex = 45;
            this.cmbModel.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(267, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 36);
            this.label6.TabIndex = 10;
            this.label6.Text = "Model:";
            this.label6.Visible = false;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 89);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(275, 217);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(54, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 24);
            this.label1.TabIndex = 37;
            this.label1.Text = "User Information";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.button2.Location = new System.Drawing.Point(0, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(279, 862);
            this.button2.TabIndex = 38;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(1144, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 41);
            this.button3.TabIndex = 32;
            this.button3.Text = "—";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(1236, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(45, 41);
            this.button4.TabIndex = 31;
            this.button4.Text = "X";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Maiandra GD", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(1190, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(45, 41);
            this.button5.TabIndex = 30;
            this.button5.Text = "█";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 80);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(-1, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1285, 88);
            this.button1.TabIndex = 29;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lbl_Position
            // 
            this.lbl_Position.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Position.AutoSize = true;
            this.lbl_Position.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.lbl_Position.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Position.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Position.ForeColor = System.Drawing.Color.Transparent;
            this.lbl_Position.Location = new System.Drawing.Point(99, 454);
            this.lbl_Position.Name = "lbl_Position";
            this.lbl_Position.Size = new System.Drawing.Size(83, 20);
            this.lbl_Position.TabIndex = 47;
            this.lbl_Position.Text = "<Position>";
            // 
            // lbl_Name
            // 
            this.lbl_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.lbl_Name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.ForeColor = System.Drawing.Color.Transparent;
            this.lbl_Name.Location = new System.Drawing.Point(67, 413);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(69, 20);
            this.lbl_Name.TabIndex = 46;
            this.lbl_Name.Text = "<Name>";
            // 
            // lbl_IDNum
            // 
            this.lbl_IDNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_IDNum.AutoSize = true;
            this.lbl_IDNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.lbl_IDNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_IDNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IDNum.ForeColor = System.Drawing.Color.Transparent;
            this.lbl_IDNum.Location = new System.Drawing.Point(67, 372);
            this.lbl_IDNum.Name = "lbl_IDNum";
            this.lbl_IDNum.Size = new System.Drawing.Size(104, 20);
            this.lbl_IDNum.TabIndex = 45;
            this.lbl_IDNum.Text = "<ID Number>";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(3, 451);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 24);
            this.label9.TabIndex = 44;
            this.label9.Text = "Authority:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(3, 410);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 24);
            this.label10.TabIndex = 43;
            this.label10.Text = "Name:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(2, 369);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 24);
            this.label11.TabIndex = 42;
            this.label11.Text = "ID NO:";
            // 
            // pictureBox11
            // 
            this.pictureBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.pictureBox11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
            this.pictureBox11.Location = new System.Drawing.Point(1004, 49);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(35, 28);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 74;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.pictureBox10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(841, 50);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(34, 28);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 73;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.pictureBox9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(655, 50);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(38, 32);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 72;
            this.pictureBox9.TabStop = false;
            // 
            // lblIDNum
            // 
            this.lblIDNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIDNum.AutoSize = true;
            this.lblIDNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.lblIDNum.Font = new System.Drawing.Font("Calibri", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDNum.ForeColor = System.Drawing.Color.White;
            this.lblIDNum.Location = new System.Drawing.Point(1036, 49);
            this.lblIDNum.Name = "lblIDNum";
            this.lblIDNum.Size = new System.Drawing.Size(116, 28);
            this.lblIDNum.TabIndex = 71;
            this.lblIDNum.Text = "ID Number";
            // 
            // lblLogout
            // 
            this.lblLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogout.AutoSize = true;
            this.lblLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.lblLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogout.Font = new System.Drawing.Font("Calibri", 17.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogout.ForeColor = System.Drawing.Color.White;
            this.lblLogout.Location = new System.Drawing.Point(872, 50);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(95, 28);
            this.lblLogout.TabIndex = 70;
            this.lblLogout.Text = "LOGOUT";
            this.lblLogout.Click += new System.EventHandler(this.lblLogout_Click);
            this.lblLogout.MouseEnter += new System.EventHandler(this.lblLogout_MouseEnter);
            this.lblLogout.MouseLeave += new System.EventHandler(this.lblLogout_MouseLeave);
            // 
            // lblDashboard
            // 
            this.lblDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.lblDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDashboard.Font = new System.Drawing.Font("Calibri", 17.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.White;
            this.lblDashboard.Location = new System.Drawing.Point(689, 50);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(137, 28);
            this.lblDashboard.TabIndex = 69;
            this.lblDashboard.Text = "DASHBOARD";
            this.lblDashboard.Click += new System.EventHandler(this.lblDashboard_Click);
            this.lblDashboard.MouseEnter += new System.EventHandler(this.lblDashboard_MouseEnter);
            this.lblDashboard.MouseLeave += new System.EventHandler(this.lblDashboard_MouseLeave);
            // 
            // btnEditMaster
            // 
            this.btnEditMaster.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEditMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEditMaster.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEditMaster.BorderColor = System.Drawing.Color.White;
            this.btnEditMaster.BorderRadius = 30;
            this.btnEditMaster.BorderSize = 0;
            this.btnEditMaster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditMaster.FlatAppearance.BorderSize = 0;
            this.btnEditMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditMaster.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditMaster.ForeColor = System.Drawing.Color.White;
            this.btnEditMaster.Location = new System.Drawing.Point(1033, 115);
            this.btnEditMaster.Name = "btnEditMaster";
            this.btnEditMaster.Size = new System.Drawing.Size(238, 69);
            this.btnEditMaster.TabIndex = 51;
            this.btnEditMaster.Text = "Modify Master Data";
            this.btnEditMaster.TextColor = System.Drawing.Color.White;
            this.btnEditMaster.UseVisualStyleBackColor = false;
            this.btnEditMaster.Click += new System.EventHandler(this.btnEditMaster_Click);
            // 
            // btnUploadMaster
            // 
            this.btnUploadMaster.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUploadMaster.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUploadMaster.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnUploadMaster.BorderColor = System.Drawing.Color.White;
            this.btnUploadMaster.BorderRadius = 30;
            this.btnUploadMaster.BorderSize = 0;
            this.btnUploadMaster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadMaster.FlatAppearance.BorderSize = 0;
            this.btnUploadMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadMaster.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadMaster.ForeColor = System.Drawing.Color.White;
            this.btnUploadMaster.Location = new System.Drawing.Point(370, 416);
            this.btnUploadMaster.Name = "btnUploadMaster";
            this.btnUploadMaster.Size = new System.Drawing.Size(238, 69);
            this.btnUploadMaster.TabIndex = 42;
            this.btnUploadMaster.Text = "Upload";
            this.btnUploadMaster.TextColor = System.Drawing.Color.White;
            this.btnUploadMaster.UseVisualStyleBackColor = false;
            this.btnUploadMaster.Click += new System.EventHandler(this.btnUploadMaster_Click);
            // 
            // jeButton2
            // 
            this.jeButton2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.jeButton2.BackColor = System.Drawing.Color.Red;
            this.jeButton2.BackgroundColor = System.Drawing.Color.Red;
            this.jeButton2.BorderColor = System.Drawing.Color.White;
            this.jeButton2.BorderRadius = 30;
            this.jeButton2.BorderSize = 0;
            this.jeButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jeButton2.FlatAppearance.BorderSize = 0;
            this.jeButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jeButton2.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jeButton2.ForeColor = System.Drawing.Color.White;
            this.jeButton2.Location = new System.Drawing.Point(727, 613);
            this.jeButton2.Name = "jeButton2";
            this.jeButton2.Size = new System.Drawing.Size(48, 31);
            this.jeButton2.TabIndex = 50;
            this.jeButton2.Text = "Delete Old";
            this.jeButton2.TextColor = System.Drawing.Color.White;
            this.jeButton2.UseVisualStyleBackColor = false;
            this.jeButton2.Visible = false;
            this.jeButton2.Click += new System.EventHandler(this.jeButton2_Click);
            // 
            // jeButton1
            // 
            this.jeButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.jeButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.jeButton1.BorderColor = System.Drawing.Color.White;
            this.jeButton1.BorderRadius = 30;
            this.jeButton1.BorderSize = 0;
            this.jeButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jeButton1.Enabled = false;
            this.jeButton1.FlatAppearance.BorderSize = 0;
            this.jeButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jeButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jeButton1.ForeColor = System.Drawing.Color.White;
            this.jeButton1.Location = new System.Drawing.Point(15, 25);
            this.jeButton1.Name = "jeButton1";
            this.jeButton1.Size = new System.Drawing.Size(126, 39);
            this.jeButton1.TabIndex = 33;
            this.jeButton1.Text = "Home";
            this.jeButton1.TextColor = System.Drawing.Color.White;
            this.jeButton1.UseVisualStyleBackColor = false;
            this.jeButton1.Visible = false;
            // 
            // jeButton14
            // 
            this.jeButton14.BackColor = System.Drawing.Color.CornflowerBlue;
            this.jeButton14.BackgroundColor = System.Drawing.Color.CornflowerBlue;
            this.jeButton14.BorderColor = System.Drawing.Color.DarkMagenta;
            this.jeButton14.BorderRadius = 20;
            this.jeButton14.BorderSize = 0;
            this.jeButton14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jeButton14.Enabled = false;
            this.jeButton14.FlatAppearance.BorderSize = 0;
            this.jeButton14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jeButton14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jeButton14.ForeColor = System.Drawing.Color.White;
            this.jeButton14.Location = new System.Drawing.Point(86, 630);
            this.jeButton14.Name = "jeButton14";
            this.jeButton14.Size = new System.Drawing.Size(106, 39);
            this.jeButton14.TabIndex = 40;
            this.jeButton14.Text = "&Log out";
            this.jeButton14.TextColor = System.Drawing.Color.White;
            this.jeButton14.UseVisualStyleBackColor = false;
            this.jeButton14.Visible = false;
            this.jeButton14.Click += new System.EventHandler(this.jeButton14_Click);
            // 
            // Import_Master_Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1283, 944);
            this.Controls.Add(this.btnEditMaster);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.lblIDNum);
            this.Controls.Add(this.lblLogout);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.lbl_Position);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.lbl_IDNum);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.GBSection);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.jeButton1);
            this.Controls.Add(this.jeButton14);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbModel);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Import_Master_Data";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Import_Master_Data_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Import_Master_Data_MouseDown);
            this.GBSection.ResumeLayout(false);
            this.GBSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GBSection;
        private System.Windows.Forms.Label label2;
        private Finished_Good_Monitoring_System.JEButton jeButton14;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private Finished_Good_Monitoring_System.JEButton jeButton1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Finished_Good_Monitoring_System.JEButton btnUploadMaster;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_Position;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_IDNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtRevDate;
        private System.Windows.Forms.ComboBox cmbModel;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label lblIDNum;
        private System.Windows.Forms.Label lblLogout;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label7;
        private Finished_Good_Monitoring_System.JEButton jeButton2;
        private Finished_Good_Monitoring_System.JEButton btnEditMaster;
        private System.Windows.Forms.ComboBox cmbChecksheet;
    }
}