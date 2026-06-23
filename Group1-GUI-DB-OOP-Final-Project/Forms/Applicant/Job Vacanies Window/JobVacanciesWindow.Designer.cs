namespace Group1_GUI_DB_OOP_Final_Project.Forms.Applicant
{
    partial class JobVacanciesWindow
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
            SearchBox = new TextBox();
            SearchButton = new Button();
            label3 = new Label();
            DeptCB = new ComboBox();
            label4 = new Label();
            EmploymentTypeCB = new ComboBox();
            ClearButton = new Button();
            JobVacanciesGrid = new DataGridView();
            DetailsTextBox = new RichTextBox();
            panel2 = new Panel();
            label5 = new Label();
            ApplyButton = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)JobVacanciesGrid).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateBlue;
            panel1.Controls.Add(BackButton);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-6, 2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1688, 114);
            panel1.TabIndex = 2;
            // 
            // BackButton
            // 
            BackButton.FlatAppearance.BorderColor = Color.White;
            BackButton.FlatAppearance.BorderSize = 2;
            BackButton.FlatStyle = FlatStyle.Flat;
            BackButton.ForeColor = Color.White;
            BackButton.Location = new Point(1450, 21);
            BackButton.Margin = new Padding(3, 2, 3, 2);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(175, 70);
            BackButton.TabIndex = 12;
            BackButton.Text = "BACK TO LIST";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(131, 34);
            label1.Name = "label1";
            label1.Size = new Size(340, 44);
            label1.TabIndex = 0;
            label1.Text = "JOB VACANCIES";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 222);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 3;
            label2.Text = "Search Job :";
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(145, 222);
            SearchBox.Margin = new Padding(3, 2, 3, 2);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(326, 23);
            SearchBox.TabIndex = 4;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(494, 221);
            SearchButton.Margin = new Padding(3, 2, 3, 2);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(82, 22);
            SearchButton.TabIndex = 5;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 250);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 6;
            label3.Text = "Department :";
            // 
            // DeptCB
            // 
            DeptCB.FormattingEnabled = true;
            DeptCB.Location = new Point(145, 248);
            DeptCB.Margin = new Padding(3, 2, 3, 2);
            DeptCB.Name = "DeptCB";
            DeptCB.Size = new Size(228, 23);
            DeptCB.TabIndex = 7;
            DeptCB.SelectedIndexChanged += DeptCB_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(387, 250);
            label4.Name = "label4";
            label4.Size = new Size(108, 15);
            label4.TabIndex = 8;
            label4.Text = "Employment Type :";
            // 
            // EmploymentTypeCB
            // 
            EmploymentTypeCB.FormattingEnabled = true;
            EmploymentTypeCB.Location = new Point(510, 248);
            EmploymentTypeCB.Margin = new Padding(3, 2, 3, 2);
            EmploymentTypeCB.Name = "EmploymentTypeCB";
            EmploymentTypeCB.Size = new Size(171, 23);
            EmploymentTypeCB.TabIndex = 9;
            EmploymentTypeCB.SelectedIndexChanged += EmploymentTypeCB_SelectedIndexChanged;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(699, 248);
            ClearButton.Margin = new Padding(3, 2, 3, 2);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(82, 22);
            ClearButton.TabIndex = 10;
            ClearButton.Text = "Clear Filter";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // JobVacanciesGrid
            // 
            JobVacanciesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            JobVacanciesGrid.Location = new Point(53, 282);
            JobVacanciesGrid.Margin = new Padding(3, 2, 3, 2);
            JobVacanciesGrid.Name = "JobVacanciesGrid";
            JobVacanciesGrid.RowHeadersWidth = 51;
            JobVacanciesGrid.Size = new Size(984, 434);
            JobVacanciesGrid.TabIndex = 11;
            JobVacanciesGrid.CellContentClick += JobVacanciesGrid_CellContentClick;
            // 
            // DetailsTextBox
            // 
            DetailsTextBox.Location = new Point(1087, 282);
            DetailsTextBox.Margin = new Padding(3, 2, 3, 2);
            DetailsTextBox.Name = "DetailsTextBox";
            DetailsTextBox.Size = new Size(402, 434);
            DetailsTextBox.TabIndex = 12;
            DetailsTextBox.Text = "";
            // 
            // panel2
            // 
            panel2.BackColor = Color.SlateGray;
            panel2.Controls.Add(label5);
            panel2.Location = new Point(1087, 220);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(402, 58);
            panel2.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(125, 14);
            label5.Name = "label5";
            label5.Size = new Size(122, 28);
            label5.TabIndex = 0;
            label5.Text = "DETAILS";
            // 
            // ApplyButton
            // 
            ApplyButton.BackColor = Color.Transparent;
            ApplyButton.FlatAppearance.BorderColor = Color.Black;
            ApplyButton.FlatAppearance.BorderSize = 2;
            ApplyButton.FlatStyle = FlatStyle.Flat;
            ApplyButton.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ApplyButton.Location = new Point(1200, 642);
            ApplyButton.Margin = new Padding(3, 2, 3, 2);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(168, 74);
            ApplyButton.TabIndex = 14;
            ApplyButton.Text = "APPLY";
            ApplyButton.UseVisualStyleBackColor = false;
            ApplyButton.Click += ApplyButton_Click_1;
            // 
            // JobVacanciesWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 749);
            Controls.Add(ApplyButton);
            Controls.Add(panel2);
            Controls.Add(DetailsTextBox);
            Controls.Add(JobVacanciesGrid);
            Controls.Add(ClearButton);
            Controls.Add(EmploymentTypeCB);
            Controls.Add(label4);
            Controls.Add(DeptCB);
            Controls.Add(label3);
            Controls.Add(SearchButton);
            Controls.Add(SearchBox);
            Controls.Add(label2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "JobVacanciesWindow";
            Text = "JobVacanciesWindow";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)JobVacanciesGrid).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox SearchBox;
        private Button SearchButton;
        private Label label3;
        private ComboBox DeptCB;
        private Label label4;
        private ComboBox EmploymentTypeCB;
        private Button ClearButton;
        private DataGridView JobVacanciesGrid;
        private Button BackButton;
        private RichTextBox DetailsTextBox;
        private Panel panel2;
        private Label label5;
        private Button ApplyButton;
    }
}