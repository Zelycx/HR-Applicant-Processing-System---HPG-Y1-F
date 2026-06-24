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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            dgvVacancies = new DataGridView();
            JobTitle = new DataGridViewTextBoxColumn();
            Slots = new DataGridViewTextBoxColumn();
            Dept = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            AddButton = new Button();
            EditButton = new Button();
            CloseOrReopenButton = new Button();
            DashboardButton = new Button();
            panel1 = new Panel();
            label4 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            comboBox2 = new ComboBox();
            cmbDepartment = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvVacancies).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 9F);
            label1.Location = new Point(24, 14);
            label1.Name = "label1";
            label1.Size = new Size(66, 16);
            label1.TabIndex = 0;
            label1.Text = "Job Title : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 9F);
            label2.Location = new Point(24, 43);
            label2.Name = "label2";
            label2.Size = new Size(81, 16);
            label2.TabIndex = 1;
            label2.Text = "Department :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 9F);
            label3.Location = new Point(24, 73);
            label3.Name = "label3";
            label3.Size = new Size(51, 16);
            label3.TabIndex = 2;
            label3.Text = "Status :";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(120, 11);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(309, 23);
            textBox1.TabIndex = 3;
            // 
            // dgvVacancies
            // 
            dgvVacancies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVacancies.Columns.AddRange(new DataGridViewColumn[] { JobTitle, Slots, Dept, Status });
            dgvVacancies.Location = new Point(66, 232);
            dgvVacancies.Margin = new Padding(3, 2, 3, 2);
            dgvVacancies.Name = "dgvVacancies";
            dgvVacancies.RowHeadersWidth = 51;
            dgvVacancies.Size = new Size(830, 440);
            dgvVacancies.TabIndex = 6;
            // 
            // JobTitle
            // 
            JobTitle.HeaderText = "Job Title";
            JobTitle.MinimumWidth = 6;
            JobTitle.Name = "JobTitle";
            JobTitle.Width = 224;
            // 
            // Slots
            // 
            Slots.HeaderText = "Slots";
            Slots.MinimumWidth = 6;
            Slots.Name = "Slots";
            Slots.Width = 224;
            // 
            // Dept
            // 
            Dept.HeaderText = "Dept";
            Dept.MinimumWidth = 6;
            Dept.Name = "Dept";
            Dept.Width = 224;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 224;
            // 
            // AddButton
            // 
            AddButton.FlatAppearance.BorderColor = Color.White;
            AddButton.FlatAppearance.BorderSize = 2;
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.Font = new Font("Century", 10.8F);
            AddButton.ForeColor = Color.White;
            AddButton.Location = new Point(40, 18);
            AddButton.Margin = new Padding(3, 2, 3, 2);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(242, 76);
            AddButton.TabIndex = 7;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // EditButton
            // 
            EditButton.FlatAppearance.BorderColor = Color.White;
            EditButton.FlatAppearance.BorderSize = 2;
            EditButton.FlatStyle = FlatStyle.Flat;
            EditButton.Font = new Font("Century", 10.8F);
            EditButton.ForeColor = Color.White;
            EditButton.Location = new Point(40, 107);
            EditButton.Margin = new Padding(3, 2, 3, 2);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(242, 76);
            EditButton.TabIndex = 8;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // CloseOrReopenButton
            // 
            CloseOrReopenButton.FlatAppearance.BorderColor = Color.White;
            CloseOrReopenButton.FlatAppearance.BorderSize = 2;
            CloseOrReopenButton.FlatStyle = FlatStyle.Flat;
            CloseOrReopenButton.Font = new Font("Century", 10.8F);
            CloseOrReopenButton.ForeColor = Color.White;
            CloseOrReopenButton.Location = new Point(40, 225);
            CloseOrReopenButton.Margin = new Padding(3, 2, 3, 2);
            CloseOrReopenButton.Name = "CloseOrReopenButton";
            CloseOrReopenButton.Size = new Size(242, 76);
            CloseOrReopenButton.TabIndex = 9;
            CloseOrReopenButton.Text = "Close/Reopen";
            CloseOrReopenButton.UseVisualStyleBackColor = true;
            CloseOrReopenButton.Click += CloseOrReopenButton_Click;
            // 
            // DashboardButton
            // 
            DashboardButton.FlatAppearance.BorderColor = Color.White;
            DashboardButton.FlatAppearance.BorderSize = 2;
            DashboardButton.FlatStyle = FlatStyle.Flat;
            DashboardButton.Font = new Font("Century", 10.8F);
            DashboardButton.ForeColor = Color.White;
            DashboardButton.Location = new Point(40, 306);
            DashboardButton.Margin = new Padding(3, 2, 3, 2);
            DashboardButton.Name = "DashboardButton";
            DashboardButton.Size = new Size(242, 76);
            DashboardButton.TabIndex = 10;
            DashboardButton.Text = "Dashboard";
            DashboardButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SlateGray;
            panel1.Controls.Add(label4);
            panel1.Location = new Point(0, -2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1664, 115);
            panel1.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(411, 36);
            label4.Name = "label4";
            label4.Size = new Size(689, 41);
            label4.TabIndex = 6;
            label4.Text = "JOB VACANCIES AND MANAGEMENT";
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightSlateGray;
            panel2.Controls.Add(AddButton);
            panel2.Controls.Add(DashboardButton);
            panel2.Controls.Add(EditButton);
            panel2.Controls.Add(CloseOrReopenButton);
            panel2.Location = new Point(1222, 148);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(317, 402);
            panel2.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(comboBox2);
            panel3.Controls.Add(cmbDepartment);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(66, 123);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(457, 104);
            panel3.TabIndex = 13;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(120, 72);
            comboBox2.Margin = new Padding(3, 2, 3, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(309, 23);
            comboBox2.TabIndex = 5;
            // 
            // cmbDepartment
            // 
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(120, 43);
            cmbDepartment.Margin = new Padding(3, 2, 3, 2);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(309, 23);
            cmbDepartment.TabIndex = 4;
            // 
            // JobVacanciesManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(1664, 775);
            Controls.Add(panel1);
            Controls.Add(dgvVacancies);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Margin = new Padding(3, 2, 3, 2);
            Name = "JobVacanciesManagementForm";
            Text = "JobVacanciesManagementForm";
            Load += JobVacanciesManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVacancies).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private DataGridView dgvVacancies;
        private Button AddButton;
        private Button EditButton;
        private Button CloseOrReopenButton;
        private Button DashboardButton;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private ComboBox comboBox2;
        private ComboBox cmbDepartment;
        private Label label4;
        private DataGridViewTextBoxColumn JobTitle;
        private DataGridViewTextBoxColumn Slots;
        private DataGridViewTextBoxColumn Dept;
        private DataGridViewTextBoxColumn Status;
    }
}