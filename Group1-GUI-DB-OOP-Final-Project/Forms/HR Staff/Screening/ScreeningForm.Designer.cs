namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR_Staff.Screening
{
    partial class ScreeningForm
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
            label1 = new Label();
            panel2 = new Panel();
            label5 = new Label();
            RemarksTextBox = new RichTextBox();
            panel5 = new Panel();
            JobQualifications = new DataGridView();
            Requirements = new DataGridViewTextBoxColumn();
            ApplicantInventory = new DataGridViewTextBoxColumn();
            panel4 = new Panel();
            label4 = new Label();
            panel3 = new Panel();
            PositionTextBox = new TextBox();
            NameTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            panel6 = new Panel();
            NotQualifiedRadioButton = new RadioButton();
            panel7 = new Panel();
            label6 = new Label();
            QualifiedRadioButton = new RadioButton();
            SaveScreening = new Button();
            BackButton = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)JobQualifications).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-7, -6);
            panel1.Name = "panel1";
            panel1.Size = new Size(1929, 152);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(150, 46);
            label1.Name = "label1";
            label1.Size = new Size(303, 54);
            label1.TabIndex = 0;
            label1.Text = "SCREENING";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Silver;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(RemarksTextBox);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel6);
            panel2.Font = new Font("Century", 10.2F, FontStyle.Bold);
            panel2.ForeColor = Color.White;
            panel2.Location = new Point(275, 213);
            panel2.Name = "panel2";
            panel2.Size = new Size(1343, 751);
            panel2.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(700, 75);
            label5.Name = "label5";
            label5.Size = new Size(108, 21);
            label5.TabIndex = 8;
            label5.Text = "REMARKS :";
            // 
            // RemarksTextBox
            // 
            RemarksTextBox.Location = new Point(689, 120);
            RemarksTextBox.Name = "RemarksTextBox";
            RemarksTextBox.Size = new Size(598, 228);
            RemarksTextBox.TabIndex = 7;
            RemarksTextBox.Text = "";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(JobQualifications);
            panel5.Location = new Point(43, 274);
            panel5.Name = "panel5";
            panel5.Size = new Size(577, 408);
            panel5.TabIndex = 6;
            // 
            // JobQualifications
            // 
            JobQualifications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            JobQualifications.Columns.AddRange(new DataGridViewColumn[] { Requirements, ApplicantInventory });
            JobQualifications.Location = new Point(25, 49);
            JobQualifications.Name = "JobQualifications";
            JobQualifications.RowHeadersWidth = 51;
            JobQualifications.Size = new Size(529, 329);
            JobQualifications.TabIndex = 0;
            // 
            // Requirements
            // 
            Requirements.HeaderText = "Requirements";
            Requirements.MinimumWidth = 6;
            Requirements.Name = "Requirements";
            Requirements.Width = 240;
            // 
            // ApplicantInventory
            // 
            ApplicantInventory.HeaderText = "Applicant Inventory";
            ApplicantInventory.MinimumWidth = 6;
            ApplicantInventory.Name = "ApplicantInventory";
            ApplicantInventory.Width = 240;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Gray;
            panel4.Controls.Add(label4);
            panel4.Location = new Point(43, 213);
            panel4.Name = "panel4";
            panel4.Size = new Size(577, 55);
            panel4.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Gray;
            label4.Font = new Font("Century", 10.2F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(168, 16);
            label4.Name = "label4";
            label4.Size = new Size(222, 21);
            label4.TabIndex = 4;
            label4.Text = "JOB QUALIFICATIONS";
            // 
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(PositionTextBox);
            panel3.Controls.Add(NameTextBox);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(38, 24);
            panel3.Name = "panel3";
            panel3.Size = new Size(582, 125);
            panel3.TabIndex = 4;
            // 
            // PositionTextBox
            // 
            PositionTextBox.Location = new Point(183, 68);
            PositionTextBox.Name = "PositionTextBox";
            PositionTextBox.Size = new Size(376, 28);
            PositionTextBox.TabIndex = 3;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(183, 23);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(376, 28);
            NameTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DimGray;
            label2.Font = new Font("Century", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(22, 26);
            label2.Name = "label2";
            label2.Size = new Size(144, 21);
            label2.TabIndex = 0;
            label2.Text = "APPLICANT   :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.DimGray;
            label3.Font = new Font("Century", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(22, 75);
            label3.Name = "label3";
            label3.Size = new Size(129, 21);
            label3.TabIndex = 1;
            label3.Text = "POSITION   :";
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(NotQualifiedRadioButton);
            panel6.Controls.Add(panel7);
            panel6.Controls.Add(QualifiedRadioButton);
            panel6.Location = new Point(862, 410);
            panel6.Name = "panel6";
            panel6.Size = new Size(254, 242);
            panel6.TabIndex = 12;
            // 
            // NotQualifiedRadioButton
            // 
            NotQualifiedRadioButton.AutoSize = true;
            NotQualifiedRadioButton.Font = new Font("Century", 10.2F);
            NotQualifiedRadioButton.ForeColor = Color.Black;
            NotQualifiedRadioButton.Location = new Point(46, 159);
            NotQualifiedRadioButton.Name = "NotQualifiedRadioButton";
            NotQualifiedRadioButton.Size = new Size(174, 25);
            NotQualifiedRadioButton.TabIndex = 10;
            NotQualifiedRadioButton.TabStop = true;
            NotQualifiedRadioButton.Text = "NOT QUALIFIED";
            NotQualifiedRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            panel7.BackColor = Color.DimGray;
            panel7.Controls.Add(label6);
            panel7.Location = new Point(0, 1);
            panel7.Name = "panel7";
            panel7.Size = new Size(254, 66);
            panel7.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(28, 24);
            label6.Name = "label6";
            label6.Size = new Size(203, 21);
            label6.TabIndex = 11;
            label6.Text = "SCREENING RESULT :";
            // 
            // QualifiedRadioButton
            // 
            QualifiedRadioButton.AutoSize = true;
            QualifiedRadioButton.Font = new Font("Century", 10.2F);
            QualifiedRadioButton.ForeColor = Color.Black;
            QualifiedRadioButton.Location = new Point(46, 98);
            QualifiedRadioButton.Name = "QualifiedRadioButton";
            QualifiedRadioButton.Size = new Size(131, 25);
            QualifiedRadioButton.TabIndex = 9;
            QualifiedRadioButton.TabStop = true;
            QualifiedRadioButton.Text = "QUALIFIED";
            QualifiedRadioButton.UseVisualStyleBackColor = true;
            // 
            // SaveScreening
            // 
            SaveScreening.FlatAppearance.BorderColor = Color.Black;
            SaveScreening.FlatAppearance.BorderSize = 2;
            SaveScreening.FlatStyle = FlatStyle.Flat;
            SaveScreening.Location = new Point(1670, 216);
            SaveScreening.Name = "SaveScreening";
            SaveScreening.Size = new Size(200, 93);
            SaveScreening.TabIndex = 3;
            SaveScreening.Text = "SAVE SCREENING";
            SaveScreening.UseVisualStyleBackColor = true;
            SaveScreening.Click += SaveScreening_Click;
            // 
            // BackButton
            // 
            BackButton.FlatAppearance.BorderColor = Color.Black;
            BackButton.FlatAppearance.BorderSize = 2;
            BackButton.FlatStyle = FlatStyle.Flat;
            BackButton.Location = new Point(1670, 333);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(200, 93);
            BackButton.TabIndex = 4;
            BackButton.Text = "BACK TO LIST";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // ScreeningForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1902, 1033);
            Controls.Add(BackButton);
            Controls.Add(SaveScreening);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ScreeningForm";
            Text = "ScreeningForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)JobQualifications).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label3;
        private Label label2;
        private RichTextBox RemarksTextBox;
        private Panel panel5;
        private DataGridView JobQualifications;
        private Panel panel4;
        private Label label4;
        private Panel panel3;
        private TextBox PositionTextBox;
        private TextBox NameTextBox;
        private Panel panel6;
        private RadioButton NotQualifiedRadioButton;
        private RadioButton QualifiedRadioButton;
        private Label label6;
        private Label label5;
        private DataGridViewTextBoxColumn Requirements;
        private DataGridViewTextBoxColumn ApplicantInventory;
        private Panel panel7;
        private Button SaveScreening;
        private Button BackButton;
    }
}