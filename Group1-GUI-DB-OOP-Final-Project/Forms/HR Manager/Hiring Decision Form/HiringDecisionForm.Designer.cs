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
            dgvApplications = new DataGridView();
            lblRemarks = new Label();
            txtRemarks = new TextBox();
            btnAccept = new Button();
            btnReject = new Button();
            btnHold = new Button();
            btnLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).BeginInit();
            SuspendLayout();
            // 
            // dgvApplications
            // 
            dgvApplications.AllowUserToAddRows = false;
            dgvApplications.AllowUserToDeleteRows = false;
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplications.Location = new Point(20, 20);
            dgvApplications.MultiSelect = false;
            dgvApplications.Name = "dgvApplications";
            dgvApplications.ReadOnly = true;
            dgvApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApplications.Size = new Size(940, 300);
            dgvApplications.TabIndex = 0;
            // 
            // lblRemarks
            // 
            lblRemarks.AutoSize = true;
            lblRemarks.Location = new Point(20, 340);
            lblRemarks.Name = "lblRemarks";
            lblRemarks.Size = new Size(55, 15);
            lblRemarks.TabIndex = 1;
            lblRemarks.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            txtRemarks.Location = new Point(90, 335);
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(600, 23);
            txtRemarks.TabIndex = 2;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(20, 390);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(120, 40);
            btnAccept.TabIndex = 3;
            btnAccept.Text = "Accept";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(160, 390);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(120, 40);
            btnReject.TabIndex = 3;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // btnHold
            // 
            btnHold.Location = new Point(300, 390);
            btnHold.Name = "btnHold";
            btnHold.Size = new Size(120, 40);
            btnHold.TabIndex = 3;
            btnHold.Text = "Hold";
            btnHold.UseVisualStyleBackColor = true;
            btnHold.Click += btnHold_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(440, 390);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(180, 40);
            btnLoad.TabIndex = 4;
            btnLoad.Text = "Load Applications";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // HiringDecisionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(btnLoad);
            Controls.Add(btnHold);
            Controls.Add(btnReject);
            Controls.Add(btnAccept);
            Controls.Add(txtRemarks);
            Controls.Add(lblRemarks);
            Controls.Add(dgvApplications);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(20, 20);
            MaximizeBox = false;
            Name = "HiringDecisionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HiringDecisionForm";
            Load += HiringDecisionForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvApplications;
        private Label lblRemarks;
        private TextBox txtRemarks;
        private Button btnAccept;
        private Button btnReject;
        private Button btnHold;
        private Button btnLoad;
    }
}