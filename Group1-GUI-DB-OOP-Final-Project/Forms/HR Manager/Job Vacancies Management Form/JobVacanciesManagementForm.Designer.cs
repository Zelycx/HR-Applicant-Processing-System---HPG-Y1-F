namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR_Manager
{
    partial class JobVacanciesManagementForm
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
            btnBack = new Button();
            dgvVacancy = new DataGridView();
            colJobTitle = new DataGridViewTextBoxColumn();
            colDepartment = new DataGridViewTextBoxColumn();
            colQualifications = new DataGridViewTextBoxColumn();
            colDocuments = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            txtJobTitle = new TextBox();
            txtDepartment = new TextBox();
            txtQualifications = new TextBox();
            txtRequiredDocuments = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cmbStatus = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnClose = new Button();
            btnReopen = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVacancy).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(394, 256);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // dgvVacancy
            // 
            dgvVacancy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVacancy.Columns.AddRange(new DataGridViewColumn[] { colJobTitle, colDepartment, colQualifications, colDocuments, colStatus });
            dgvVacancy.Location = new Point(12, 353);
            dgvVacancy.Name = "dgvVacancy";
            dgvVacancy.Size = new Size(544, 85);
            dgvVacancy.TabIndex = 3;
            dgvVacancy.CellClick += dgvVacancy_CellClick;
            dgvVacancy.CellContentClick += dgvVacancy_CellContentClick;
            // 
            // colJobTitle
            // 
            colJobTitle.HeaderText = "Job Title";
            colJobTitle.Name = "colJobTitle";
            // 
            // colDepartment
            // 
            colDepartment.HeaderText = "Department";
            colDepartment.Name = "colDepartment";
            // 
            // colQualifications
            // 
            colQualifications.HeaderText = "Qualifications";
            colQualifications.Name = "colQualifications";
            // 
            // colDocuments
            // 
            colDocuments.HeaderText = "Required Documents";
            colDocuments.Name = "colDocuments";
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            // 
            // txtJobTitle
            // 
            txtJobTitle.Location = new Point(237, 60);
            txtJobTitle.Name = "txtJobTitle";
            txtJobTitle.Size = new Size(100, 23);
            txtJobTitle.TabIndex = 4;
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(237, 89);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(100, 23);
            txtDepartment.TabIndex = 4;
            // 
            // txtQualifications
            // 
            txtQualifications.Location = new Point(237, 118);
            txtQualifications.Multiline = true;
            txtQualifications.Name = "txtQualifications";
            txtQualifications.Size = new Size(100, 23);
            txtQualifications.TabIndex = 4;
            // 
            // txtRequiredDocuments
            // 
            txtRequiredDocuments.Location = new Point(237, 147);
            txtRequiredDocuments.Multiline = true;
            txtRequiredDocuments.Name = "txtRequiredDocuments";
            txtRequiredDocuments.Size = new Size(100, 23);
            txtRequiredDocuments.TabIndex = 4;
            txtRequiredDocuments.TextChanged += txtRequiredDocuments_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 65);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 5;
            label1.Text = "Job Title:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(104, 92);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 5;
            label2.Text = "Department:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(104, 179);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 5;
            label3.Text = "Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(104, 121);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 5;
            label4.Text = "Qualifications:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(104, 150);
            label5.Name = "label5";
            label5.Size = new Size(121, 15);
            label5.TabIndex = 5;
            label5.Text = "Required Documents:";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Active", "Closed" });
            cmbStatus.Location = new Point(237, 176);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(121, 23);
            cmbStatus.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(93, 287);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(64, 23);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add Vacancy";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(163, 287);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(244, 287);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close Vacancy";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnReopen
            // 
            btnReopen.Location = new Point(325, 287);
            btnReopen.Name = "btnReopen";
            btnReopen.Size = new Size(75, 23);
            btnReopen.TabIndex = 9;
            btnReopen.Text = "Reopen Vacancy";
            btnReopen.UseVisualStyleBackColor = true;
            btnReopen.Click += btnReopen_Click;
            // 
            // JobVacanciesManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReopen);
            Controls.Add(btnClose);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(cmbStatus);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtRequiredDocuments);
            Controls.Add(txtQualifications);
            Controls.Add(txtDepartment);
            Controls.Add(txtJobTitle);
            Controls.Add(dgvVacancy);
            Controls.Add(btnBack);
            Name = "JobVacanciesManagementForm";
            Text = "JobVacanciesManagementForm";
            ((System.ComponentModel.ISupportInitialize)dgvVacancy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private DataGridView dgvVacancy;
        private DataGridViewTextBoxColumn colJobTitle;
        private DataGridViewTextBoxColumn colDepartment;
        private DataGridViewTextBoxColumn colQualifications;
        private DataGridViewTextBoxColumn colDocuments;
        private DataGridViewTextBoxColumn colStatus;
        private TextBox txtJobTitle;
        private TextBox txtDepartment;
        private TextBox txtQualifications;
        private TextBox txtRequiredDocuments;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cmbStatus;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnClose;
        private Button btnReopen;
    }
}