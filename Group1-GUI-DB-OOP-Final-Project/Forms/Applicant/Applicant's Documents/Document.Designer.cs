namespace Group1_GUI_DB_OOP_Final_Project.Forms
{
    partial class Document
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
            MyDocumentsPanel = new Panel();
            MyDocumentsLabel = new Label();
            NavigationPanel = new Panel();
            ApplicationsStatusButton = new Button();
            MyDocumentsActiveButton = new Button();
            MyApplicationButton = new Button();
            JobVacanciesButton = new Button();
            MyProfileButton = new Button();
            DashboardButton = new Button();
            UploadRequiredDocumentsPanel = new Panel();
            DiplomaBrowseButton = new Button();
            TORBrowseButton = new Button();
            ValidIBrowseButton = new Button();
            DiplomaTextBox = new TextBox();
            DiplomaLabel = new Label();
            TORTextBox = new TextBox();
            TORLabel = new Label();
            ResumeBrowseButton = new Button();
            ValidIDTextBox = new TextBox();
            ValidIDLabel = new Label();
            ResumeTextBox = new TextBox();
            ResumeLabel = new Label();
            UploadDocumentsPanel = new Panel();
            UploadDocumentsLabel = new Label();
            UploadedDocumentsPanel = new Panel();
            BackButton = new Button();
            RefreshButton = new Button();
            RemoveButton = new Button();
            UploadButton = new Button();
            dataGridView1 = new DataGridView();
            DocumentIDColumn = new DataGridViewTextBoxColumn();
            DocumentTypeColumn = new DataGridViewTextBoxColumn();
            FileNameColumn = new DataGridViewTextBoxColumn();
            UploadDateColumn = new DataGridViewTextBoxColumn();
            StatusColumn = new DataGridViewTextBoxColumn();
            DocumentsHeaderPanel = new Panel();
            DocumentsTitleLabel = new Label();
            openFileDialog1 = new OpenFileDialog();
            MyDocumentsPanel.SuspendLayout();
            NavigationPanel.SuspendLayout();
            UploadRequiredDocumentsPanel.SuspendLayout();
            UploadDocumentsPanel.SuspendLayout();
            UploadedDocumentsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            DocumentsHeaderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MyDocumentsPanel
            // 
            MyDocumentsPanel.BackColor = Color.MidnightBlue;
            MyDocumentsPanel.Controls.Add(MyDocumentsLabel);
            MyDocumentsPanel.Location = new Point(2, 0);
            MyDocumentsPanel.Name = "MyDocumentsPanel";
            MyDocumentsPanel.Size = new Size(1365, 114);
            MyDocumentsPanel.TabIndex = 0;
            // 
            // MyDocumentsLabel
            // 
            MyDocumentsLabel.AutoSize = true;
            MyDocumentsLabel.Font = new Font("Century", 25.8000011F);
            MyDocumentsLabel.ForeColor = Color.White;
            MyDocumentsLabel.Location = new Point(29, 33);
            MyDocumentsLabel.Name = "MyDocumentsLabel";
            MyDocumentsLabel.Size = new Size(326, 41);
            MyDocumentsLabel.TabIndex = 0;
            MyDocumentsLabel.Text = "MY DOCUMENTS";
            // 
            // NavigationPanel
            // 
            NavigationPanel.BackColor = Color.Gainsboro;
            NavigationPanel.Controls.Add(ApplicationsStatusButton);
            NavigationPanel.Controls.Add(MyDocumentsActiveButton);
            NavigationPanel.Controls.Add(MyApplicationButton);
            NavigationPanel.Controls.Add(JobVacanciesButton);
            NavigationPanel.Controls.Add(MyProfileButton);
            NavigationPanel.Controls.Add(DashboardButton);
            NavigationPanel.Location = new Point(30, 136);
            NavigationPanel.Name = "NavigationPanel";
            NavigationPanel.Size = new Size(199, 590);
            NavigationPanel.TabIndex = 1;
            // 
            // ApplicationsStatusButton
            // 
            ApplicationsStatusButton.BackColor = Color.WhiteSmoke;
            ApplicationsStatusButton.FlatAppearance.BorderColor = Color.Black;
            ApplicationsStatusButton.FlatAppearance.BorderSize = 2;
            ApplicationsStatusButton.FlatStyle = FlatStyle.Flat;
            ApplicationsStatusButton.Font = new Font("Century", 10.2F);
            ApplicationsStatusButton.Location = new Point(16, 484);
            ApplicationsStatusButton.Name = "ApplicationsStatusButton";
            ApplicationsStatusButton.Size = new Size(168, 80);
            ApplicationsStatusButton.TabIndex = 5;
            ApplicationsStatusButton.Text = "Application Status";
            ApplicationsStatusButton.UseVisualStyleBackColor = false;
            // 
            // MyDocumentsActiveButton
            // 
            MyDocumentsActiveButton.BackColor = Color.LightSkyBlue;
            MyDocumentsActiveButton.FlatAppearance.BorderColor = Color.Black;
            MyDocumentsActiveButton.FlatAppearance.BorderSize = 2;
            MyDocumentsActiveButton.FlatStyle = FlatStyle.Flat;
            MyDocumentsActiveButton.Font = new Font("Century", 10.2F);
            MyDocumentsActiveButton.Location = new Point(16, 391);
            MyDocumentsActiveButton.Name = "MyDocumentsActiveButton";
            MyDocumentsActiveButton.RightToLeft = RightToLeft.No;
            MyDocumentsActiveButton.Size = new Size(168, 80);
            MyDocumentsActiveButton.TabIndex = 4;
            MyDocumentsActiveButton.Text = "My Documents";
            MyDocumentsActiveButton.UseVisualStyleBackColor = false;
            // 
            // MyApplicationButton
            // 
            MyApplicationButton.BackColor = Color.WhiteSmoke;
            MyApplicationButton.FlatAppearance.BorderColor = Color.Black;
            MyApplicationButton.FlatAppearance.BorderSize = 2;
            MyApplicationButton.FlatStyle = FlatStyle.Flat;
            MyApplicationButton.Font = new Font("Century", 10.2F);
            MyApplicationButton.Location = new Point(16, 297);
            MyApplicationButton.Name = "MyApplicationButton";
            MyApplicationButton.Size = new Size(168, 80);
            MyApplicationButton.TabIndex = 3;
            MyApplicationButton.Text = "My Application ";
            MyApplicationButton.UseVisualStyleBackColor = false;
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
            DashboardButton.Text = "DashBoard";
            DashboardButton.UseVisualStyleBackColor = false;
            // 
            // UploadRequiredDocumentsPanel
            // 
            UploadRequiredDocumentsPanel.BackColor = Color.LightGray;
            UploadRequiredDocumentsPanel.Controls.Add(DiplomaBrowseButton);
            UploadRequiredDocumentsPanel.Controls.Add(TORBrowseButton);
            UploadRequiredDocumentsPanel.Controls.Add(ValidIBrowseButton);
            UploadRequiredDocumentsPanel.Controls.Add(DiplomaTextBox);
            UploadRequiredDocumentsPanel.Controls.Add(DiplomaLabel);
            UploadRequiredDocumentsPanel.Controls.Add(TORTextBox);
            UploadRequiredDocumentsPanel.Controls.Add(TORLabel);
            UploadRequiredDocumentsPanel.Controls.Add(ResumeBrowseButton);
            UploadRequiredDocumentsPanel.Controls.Add(ValidIDTextBox);
            UploadRequiredDocumentsPanel.Controls.Add(ValidIDLabel);
            UploadRequiredDocumentsPanel.Controls.Add(ResumeTextBox);
            UploadRequiredDocumentsPanel.Controls.Add(ResumeLabel);
            UploadRequiredDocumentsPanel.Controls.Add(UploadDocumentsPanel);
            UploadRequiredDocumentsPanel.Location = new Point(250, 136);
            UploadRequiredDocumentsPanel.Name = "UploadRequiredDocumentsPanel";
            UploadRequiredDocumentsPanel.Size = new Size(287, 471);
            UploadRequiredDocumentsPanel.TabIndex = 3;
            // 
            // DiplomaBrowseButton
            // 
            DiplomaBrowseButton.BackColor = Color.DarkGray;
            DiplomaBrowseButton.FlatAppearance.BorderColor = Color.Black;
            DiplomaBrowseButton.FlatStyle = FlatStyle.Flat;
            DiplomaBrowseButton.Location = new Point(203, 311);
            DiplomaBrowseButton.Name = "DiplomaBrowseButton";
            DiplomaBrowseButton.Size = new Size(62, 23);
            DiplomaBrowseButton.TabIndex = 12;
            DiplomaBrowseButton.Text = "Browse";
            DiplomaBrowseButton.UseVisualStyleBackColor = false;
            // 
            // TORBrowseButton
            // 
            TORBrowseButton.BackColor = Color.DarkGray;
            TORBrowseButton.FlatAppearance.BorderColor = Color.Black;
            TORBrowseButton.FlatStyle = FlatStyle.Flat;
            TORBrowseButton.Location = new Point(203, 245);
            TORBrowseButton.Name = "TORBrowseButton";
            TORBrowseButton.Size = new Size(62, 23);
            TORBrowseButton.TabIndex = 11;
            TORBrowseButton.Text = "Browse";
            TORBrowseButton.UseVisualStyleBackColor = false;
            // 
            // ValidIBrowseButton
            // 
            ValidIBrowseButton.BackColor = Color.DarkGray;
            ValidIBrowseButton.FlatAppearance.BorderColor = Color.Black;
            ValidIBrowseButton.FlatStyle = FlatStyle.Flat;
            ValidIBrowseButton.Location = new Point(203, 172);
            ValidIBrowseButton.Name = "ValidIBrowseButton";
            ValidIBrowseButton.Size = new Size(62, 23);
            ValidIBrowseButton.TabIndex = 10;
            ValidIBrowseButton.Text = "Browse";
            ValidIBrowseButton.UseVisualStyleBackColor = false;
            // 
            // DiplomaTextBox
            // 
            DiplomaTextBox.Location = new Point(29, 312);
            DiplomaTextBox.Name = "DiplomaTextBox";
            DiplomaTextBox.Size = new Size(168, 23);
            DiplomaTextBox.TabIndex = 9;
            // 
            // DiplomaLabel
            // 
            DiplomaLabel.AutoSize = true;
            DiplomaLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            DiplomaLabel.Location = new Point(21, 294);
            DiplomaLabel.Name = "DiplomaLabel";
            DiplomaLabel.Size = new Size(53, 15);
            DiplomaLabel.TabIndex = 8;
            DiplomaLabel.Text = "Diploma";
            // 
            // TORTextBox
            // 
            TORTextBox.Location = new Point(29, 246);
            TORTextBox.Name = "TORTextBox";
            TORTextBox.Size = new Size(168, 23);
            TORTextBox.TabIndex = 7;
            // 
            // TORLabel
            // 
            TORLabel.AutoSize = true;
            TORLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            TORLabel.Location = new Point(21, 227);
            TORLabel.Name = "TORLabel";
            TORLabel.Size = new Size(155, 15);
            TORLabel.TabIndex = 6;
            TORLabel.Text = "Transcript of Record (TOR)";
            // 
            // ResumeBrowseButton
            // 
            ResumeBrowseButton.BackColor = Color.DarkGray;
            ResumeBrowseButton.FlatStyle = FlatStyle.Flat;
            ResumeBrowseButton.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ResumeBrowseButton.Location = new Point(203, 104);
            ResumeBrowseButton.Name = "ResumeBrowseButton";
            ResumeBrowseButton.Size = new Size(62, 23);
            ResumeBrowseButton.TabIndex = 5;
            ResumeBrowseButton.Text = "Browse";
            ResumeBrowseButton.UseVisualStyleBackColor = false;
            // 
            // ValidIDTextBox
            // 
            ValidIDTextBox.Location = new Point(29, 173);
            ValidIDTextBox.Name = "ValidIDTextBox";
            ValidIDTextBox.Size = new Size(168, 23);
            ValidIDTextBox.TabIndex = 4;
            // 
            // ValidIDLabel
            // 
            ValidIDLabel.AutoSize = true;
            ValidIDLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ValidIDLabel.Location = new Point(19, 153);
            ValidIDLabel.Name = "ValidIDLabel";
            ValidIDLabel.Size = new Size(49, 15);
            ValidIDLabel.TabIndex = 3;
            ValidIDLabel.Text = "Valid ID";
            // 
            // ResumeTextBox
            // 
            ResumeTextBox.Location = new Point(29, 104);
            ResumeTextBox.Name = "ResumeTextBox";
            ResumeTextBox.Size = new Size(168, 23);
            ResumeTextBox.TabIndex = 2;
            // 
            // ResumeLabel
            // 
            ResumeLabel.AutoSize = true;
            ResumeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ResumeLabel.Location = new Point(19, 84);
            ResumeLabel.Name = "ResumeLabel";
            ResumeLabel.Size = new Size(52, 15);
            ResumeLabel.TabIndex = 1;
            ResumeLabel.Text = "Resume";
            // 
            // UploadDocumentsPanel
            // 
            UploadDocumentsPanel.BackColor = Color.LightSlateGray;
            UploadDocumentsPanel.Controls.Add(UploadDocumentsLabel);
            UploadDocumentsPanel.Location = new Point(0, -1);
            UploadDocumentsPanel.Name = "UploadDocumentsPanel";
            UploadDocumentsPanel.Size = new Size(287, 62);
            UploadDocumentsPanel.TabIndex = 0;
            // 
            // UploadDocumentsLabel
            // 
            UploadDocumentsLabel.AutoSize = true;
            UploadDocumentsLabel.Font = new Font("Century", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UploadDocumentsLabel.ForeColor = SystemColors.Window;
            UploadDocumentsLabel.Location = new Point(39, 12);
            UploadDocumentsLabel.Name = "UploadDocumentsLabel";
            UploadDocumentsLabel.Size = new Size(205, 42);
            UploadDocumentsLabel.TabIndex = 0;
            UploadDocumentsLabel.Text = "UPLOAD REQUIRED \r\n      DOCUMENTS";
            // 
            // UploadedDocumentsPanel
            // 
            UploadedDocumentsPanel.BackColor = Color.LightGray;
            UploadedDocumentsPanel.Controls.Add(BackButton);
            UploadedDocumentsPanel.Controls.Add(RefreshButton);
            UploadedDocumentsPanel.Controls.Add(RemoveButton);
            UploadedDocumentsPanel.Controls.Add(UploadButton);
            UploadedDocumentsPanel.Controls.Add(dataGridView1);
            UploadedDocumentsPanel.Controls.Add(DocumentsHeaderPanel);
            UploadedDocumentsPanel.Location = new Point(534, 135);
            UploadedDocumentsPanel.Name = "UploadedDocumentsPanel";
            UploadedDocumentsPanel.Size = new Size(629, 472);
            UploadedDocumentsPanel.TabIndex = 4;
            // 
            // BackButton
            // 
            BackButton.BackColor = Color.WhiteSmoke;
            BackButton.FlatAppearance.BorderColor = Color.Black;
            BackButton.FlatAppearance.BorderSize = 2;
            BackButton.FlatStyle = FlatStyle.Flat;
            BackButton.Font = new Font("Century", 10F);
            BackButton.Location = new Point(423, 422);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(92, 41);
            BackButton.TabIndex = 5;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = false;
            // 
            // RefreshButton
            // 
            RefreshButton.BackColor = Color.WhiteSmoke;
            RefreshButton.FlatAppearance.BorderColor = Color.Black;
            RefreshButton.FlatAppearance.BorderSize = 2;
            RefreshButton.FlatStyle = FlatStyle.Flat;
            RefreshButton.Font = new Font("Century", 10F);
            RefreshButton.Location = new Point(315, 422);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(92, 41);
            RefreshButton.TabIndex = 4;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = false;
            // 
            // RemoveButton
            // 
            RemoveButton.BackColor = Color.WhiteSmoke;
            RemoveButton.FlatAppearance.BorderColor = Color.Black;
            RemoveButton.FlatAppearance.BorderSize = 2;
            RemoveButton.FlatStyle = FlatStyle.Flat;
            RemoveButton.Font = new Font("Century", 10F);
            RemoveButton.Location = new Point(205, 422);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(92, 41);
            RemoveButton.TabIndex = 3;
            RemoveButton.Text = "Remove";
            RemoveButton.UseVisualStyleBackColor = false;
            // 
            // UploadButton
            // 
            UploadButton.BackColor = Color.WhiteSmoke;
            UploadButton.FlatAppearance.BorderSize = 2;
            UploadButton.FlatStyle = FlatStyle.Flat;
            UploadButton.Font = new Font("Century", 10F);
            UploadButton.Location = new Point(95, 422);
            UploadButton.Name = "UploadButton";
            UploadButton.Size = new Size(92, 41);
            UploadButton.TabIndex = 2;
            UploadButton.Text = "Upload";
            UploadButton.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.DarkGray;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { DocumentIDColumn, DocumentTypeColumn, FileNameColumn, UploadDateColumn, StatusColumn });
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(28, 83);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(576, 322);
            dataGridView1.TabIndex = 1;
            // 
            // DocumentIDColumn
            // 
            DocumentIDColumn.HeaderText = "ID";
            DocumentIDColumn.Name = "DocumentIDColumn";
            DocumentIDColumn.ReadOnly = true;
            DocumentIDColumn.Visible = false;
            // 
            // DocumentTypeColumn
            // 
            DocumentTypeColumn.HeaderText = "Document Type";
            DocumentTypeColumn.Name = "DocumentTypeColumn";
            DocumentTypeColumn.ReadOnly = true;
            // 
            // FileNameColumn
            // 
            FileNameColumn.HeaderText = "File Name";
            FileNameColumn.Name = "FileNameColumn";
            FileNameColumn.ReadOnly = true;
            // 
            // UploadDateColumn
            // 
            UploadDateColumn.HeaderText = "Date Uploaded";
            UploadDateColumn.Name = "UploadDateColumn";
            UploadDateColumn.ReadOnly = true;
            // 
            // StatusColumn
            // 
            StatusColumn.HeaderText = "Status";
            StatusColumn.Name = "StatusColumn";
            StatusColumn.ReadOnly = true;
            // 
            // DocumentsHeaderPanel
            // 
            DocumentsHeaderPanel.BackColor = Color.LightSlateGray;
            DocumentsHeaderPanel.Controls.Add(DocumentsTitleLabel);
            DocumentsHeaderPanel.Location = new Point(1, 1);
            DocumentsHeaderPanel.Name = "DocumentsHeaderPanel";
            DocumentsHeaderPanel.Size = new Size(628, 61);
            DocumentsHeaderPanel.TabIndex = 0;
            // 
            // DocumentsTitleLabel
            // 
            DocumentsTitleLabel.AutoSize = true;
            DocumentsTitleLabel.Font = new Font("Century", 12.75F, FontStyle.Bold);
            DocumentsTitleLabel.ForeColor = Color.White;
            DocumentsTitleLabel.Location = new Point(204, 25);
            DocumentsTitleLabel.Name = "DocumentsTitleLabel";
            DocumentsTitleLabel.Size = new Size(235, 21);
            DocumentsTitleLabel.TabIndex = 0;
            DocumentsTitleLabel.Text = "UPLODED DOCUMENTS";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "PDF Files|*.pdf|\nImage Files|*.jpg;*.jpeg;*.png|\nWord Files|*.doc;*.docx|\nAll Files|*.*";
            // 
            // Document
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1370, 749);
            Controls.Add(UploadedDocumentsPanel);
            Controls.Add(UploadRequiredDocumentsPanel);
            Controls.Add(NavigationPanel);
            Controls.Add(MyDocumentsPanel);
            Name = "Document";
            Text = "Document";
            MyDocumentsPanel.ResumeLayout(false);
            MyDocumentsPanel.PerformLayout();
            NavigationPanel.ResumeLayout(false);
            UploadRequiredDocumentsPanel.ResumeLayout(false);
            UploadRequiredDocumentsPanel.PerformLayout();
            UploadDocumentsPanel.ResumeLayout(false);
            UploadDocumentsPanel.PerformLayout();
            UploadedDocumentsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            DocumentsHeaderPanel.ResumeLayout(false);
            DocumentsHeaderPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel MyDocumentsPanel;
        private Label MyDocumentsLabel;
        private Panel NavigationPanel;
        private Button DashboardButton;
        private Button MyProfileButton;
        private Button ApplicationsStatusButton;
        private Button MyDocumentsActiveButton;
        private Button MyApplicationButton;
        private Button JobVacanciesButton;
        private Panel UploadRequiredDocumentsPanel;
        private Panel UploadDocumentsPanel;
        private Label UploadDocumentsLabel;
        private Panel UploadedDocumentsPanel;
        private Panel DocumentsHeaderPanel;
        private TextBox ResumeTextBox;
        private Label ResumeLabel;
        private Button ResumeBrowseButton;
        private TextBox ValidIDTextBox;
        private Label ValidIDLabel;
        private Button DiplomaBrowseButton;
        private Button TORBrowseButton;
        private Button ValidIBrowseButton;
        private TextBox DiplomaTextBox;
        private Label DiplomaLabel;
        private TextBox TORTextBox;
        private Label TORLabel;
        private DataGridView dataGridView1;
        private Label DocumentsTitleLabel;
        private OpenFileDialog openFileDialog1;
        private Button BackButton;
        private Button RefreshButton;
        private Button RemoveButton;
        private Button UploadButton;
        private DataGridViewTextBoxColumn DocumentIDColumn;
        private DataGridViewTextBoxColumn DocumentTypeColumn;
        private DataGridViewTextBoxColumn FileNameColumn;
        private DataGridViewTextBoxColumn UploadDateColumn;
        private DataGridViewTextBoxColumn StatusColumn;
    }
}