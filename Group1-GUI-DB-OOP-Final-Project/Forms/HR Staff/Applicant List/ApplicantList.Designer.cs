namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR
{
    partial class ApplicantList
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
            dgvApplicants = new DataGridView();
            colApplicantID = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colPosition = new DataGridViewTextBoxColumn();
            colDepartment = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            txtSearch = new TextBox();
            btnSearch = new Button();
            label1 = new Label();
            btnReset = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            TextBox3 = new TextBox();
            txtStatus = new TextBox();
            txtFullName = new TextBox();
            txtPosition = new TextBox();
            txtDepartment = new TextBox();
            textBox8 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvApplicants).BeginInit();
            SuspendLayout();
            // 
            // dgvApplicants
            // 
            dgvApplicants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplicants.Columns.AddRange(new DataGridViewColumn[] { colApplicantID, colFullName, colPosition, colDepartment, colStatus });
            dgvApplicants.Location = new Point(12, 75);
            dgvApplicants.Name = "dgvApplicants";
            dgvApplicants.Size = new Size(776, 153);
            dgvApplicants.TabIndex = 0;
            dgvApplicants.CellClick += dgvApplicants_CellClick;
            dgvApplicants.CellContentClick += dgvApplicants_CellContentClick;
            // 
            // colApplicantID
            // 
            colApplicantID.HeaderText = "Applicant ID";
            colApplicantID.Name = "colApplicantID";
            // 
            // colFullName
            // 
            colFullName.HeaderText = "Full Name";
            colFullName.Name = "colFullName";
            // 
            // colPosition
            // 
            colPosition.HeaderText = "Position Applied";
            colPosition.Name = "colPosition";
            // 
            // colDepartment
            // 
            colDepartment.HeaderText = "Department";
            colDepartment.Name = "colDepartment";
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(111, 35);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(217, 35);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(54, 38);
            label1.Name = "label1";
            label1.Size = new Size(52, 17);
            label1.TabIndex = 3;
            label1.Text = "Search:";
            label1.Click += label1_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(298, 35);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 4;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(27, 244);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 5;
            textBox1.Text = "Full Name:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(27, 273);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 5;
            textBox2.Text = "Position:";
            // 
            // TextBox3
            // 
            TextBox3.Location = new Point(27, 302);
            TextBox3.Name = "TextBox3";
            TextBox3.Size = new Size(100, 23);
            TextBox3.TabIndex = 5;
            TextBox3.Text = "Department:";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(27, 331);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(100, 23);
            txtStatus.TabIndex = 5;
            txtStatus.Text = "Status:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(133, 244);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(100, 23);
            txtFullName.TabIndex = 5;
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(133, 273);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(100, 23);
            txtPosition.TabIndex = 5;
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(133, 302);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(100, 23);
            txtDepartment.TabIndex = 5;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(133, 331);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(100, 23);
            textBox8.TabIndex = 5;
            // 
            // ApplicantList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtStatus);
            Controls.Add(TextBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox8);
            Controls.Add(txtDepartment);
            Controls.Add(txtPosition);
            Controls.Add(txtFullName);
            Controls.Add(textBox1);
            Controls.Add(btnReset);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvApplicants);
            Name = "ApplicantList";
            Text = "ApplicantList";
            Load += ApplicantList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvApplicants).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvApplicants;
        private DataGridViewTextBoxColumn colApplicantID;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colPosition;
        private DataGridViewTextBoxColumn colDepartment;
        private DataGridViewTextBoxColumn colStatus;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label label1;
        private Button btnReset;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox TextBox3;
        private TextBox txtStatus;
        private TextBox txtFullName;
        private TextBox txtPosition;
        private TextBox txtDepartment;
        private TextBox textBox8;
    }
}