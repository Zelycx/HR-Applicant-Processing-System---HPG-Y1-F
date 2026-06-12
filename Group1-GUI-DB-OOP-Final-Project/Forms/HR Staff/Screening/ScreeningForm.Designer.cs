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
            dgvScreening = new DataGridView();
            colApplicantID = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colPosition = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            label1 = new Label();
            txtSelectedApplicant = new TextBox();
            btnAccept = new Button();
            btnReject = new Button();
            btnPending = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvScreening).BeginInit();
            SuspendLayout();
            // 
            // dgvScreening
            // 
            dgvScreening.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScreening.Columns.AddRange(new DataGridViewColumn[] { colApplicantID, colFullName, colPosition, colStatus });
            dgvScreening.Location = new Point(12, 126);
            dgvScreening.Name = "dgvScreening";
            dgvScreening.Size = new Size(776, 146);
            dgvScreening.TabIndex = 0;
            dgvScreening.CellContentClick += dataGridView1_CellContentClick;
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
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 88);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 1;
            label1.Text = "Selected Applicants:";
            // 
            // txtSelectedApplicant
            // 
            txtSelectedApplicant.Location = new Point(172, 85);
            txtSelectedApplicant.Name = "txtSelectedApplicant";
            txtSelectedApplicant.ReadOnly = true;
            txtSelectedApplicant.Size = new Size(100, 23);
            txtSelectedApplicant.TabIndex = 2;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(91, 296);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 23);
            btnAccept.TabIndex = 3;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(172, 296);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(75, 23);
            btnReject.TabIndex = 3;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            // 
            // btnPending
            // 
            btnPending.Location = new Point(253, 296);
            btnPending.Name = "btnPending";
            btnPending.Size = new Size(75, 23);
            btnPending.TabIndex = 3;
            btnPending.Text = "Pending";
            btnPending.UseVisualStyleBackColor = true;
            // 
            // Screening
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPending);
            Controls.Add(btnReject);
            Controls.Add(btnAccept);
            Controls.Add(txtSelectedApplicant);
            Controls.Add(label1);
            Controls.Add(dgvScreening);
            Name = "Screening";
            Text = "Screening";
            Load += Screening_Load;
            ((System.ComponentModel.ISupportInitialize)dgvScreening).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvScreening;
        private DataGridViewTextBoxColumn colApplicantID;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colPosition;
        private DataGridViewTextBoxColumn colStatus;
        private Label label1;
        private TextBox txtSelectedApplicant;
        private Button btnAccept;
        private Button btnReject;
        private Button btnPending;
    }
}