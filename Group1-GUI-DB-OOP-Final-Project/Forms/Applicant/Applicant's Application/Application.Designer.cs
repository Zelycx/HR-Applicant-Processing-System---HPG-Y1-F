namespace Group1_GUI_DB_OOP_Final_Project.Forms.Applicant
{
    partial class Application
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
            MyApplicationPanel = new Panel();
            MyApplicationLabel = new Label();
            NavigationPanel = new Panel();
            ApplicationStatusButton = new Button();
            MyDocumentsButton = new Button();
            MyApplicationActiveButton = new Button();
            JobVacanciesButton = new Button();
            MyProfileButton = new Button();
            DashboardButton = new Button();
            SelectedJobPanel = new Panel();
            StatusTextBox = new TextBox();
            JobTypeTextBox = new TextBox();
            JobTitleTextBox = new TextBox();
            DepartmentTextBox = new TextBox();
            SelectedJobHeader = new Panel();
            label2 = new Label();
            StatusLabel = new Label();
            JobTypeLabel = new Label();
            DepartmentLabel = new Label();
            JobTitleLabel = new Label();
            ApplicationActionPanel = new Panel();
            EditApplicationButton = new Button();
            SubmitApplicationButton = new Button();
            SaveDraftButton = new Button();
            StartDraftButton = new Button();
            ApplicationActionHeader = new Panel();
            label7 = new Label();
            ApplicationDataPanel = new Panel();
            AvailabaleStartDateLabel = new Label();
            ExpectedSalaryLabel = new Label();
            PrefferedInterviewTypeLabel = new Label();
            StartDatedateTimePicker = new DateTimePicker();
            ExpectedSalaryTextBox = new TextBox();
            PrefferedInterviewTypeComboBox = new ComboBox();
            CoverLetterLabel = new Label();
            CoverLetterTextBox = new TextBox();
            ApplicationDataHeader = new Panel();
            label8 = new Label();
            MyApplicationPanel.SuspendLayout();
            NavigationPanel.SuspendLayout();
            SelectedJobPanel.SuspendLayout();
            SelectedJobHeader.SuspendLayout();
            ApplicationActionPanel.SuspendLayout();
            ApplicationActionHeader.SuspendLayout();
            ApplicationDataPanel.SuspendLayout();
            ApplicationDataHeader.SuspendLayout();
            SuspendLayout();
            // 
            // MyApplicationPanel
            // 
            MyApplicationPanel.BackColor = Color.MidnightBlue;
            MyApplicationPanel.Controls.Add(MyApplicationLabel);
            MyApplicationPanel.Location = new Point(2, 1);
            MyApplicationPanel.Name = "MyApplicationPanel";
            MyApplicationPanel.Size = new Size(1365, 114);
            MyApplicationPanel.TabIndex = 0;
            // 
            // MyApplicationLabel
            // 
            MyApplicationLabel.AutoSize = true;
            MyApplicationLabel.Font = new Font("Century", 25.8000011F);
            MyApplicationLabel.ForeColor = Color.White;
            MyApplicationLabel.Location = new Point(37, 32);
            MyApplicationLabel.Name = "MyApplicationLabel";
            MyApplicationLabel.Size = new Size(337, 41);
            MyApplicationLabel.TabIndex = 0;
            MyApplicationLabel.Text = "MY APPLICATION";
            // 
            // NavigationPanel
            // 
            NavigationPanel.BackColor = Color.Gainsboro;
            NavigationPanel.Controls.Add(ApplicationStatusButton);
            NavigationPanel.Controls.Add(MyDocumentsButton);
            NavigationPanel.Controls.Add(MyApplicationActiveButton);
            NavigationPanel.Controls.Add(JobVacanciesButton);
            NavigationPanel.Controls.Add(MyProfileButton);
            NavigationPanel.Controls.Add(DashboardButton);
            NavigationPanel.Location = new Point(96, 136);
            NavigationPanel.Name = "NavigationPanel";
            NavigationPanel.Size = new Size(199, 590);
            NavigationPanel.TabIndex = 1;
            // 
            // ApplicationStatusButton
            // 
            ApplicationStatusButton.BackColor = Color.WhiteSmoke;
            ApplicationStatusButton.FlatAppearance.BorderColor = Color.Black;
            ApplicationStatusButton.FlatAppearance.BorderSize = 2;
            ApplicationStatusButton.FlatStyle = FlatStyle.Flat;
            ApplicationStatusButton.Font = new Font("Century", 10.2F);
            ApplicationStatusButton.Location = new Point(16, 484);
            ApplicationStatusButton.Name = "ApplicationStatusButton";
            ApplicationStatusButton.Size = new Size(168, 80);
            ApplicationStatusButton.TabIndex = 5;
            ApplicationStatusButton.Text = "Application Status";
            ApplicationStatusButton.UseVisualStyleBackColor = false;
            // 
            // MyDocumentsButton
            // 
            MyDocumentsButton.BackColor = Color.WhiteSmoke;
            MyDocumentsButton.FlatAppearance.BorderColor = Color.Black;
            MyDocumentsButton.FlatAppearance.BorderSize = 2;
            MyDocumentsButton.FlatStyle = FlatStyle.Flat;
            MyDocumentsButton.Font = new Font("Century", 10.2F);
            MyDocumentsButton.Location = new Point(16, 391);
            MyDocumentsButton.Name = "MyDocumentsButton";
            MyDocumentsButton.Size = new Size(168, 80);
            MyDocumentsButton.TabIndex = 4;
            MyDocumentsButton.Text = "My Documents";
            MyDocumentsButton.UseVisualStyleBackColor = false;
            MyDocumentsButton.Click += MyDocumentsButton_Click;
            // 
            // MyApplicationActiveButton
            // 
            MyApplicationActiveButton.BackColor = Color.WhiteSmoke;
            MyApplicationActiveButton.FlatAppearance.BorderColor = Color.Black;
            MyApplicationActiveButton.FlatAppearance.BorderSize = 2;
            MyApplicationActiveButton.FlatStyle = FlatStyle.Flat;
            MyApplicationActiveButton.Font = new Font("Century", 10.2F);
            MyApplicationActiveButton.Location = new Point(16, 297);
            MyApplicationActiveButton.Name = "MyApplicationActiveButton";
            MyApplicationActiveButton.Size = new Size(168, 80);
            MyApplicationActiveButton.TabIndex = 3;
            MyApplicationActiveButton.Text = "My Application \r\n(ACTIVE)";
            MyApplicationActiveButton.UseVisualStyleBackColor = false;
            // 
            // JobVacanciesButton
            // 
            JobVacanciesButton.BackColor = Color.WhiteSmoke;
            JobVacanciesButton.FlatAppearance.BorderColor = Color.Black;
            JobVacanciesButton.FlatAppearance.BorderSize = 2;
            JobVacanciesButton.FlatStyle = FlatStyle.Flat;
            JobVacanciesButton.Font = new Font("Century", 10.2F);
            JobVacanciesButton.Location = new Point(16, 205);
            JobVacanciesButton.Name = "JobVacanciesButton";
            JobVacanciesButton.Size = new Size(168, 80);
            JobVacanciesButton.TabIndex = 2;
            JobVacanciesButton.Text = "Job Vacancies";
            JobVacanciesButton.UseVisualStyleBackColor = false;
            JobVacanciesButton.Click += JobVacanciesButton_Click;
            // 
            // MyProfileButton
            // 
            MyProfileButton.BackColor = Color.WhiteSmoke;
            MyProfileButton.FlatAppearance.BorderColor = Color.Black;
            MyProfileButton.FlatAppearance.BorderSize = 2;
            MyProfileButton.FlatStyle = FlatStyle.Flat;
            MyProfileButton.Font = new Font("Century", 10.2F);
            MyProfileButton.Location = new Point(16, 115);
            MyProfileButton.Name = "MyProfileButton";
            MyProfileButton.Size = new Size(168, 80);
            MyProfileButton.TabIndex = 1;
            MyProfileButton.Text = "My Profile";
            MyProfileButton.UseVisualStyleBackColor = false;
            MyProfileButton.Click += MyProfileButtom_Click;
            // 
            // DashboardButton
            // 
            DashboardButton.BackColor = Color.WhiteSmoke;
            DashboardButton.FlatAppearance.BorderColor = Color.Black;
            DashboardButton.FlatAppearance.BorderSize = 2;
            DashboardButton.FlatStyle = FlatStyle.Flat;
            DashboardButton.Font = new Font("Century", 10.2F);
            DashboardButton.Location = new Point(15, 25);
            DashboardButton.Name = "DashboardButton";
            DashboardButton.Size = new Size(168, 80);
            DashboardButton.TabIndex = 0;
            DashboardButton.Text = "Dashboard";
            DashboardButton.UseVisualStyleBackColor = false;
            DashboardButton.Click += DashboardButton_Click;
            // 
            // SelectedJobPanel
            // 
            SelectedJobPanel.BackColor = Color.Gainsboro;
            SelectedJobPanel.Controls.Add(StatusTextBox);
            SelectedJobPanel.Controls.Add(JobTypeTextBox);
            SelectedJobPanel.Controls.Add(JobTitleTextBox);
            SelectedJobPanel.Controls.Add(DepartmentTextBox);
            SelectedJobPanel.Controls.Add(SelectedJobHeader);
            SelectedJobPanel.Controls.Add(StatusLabel);
            SelectedJobPanel.Controls.Add(JobTypeLabel);
            SelectedJobPanel.Controls.Add(DepartmentLabel);
            SelectedJobPanel.Controls.Add(JobTitleLabel);
            SelectedJobPanel.Location = new Point(322, 136);
            SelectedJobPanel.Name = "SelectedJobPanel";
            SelectedJobPanel.Size = new Size(516, 175);
            SelectedJobPanel.TabIndex = 2;
            // 
            // StatusTextBox
            // 
            StatusTextBox.Location = new Point(111, 134);
            StatusTextBox.Name = "StatusTextBox";
            StatusTextBox.Size = new Size(326, 23);
            StatusTextBox.TabIndex = 13;
            // 
            // JobTypeTextBox
            // 
            JobTypeTextBox.Location = new Point(111, 102);
            JobTypeTextBox.Name = "JobTypeTextBox";
            JobTypeTextBox.Size = new Size(326, 23);
            JobTypeTextBox.TabIndex = 12;
            // 
            // JobTitleTextBox
            // 
            JobTitleTextBox.Location = new Point(111, 44);
            JobTitleTextBox.Name = "JobTitleTextBox";
            JobTitleTextBox.Size = new Size(326, 23);
            JobTitleTextBox.TabIndex = 11;
            // 
            // DepartmentTextBox
            // 
            DepartmentTextBox.Location = new Point(111, 72);
            DepartmentTextBox.Name = "DepartmentTextBox";
            DepartmentTextBox.Size = new Size(326, 23);
            DepartmentTextBox.TabIndex = 10;
            // 
            // SelectedJobHeader
            // 
            SelectedJobHeader.BackColor = Color.SlateGray;
            SelectedJobHeader.Controls.Add(label2);
            SelectedJobHeader.Location = new Point(1, 1);
            SelectedJobHeader.Name = "SelectedJobHeader";
            SelectedJobHeader.Size = new Size(515, 32);
            SelectedJobHeader.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 15F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(10, 5);
            label2.Name = "label2";
            label2.Size = new Size(168, 23);
            label2.TabIndex = 0;
            label2.Text = "SELECTED JOB";
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(35, 138);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(42, 15);
            StatusLabel.TabIndex = 8;
            StatusLabel.Text = "Status:";
            // 
            // JobTypeLabel
            // 
            JobTypeLabel.AutoSize = true;
            JobTypeLabel.Location = new Point(34, 108);
            JobTypeLabel.Name = "JobTypeLabel";
            JobTypeLabel.Size = new Size(55, 15);
            JobTypeLabel.TabIndex = 7;
            JobTypeLabel.Text = "Job Type:";
            // 
            // DepartmentLabel
            // 
            DepartmentLabel.AutoSize = true;
            DepartmentLabel.Location = new Point(34, 76);
            DepartmentLabel.Name = "DepartmentLabel";
            DepartmentLabel.Size = new Size(73, 15);
            DepartmentLabel.TabIndex = 6;
            DepartmentLabel.Text = "Department:";
            // 
            // JobTitleLabel
            // 
            JobTitleLabel.AutoSize = true;
            JobTitleLabel.Font = new Font("Segoe UI", 9F);
            JobTitleLabel.Location = new Point(33, 47);
            JobTitleLabel.Name = "JobTitleLabel";
            JobTitleLabel.Size = new Size(53, 15);
            JobTitleLabel.TabIndex = 1;
            JobTitleLabel.Text = "Job Title:";
            // 
            // ApplicationActionPanel
            // 
            ApplicationActionPanel.BackColor = Color.Gainsboro;
            ApplicationActionPanel.Controls.Add(EditApplicationButton);
            ApplicationActionPanel.Controls.Add(SubmitApplicationButton);
            ApplicationActionPanel.Controls.Add(SaveDraftButton);
            ApplicationActionPanel.Controls.Add(StartDraftButton);
            ApplicationActionPanel.Controls.Add(ApplicationActionHeader);
            ApplicationActionPanel.Location = new Point(322, 311);
            ApplicationActionPanel.Name = "ApplicationActionPanel";
            ApplicationActionPanel.Size = new Size(516, 234);
            ApplicationActionPanel.TabIndex = 3;
            // 
            // EditApplicationButton
            // 
            EditApplicationButton.BackColor = Color.WhiteSmoke;
            EditApplicationButton.FlatAppearance.BorderColor = Color.Black;
            EditApplicationButton.FlatAppearance.BorderSize = 2;
            EditApplicationButton.FlatStyle = FlatStyle.Flat;
            EditApplicationButton.Font = new Font("Century", 10.2F);
            EditApplicationButton.Location = new Point(283, 151);
            EditApplicationButton.Name = "EditApplicationButton";
            EditApplicationButton.Size = new Size(200, 60);
            EditApplicationButton.TabIndex = 4;
            EditApplicationButton.Text = "Edit Application";
            EditApplicationButton.UseVisualStyleBackColor = false;
            EditApplicationButton.Click += EditApplicationButton_Click;
            // 
            // SubmitApplicationButton
            // 
            SubmitApplicationButton.BackColor = Color.LightGreen;
            SubmitApplicationButton.FlatAppearance.BorderColor = Color.Black;
            SubmitApplicationButton.FlatAppearance.BorderSize = 2;
            SubmitApplicationButton.FlatStyle = FlatStyle.Flat;
            SubmitApplicationButton.Font = new Font("Century", 10.2F, FontStyle.Bold);
            SubmitApplicationButton.ForeColor = Color.DarkGreen;
            SubmitApplicationButton.Location = new Point(34, 152);
            SubmitApplicationButton.Name = "SubmitApplicationButton";
            SubmitApplicationButton.Size = new Size(200, 60);
            SubmitApplicationButton.TabIndex = 3;
            SubmitApplicationButton.Text = "Submit Application";
            SubmitApplicationButton.UseVisualStyleBackColor = false;
            // 
            // SaveDraftButton
            // 
            SaveDraftButton.BackColor = Color.WhiteSmoke;
            SaveDraftButton.FlatAppearance.BorderColor = Color.Black;
            SaveDraftButton.FlatAppearance.BorderSize = 2;
            SaveDraftButton.FlatStyle = FlatStyle.Flat;
            SaveDraftButton.Font = new Font("Century", 10.2F);
            SaveDraftButton.Location = new Point(282, 61);
            SaveDraftButton.Name = "SaveDraftButton";
            SaveDraftButton.Size = new Size(200, 60);
            SaveDraftButton.TabIndex = 2;
            SaveDraftButton.Text = "Save Draft";
            SaveDraftButton.UseVisualStyleBackColor = false;
            SaveDraftButton.Click += SaveDraftButton_Click;
            // 
            // StartDraftButton
            // 
            StartDraftButton.BackColor = Color.WhiteSmoke;
            StartDraftButton.FlatAppearance.BorderColor = Color.Black;
            StartDraftButton.FlatAppearance.BorderSize = 2;
            StartDraftButton.FlatStyle = FlatStyle.Flat;
            StartDraftButton.Font = new Font("Century", 10.2F);
            StartDraftButton.Location = new Point(35, 61);
            StartDraftButton.Name = "StartDraftButton";
            StartDraftButton.Size = new Size(200, 60);
            StartDraftButton.TabIndex = 1;
            StartDraftButton.Text = "Start Draft";
            StartDraftButton.UseVisualStyleBackColor = false;
            StartDraftButton.Click += StartDraftButton_Click;
            // 
            // ApplicationActionHeader
            // 
            ApplicationActionHeader.BackColor = Color.SlateGray;
            ApplicationActionHeader.Controls.Add(label7);
            ApplicationActionHeader.Location = new Point(0, 1);
            ApplicationActionHeader.Name = "ApplicationActionHeader";
            ApplicationActionHeader.Size = new Size(515, 32);
            ApplicationActionHeader.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century", 15F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(3, 4);
            label7.Name = "label7";
            label7.Size = new Size(239, 23);
            label7.TabIndex = 0;
            label7.Text = "APPLICATION ACTION";
            // 
            // ApplicationDataPanel
            // 
            ApplicationDataPanel.BackColor = Color.Gainsboro;
            ApplicationDataPanel.Controls.Add(AvailabaleStartDateLabel);
            ApplicationDataPanel.Controls.Add(ExpectedSalaryLabel);
            ApplicationDataPanel.Controls.Add(PrefferedInterviewTypeLabel);
            ApplicationDataPanel.Controls.Add(StartDatedateTimePicker);
            ApplicationDataPanel.Controls.Add(ExpectedSalaryTextBox);
            ApplicationDataPanel.Controls.Add(PrefferedInterviewTypeComboBox);
            ApplicationDataPanel.Controls.Add(CoverLetterLabel);
            ApplicationDataPanel.Controls.Add(CoverLetterTextBox);
            ApplicationDataPanel.Controls.Add(ApplicationDataHeader);
            ApplicationDataPanel.Location = new Point(322, 545);
            ApplicationDataPanel.Name = "ApplicationDataPanel";
            ApplicationDataPanel.Size = new Size(516, 181);
            ApplicationDataPanel.TabIndex = 4;
            // 
            // AvailabaleStartDateLabel
            // 
            AvailabaleStartDateLabel.AutoSize = true;
            AvailabaleStartDateLabel.Location = new Point(12, 150);
            AvailabaleStartDateLabel.Name = "AvailabaleStartDateLabel";
            AvailabaleStartDateLabel.Size = new Size(109, 15);
            AvailabaleStartDateLabel.TabIndex = 10;
            AvailabaleStartDateLabel.Text = "Available Start Date";
            // 
            // ExpectedSalaryLabel
            // 
            ExpectedSalaryLabel.AutoSize = true;
            ExpectedSalaryLabel.Location = new Point(12, 117);
            ExpectedSalaryLabel.Name = "ExpectedSalaryLabel";
            ExpectedSalaryLabel.Size = new Size(92, 15);
            ExpectedSalaryLabel.TabIndex = 9;
            ExpectedSalaryLabel.Text = "Expected Salary:";
            // 
            // PrefferedInterviewTypeLabel
            // 
            PrefferedInterviewTypeLabel.AutoSize = true;
            PrefferedInterviewTypeLabel.Location = new Point(12, 82);
            PrefferedInterviewTypeLabel.Name = "PrefferedInterviewTypeLabel";
            PrefferedInterviewTypeLabel.Size = new Size(136, 15);
            PrefferedInterviewTypeLabel.TabIndex = 8;
            PrefferedInterviewTypeLabel.Text = "Preferred Interview Type:";
            // 
            // StartDatedateTimePicker
            // 
            StartDatedateTimePicker.Location = new Point(155, 146);
            StartDatedateTimePicker.Name = "StartDatedateTimePicker";
            StartDatedateTimePicker.Size = new Size(333, 23);
            StartDatedateTimePicker.TabIndex = 7;
            // 
            // ExpectedSalaryTextBox
            // 
            ExpectedSalaryTextBox.Location = new Point(155, 111);
            ExpectedSalaryTextBox.Name = "ExpectedSalaryTextBox";
            ExpectedSalaryTextBox.Size = new Size(333, 23);
            ExpectedSalaryTextBox.TabIndex = 6;
            ExpectedSalaryTextBox.KeyPress += ExpectedSalaryTextBox_KeyPress;
            // 
            // PrefferedInterviewTypeComboBox
            // 
            PrefferedInterviewTypeComboBox.FormattingEnabled = true;
            PrefferedInterviewTypeComboBox.Location = new Point(155, 78);
            PrefferedInterviewTypeComboBox.Name = "PrefferedInterviewTypeComboBox";
            PrefferedInterviewTypeComboBox.Size = new Size(333, 23);
            PrefferedInterviewTypeComboBox.TabIndex = 5;
            // 
            // CoverLetterLabel
            // 
            CoverLetterLabel.AutoSize = true;
            CoverLetterLabel.Location = new Point(12, 50);
            CoverLetterLabel.Name = "CoverLetterLabel";
            CoverLetterLabel.Size = new Size(74, 15);
            CoverLetterLabel.TabIndex = 2;
            CoverLetterLabel.Text = "Cover Letter:";
            // 
            // CoverLetterTextBox
            // 
            CoverLetterTextBox.Location = new Point(155, 45);
            CoverLetterTextBox.Name = "CoverLetterTextBox";
            CoverLetterTextBox.Size = new Size(333, 23);
            CoverLetterTextBox.TabIndex = 1;
            CoverLetterTextBox.TextChanged += CoverLetterTextBox_TextChanged;
            // 
            // ApplicationDataHeader
            // 
            ApplicationDataHeader.BackColor = Color.SlateGray;
            ApplicationDataHeader.Controls.Add(label8);
            ApplicationDataHeader.Location = new Point(0, 0);
            ApplicationDataHeader.Name = "ApplicationDataHeader";
            ApplicationDataHeader.Size = new Size(515, 32);
            ApplicationDataHeader.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century", 15F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(0, 5);
            label8.Name = "label8";
            label8.Size = new Size(215, 23);
            label8.TabIndex = 0;
            label8.Text = "APPLICATION DATA";
            // 
            // Application
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(ApplicationDataPanel);
            Controls.Add(ApplicationActionPanel);
            Controls.Add(SelectedJobPanel);
            Controls.Add(NavigationPanel);
            Controls.Add(MyApplicationPanel);
            Name = "Application";
            Text = "Application";
            MyApplicationPanel.ResumeLayout(false);
            MyApplicationPanel.PerformLayout();
            NavigationPanel.ResumeLayout(false);
            SelectedJobPanel.ResumeLayout(false);
            SelectedJobPanel.PerformLayout();
            SelectedJobHeader.ResumeLayout(false);
            SelectedJobHeader.PerformLayout();
            ApplicationActionPanel.ResumeLayout(false);
            ApplicationActionHeader.ResumeLayout(false);
            ApplicationActionHeader.PerformLayout();
            ApplicationDataPanel.ResumeLayout(false);
            ApplicationDataPanel.PerformLayout();
            ApplicationDataHeader.ResumeLayout(false);
            ApplicationDataHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel MyApplicationPanel;
        private Label MyApplicationLabel;
        private Panel NavigationPanel;
        private Button DashboardButton;
        private Button MyProfileButton;
        private Button MyDocumentsButton;
        private Button MyApplicationActiveButton;
        private Button JobVacanciesButton;
        private Button ApplicationStatusButton;
        private Panel SelectedJobPanel;
        private Label JobTitleLabel;
        private Label DepartmentLabel;
        private Panel SelectedJobHeader;
        private Label StatusLabel;
        private Label JobTypeLabel;
        private Panel ApplicationActionPanel;
        private Panel ApplicationDataPanel;
        private Label label2;
        private Panel ApplicationActionHeader;
        private Button StartDraftButton;
        private Label label7;
        private Button SubmitApplicationButton;
        private Button SaveDraftButton;
        private Button EditApplicationButton;
        private Panel ApplicationDataHeader;
        private Label label8;
        private TextBox StatusTextBox;
        private TextBox JobTypeTextBox;
        private TextBox JobTitleTextBox;
        private TextBox DepartmentTextBox;
        private TextBox CoverLetterTextBox;
        private ComboBox PrefferedInterviewTypeComboBox;
        private Label CoverLetterLabel;
        private TextBox ExpectedSalaryTextBox;
        private DateTimePicker StartDatedateTimePicker;
        private Label PrefferedInterviewTypeLabel;
        private Label AvailabaleStartDateLabel;
        private Label ExpectedSalaryLabel;
    }
}