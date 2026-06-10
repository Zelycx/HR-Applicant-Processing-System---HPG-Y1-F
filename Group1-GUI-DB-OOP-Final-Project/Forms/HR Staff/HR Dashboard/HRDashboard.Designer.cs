namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR
{
    partial class HRDashboard
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
            btnLogout = new Button();
            btnJobVacancy = new Button();
            btnApplicants = new Button();
            btnReports = new Button();
            btnDepartments = new Button();
            btnUsers = new Button();
            btnMaintenance = new Button();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(321, 258);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += Button1_Click;
            // 
            // btnJobVacancy
            // 
            btnJobVacancy.Location = new Point(201, 143);
            btnJobVacancy.Name = "btnJobVacancy";
            btnJobVacancy.Size = new Size(101, 23);
            btnJobVacancy.TabIndex = 1;
            btnJobVacancy.Text = "Job Vacancy";
            btnJobVacancy.UseVisualStyleBackColor = true;
            btnJobVacancy.Click += btnJobVacancy_Click;
            // 
            // btnApplicants
            // 
            btnApplicants.Location = new Point(214, 172);
            btnApplicants.Name = "btnApplicants";
            btnApplicants.Size = new Size(75, 23);
            btnApplicants.TabIndex = 2;
            btnApplicants.Text = "Applicants";
            btnApplicants.UseVisualStyleBackColor = true;
            btnApplicants.Click += btnApplicants_Click;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(410, 143);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(75, 23);
            btnReports.TabIndex = 3;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnDepartments
            // 
            btnDepartments.Location = new Point(410, 172);
            btnDepartments.Name = "btnDepartments";
            btnDepartments.Size = new Size(94, 23);
            btnDepartments.TabIndex = 4;
            btnDepartments.Text = "Departments";
            btnDepartments.UseVisualStyleBackColor = true;
            btnDepartments.Click += btnDepartments_Click;
            // 
            // btnUsers
            // 
            btnUsers.Location = new Point(191, 201);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(130, 23);
            btnUsers.TabIndex = 5;
            btnUsers.Text = "User Management";
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnMaintenance
            // 
            btnMaintenance.Location = new Point(410, 201);
            btnMaintenance.Name = "btnMaintenance";
            btnMaintenance.Size = new Size(87, 23);
            btnMaintenance.TabIndex = 6;
            btnMaintenance.Text = "Maintenance";
            btnMaintenance.UseVisualStyleBackColor = true;
            // 
            // HRDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMaintenance);
            Controls.Add(btnUsers);
            Controls.Add(btnDepartments);
            Controls.Add(btnReports);
            Controls.Add(btnApplicants);
            Controls.Add(btnJobVacancy);
            Controls.Add(btnLogout);
            Name = "HRDashboard";
            Text = "HRDashboard";
            FormClosed += HRDashboard_FormClosed;
            Load += HRDashboard_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnLogout;
        private Button btnJobVacancy;
        private Button btnApplicants;
        private Button btnReports;
        private Button btnDepartments;
        private Button btnUsers;
        private Button btnMaintenance;
    }
}