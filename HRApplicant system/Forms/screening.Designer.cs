namespace HRApplicant_system.Forms
{
    partial class screening
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvApplicants = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblApplicant = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.rtbRemarks = new System.Windows.Forms.RichTextBox();
            this.btnQualified = new System.Windows.Forms.Button();
            this.btnNotQualified = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Location = new System.Drawing.Point(140, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(356, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Applicant Screening";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(65, 55);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(72, 22);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(143, 54);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 26);
            this.txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(399, 55);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 35);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // lvApplicants
            // 
            this.lvApplicants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvApplicants.FullRowSelect = true;
            this.lvApplicants.GridLines = true;
            this.lvApplicants.HideSelection = false;
            this.lvApplicants.Location = new System.Drawing.Point(12, 96);
            this.lvApplicants.Name = "lvApplicants";
            this.lvApplicants.Size = new System.Drawing.Size(640, 220);
            this.lvApplicants.TabIndex = 5;
            this.lvApplicants.UseCompatibleStateImageBehavior = false;
            this.lvApplicants.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "App ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Applicant Name";
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Position";
            this.columnHeader3.Width = 180;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date Applied";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status";
            this.columnHeader5.Width = 80;
            // 
            // lblApplicant
            // 
            this.lblApplicant.AutoSize = true;
            this.lblApplicant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicant.Location = new System.Drawing.Point(12, 319);
            this.lblApplicant.Name = "lblApplicant";
            this.lblApplicant.Size = new System.Drawing.Size(109, 25);
            this.lblApplicant.TabIndex = 6;
            this.lblApplicant.Text = "Applicant:";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(12, 344);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(96, 25);
            this.lblPosition.TabIndex = 8;
            this.lblPosition.Text = "Position:";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(12, 369);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(207, 25);
            this.lblRemarks.TabIndex = 10;
            this.lblRemarks.Text = "Screening Remarks:";
            // 
            // rtbRemarks
            // 
            this.rtbRemarks.Location = new System.Drawing.Point(12, 397);
            this.rtbRemarks.Name = "rtbRemarks";
            this.rtbRemarks.Size = new System.Drawing.Size(600, 80);
            this.rtbRemarks.TabIndex = 11;
            this.rtbRemarks.Text = "";
            // 
            // btnQualified
            // 
            this.btnQualified.BackColor = System.Drawing.Color.Green;
            this.btnQualified.ForeColor = System.Drawing.Color.White;
            this.btnQualified.Location = new System.Drawing.Point(52, 483);
            this.btnQualified.Name = "btnQualified";
            this.btnQualified.Size = new System.Drawing.Size(167, 32);
            this.btnQualified.TabIndex = 12;
            this.btnQualified.Text = "Mark as Qualified";
            this.btnQualified.UseVisualStyleBackColor = false;
            // 
            // btnNotQualified
            // 
            this.btnNotQualified.BackColor = System.Drawing.Color.Red;
            this.btnNotQualified.ForeColor = System.Drawing.Color.White;
            this.btnNotQualified.Location = new System.Drawing.Point(261, 485);
            this.btnNotQualified.Name = "btnNotQualified";
            this.btnNotQualified.Size = new System.Drawing.Size(193, 32);
            this.btnNotQualified.TabIndex = 13;
            this.btnNotQualified.Text = "Mark as Not Qualified";
            this.btnNotQualified.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(532, 483);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 32);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // screening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 529);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNotQualified);
            this.Controls.Add(this.btnQualified);
            this.Controls.Add(this.rtbRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblApplicant);
            this.Controls.Add(this.lvApplicants);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblTitle);
            this.Name = "screening";
            this.Text = "screening";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvApplicants;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblApplicant;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.RichTextBox rtbRemarks;
        private System.Windows.Forms.Button btnQualified;
        private System.Windows.Forms.Button btnNotQualified;
        private System.Windows.Forms.Button btnBack;
    }
}