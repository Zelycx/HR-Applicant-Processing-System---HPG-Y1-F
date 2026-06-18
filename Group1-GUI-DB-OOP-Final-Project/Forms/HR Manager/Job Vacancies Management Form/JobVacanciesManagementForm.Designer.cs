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
            dataGridView1 = new DataGridView();
            AddButton = new Button();
            EditButton = new Button();
            CloseOrReopenButton = new Button();
            DashboardButton = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label4 = new Label();
            JobTitle = new DataGridViewTextBoxColumn();
            Slots = new DataGridViewTextBoxColumn();
            Dept = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 9F);
            label1.Location = new Point(27, 18);
            label1.Name = "label1";
            label1.Size = new Size(82, 18);
            label1.TabIndex = 0;
            label1.Text = "Job Title : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 9F);
            label2.Location = new Point(27, 57);
            label2.Name = "label2";
            label2.Size = new Size(102, 18);
            label2.TabIndex = 1;
            label2.Text = "Department :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 9F);
            label3.Location = new Point(27, 97);
            label3.Name = "label3";
            label3.Size = new Size(61, 18);
            label3.TabIndex = 2;
            label3.Text = "Status :";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(137, 15);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(353, 27);
            textBox1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { JobTitle, Slots, Dept, Status });
            dataGridView1.Location = new Point(75, 309);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(948, 586);
            dataGridView1.TabIndex = 6;
            // 
            // AddButton
            // 
            AddButton.FlatAppearance.BorderColor = Color.White;
            AddButton.FlatAppearance.BorderSize = 2;
            AddButton.FlatStyle = FlatStyle.Flat;
            AddButton.Font = new Font("Century", 10.8F);
            AddButton.ForeColor = Color.White;
            AddButton.Location = new Point(46, 24);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(277, 102);
            AddButton.TabIndex = 7;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            EditButton.FlatAppearance.BorderColor = Color.White;
            EditButton.FlatAppearance.BorderSize = 2;
            EditButton.FlatStyle = FlatStyle.Flat;
            EditButton.Font = new Font("Century", 10.8F);
            EditButton.ForeColor = Color.White;
            EditButton.Location = new Point(46, 143);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(277, 102);
            EditButton.TabIndex = 8;
            EditButton.Text = "Edit";
            EditButton.UseVisualStyleBackColor = true;
            // 
            // CloseOrReopenButton
            // 
            CloseOrReopenButton.FlatAppearance.BorderColor = Color.White;
            CloseOrReopenButton.FlatAppearance.BorderSize = 2;
            CloseOrReopenButton.FlatStyle = FlatStyle.Flat;
            CloseOrReopenButton.Font = new Font("Century", 10.8F);
            CloseOrReopenButton.ForeColor = Color.White;
            CloseOrReopenButton.Location = new Point(46, 300);
            CloseOrReopenButton.Name = "CloseOrReopenButton";
            CloseOrReopenButton.Size = new Size(277, 102);
            CloseOrReopenButton.TabIndex = 9;
            CloseOrReopenButton.Text = "Close/Reopen";
            CloseOrReopenButton.UseVisualStyleBackColor = true;
            // 
            // DashboardButton
            // 
            DashboardButton.FlatAppearance.BorderColor = Color.White;
            DashboardButton.FlatAppearance.BorderSize = 2;
            DashboardButton.FlatStyle = FlatStyle.Flat;
            DashboardButton.Font = new Font("Century", 10.8F);
            DashboardButton.ForeColor = Color.White;
            DashboardButton.Location = new Point(46, 408);
            DashboardButton.Name = "DashboardButton";
            DashboardButton.Size = new Size(277, 102);
            DashboardButton.TabIndex = 10;
            DashboardButton.Text = "Dashboard";
            DashboardButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SlateGray;
            panel1.Controls.Add(label4);
            panel1.Location = new Point(0, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1902, 153);
            panel1.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightSlateGray;
            panel2.Controls.Add(AddButton);
            panel2.Controls.Add(DashboardButton);
            panel2.Controls.Add(EditButton);
            panel2.Controls.Add(CloseOrReopenButton);
            panel2.Location = new Point(1397, 197);
            panel2.Name = "panel2";
            panel2.Size = new Size(362, 536);
            panel2.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(comboBox2);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(75, 164);
            panel3.Name = "panel3";
            panel3.Size = new Size(522, 139);
            panel3.TabIndex = 13;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(137, 57);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(353, 28);
            comboBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(137, 96);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(353, 28);
            comboBox2.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(470, 48);
            label4.Name = "label4";
            label4.Size = new Size(872, 54);
            label4.TabIndex = 6;
            label4.Text = "JOB VACANCIES AND MANAGEMENT";
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
            // JobVacanciesManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Name = "JobVacanciesManagementForm";
            Text = "JobVacanciesManagementForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private DataGridView dataGridView1;
        private Button AddButton;
        private Button EditButton;
        private Button CloseOrReopenButton;
        private Button DashboardButton;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Label label4;
        private DataGridViewTextBoxColumn JobTitle;
        private DataGridViewTextBoxColumn Slots;
        private DataGridViewTextBoxColumn Dept;
        private DataGridViewTextBoxColumn Status;
    }
}