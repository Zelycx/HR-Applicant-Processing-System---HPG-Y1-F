namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR_Manager.Job_Vacancies_Management_Form.AddOrEdit
{
    partial class AddOrEditForm
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
            // ── Instantiate ALL controls first ─────────────────────────────
            btnSave = new Button();
            btnCancel = new Button();
            txtQualifications = new TextBox();
            label5 = new Label();
            txtJobDescription = new TextBox();
            label4 = new Label();
            cmbEmploymentType = new ComboBox();
            label3 = new Label();
            cmbDepartment = new ComboBox();
            label2 = new Label();
            txtJobTitle = new TextBox();
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            panel1 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            BackButton = new Button();
            label6 = new Label();
            clbRequirements = new CheckedListBox();   // ← NEW
            label7 = new Label();             // ← NEW

            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();

            // ── btnSave ───────────────────────────────────────────────────
            btnSave.FlatAppearance.BorderColor = Color.White;
            btnSave.FlatAppearance.BorderSize = 2;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Century", 12F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(40, 15);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(227, 92);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // ── btnCancel ─────────────────────────────────────────────────
            btnCancel.FlatAppearance.BorderColor = Color.White;
            btnCancel.FlatAppearance.BorderSize = 2;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Century", 12F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(305, 15);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(227, 92);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            // ── txtQualifications ─────────────────────────────────────────
            txtQualifications.BorderStyle = BorderStyle.FixedSingle;
            txtQualifications.Location = new Point(760, 271);
            txtQualifications.Margin = new Padding(3, 4, 3, 4);
            txtQualifications.Multiline = true;
            txtQualifications.Name = "txtQualifications";
            txtQualifications.Size = new Size(587, 401);
            txtQualifications.TabIndex = 9;

            // ── label5 (Qualifications) ───────────────────────────────────
            label5.AutoSize = true;
            label5.Font = new Font("Century", 12F);
            label5.Location = new Point(760, 234);
            label5.Name = "label5";
            label5.Size = new Size(139, 23);
            label5.TabIndex = 8;
            label5.Text = "Qualifications";

            // ── txtJobDescription ─────────────────────────────────────────
            txtJobDescription.BorderStyle = BorderStyle.FixedSingle;
            txtJobDescription.Location = new Point(45, 271);
            txtJobDescription.Margin = new Padding(3, 4, 3, 4);
            txtJobDescription.Multiline = true;
            txtJobDescription.Name = "txtJobDescription";
            txtJobDescription.Size = new Size(677, 402);
            txtJobDescription.TabIndex = 7;

            // ── label4 (Job Description) ──────────────────────────────────
            label4.AutoSize = true;
            label4.Font = new Font("Century", 12F);
            label4.Location = new Point(45, 234);
            label4.Name = "label4";
            label4.Size = new Size(154, 23);
            label4.TabIndex = 6;
            label4.Text = "Job Description";

            // ── cmbEmploymentType ─────────────────────────────────────────
            cmbEmploymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmploymentType.Font = new Font("Century", 12F);
            cmbEmploymentType.FormattingEnabled = true;
            cmbEmploymentType.Location = new Point(252, 177);
            cmbEmploymentType.Margin = new Padding(3, 4, 3, 4);
            cmbEmploymentType.Name = "cmbEmploymentType";
            cmbEmploymentType.Size = new Size(557, 31);
            cmbEmploymentType.TabIndex = 5;

            // ── label3 (Employment Type) ──────────────────────────────────
            label3.AutoSize = true;
            label3.Font = new Font("Century", 12F);
            label3.Location = new Point(45, 181);
            label3.Name = "label3";
            label3.Size = new Size(179, 23);
            label3.TabIndex = 4;
            label3.Text = "Employment Type";

            // ── cmbDepartment ─────────────────────────────────────────────
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.Font = new Font("Century", 12F);
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(252, 124);
            cmbDepartment.Margin = new Padding(3, 4, 3, 4);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(557, 31);
            cmbDepartment.TabIndex = 3;

            // ── label2 (Department) ───────────────────────────────────────
            label2.AutoSize = true;
            label2.Font = new Font("Century", 12F);
            label2.Location = new Point(45, 128);
            label2.Name = "label2";
            label2.Size = new Size(123, 23);
            label2.TabIndex = 2;
            label2.Text = "Department";

            // ── txtJobTitle ───────────────────────────────────────────────
            txtJobTitle.BorderStyle = BorderStyle.FixedSingle;
            txtJobTitle.Font = new Font("Century", 12F);
            txtJobTitle.Location = new Point(252, 71);
            txtJobTitle.Margin = new Padding(3, 4, 3, 4);
            txtJobTitle.Name = "txtJobTitle";
            txtJobTitle.Size = new Size(557, 32);
            txtJobTitle.TabIndex = 1;

            // ── label1 (Job Title) ────────────────────────────────────────
            label1.AutoSize = true;
            label1.Font = new Font("Century", 12F);
            label1.Location = new Point(45, 74);
            label1.Name = "label1";
            label1.Size = new Size(91, 23);
            label1.TabIndex = 0;
            label1.Text = "Job Title";

            // ── openFileDialog1 ───────────────────────────────────────────
            openFileDialog1.FileName = "openFileDialog1";

            // ── label7 (Required Documents) — sits right of the combo area ─
            label7.AutoSize = true;
            label7.Font = new Font("Century", 12F);
            label7.Location = new Point(843, 74);
            label7.Name = "label7";
            label7.Size = new Size(200, 23);
            label7.TabIndex = 12;
            label7.Text = "Required Documents";

            // ── clbRequirements ───────────────────────────────────────────
            // Positioned in the empty space to the right of the combo boxes
            // (x=843..1370, y=107..227) — inside panel1
            clbRequirements.FormattingEnabled = true;
            clbRequirements.Font = new Font("Century", 10F);
            clbRequirements.Location = new Point(843, 107);
            clbRequirements.Name = "clbRequirements";
            clbRequirements.Size = new Size(510, 120);
            clbRequirements.TabIndex = 13;

            // ── panel3 (Save / Cancel buttons) ───────────────────────────
            panel3.BackColor = Color.SteelBlue;
            panel3.Controls.Add(btnCancel);
            panel3.Controls.Add(btnSave);
            panel3.Location = new Point(455, 694);
            panel3.Name = "panel3";
            panel3.Size = new Size(576, 125);
            panel3.TabIndex = 11;

            // ── panel1 (main content area) ────────────────────────────────
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label7);            // ← NEW
            panel1.Controls.Add(clbRequirements);   // ← NEW
            panel1.Controls.Add(txtJobDescription);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbDepartment);
            panel1.Controls.Add(txtQualifications);
            panel1.Controls.Add(cmbEmploymentType);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtJobTitle);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(190, 153);
            panel1.Name = "panel1";
            panel1.Size = new Size(1401, 836);
            panel1.TabIndex = 11;

            // ── BackButton ────────────────────────────────────────────────
            BackButton.FlatAppearance.BorderColor = Color.White;
            BackButton.FlatAppearance.BorderSize = 2;
            BackButton.FlatStyle = FlatStyle.Flat;
            BackButton.Font = new Font("Century", 10.2F);
            BackButton.ForeColor = Color.White;
            BackButton.Location = new Point(669, 8);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(189, 119);
            BackButton.TabIndex = 15;
            BackButton.Text = "BACK TO DASHBOARD";
            BackButton.UseVisualStyleBackColor = true;

            // ── label6 (JOB DEVELOPMENT header) ──────────────────────────
            label6.AutoSize = true;
            label6.Font = new Font("Century", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(55, 33);
            label6.Name = "label6";
            label6.Size = new Size(486, 54);
            label6.TabIndex = 1;
            label6.Text = "JOB DEVELOPMENT";

            // ── panel2 (top header bar) ───────────────────────────────────
            panel2.BackColor = Color.SlateBlue;
            panel2.Controls.Add(BackButton);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(1017, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(891, 132);
            panel2.TabIndex = 11;

            // ── AddOrEditForm ─────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddOrEditForm";
            Text = "AddOrEditForm";
            Load += AddOrEditForm_Load;

            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtJobTitle;
        private Label label1;
        private TextBox txtJobDescription;
        private Label label4;
        private ComboBox cmbEmploymentType;
        private Label label3;
        private ComboBox cmbDepartment;
        private Label label2;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtQualifications;
        private Label label5;
        private OpenFileDialog openFileDialog1;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Button BackButton;
        private Label label6;
        private System.Windows.Forms.CheckedListBox clbRequirements;   // ← NEW
        private Label label7;                // ← NEW
    }
}