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
            panel1 = new Panel();
            BackButton = new Button();
            label4 = new Label();
            SearchBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ApplicantStatus = new ComboBox();
            label3 = new Label();
            PositionApplied = new ComboBox();
            SearchButton = new Button();
            panel2 = new Panel();
            ApplicatListTable = new DataGridView();
            ApplicantNameColumn = new DataGridViewTextBoxColumn();
            PositionAppliedColumn = new DataGridViewTextBoxColumn();
            StatusColumn = new DataGridViewTextBoxColumn();
            DateAppliedColumn = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            ReviewApplicantButton = new Button();
            ScreeningButton = new Button();
            IntSchedButton = new Button();
            IntEvaButton = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ApplicatListTable).BeginInit();
            panel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SlateBlue;
            panel1.Controls.Add(BackButton);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(-3, 53);
            panel1.Name = "panel1";
            panel1.Size = new Size(891, 132);
            panel1.TabIndex = 0;
            // 
            // BackButton
            // 
            BackButton.FlatAppearance.BorderColor = Color.White;
            BackButton.FlatAppearance.BorderSize = 2;
            BackButton.FlatStyle = FlatStyle.Flat;
            BackButton.Font = new Font("Century", 10.2F);
            BackButton.ForeColor = Color.White;
            BackButton.Location = new Point(15, 7);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(189, 119);
            BackButton.TabIndex = 15;
            BackButton.Text = "BACK TO DASHBOARD";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(426, 32);
            label4.Name = "label4";
            label4.Size = new Size(317, 54);
            label4.TabIndex = 1;
            label4.Text = "APPLICANTS";
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(79, 23);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(328, 27);
            SearchBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 25);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 2;
            label1.Text = "Search :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(451, 25);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 3;
            label2.Text = "Status :";
            // 
            // ApplicantStatus
            // 
            ApplicantStatus.FormattingEnabled = true;
            ApplicantStatus.Location = new Point(513, 22);
            ApplicantStatus.Name = "ApplicantStatus";
            ApplicantStatus.Size = new Size(192, 28);
            ApplicantStatus.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(752, 26);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 5;
            label3.Text = "Position :";
            // 
            // PositionApplied
            // 
            PositionApplied.FormattingEnabled = true;
            PositionApplied.Location = new Point(826, 22);
            PositionApplied.Name = "PositionApplied";
            PositionApplied.Size = new Size(192, 28);
            PositionApplied.TabIndex = 6;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(1078, 5);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(138, 60);
            SearchButton.TabIndex = 7;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(SearchButton);
            panel2.Controls.Add(ApplicantStatus);
            panel2.Controls.Add(SearchBox);
            panel2.Controls.Add(PositionApplied);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(53, 22);
            panel2.Name = "panel2";
            panel2.Size = new Size(1234, 68);
            panel2.TabIndex = 8;
            // 
            // ApplicatListTable
            // 
            ApplicatListTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ApplicatListTable.Columns.AddRange(new DataGridViewColumn[] { ApplicantNameColumn, PositionAppliedColumn, StatusColumn, DateAppliedColumn });
            ApplicatListTable.Location = new Point(53, 91);
            ApplicatListTable.Name = "ApplicatListTable";
            ApplicatListTable.RowHeadersWidth = 51;
            ApplicatListTable.Size = new Size(1286, 565);
            ApplicatListTable.TabIndex = 9;
            // 
            // ApplicantNameColumn
            // 
            ApplicantNameColumn.HeaderText = "Applicant Name";
            ApplicantNameColumn.MinimumWidth = 6;
            ApplicantNameColumn.Name = "ApplicantNameColumn";
            ApplicantNameColumn.Width = 308;
            // 
            // PositionAppliedColumn
            // 
            PositionAppliedColumn.HeaderText = "Position Applied";
            PositionAppliedColumn.MinimumWidth = 6;
            PositionAppliedColumn.Name = "PositionAppliedColumn";
            PositionAppliedColumn.Width = 308;
            // 
            // StatusColumn
            // 
            StatusColumn.HeaderText = "Status";
            StatusColumn.MinimumWidth = 6;
            StatusColumn.Name = "StatusColumn";
            StatusColumn.Width = 308;
            // 
            // DateAppliedColumn
            // 
            DateAppliedColumn.HeaderText = "Date Applied";
            DateAppliedColumn.MinimumWidth = 6;
            DateAppliedColumn.Name = "DateAppliedColumn";
            DateAppliedColumn.Width = 308;
            // 
            // panel3
            // 
            panel3.Controls.Add(flowLayoutPanel2);
            panel3.Controls.Add(ApplicatListTable);
            panel3.Controls.Add(panel2);
            panel3.Location = new Point(33, 214);
            panel3.Name = "panel3";
            panel3.Size = new Size(1827, 691);
            panel3.TabIndex = 10;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.LightSteelBlue;
            flowLayoutPanel2.Controls.Add(ReviewApplicantButton);
            flowLayoutPanel2.Controls.Add(ScreeningButton);
            flowLayoutPanel2.Controls.Add(IntSchedButton);
            flowLayoutPanel2.Controls.Add(IntEvaButton);
            flowLayoutPanel2.Location = new Point(1365, 91);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(235, 323);
            flowLayoutPanel2.TabIndex = 11;
            // 
            // ReviewApplicantButton
            // 
            ReviewApplicantButton.Font = new Font("Century", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ReviewApplicantButton.Location = new Point(3, 3);
            ReviewApplicantButton.Name = "ReviewApplicantButton";
            ReviewApplicantButton.Size = new Size(229, 75);
            ReviewApplicantButton.TabIndex = 11;
            ReviewApplicantButton.Text = "Review Application";
            ReviewApplicantButton.UseVisualStyleBackColor = true;
            ReviewApplicantButton.Click += ReviewApplicantButton_Click;
            // 
            // ScreeningButton
            // 
            ScreeningButton.Font = new Font("Century", 9F);
            ScreeningButton.Location = new Point(3, 84);
            ScreeningButton.Name = "ScreeningButton";
            ScreeningButton.Size = new Size(229, 75);
            ScreeningButton.TabIndex = 6;
            ScreeningButton.Text = "Screen Applicant";
            ScreeningButton.UseVisualStyleBackColor = true;
            ScreeningButton.Click += ScreeningButton_Click;
            // 
            // IntSchedButton
            // 
            IntSchedButton.Font = new Font("Century", 9F);
            IntSchedButton.Location = new Point(3, 165);
            IntSchedButton.Name = "IntSchedButton";
            IntSchedButton.Size = new Size(229, 75);
            IntSchedButton.TabIndex = 7;
            IntSchedButton.Text = "Schedule an Interview";
            IntSchedButton.UseVisualStyleBackColor = true;
            IntSchedButton.Click += IntSchedButton_Click;
            // 
            // IntEvaButton
            // 
            IntEvaButton.Font = new Font("Century", 9F);
            IntEvaButton.Location = new Point(3, 246);
            IntEvaButton.Name = "IntEvaButton";
            IntEvaButton.Size = new Size(229, 75);
            IntEvaButton.TabIndex = 8;
            IntEvaButton.Text = "Evaluate Interview";
            IntEvaButton.UseVisualStyleBackColor = true;
            IntEvaButton.Click += IntEvaButton_Click;
            // 
            // ApplicantList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Name = "ApplicantList";
            Text = "ApplicantList";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ApplicatListTable).EndInit();
            panel3.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox SearchBox;
        private Label label1;
        private Label label2;
        private ComboBox ApplicantStatus;
        private Label label3;
        private ComboBox PositionApplied;
        private Button SearchButton;
        private Panel panel2;
        private DataGridView ApplicatListTable;
        private Panel panel3;
        private Button ReviewApplicantButton;
        private DataGridViewTextBoxColumn ApplicantNameColumn;
        private DataGridViewTextBoxColumn PositionAppliedColumn;
        private DataGridViewTextBoxColumn StatusColumn;
        private DataGridViewTextBoxColumn DateAppliedColumn;
        private Label label4;
        private Button BackButton;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button ScreeningButton;
        private Button IntSchedButton;
        private Button IntEvaButton;
    }
}