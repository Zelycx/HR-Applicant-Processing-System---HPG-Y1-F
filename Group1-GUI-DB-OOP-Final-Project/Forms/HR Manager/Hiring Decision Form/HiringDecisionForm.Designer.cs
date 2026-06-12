namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR_Manager
{
    partial class HiringDecisionForm
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
            colStatus = new DataGridViewTextBoxColumn();
            colRemarks = new DataGridViewTextBoxColumn();
            btnAccept = new Button();
            btnReject = new Button();
            btnHold = new Button();
            label1 = new Label();
            txtRemarks = new TextBox();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvApplicants).BeginInit();
            SuspendLayout();
            // 
            // dgvApplicants
            // 
            dgvApplicants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplicants.Columns.AddRange(new DataGridViewColumn[] { colApplicantID, colFullName, colPosition, colStatus, colRemarks });
            dgvApplicants.Location = new Point(96, 268);
            dgvApplicants.Name = "dgvApplicants";
            dgvApplicants.Size = new Size(532, 150);
            dgvApplicants.TabIndex = 0;
            dgvApplicants.CellClick += dgvApplicants_CellClick;
            // 
            // colApplicantID
            // 
            colApplicantID.HeaderText = "ID";
            colApplicantID.Name = "colApplicantID";
            // 
            // colFullName
            // 
            colFullName.HeaderText = "Full Name";
            colFullName.Name = "colFullName";
            // 
            // colPosition
            // 
            colPosition.HeaderText = "Position";
            colPosition.Name = "colPosition";
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            // 
            // colRemarks
            // 
            colRemarks.HeaderText = "Remarks";
            colRemarks.Name = "colRemarks";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(128, 217);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(75, 23);
            btnAccept.TabIndex = 1;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(209, 217);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(75, 23);
            btnReject.TabIndex = 1;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // btnHold
            // 
            btnHold.Location = new Point(290, 217);
            btnHold.Name = "btnHold";
            btnHold.Size = new Size(75, 23);
            btnHold.TabIndex = 1;
            btnHold.Text = "On Hold";
            btnHold.UseVisualStyleBackColor = true;
            btnHold.Click += btnHold_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(133, 179);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 2;
            label1.Text = "Final Remarks";
            // 
            // txtRemarks
            // 
            txtRemarks.Location = new Point(219, 176);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(100, 23);
            txtRemarks.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(164, 142);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(89, 15);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status: Pending";
            // 
            // HiringDecisionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStatus);
            Controls.Add(txtRemarks);
            Controls.Add(label1);
            Controls.Add(btnHold);
            Controls.Add(btnReject);
            Controls.Add(btnAccept);
            Controls.Add(dgvApplicants);
            Name = "HiringDecisionForm";
            Text = "HiringDecisionForm";
            Load += HiringDecisionForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvApplicants).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvApplicants;
        private DataGridViewTextBoxColumn colApplicantID;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colPosition;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colRemarks;
        private Button btnAccept;
        private Button btnReject;
        private Button btnHold;
        private Label label1;
        private TextBox txtRemarks;
        private Label lblStatus;
    }
}