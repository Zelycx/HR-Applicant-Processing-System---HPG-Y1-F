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
            panelTop = new Panel();
            lblReportsTitle = new Label();
            cmbFilterStatus = new ComboBox();
            txtSearch = new TextBox();
            btnRefresh = new Button();
            dgvReports = new DataGridView();
            panelBottom = new Panel();
            lblTotal = new Label();
            lblPending = new Label();
            lblInterview = new Label();
            lblAccepted = new Label();
            lblRejected = new Label();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(txtSearch);
            panelTop.Controls.Add(cmbFilterStatus);
            panelTop.Controls.Add(lblReportsTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(887, 100);
            panelTop.TabIndex = 0;
            // 
            // lblReportsTitle
            // 
            lblReportsTitle.AutoSize = true;
            lblReportsTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReportsTitle.Location = new Point(20, 25);
            lblReportsTitle.Name = "lblReportsTitle";
            lblReportsTitle.Size = new Size(189, 30);
            lblReportsTitle.TabIndex = 0;
            lblReportsTitle.Text = "REPORTS CENTER";
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.FormattingEnabled = true;
            cmbFilterStatus.Items.AddRange(new object[] { "All", "Pending", "Interview", "Accepted", "Rejected" });
            cmbFilterStatus.Location = new Point(350, 30);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(160, 23);
            cmbFilterStatus.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(540, 30);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search Applicant Name...";
            txtSearch.Size = new Size(200, 23);
            txtSearch.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(760, 23);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dgvReports
            // 
            dgvReports.AllowUserToAddRows = false;
            dgvReports.AllowUserToDeleteRows = false;
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReports.BackgroundColor = Color.White;
            dgvReports.BorderStyle = BorderStyle.None;
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Dock = DockStyle.Fill;
            dgvReports.Location = new Point(0, 100);
            dgvReports.MultiSelect = false;
            dgvReports.Name = "dgvReports";
            dgvReports.ReadOnly = true;
            dgvReports.RowHeadersVisible = false;
            dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReports.Size = new Size(887, 421);
            dgvReports.TabIndex = 2;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.White;
            panelBottom.Controls.Add(lblRejected);
            panelBottom.Controls.Add(lblAccepted);
            panelBottom.Controls.Add(lblInterview);
            panelBottom.Controls.Add(lblPending);
            panelBottom.Controls.Add(lblTotal);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 421);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(887, 100);
            panelBottom.TabIndex = 3;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(20, 25);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(44, 15);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total: 0";
            // 
            // lblPending
            // 
            lblPending.AutoSize = true;
            lblPending.Location = new Point(150, 25);
            lblPending.Name = "lblPending";
            lblPending.Size = new Size(63, 15);
            lblPending.TabIndex = 0;
            lblPending.Text = "Pending: 0";
            // 
            // lblInterview
            // 
            lblInterview.AutoSize = true;
            lblInterview.Location = new Point(300, 25);
            lblInterview.Name = "lblInterview";
            lblInterview.Size = new Size(67, 15);
            lblInterview.TabIndex = 0;
            lblInterview.Text = "Interview: 0";
            // 
            // lblAccepted
            // 
            lblAccepted.AutoSize = true;
            lblAccepted.Location = new Point(450, 25);
            lblAccepted.Name = "lblAccepted";
            lblAccepted.Size = new Size(69, 15);
            lblAccepted.TabIndex = 0;
            lblAccepted.Text = "Accepted: 0";
            // 
            // lblRejected
            // 
            lblRejected.AutoSize = true;
            lblRejected.Location = new Point(600, 25);
            lblRejected.Name = "lblRejected";
            lblRejected.Size = new Size(64, 15);
            lblRejected.TabIndex = 0;
            lblRejected.Text = "Rejected: 0";
            // 
            // Reports
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 521);
            Controls.Add(panelBottom);
            Controls.Add(dgvReports);
            Controls.Add(btnRefresh);
            Controls.Add(panelTop);
            Name = "Reports";
            Text = "Reports";
            WindowState = FormWindowState.Maximized;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private ComboBox cmbFilterStatus;
        private Label lblReportsTitle;
        private TextBox txtSearch;
        private Button btnRefresh;
        private DataGridView dgvReports;
        private Panel panelBottom;
        private Label lblRejected;
        private Label lblAccepted;
        private Label lblInterview;
        private Label lblPending;
        private Label lblTotal;
    }
}