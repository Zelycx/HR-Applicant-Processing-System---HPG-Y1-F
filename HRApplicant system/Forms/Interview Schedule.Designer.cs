namespace HRApplicant_system.Forms
{
    partial class Interview_Schedule
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvApplicants = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblApplicant = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblInterviewer = new System.Windows.Forms.Label();
            this.dtpSchedule = new System.Windows.Forms.DateTimePicker();
            this.lblApplicantValue = new System.Windows.Forms.Label();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.cmbInterviewer = new System.Windows.Forms.ComboBox();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Location = new System.Drawing.Point(144, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(368, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Interview Scheduling";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(86, 49);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(72, 22);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(164, 45);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 26);
            this.txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(420, 41);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 35);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // lvApplicants
            // 
            this.lvApplicants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvApplicants.FullRowSelect = true;
            this.lvApplicants.GridLines = true;
            this.lvApplicants.HideSelection = false;
            this.lvApplicants.Location = new System.Drawing.Point(12, 77);
            this.lvApplicants.Name = "lvApplicants";
            this.lvApplicants.Size = new System.Drawing.Size(640, 180);
            this.lvApplicants.TabIndex = 6;
            this.lvApplicants.UseCompatibleStateImageBehavior = false;
            this.lvApplicants.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "App ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Applicant Name";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Position";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.Width = 150;
            // 
            // lblApplicant
            // 
            this.lblApplicant.AutoSize = true;
            this.lblApplicant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicant.Location = new System.Drawing.Point(10, 272);
            this.lblApplicant.Name = "lblApplicant";
            this.lblApplicant.Size = new System.Drawing.Size(109, 25);
            this.lblApplicant.TabIndex = 7;
            this.lblApplicant.Text = "Applicant:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(10, 310);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(211, 25);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "Interview Date/Time:";
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(12, 344);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(73, 25);
            this.lblMode.TabIndex = 11;
            this.lblMode.Text = "Mode:";
            this.lblMode.Click += new System.EventHandler(this.lblMode_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(12, 372);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(148, 25);
            this.lblLocation.TabIndex = 13;
            this.lblLocation.Text = "Location/Link:";
            // 
            // lblInterviewer
            // 
            this.lblInterviewer.AutoSize = true;
            this.lblInterviewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterviewer.Location = new System.Drawing.Point(12, 409);
            this.lblInterviewer.Name = "lblInterviewer";
            this.lblInterviewer.Size = new System.Drawing.Size(124, 25);
            this.lblInterviewer.TabIndex = 15;
            this.lblInterviewer.Text = "Interviewer:";
            this.lblInterviewer.Click += new System.EventHandler(this.lblInterviewer_Click);
            // 
            // dtpSchedule
            // 
            this.dtpSchedule.CustomFormat = "MMMM dd, yyyy hh:mm tt";
            this.dtpSchedule.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSchedule.Location = new System.Drawing.Point(227, 309);
            this.dtpSchedule.Name = "dtpSchedule";
            this.dtpSchedule.Size = new System.Drawing.Size(250, 26);
            this.dtpSchedule.TabIndex = 16;
            // 
            // lblApplicantValue
            // 
            this.lblApplicantValue.AutoSize = true;
            this.lblApplicantValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicantValue.Location = new System.Drawing.Point(224, 260);
            this.lblApplicantValue.Name = "lblApplicantValue";
            this.lblApplicantValue.Size = new System.Drawing.Size(19, 25);
            this.lblApplicantValue.TabIndex = 17;
            this.lblApplicantValue.Text = "-";
            // 
            // cmbMode
            // 
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "Face to Face",
            "Online",
            "Phone"});
            this.cmbMode.Location = new System.Drawing.Point(227, 341);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(180, 28);
            this.cmbMode.TabIndex = 18;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(227, 375);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(400, 26);
            this.txtLocation.TabIndex = 19;
            // 
            // cmbInterviewer
            // 
            this.cmbInterviewer.FormattingEnabled = true;
            this.cmbInterviewer.Location = new System.Drawing.Point(227, 410);
            this.cmbInterviewer.Name = "cmbInterviewer";
            this.cmbInterviewer.Size = new System.Drawing.Size(250, 28);
            this.cmbInterviewer.TabIndex = 20;
            // 
            // btnSchedule
            // 
            this.btnSchedule.BackColor = System.Drawing.Color.Green;
            this.btnSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSchedule.Location = new System.Drawing.Point(44, 440);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(177, 42);
            this.btnSchedule.TabIndex = 21;
            this.btnSchedule.Text = "Schedule Interview";
            this.btnSchedule.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(547, 450);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 32);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // Interview_Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 494);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSchedule);
            this.Controls.Add(this.cmbInterviewer);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.cmbMode);
            this.Controls.Add(this.lblApplicantValue);
            this.Controls.Add(this.dtpSchedule);
            this.Controls.Add(this.lblInterviewer);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblApplicant);
            this.Controls.Add(this.lvApplicants);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblTitle);
            this.Name = "Interview_Schedule";
            this.Text = "Interview_Schedule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvApplicants;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblApplicant;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblInterviewer;
        private System.Windows.Forms.DateTimePicker dtpSchedule;
        private System.Windows.Forms.Label lblApplicantValue;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.ComboBox cmbInterviewer;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnBack;
    }
}