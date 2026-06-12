namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR
{
    partial class Reports
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
            dgvReports = new DataGridView();
            btnAll = new Button();
            btnPending = new Button();
            btnAccepted = new Button();
            btnRejected = new Button();
            btnOnHold = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            SuspendLayout();
            // 
            // dgvReports
            // 
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(86, 261);
            dgvReports.Name = "dgvReports";
            dgvReports.Size = new Size(240, 150);
            dgvReports.TabIndex = 0;
            // 
            // btnAll
            // 
            btnAll.Location = new Point(98, 184);
            btnAll.Name = "btnAll";
            btnAll.Size = new Size(75, 23);
            btnAll.TabIndex = 1;
            btnAll.Text = "All Applicants";
            btnAll.UseVisualStyleBackColor = true;
            btnAll.Click += btnAll_Click;
            // 
            // btnPending
            // 
            btnPending.Location = new Point(179, 184);
            btnPending.Name = "btnPending";
            btnPending.Size = new Size(75, 23);
            btnPending.TabIndex = 1;
            btnPending.Text = "Pending";
            btnPending.UseVisualStyleBackColor = true;
            btnPending.Click += btnPending_Click;
            // 
            // btnAccepted
            // 
            btnAccepted.Location = new Point(260, 184);
            btnAccepted.Name = "btnAccepted";
            btnAccepted.Size = new Size(75, 23);
            btnAccepted.TabIndex = 1;
            btnAccepted.Text = "Accepted";
            btnAccepted.UseVisualStyleBackColor = true;
            btnAccepted.Click += btnAccepted_Click;
            // 
            // btnRejected
            // 
            btnRejected.Location = new Point(341, 184);
            btnRejected.Name = "btnRejected";
            btnRejected.Size = new Size(75, 23);
            btnRejected.TabIndex = 1;
            btnRejected.Text = "Rejected";
            btnRejected.UseVisualStyleBackColor = true;
            btnRejected.Click += btnRejected_Click;
            // 
            // btnOnHold
            // 
            btnOnHold.Location = new Point(422, 184);
            btnOnHold.Name = "btnOnHold";
            btnOnHold.Size = new Size(75, 23);
            btnOnHold.TabIndex = 1;
            btnOnHold.Text = "On Hold";
            btnOnHold.UseVisualStyleBackColor = true;
            btnOnHold.Click += btnOnHold_Click;
            // 
            // Reports
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOnHold);
            Controls.Add(btnRejected);
            Controls.Add(btnAccepted);
            Controls.Add(btnPending);
            Controls.Add(btnAll);
            Controls.Add(dgvReports);
            Name = "Reports";
            Text = "Reports";
            Load += Reports_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvReports;
        private Button btnAll;
        private Button btnPending;
        private Button btnAccepted;
        private Button btnRejected;
        private Button btnOnHold;
    }
}