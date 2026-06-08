namespace HRApplicant_system.Forms
{
    partial class Interview_Evaluation
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
            this.lvInterviews = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblApplicant = new System.Windows.Forms.Label();
            this.lblApplicantValue = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.nudScore = new System.Windows.Forms.NumericUpDown();
            this.cmbResult = new System.Windows.Forms.ComboBox();
            this.rtbRemarks = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudScore)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Location = new System.Drawing.Point(105, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(358, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Interview Evaluation";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(12, 60);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(151, 22);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search Applicant:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(169, 60);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 26);
            this.txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(439, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 35);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // lvInterviews
            // 
            this.lvInterviews.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvInterviews.FullRowSelect = true;
            this.lvInterviews.GridLines = true;
            this.lvInterviews.HideSelection = false;
            this.lvInterviews.Location = new System.Drawing.Point(26, 101);
            this.lvInterviews.Name = "lvInterviews";
            this.lvInterviews.Size = new System.Drawing.Size(540, 180);
            this.lvInterviews.TabIndex = 5;
            this.lvInterviews.UseCompatibleStateImageBehavior = false;
            this.lvInterviews.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Interview ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Applicant Name";
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Scheduled Date";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.Width = 100;
            // 
            // lblApplicant
            // 
            this.lblApplicant.AutoSize = true;
            this.lblApplicant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicant.Location = new System.Drawing.Point(21, 284);
            this.lblApplicant.Name = "lblApplicant";
            this.lblApplicant.Size = new System.Drawing.Size(109, 25);
            this.lblApplicant.TabIndex = 6;
            this.lblApplicant.Text = "Applicant:";
            // 
            // lblApplicantValue
            // 
            this.lblApplicantValue.AutoSize = true;
            this.lblApplicantValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicantValue.Location = new System.Drawing.Point(164, 284);
            this.lblApplicantValue.Name = "lblApplicantValue";
            this.lblApplicantValue.Size = new System.Drawing.Size(19, 25);
            this.lblApplicantValue.TabIndex = 7;
            this.lblApplicantValue.Text = "-";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(21, 324);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(154, 25);
            this.lblScore.TabIndex = 8;
            this.lblScore.Text = "Score (0-100):";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(21, 366);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(79, 25);
            this.lblResult.TabIndex = 10;
            this.lblResult.Text = "Result:";
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(21, 405);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(103, 25);
            this.lblRemarks.TabIndex = 12;
            this.lblRemarks.Text = "Remarks:";
            // 
            // nudScore
            // 
            this.nudScore.Location = new System.Drawing.Point(181, 326);
            this.nudScore.Name = "nudScore";
            this.nudScore.Size = new System.Drawing.Size(100, 26);
            this.nudScore.TabIndex = 13;
            // 
            // cmbResult
            // 
            this.cmbResult.FormattingEnabled = true;
            this.cmbResult.Items.AddRange(new object[] {
            "Pass",
            "Fail",
            "For Further Review"});
            this.cmbResult.Location = new System.Drawing.Point(181, 363);
            this.cmbResult.Name = "cmbResult";
            this.cmbResult.Size = new System.Drawing.Size(150, 28);
            this.cmbResult.TabIndex = 14;
            // 
            // rtbRemarks
            // 
            this.rtbRemarks.Location = new System.Drawing.Point(16, 433);
            this.rtbRemarks.Name = "rtbRemarks";
            this.rtbRemarks.Size = new System.Drawing.Size(500, 80);
            this.rtbRemarks.TabIndex = 15;
            this.rtbRemarks.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(27, 519);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 35);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save Evaluation";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(439, 519);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(77, 35);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // Interview_Evaluation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 568);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rtbRemarks);
            this.Controls.Add(this.cmbResult);
            this.Controls.Add(this.nudScore);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblApplicantValue);
            this.Controls.Add(this.lblApplicant);
            this.Controls.Add(this.lvInterviews);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblTitle);
            this.Name = "Interview_Evaluation";
            this.Text = "Interview_Evaluation";
            ((System.ComponentModel.ISupportInitialize)(this.nudScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvInterviews;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblApplicant;
        private System.Windows.Forms.Label lblApplicantValue;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.NumericUpDown nudScore;
        private System.Windows.Forms.ComboBox cmbResult;
        private System.Windows.Forms.RichTextBox rtbRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
    }
}