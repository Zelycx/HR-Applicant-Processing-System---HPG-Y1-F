namespace Group1_GUI_DB_OOP_Final_Project.Forms.Applicant
{
    partial class ApplicantDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicantDashboard));
            panel1 = new Panel();
            LogOutButton = new Button();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            panel7 = new Panel();
            panel10 = new Panel();
            label5 = new Label();
            panel5 = new Panel();
            panel4 = new Panel();
            ApplicantLastLog = new Label();
            label4 = new Label();
            NameOfApplicant = new Label();
            label3 = new Label();
            label2 = new Label();
            panel6 = new Panel();
            panel11 = new Panel();
            label6 = new Label();
            panel8 = new Panel();
            panel12 = new Panel();
            label7 = new Label();
            Applications = new DataGridView();
            PositionColumn = new DataGridViewTextBoxColumn();
            DateAppliedColumn = new DataGridViewTextBoxColumn();
            StatusColumn = new DataGridViewTextBoxColumn();
            panel9 = new Panel();
            label8 = new Label();
            panel13 = new Panel();
            label9 = new Label();
            MissingRequirements = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Applications).BeginInit();
            panel9.SuspendLayout();
            panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MissingRequirements).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(LogOutButton);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-2, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1940, 152);
            panel1.TabIndex = 0;
            // 
            // LogOutButton
            // 
            LogOutButton.FlatAppearance.BorderColor = Color.White;
            LogOutButton.FlatAppearance.BorderSize = 2;
            LogOutButton.FlatStyle = FlatStyle.Flat;
            LogOutButton.Font = new Font("Century", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LogOutButton.ForeColor = Color.White;
            LogOutButton.Location = new Point(1717, 14);
            LogOutButton.Name = "LogOutButton";
            LogOutButton.Size = new Size(175, 84);
            LogOutButton.TabIndex = 3;
            LogOutButton.Text = "LOG OUT";
            LogOutButton.UseVisualStyleBackColor = true;
            LogOutButton.Click += LogOutButton_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Location = new Point(178, 109);
            panel2.Name = "panel2";
            panel2.Size = new Size(516, 10);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(175, 64);
            label1.Name = "label1";
            label1.Size = new Size(504, 44);
            label1.TabIndex = 1;
            label1.Text = "APPLICANT DASHBOARD";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(8, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(151, 136);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.ForeColor = Color.Transparent;
            panel3.Location = new Point(176, 112);
            panel3.Name = "panel3";
            panel3.Size = new Size(10, 50);
            panel3.TabIndex = 3;
            // 
            // panel7
            // 
            panel7.BackColor = Color.LightSkyBlue;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(panel10);
            panel7.Controls.Add(label5);
            panel7.Location = new Point(1013, 156);
            panel7.Name = "panel7";
            panel7.Size = new Size(184, 113);
            panel7.TabIndex = 4;
            // 
            // panel10
            // 
            panel10.BackColor = Color.Azure;
            panel10.Location = new Point(26, 29);
            panel10.Name = "panel10";
            panel10.Size = new Size(126, 79);
            panel10.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 8);
            label5.Name = "label5";
            label5.Size = new Size(142, 21);
            label5.TabIndex = 0;
            label5.Text = "APPLICATIONS";
            // 
            // panel5
            // 
            panel5.BackColor = Color.Black;
            panel5.Controls.Add(panel4);
            panel5.Location = new Point(186, 117);
            panel5.Name = "panel5";
            panel5.Size = new Size(821, 152);
            panel5.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.AliceBlue;
            panel4.Controls.Add(ApplicantLastLog);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(NameOfApplicant);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(815, 146);
            panel4.TabIndex = 1;
            // 
            // ApplicantLastLog
            // 
            ApplicantLastLog.AutoSize = true;
            ApplicantLastLog.Font = new Font("Century", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ApplicantLastLog.Location = new Point(158, 89);
            ApplicantLastLog.Name = "ApplicantLastLog";
            ApplicantLastLog.Size = new Size(148, 28);
            ApplicantLastLog.TabIndex = 4;
            ApplicantLastLog.Text = "Place Holder";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(203, 33);
            label4.Name = "label4";
            label4.Size = new Size(259, 33);
            label4.TabIndex = 3;
            label4.Text = "PLACE HOLDER";
            // 
            // NameOfApplicant
            // 
            NameOfApplicant.AutoSize = true;
            NameOfApplicant.Font = new Font("Century", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameOfApplicant.Location = new Point(203, 33);
            NameOfApplicant.Name = "NameOfApplicant";
            NameOfApplicant.Size = new Size(0, 33);
            NameOfApplicant.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(29, 89);
            label3.Name = "label3";
            label3.Size = new Size(138, 28);
            label3.TabIndex = 1;
            label3.Text = "Last Login: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 33);
            label2.Name = "label2";
            label2.Size = new Size(177, 33);
            label2.TabIndex = 0;
            label2.Text = "WELCOME,";
            // 
            // panel6
            // 
            panel6.BackColor = Color.LightSkyBlue;
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(panel11);
            panel6.Controls.Add(label6);
            panel6.Location = new Point(1203, 156);
            panel6.Name = "panel6";
            panel6.Size = new Size(184, 113);
            panel6.TabIndex = 5;
            // 
            // panel11
            // 
            panel11.BackColor = Color.Azure;
            panel11.Location = new Point(25, 30);
            panel11.Name = "panel11";
            panel11.Size = new Size(126, 79);
            panel11.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(26, 8);
            label6.Name = "label6";
            label6.Size = new Size(125, 21);
            label6.TabIndex = 1;
            label6.Text = "INTERVIEWS";
            // 
            // panel8
            // 
            panel8.BackColor = Color.LightSkyBlue;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(panel12);
            panel8.Controls.Add(label7);
            panel8.Location = new Point(1393, 156);
            panel8.Name = "panel8";
            panel8.Size = new Size(231, 113);
            panel8.TabIndex = 5;
            // 
            // panel12
            // 
            panel12.BackColor = Color.Azure;
            panel12.Location = new Point(26, 29);
            panel12.Name = "panel12";
            panel12.Size = new Size(180, 79);
            panel12.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(29, 8);
            label7.Name = "label7";
            label7.Size = new Size(172, 21);
            label7.TabIndex = 2;
            label7.Text = "CURRENT STATUS";
            // 
            // Applications
            // 
            Applications.AllowUserToAddRows = false;
            Applications.AllowUserToDeleteRows = false;
            Applications.AllowUserToResizeColumns = false;
            Applications.BackgroundColor = Color.White;
            Applications.BorderStyle = BorderStyle.None;
            Applications.CellBorderStyle = DataGridViewCellBorderStyle.None;
            Applications.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Applications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Applications.Columns.AddRange(new DataGridViewColumn[] { PositionColumn, DateAppliedColumn, StatusColumn });
            Applications.Location = new Point(-4, 64);
            Applications.MultiSelect = false;
            Applications.Name = "Applications";
            Applications.ReadOnly = true;
            Applications.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Applications.RowHeadersVisible = false;
            Applications.RowHeadersWidth = 51;
            Applications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Applications.Size = new Size(377, 188);
            Applications.TabIndex = 6;
            // 
            // PositionColumn
            // 
            PositionColumn.HeaderText = "Position";
            PositionColumn.MinimumWidth = 6;
            PositionColumn.Name = "PositionColumn";
            PositionColumn.ReadOnly = true;
            PositionColumn.Width = 125;
            // 
            // DateAppliedColumn
            // 
            DateAppliedColumn.HeaderText = "Date Applied";
            DateAppliedColumn.MinimumWidth = 6;
            DateAppliedColumn.Name = "DateAppliedColumn";
            DateAppliedColumn.ReadOnly = true;
            DateAppliedColumn.Width = 125;
            // 
            // StatusColumn
            // 
            StatusColumn.HeaderText = "Status";
            StatusColumn.MinimumWidth = 6;
            StatusColumn.Name = "StatusColumn";
            StatusColumn.ReadOnly = true;
            StatusColumn.Width = 125;
            // 
            // panel9
            // 
            panel9.BackColor = Color.Gray;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(label8);
            panel9.Controls.Add(Applications);
            panel9.Location = new Point(192, 309);
            panel9.Name = "panel9";
            panel9.Size = new Size(368, 244);
            panel9.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(81, 16);
            label8.Name = "label8";
            label8.Size = new Size(201, 22);
            label8.TabIndex = 7;
            label8.Text = "MY APPLICATIONS";
            // 
            // panel13
            // 
            panel13.BackColor = Color.Gray;
            panel13.BorderStyle = BorderStyle.FixedSingle;
            panel13.Controls.Add(label9);
            panel13.Controls.Add(MissingRequirements);
            panel13.Location = new Point(596, 309);
            panel13.Name = "panel13";
            panel13.Size = new Size(368, 244);
            panel13.TabIndex = 8;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(47, 16);
            label9.Name = "label9";
            label9.Size = new Size(273, 22);
            label9.TabIndex = 7;
            label9.Text = "MISSING REQUIREMENTS";
            // 
            // MissingRequirements
            // 
            MissingRequirements.AllowUserToAddRows = false;
            MissingRequirements.AllowUserToDeleteRows = false;
            MissingRequirements.AllowUserToResizeColumns = false;
            MissingRequirements.BackgroundColor = Color.White;
            MissingRequirements.BorderStyle = BorderStyle.None;
            MissingRequirements.CellBorderStyle = DataGridViewCellBorderStyle.None;
            MissingRequirements.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            MissingRequirements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MissingRequirements.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn3 });
            MissingRequirements.Location = new Point(-4, 64);
            MissingRequirements.MultiSelect = false;
            MissingRequirements.Name = "MissingRequirements";
            MissingRequirements.ReadOnly = true;
            MissingRequirements.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            MissingRequirements.RowHeadersVisible = false;
            MissingRequirements.RowHeadersWidth = 51;
            MissingRequirements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MissingRequirements.Size = new Size(377, 188);
            MissingRequirements.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Job";
            dataGridViewTextBoxColumn1.MinimumWidth = 9;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 185;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Missing Requirements";
            dataGridViewTextBoxColumn3.MinimumWidth = 9;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 185;
            // 
            // ApplicantDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel13);
            Controls.Add(panel9);
            Controls.Add(panel8);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel7);
            Name = "ApplicantDashboard";
            Text = "ApplicantDashboard";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Applications).EndInit();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MissingRequirements).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Panel panel2;
        private Label label1;
        private Panel panel7;
        private Panel panel5;
        private Panel panel4;
        private Label NameOfApplicant;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label ApplicantLastLog;
        private Panel panel6;
        private Panel panel8;
        private Label label5;
        private Label label6;
        private Label label7;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private DataGridView Applications;
        private DataGridViewTextBoxColumn PositionColumn;
        private DataGridViewTextBoxColumn DateAppliedColumn;
        private DataGridViewTextBoxColumn StatusColumn;
        private Panel panel9;
        private Label label8;
        private Button LogOutButton;
        private Panel panel13;
        private Label label9;
        private DataGridView MissingRequirements;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}