namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR_Staff.Interview_Management
{
    partial class InterviewSched
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
            panel1 = new Panel();
            BackButton = new Button();
            label1 = new Label();
            label2 = new Label();
            ApplicantName = new TextBox();
            label4 = new Label();
            ApplicantId = new TextBox();
            CurrentStatus = new TextBox();
            label5 = new Label();
            JobApplied = new TextBox();
            panel2 = new Panel();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            InterviewMode = new ComboBox();
            InterviewLocation = new TextBox();
            Status = new ComboBox();
            SaveScheduleButton = new Button();
            CancelInterviewButton = new Button();
            label3 = new Label();
            InterviewerName = new TextBox();
            InterviewDate = new DateTimePicker();
            InterviewTime = new DateTimePicker();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(BackButton);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1929, 152);
            panel1.TabIndex = 9;
            // 
            // BackButton
            // 
            BackButton.FlatAppearance.BorderColor = Color.White;
            BackButton.FlatAppearance.BorderSize = 2;
            BackButton.FlatStyle = FlatStyle.Flat;
            BackButton.Font = new Font("Century", 10.2F);
            BackButton.ForeColor = Color.White;
            BackButton.Location = new Point(1703, 20);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(189, 119);
            BackButton.TabIndex = 14;
            BackButton.Text = "BACK TO LIST";
            BackButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(64, 45);
            label1.Name = "label1";
            label1.Size = new Size(647, 54);
            label1.TabIndex = 0;
            label1.Text = "SCHEDULE AN INTERVIEW";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(38, 184);
            label2.Name = "label2";
            label2.Size = new Size(150, 41);
            label2.TabIndex = 10;
            label2.Text = "Applicant:";
            // 
            // ApplicantName
            // 
            ApplicantName.Location = new Point(244, 198);
            ApplicantName.Name = "ApplicantName";
            ApplicantName.ReadOnly = true;
            ApplicantName.Size = new Size(272, 27);
            ApplicantName.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(38, 225);
            label4.Name = "label4";
            label4.Size = new Size(212, 41);
            label4.TabIndex = 13;
            label4.Text = "Application ID:";
            // 
            // ApplicantId
            // 
            ApplicantId.Location = new Point(244, 239);
            ApplicantId.Name = "ApplicantId";
            ApplicantId.ReadOnly = true;
            ApplicantId.Size = new Size(272, 27);
            ApplicantId.TabIndex = 14;
            // 
            // CurrentStatus
            // 
            CurrentStatus.Location = new Point(244, 280);
            CurrentStatus.Name = "CurrentStatus";
            CurrentStatus.ReadOnly = true;
            CurrentStatus.Size = new Size(272, 27);
            CurrentStatus.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(535, 225);
            label5.Name = "label5";
            label5.Size = new Size(183, 41);
            label5.TabIndex = 16;
            label5.Text = "Job Applied:";
            // 
            // JobApplied
            // 
            JobApplied.Location = new Point(724, 239);
            JobApplied.Name = "JobApplied";
            JobApplied.ReadOnly = true;
            JobApplied.Size = new Size(289, 27);
            JobApplied.TabIndex = 17;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Controls.Add(label6);
            panel2.Location = new Point(12, 335);
            panel2.Name = "panel2";
            panel2.Size = new Size(1929, 92);
            panel2.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(26, 20);
            label6.Name = "label6";
            label6.Size = new Size(497, 54);
            label6.TabIndex = 0;
            label6.Text = "SCHEDULE DETAILS";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(38, 444);
            label7.Name = "label7";
            label7.Size = new Size(215, 41);
            label7.TabIndex = 19;
            label7.Text = "Interview Date:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(38, 485);
            label8.Name = "label8";
            label8.Size = new Size(218, 41);
            label8.TabIndex = 20;
            label8.Text = "Interview Time:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(586, 453);
            label9.Name = "label9";
            label9.Size = new Size(274, 41);
            label9.TabIndex = 21;
            label9.Text = " Interviewer Name: ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(586, 494);
            label10.Name = "label10";
            label10.Size = new Size(240, 41);
            label10.TabIndex = 22;
            label10.Text = " Interview Mode:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(586, 535);
            label11.Name = "label11";
            label11.Size = new Size(274, 41);
            label11.TabIndex = 23;
            label11.Text = " Interview Location:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(592, 575);
            label12.Name = "label12";
            label12.Size = new Size(105, 41);
            label12.TabIndex = 24;
            label12.Text = "Status:";
            // 
            // InterviewMode
            // 
            InterviewMode.Enabled = false;
            InterviewMode.FormattingEnabled = true;
            InterviewMode.Location = new Point(866, 508);
            InterviewMode.Name = "InterviewMode";
            InterviewMode.Size = new Size(254, 28);
            InterviewMode.TabIndex = 28;
            // 
            // InterviewLocation
            // 
            InterviewLocation.Location = new Point(866, 549);
            InterviewLocation.Name = "InterviewLocation";
            InterviewLocation.ReadOnly = true;
            InterviewLocation.Size = new Size(254, 27);
            InterviewLocation.TabIndex = 29;
            // 
            // Status
            // 
            Status.Enabled = false;
            Status.FormattingEnabled = true;
            Status.Location = new Point(866, 588);
            Status.Name = "Status";
            Status.Size = new Size(254, 28);
            Status.TabIndex = 30;
            // 
            // SaveScheduleButton
            // 
            SaveScheduleButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SaveScheduleButton.Location = new Point(210, 777);
            SaveScheduleButton.Name = "SaveScheduleButton";
            SaveScheduleButton.Size = new Size(306, 121);
            SaveScheduleButton.TabIndex = 32;
            SaveScheduleButton.Text = "Save Schedule";
            SaveScheduleButton.UseVisualStyleBackColor = true;
            SaveScheduleButton.Click += SaveScheduleButton_Click;
            // 
            // CancelInterviewButton
            // 
            CancelInterviewButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CancelInterviewButton.Location = new Point(980, 777);
            CancelInterviewButton.Name = "CancelInterviewButton";
            CancelInterviewButton.Size = new Size(306, 121);
            CancelInterviewButton.TabIndex = 33;
            CancelInterviewButton.Text = "Cancel Interview";
            CancelInterviewButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(36, 266);
            label3.Name = "label3";
            label3.Size = new Size(220, 41);
            label3.TabIndex = 34;
            label3.Text = "Current Status: ";
            // 
            // InterviewerName
            // 
            InterviewerName.Location = new Point(866, 458);
            InterviewerName.Name = "InterviewerName";
            InterviewerName.ReadOnly = true;
            InterviewerName.Size = new Size(254, 27);
            InterviewerName.TabIndex = 35;
            // 
            // InterviewDate
            // 
            InterviewDate.Enabled = false;
            InterviewDate.Location = new Point(259, 453);
            InterviewDate.Name = "InterviewDate";
            InterviewDate.Size = new Size(257, 27);
            InterviewDate.TabIndex = 36;
            // 
            // InterviewTime
            // 
            InterviewTime.Enabled = false;
            InterviewTime.Location = new Point(259, 494);
            InterviewTime.Name = "InterviewTime";
            InterviewTime.Size = new Size(257, 27);
            InterviewTime.TabIndex = 37;
            // 
            // InterviewSched
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(InterviewTime);
            Controls.Add(InterviewDate);
            Controls.Add(InterviewerName);
            Controls.Add(label3);
            Controls.Add(CancelInterviewButton);
            Controls.Add(SaveScheduleButton);
            Controls.Add(Status);
            Controls.Add(InterviewLocation);
            Controls.Add(InterviewMode);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(panel2);
            Controls.Add(JobApplied);
            Controls.Add(label5);
            Controls.Add(CurrentStatus);
            Controls.Add(ApplicantId);
            Controls.Add(label4);
            Controls.Add(ApplicantName);
            Controls.Add(label2);
            Controls.Add(panel1);
            Enabled = false;
            Name = "InterviewSched";
            Text = "InterviewSched";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button BackButton;
        private Label label1;
        private Label label2;
        private TextBox ApplicantName;
        private Label label4;
        private TextBox ApplicantId;
        private TextBox CurrentStatus;
        private Label label5;
        private TextBox JobApplied;
        private Panel panel2;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private ComboBox InterviewMode;
        private TextBox InterviewLocation;
        private ComboBox Status;
        private Button SaveScheduleButton;
        private Button CancelInterviewButton;
        private Label label3;
        private Label label6;
        private TextBox InterviewerName;
        private DateTimePicker InterviewDate;
        private DateTimePicker InterviewTime;
    }
}