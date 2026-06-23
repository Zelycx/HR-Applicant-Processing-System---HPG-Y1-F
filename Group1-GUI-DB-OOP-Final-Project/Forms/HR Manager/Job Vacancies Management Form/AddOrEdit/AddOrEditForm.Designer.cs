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
            lblTitle = new Label();
            grpDetails = new GroupBox();
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
            grpDetails.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(250, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(130, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add / Edit Job Vacancy";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // grpDetails
            // 
            grpDetails.Controls.Add(btnSave);
            grpDetails.Controls.Add(btnCancel);
            grpDetails.Controls.Add(txtQualifications);
            grpDetails.Controls.Add(label5);
            grpDetails.Controls.Add(txtJobDescription);
            grpDetails.Controls.Add(label4);
            grpDetails.Controls.Add(cmbEmploymentType);
            grpDetails.Controls.Add(label3);
            grpDetails.Controls.Add(cmbDepartment);
            grpDetails.Controls.Add(label2);
            grpDetails.Controls.Add(txtJobTitle);
            grpDetails.Controls.Add(label1);
            grpDetails.Location = new Point(30, 60);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(620, 420);
            grpDetails.TabIndex = 1;
            grpDetails.TabStop = false;
            grpDetails.Text = "Job Details";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(150, 349);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 35);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(330, 349);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 35);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtQualifications
            // 
            txtQualifications.Location = new Point(150, 255);
            txtQualifications.Multiline = true;
            txtQualifications.Name = "txtQualifications";
            txtQualifications.Size = new Size(400, 80);
            txtQualifications.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 260);
            label5.Name = "label5";
            label5.Size = new Size(80, 15);
            label5.TabIndex = 8;
            label5.Text = "Qualifications";
            // 
            // txtJobDescription
            // 
            txtJobDescription.Location = new Point(150, 155);
            txtJobDescription.Multiline = true;
            txtJobDescription.Name = "txtJobDescription";
            txtJobDescription.Size = new Size(400, 80);
            txtJobDescription.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 160);
            label4.Name = "label4";
            label4.Size = new Size(88, 15);
            label4.TabIndex = 6;
            label4.Text = "Job Description";
            // 
            // cmbEmploymentType
            // 
            cmbEmploymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmploymentType.FormattingEnabled = true;
            cmbEmploymentType.Location = new Point(150, 115);
            cmbEmploymentType.Name = "cmbEmploymentType";
            cmbEmploymentType.Size = new Size(250, 23);
            cmbEmploymentType.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 120);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 4;
            label3.Text = "Employment Type";
            // 
            // cmbDepartment
            // 
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(150, 75);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(250, 23);
            cmbDepartment.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 80);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 2;
            label2.Text = "Department";
            // 
            // txtJobTitle
            // 
            txtJobTitle.Location = new Point(150, 35);
            txtJobTitle.Name = "txtJobTitle";
            txtJobTitle.Size = new Size(400, 23);
            txtJobTitle.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 40);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Job Title";
            // 
            // AddOrEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpDetails);
            Controls.Add(lblTitle);
            Name = "AddOrEditForm";
            Text = "AddOrEditForm";
            Load += AddOrEditForm_Load;
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private GroupBox grpDetails;
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
    }
}