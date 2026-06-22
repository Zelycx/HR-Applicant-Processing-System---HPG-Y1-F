namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR
{
    partial class ApplicantReview
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
            GenderSelection = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            BirthdateSelection = new DateTimePicker();
            BackButton = new Button();
            panel7 = new Panel();
            label4 = new Label();
            panel4 = new Panel();
            ExperienceTextBox = new RichTextBox();
            SkillTextBox = new RichTextBox();
            label14 = new Label();
            label15 = new Label();
            panel3 = new Panel();
            YearLevelTextBox = new TextBox();
            CourseTextBox = new TextBox();
            SchoolTextBox = new TextBox();
            panel6 = new Panel();
            label3 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            LNTextBox = new TextBox();
            label17 = new Label();
            MNTextBox = new TextBox();
            label16 = new Label();
            EmailTextBox = new TextBox();
            ContactNumberTextBox = new TextBox();
            AddressTextBox = new TextBox();
            FNTextBox = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label5 = new Label();
            panel5 = new Panel();
            label2 = new Label();
            panel8 = new Panel();
            ApplicantStatusLabel = new Label();
            panel9 = new Panel();
            label18 = new Label();
            panel10 = new Panel();
            label19 = new Label();
            panel11 = new Panel();
            Documents = new ListView();
            panel12 = new Panel();
            label23 = new Label();
            label22 = new Label();
            label21 = new Label();
            HiredBy = new TextBox();
            InterviewedBy = new TextBox();
            ScreenedBy = new TextBox();
            panel13 = new Panel();
            label20 = new Label();
            panel7.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            panel13.SuspendLayout();
            SuspendLayout();
            // 
            // GenderSelection
            // 
            GenderSelection.Enabled = false;
            GenderSelection.FormattingEnabled = true;
            GenderSelection.Location = new Point(183, 235);
            GenderSelection.Name = "GenderSelection";
            GenderSelection.Size = new Size(328, 28);
            GenderSelection.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(30, 235);
            label6.Name = "label6";
            label6.Size = new Size(150, 23);
            label6.TabIndex = 4;
            label6.Text = "Gender           :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(527, 238);
            label7.Name = "label7";
            label7.Size = new Size(147, 23);
            label7.TabIndex = 5;
            label7.Text = "Birthdate       :";
            // 
            // BirthdateSelection
            // 
            BirthdateSelection.Enabled = false;
            BirthdateSelection.Location = new Point(707, 236);
            BirthdateSelection.MaxDate = new DateTime(2026, 6, 10, 8, 4, 38, 0);
            BirthdateSelection.Name = "BirthdateSelection";
            BirthdateSelection.Size = new Size(262, 27);
            BirthdateSelection.TabIndex = 10;
            BirthdateSelection.Value = new DateTime(2026, 6, 10, 0, 0, 0, 0);
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
            BackButton.Click += BackButton_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.SlateGray;
            panel7.Controls.Add(label4);
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(1387, 48);
            panel7.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(-7, 6);
            label4.Name = "label4";
            label4.Size = new Size(504, 33);
            label4.TabIndex = 1;
            label4.Text = "WORK EXPERIENCE ( OPTIONAL )";
            // 
            // panel4
            // 
            panel4.BackColor = Color.WhiteSmoke;
            panel4.Controls.Add(ExperienceTextBox);
            panel4.Controls.Add(SkillTextBox);
            panel4.Controls.Add(panel7);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(label15);
            panel4.Location = new Point(11, 623);
            panel4.Name = "panel4";
            panel4.Size = new Size(1387, 254);
            panel4.TabIndex = 10;
            // 
            // ExperienceTextBox
            // 
            ExperienceTextBox.Location = new Point(183, 64);
            ExperienceTextBox.Name = "ExperienceTextBox";
            ExperienceTextBox.ReadOnly = true;
            ExperienceTextBox.Size = new Size(439, 179);
            ExperienceTextBox.TabIndex = 20;
            ExperienceTextBox.Text = "";
            // 
            // SkillTextBox
            // 
            SkillTextBox.Location = new Point(722, 64);
            SkillTextBox.Name = "SkillTextBox";
            SkillTextBox.ReadOnly = true;
            SkillTextBox.Size = new Size(512, 179);
            SkillTextBox.TabIndex = 19;
            SkillTextBox.Text = "";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(632, 64);
            label14.Name = "label14";
            label14.Size = new Size(74, 23);
            label14.TabIndex = 13;
            label14.Text = "Skills :";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(53, 64);
            label15.Name = "label15";
            label15.Size = new Size(124, 23);
            label15.TabIndex = 12;
            label15.Text = "Experience :";
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(YearLevelTextBox);
            panel3.Controls.Add(CourseTextBox);
            panel3.Controls.Add(SchoolTextBox);
            panel3.Controls.Add(panel6);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(label13);
            panel3.Location = new Point(12, 480);
            panel3.Name = "panel3";
            panel3.Size = new Size(1387, 151);
            panel3.TabIndex = 11;
            // 
            // YearLevelTextBox
            // 
            YearLevelTextBox.BorderStyle = BorderStyle.FixedSingle;
            YearLevelTextBox.Location = new Point(1148, 87);
            YearLevelTextBox.Name = "YearLevelTextBox";
            YearLevelTextBox.ReadOnly = true;
            YearLevelTextBox.Size = new Size(176, 27);
            YearLevelTextBox.TabIndex = 17;
            // 
            // CourseTextBox
            // 
            CourseTextBox.BorderStyle = BorderStyle.FixedSingle;
            CourseTextBox.Location = new Point(746, 86);
            CourseTextBox.Name = "CourseTextBox";
            CourseTextBox.ReadOnly = true;
            CourseTextBox.Size = new Size(173, 27);
            CourseTextBox.TabIndex = 16;
            // 
            // SchoolTextBox
            // 
            SchoolTextBox.BorderStyle = BorderStyle.FixedSingle;
            SchoolTextBox.Location = new Point(224, 86);
            SchoolTextBox.Name = "SchoolTextBox";
            SchoolTextBox.ReadOnly = true;
            SchoolTextBox.Size = new Size(314, 27);
            SchoolTextBox.TabIndex = 15;
            // 
            // panel6
            // 
            panel6.BackColor = Color.SlateGray;
            panel6.Controls.Add(label3);
            panel6.Location = new Point(1, -1);
            panel6.Name = "panel6";
            panel6.Size = new Size(1386, 48);
            panel6.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(-7, 6);
            label3.Name = "label3";
            label3.Size = new Size(456, 33);
            label3.TabIndex = 1;
            label3.Text = "EDUCATIONAL BACKGROUND";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(977, 90);
            label11.Name = "label11";
            label11.Size = new Size(165, 23);
            label11.TabIndex = 11;
            label11.Text = "Education Level:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(575, 90);
            label12.Name = "label12";
            label12.Size = new Size(156, 23);
            label12.TabIndex = 10;
            label12.Text = "Course/Strand :";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(53, 86);
            label13.Name = "label13";
            label13.Size = new Size(82, 23);
            label13.TabIndex = 9;
            label13.Text = "School :";
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(BackButton);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-13, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(1929, 152);
            panel1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(64, 45);
            label1.Name = "label1";
            label1.Size = new Size(490, 54);
            label1.TabIndex = 0;
            label1.Text = "APPLICANT REVIEW";
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(GenderSelection);
            panel2.Controls.Add(BirthdateSelection);
            panel2.Controls.Add(LNTextBox);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(MNTextBox);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(EmailTextBox);
            panel2.Controls.Add(ContactNumberTextBox);
            panel2.Controls.Add(AddressTextBox);
            panel2.Controls.Add(FNTextBox);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(panel5);
            panel2.Location = new Point(11, 202);
            panel2.Name = "panel2";
            panel2.Size = new Size(1387, 281);
            panel2.TabIndex = 9;
            // 
            // LNTextBox
            // 
            LNTextBox.BorderStyle = BorderStyle.FixedSingle;
            LNTextBox.Location = new Point(183, 183);
            LNTextBox.Name = "LNTextBox";
            LNTextBox.ReadOnly = true;
            LNTextBox.Size = new Size(328, 27);
            LNTextBox.TabIndex = 18;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.Location = new Point(32, 183);
            label17.Name = "label17";
            label17.Size = new Size(148, 23);
            label17.TabIndex = 17;
            label17.Text = "Last Name     :";
            // 
            // MNTextBox
            // 
            MNTextBox.BorderStyle = BorderStyle.FixedSingle;
            MNTextBox.Location = new Point(183, 125);
            MNTextBox.Name = "MNTextBox";
            MNTextBox.ReadOnly = true;
            MNTextBox.Size = new Size(328, 27);
            MNTextBox.TabIndex = 16;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(32, 125);
            label16.Name = "label16";
            label16.Size = new Size(146, 23);
            label16.TabIndex = 15;
            label16.Text = "Middle Name :";
            // 
            // EmailTextBox
            // 
            EmailTextBox.BorderStyle = BorderStyle.FixedSingle;
            EmailTextBox.Location = new Point(709, 183);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.ReadOnly = true;
            EmailTextBox.Size = new Size(644, 27);
            EmailTextBox.TabIndex = 14;
            // 
            // ContactNumberTextBox
            // 
            ContactNumberTextBox.BorderStyle = BorderStyle.FixedSingle;
            ContactNumberTextBox.Location = new Point(709, 126);
            ContactNumberTextBox.Name = "ContactNumberTextBox";
            ContactNumberTextBox.ReadOnly = true;
            ContactNumberTextBox.Size = new Size(644, 27);
            ContactNumberTextBox.TabIndex = 13;
            // 
            // AddressTextBox
            // 
            AddressTextBox.BorderStyle = BorderStyle.FixedSingle;
            AddressTextBox.Location = new Point(708, 75);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.ReadOnly = true;
            AddressTextBox.Size = new Size(645, 27);
            AddressTextBox.TabIndex = 12;
            // 
            // FNTextBox
            // 
            FNTextBox.BorderStyle = BorderStyle.FixedSingle;
            FNTextBox.Location = new Point(183, 74);
            FNTextBox.Name = "FNTextBox";
            FNTextBox.ReadOnly = true;
            FNTextBox.Size = new Size(328, 27);
            FNTextBox.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(527, 182);
            label8.Name = "label8";
            label8.Size = new Size(77, 23);
            label8.TabIndex = 8;
            label8.Text = "Email :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(527, 125);
            label9.Name = "label9";
            label9.Size = new Size(176, 23);
            label9.TabIndex = 7;
            label9.Text = "Contact Number :";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(527, 76);
            label10.Name = "label10";
            label10.Size = new Size(95, 23);
            label10.TabIndex = 6;
            label10.Text = "Address :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(32, 74);
            label5.Name = "label5";
            label5.Size = new Size(146, 23);
            label5.TabIndex = 3;
            label5.Text = "First Name    :";
            // 
            // panel5
            // 
            panel5.BackColor = Color.SlateGray;
            panel5.Controls.Add(label2);
            panel5.Location = new Point(1, 1);
            panel5.Name = "panel5";
            panel5.Size = new Size(1387, 48);
            panel5.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(-7, 6);
            label2.Name = "label2";
            label2.Size = new Size(409, 33);
            label2.TabIndex = 1;
            label2.Text = "APPLICANT INFORMATION";
            // 
            // panel8
            // 
            panel8.BackColor = Color.WhiteSmoke;
            panel8.Controls.Add(ApplicantStatusLabel);
            panel8.Controls.Add(panel9);
            panel8.Location = new Point(1405, 202);
            panel8.Name = "panel8";
            panel8.Size = new Size(185, 190);
            panel8.TabIndex = 12;
            // 
            // ApplicantStatusLabel
            // 
            ApplicantStatusLabel.AutoSize = true;
            ApplicantStatusLabel.Location = new Point(52, 133);
            ApplicantStatusLabel.Name = "ApplicantStatusLabel";
            ApplicantStatusLabel.Size = new Size(80, 20);
            ApplicantStatusLabel.TabIndex = 2;
            ApplicantStatusLabel.Text = "Temporary";
            // 
            // panel9
            // 
            panel9.BackColor = Color.RosyBrown;
            panel9.Controls.Add(label18);
            panel9.Location = new Point(0, 1);
            panel9.Name = "panel9";
            panel9.Size = new Size(250, 101);
            panel9.TabIndex = 1;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ForeColor = Color.White;
            label18.Location = new Point(62, 33);
            label18.Name = "label18";
            label18.Size = new Size(59, 20);
            label18.TabIndex = 0;
            label18.Text = "STATUS";
            // 
            // panel10
            // 
            panel10.BackColor = Color.RosyBrown;
            panel10.Controls.Add(label19);
            panel10.Location = new Point(0, 1);
            panel10.Name = "panel10";
            panel10.Size = new Size(185, 101);
            panel10.TabIndex = 0;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.ForeColor = Color.White;
            label19.Location = new Point(43, 28);
            label19.Name = "label19";
            label19.Size = new Size(98, 20);
            label19.TabIndex = 0;
            label19.Text = "DOCUMENTS";
            // 
            // panel11
            // 
            panel11.BackColor = Color.WhiteSmoke;
            panel11.Controls.Add(Documents);
            panel11.Controls.Add(panel10);
            panel11.Location = new Point(1405, 416);
            panel11.Name = "panel11";
            panel11.Size = new Size(185, 461);
            panel11.TabIndex = 13;
            // 
            // Documents
            // 
            Documents.Location = new Point(0, 97);
            Documents.Name = "Documents";
            Documents.Size = new Size(185, 364);
            Documents.TabIndex = 1;
            Documents.UseCompatibleStateImageBehavior = false;
            Documents.SelectedIndexChanged += Documents_SelectedIndexChanged;
            // 
            // panel12
            // 
            panel12.BackColor = Color.White;
            panel12.Controls.Add(label23);
            panel12.Controls.Add(label22);
            panel12.Controls.Add(label21);
            panel12.Controls.Add(HiredBy);
            panel12.Controls.Add(InterviewedBy);
            panel12.Controls.Add(ScreenedBy);
            panel12.Controls.Add(panel13);
            panel12.Location = new Point(1613, 203);
            panel12.Name = "panel12";
            panel12.Size = new Size(250, 508);
            panel12.TabIndex = 14;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(24, 304);
            label23.Name = "label23";
            label23.Size = new Size(69, 20);
            label23.TabIndex = 7;
            label23.Text = "Hired By:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(24, 213);
            label22.Name = "label22";
            label22.Size = new Size(109, 20);
            label22.TabIndex = 6;
            label22.Text = "Interviewed By:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(24, 131);
            label21.Name = "label21";
            label21.Size = new Size(93, 20);
            label21.TabIndex = 5;
            label21.Text = "Screened By:";
            // 
            // HiredBy
            // 
            HiredBy.BorderStyle = BorderStyle.FixedSingle;
            HiredBy.Location = new Point(25, 333);
            HiredBy.Name = "HiredBy";
            HiredBy.Size = new Size(199, 27);
            HiredBy.TabIndex = 4;
            // 
            // InterviewedBy
            // 
            InterviewedBy.BorderStyle = BorderStyle.FixedSingle;
            InterviewedBy.Location = new Point(26, 241);
            InterviewedBy.Name = "InterviewedBy";
            InterviewedBy.Size = new Size(199, 27);
            InterviewedBy.TabIndex = 3;
            // 
            // ScreenedBy
            // 
            ScreenedBy.BorderStyle = BorderStyle.FixedSingle;
            ScreenedBy.Location = new Point(25, 162);
            ScreenedBy.Name = "ScreenedBy";
            ScreenedBy.Size = new Size(199, 27);
            ScreenedBy.TabIndex = 2;
            // 
            // panel13
            // 
            panel13.BackColor = Color.RosyBrown;
            panel13.Controls.Add(label20);
            panel13.Location = new Point(0, 0);
            panel13.Name = "panel13";
            panel13.Size = new Size(250, 101);
            panel13.TabIndex = 1;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.ForeColor = Color.White;
            label20.Location = new Point(77, 33);
            label20.Name = "label20";
            label20.Size = new Size(100, 20);
            label20.TabIndex = 0;
            label20.Text = "ACTIVITY LOG";
            // 
            // ApplicantReview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel12);
            Controls.Add(panel11);
            Controls.Add(panel8);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "ApplicantReview";
            Text = "ApplicantReview";
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel11.ResumeLayout(false);
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox GenderSelection;
        private Label label6;
        private Label label7;
        private DateTimePicker BirthdateSelection;
        private Button BackButton;
        private Panel panel7;
        private Label label4;
        private Panel panel4;
        private RichTextBox ExperienceTextBox;
        private RichTextBox SkillTextBox;
        private Label label14;
        private Label label15;
        private Panel panel3;
        private TextBox YearLevelTextBox;
        private TextBox CourseTextBox;
        private TextBox SchoolTextBox;
        private Panel panel6;
        private Label label3;
        private Label label11;
        private Label label12;
        private Label label13;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private TextBox LNTextBox;
        private Label label17;
        private TextBox MNTextBox;
        private Label label16;
        private TextBox EmailTextBox;
        private TextBox ContactNumberTextBox;
        private TextBox AddressTextBox;
        private TextBox FNTextBox;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label5;
        private Panel panel5;
        private Label label2;
        private Panel panel8;
        private Panel panel10;
        private Label label19;
        private Panel panel11;
        private ListView Documents;
        private Panel panel9;
        private Label label18;
        private Panel panel12;
        private Label label23;
        private Label label22;
        private Label label21;
        private TextBox HiredBy;
        private TextBox InterviewedBy;
        private TextBox ScreenedBy;
        private Panel panel13;
        private Label label20;
        private Label ApplicantStatusLabel;
    }
}