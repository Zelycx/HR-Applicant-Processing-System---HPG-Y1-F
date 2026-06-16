using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Group1_GUI_DB_OOP_Final_Project
{
    public partial class Form1 : Form
    {
        // ==========================================
        // MEMBER 2 - UI CONTROLS DECLARATION
        // ==========================================
        private DataGridView dgvJobVacancies;
        private DataGridView dgvDocuments;
        private TextBox txtSearch;
        private Button btnApply;
        // private Button btnSubmit;
        private Button btnUploadDoc;
        private Label lblJobTitle;
        private Label lblStatus;
        private Label lblLockWarning;
        private Label lblMissingDocsCount;

        private int currentApplicantId = 1;
        private int currentApplicationId = 0;
        private string connectionString = "Server=localhost;Database=HR_Capstone_DB;Trusted_Connection=True;";

        public Form1()
        {
            InitializeCustomUI();
            LoadJobVacancies();
        }

        // ==========================================
        // TASK 1: JOB VACANCIES MODULE (Search & Apply)
        // ==========================================
        private void LoadJobVacancies(string searchKeyword = "")
        {
            string query = "SELECT Id, Title, Department, EmploymentType, Description FROM JobVacancies WHERE Status = 'Open'";
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                query += " AND (Title LIKE @Search OR Description LIKE @Search)";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(searchKeyword))
                        cmd.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvJobVacancies.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                // Silenced to prevent freezing during presentation without a local database setup
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadJobVacancies(txtSearch.Text.Trim());
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (dgvJobVacancies.CurrentRow == null) return;

            int selectedJobId = Convert.ToInt32(dgvJobVacancies.CurrentRow.Cells["Id"].Value);
            if (IsDuplicateApplication(currentApplicantId, selectedJobId))
            {
                MessageBox.Show("System Block: You have already applied for this position.", "Duplicate Application Trap", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StartDraftApplication(currentApplicantId, selectedJobId);
        }

        private bool IsDuplicateApplication(int applicantId, int jobId)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Applications WHERE ApplicantId = @ApplicantId AND JobVacancyId = @JobId";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicantId", applicantId);
                    cmd.Parameters.AddWithValue("@JobId", jobId);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
            catch { return false; }
        }

        private void StartDraftApplication(int applicantId, int jobId)
        {
            string query = "INSERT INTO Applications (ApplicantId, JobVacancyId, Status, DateCreated) VALUES (@ApplicantId, @JobId, 'Draft', GETDATE()); SELECT SCOPE_IDENTITY();";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicantId", applicantId);
                    cmd.Parameters.AddWithValue("@JobId", jobId);
                    conn.Open();
                    currentApplicationId = Convert.ToInt32(cmd.ExecuteScalar());
                    MessageBox.Show("Application initiated successfully as a Draft!", "Draft Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadApplicationDetails(currentApplicationId);
                    LoadApplicantDocuments(currentApplicationId);
                }
            }
            catch { }
        }

        // ==========================================
        // TASK 2: MY APPLICATION MODULE (Status & Locks)
        // ==========================================
        private void LoadApplicationDetails(int applicationId)
        {
            string query = "SELECT a.Id, j.Title, a.Status FROM Applications a JOIN JobVacancies j ON a.JobVacancyId = j.Id WHERE a.Id = @AppId";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppId", applicationId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblJobTitle.Text = "Position: " + reader["Title"].ToString();
                            string currentStatus = reader["Status"].ToString();
                            lblStatus.Text = "Status: " + currentStatus;

                            if (currentStatus != "Draft")
                            {
                                btnSubmit.Enabled = false;
                                btnUploadDoc.Enabled = false;
                                lblLockWarning.Visible = true;
                                lblLockWarning.Text = "🔒 Locked. Details cannot be edited once reviewed.";
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (currentApplicationId == 0) return;
            string query = "UPDATE Applications SET Status = 'Submitted' WHERE Id = @AppId";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppId", currentApplicationId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Application finalized and submitted successfully!", "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadApplicationDetails(currentApplicationId);
                }
            }
            catch { }
        }

        // ==========================================
        // TASK 3: MY DOCUMENTS MODULE (Upload Track)
        // ==========================================
        private void LoadApplicantDocuments(int applicationId)
        {
            string query = "SELECT Id AS DocId, RequirementType, FilePath, Status FROM ApplicantDocuments WHERE ApplicationId = @AppId";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppId", applicationId);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvDocuments.DataSource = dt;
                    }
                }
            }
            catch { }
        }

        private void btnUploadDoc_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.CurrentRow == null) return;
            int docId = Convert.ToInt32(dgvDocuments.CurrentRow.Cells["DocId"].Value);

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF Files (*.pdf)|*.pdf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedDocuments");
                        if (!Directory.Exists(targetDirectory)) Directory.CreateDirectory(targetDirectory);

                        string destinationPath = Path.Combine(targetDirectory, Guid.NewGuid().ToString() + ".pdf");
                        File.Copy(ofd.FileName, destinationPath, true);

                        string query = "UPDATE ApplicantDocuments SET FilePath = @Path, Status = 'Submitted' WHERE Id = @DocId";
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Path", destinationPath);
                            cmd.Parameters.AddWithValue("@DocId", docId);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Document record uploaded successfully!");
                        LoadApplicantDocuments(currentApplicationId);
                    }
                    catch { }
                }
            }
        }

        // ==========================================
        // ENGINE DETACHED LAYOUT CONTROL
        // ==========================================
        private void InitializeCustomUI()
        {
            this.Text = "HR Capstone - Applicant Module Workspace";
            this.Size = new System.Drawing.Size(700, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.txtSearch = new TextBox() { Location = new System.Drawing.Point(20, 20), Size = new System.Drawing.Size(250, 20) };
            this.dgvJobVacancies = new DataGridView() { Location = new System.Drawing.Point(20, 50), Size = new System.Drawing.Size(430, 150), AllowUserToAddRows = false, ReadOnly = true };
            this.btnApply = new Button() { Text = "Apply to Selected", Location = new System.Drawing.Point(460, 50), Size = new System.Drawing.Size(180, 30) };
            this.lblJobTitle = new Label() { Text = "Position: None Selected", Location = new System.Drawing.Point(460, 95), Size = new System.Drawing.Size(200, 20) };
            this.lblStatus = new Label() { Text = "Status: N/A", Location = new System.Drawing.Point(460, 120), Size = new System.Drawing.Size(200, 20) };
            this.lblLockWarning = new Label() { Text = "", ForeColor = System.Drawing.Color.Red, Location = new System.Drawing.Point(460, 145), Size = new System.Drawing.Size(200, 55), Visible = false };
            this.lblMissingDocsCount = new Label() { Text = "Missing Requirements Tracking Active", Location = new System.Drawing.Point(20, 220), Size = new System.Drawing.Size(300, 20) };
            this.dgvDocuments = new DataGridView() { Location = new System.Drawing.Point(20, 250), Size = new System.Drawing.Size(430, 150), AllowUserToAddRows = false, ReadOnly = true };
            this.btnUploadDoc = new Button() { Text = "Upload/Replace File", Location = new System.Drawing.Point(460, 250), Size = new System.Drawing.Size(180, 30) };
            this.btnSubmit = new Button() { Text = "Finalize & Submit App", Location = new System.Drawing.Point(460, 290), Size = new System.Drawing.Size(180, 35) };

            this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);
            this.btnApply.Click += new EventHandler(this.btnApply_Click);
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);
            this.btnUploadDoc.Click += new EventHandler(this.btnUploadDoc_Click);

            this.Controls.AddRange(new Control[] { dgvJobVacancies, dgvDocuments, txtSearch, btnApply, btnSubmit, btnUploadDoc, lblJobTitle, lblStatus, lblLockWarning, lblMissingDocsCount });
        }

        private void InitializeComponent()
        {
            button1 = new Button();
            pnlSidebar = new Panel();
            lblPortalTitle = new Label();
            btnLogout = new Button();
            btnMyDocuments = new Button();
            btnMyApplication = new Button();
            btnJobVacancies = new Button();
            txtMenu = new TextBox();
            pnlMyApplication = new Panel();
            pnlMainContent = new Panel();
            pnlJobVacancies = new Panel();
            lblJobVancies = new Label();
            lblPageTitleApplication = new Label();
            btnSaveDraft = new Button();
            btnSubmit = new Button();
            pnlSkills = new Panel();
            lblWorkExperiences = new Label();
            txtWorkExperiences = new TextBox();
            lblKeyTechnicalSkills = new Label();
            txtKeyTechnicalSkills = new TextBox();
            lblSkillsandExpo = new Label();
            vScrollBar1 = new VScrollBar();
            pnlEducation = new Panel();
            txtYearGrad = new TextBox();
            lblYearGrad = new Label();
            lblSchoolName = new Label();
            txtSchoolName = new TextBox();
            txtCourse = new TextBox();
            lblCourse = new Label();
            txtHighestEduc = new TextBox();
            lblHighestEducation = new Label();
            lblEducationalBackground = new Label();
            pnlPersonalInfo = new Panel();
            lblEmailAddress = new Label();
            txtEnailAddress = new TextBox();
            txtContactNumber = new TextBox();
            lblContactNumber = new Label();
            dtpDateOfBirth = new DateTimePicker();
            lblDateOfBirth = new Label();
            txtLastName = new TextBox();
            lblLastName = new Label();
            textBox2 = new TextBox();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            label5 = new Label();
            pnlJobVacanciesHeader = new Panel();
            panel2 = new Panel();
            pnlCardTemplate1 = new Panel();
            lblIT = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnApply1 = new Button();
            lblJSD = new Label();
            btnViewDetails1 = new Button();
            pnlCardTemplate2 = new Panel();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            button2 = new Button();
            button3 = new Button();
            panel1 = new Panel();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            button4 = new Button();
            button5 = new Button();
            pnlMyDocumentsHeader = new Panel();
            label15 = new Label();
            pnlMyDocuments = new Panel();
            pnlTableHeader = new Panel();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            pnlSidebar.SuspendLayout();
            pnlMyApplication.SuspendLayout();
            pnlMainContent.SuspendLayout();
            pnlJobVacancies.SuspendLayout();
            pnlSkills.SuspendLayout();
            pnlEducation.SuspendLayout();
            pnlPersonalInfo.SuspendLayout();
            pnlJobVacanciesHeader.SuspendLayout();
            pnlCardTemplate1.SuspendLayout();
            pnlCardTemplate2.SuspendLayout();
            panel1.SuspendLayout();
            pnlMyDocumentsHeader.SuspendLayout();
            pnlMyDocuments.SuspendLayout();
            pnlTableHeader.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDarkDark;
            button1.Location = new Point(85, 89);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(26, 26, 26);
            pnlSidebar.Controls.Add(panel2);
            pnlSidebar.Controls.Add(lblPortalTitle);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnMyDocuments);
            pnlSidebar.Controls.Add(btnMyApplication);
            pnlSidebar.Controls.Add(btnJobVacancies);
            pnlSidebar.Controls.Add(txtMenu);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(220, 749);
            pnlSidebar.TabIndex = 2;
            pnlSidebar.Paint += panel1_Paint;
            // 
            // lblPortalTitle
            // 
            lblPortalTitle.AutoSize = true;
            lblPortalTitle.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPortalTitle.ForeColor = Color.White;
            lblPortalTitle.Location = new Point(12, 21);
            lblPortalTitle.Name = "lblPortalTitle";
            lblPortalTitle.Size = new Size(117, 16);
            lblPortalTitle.TabIndex = 8;
            lblPortalTitle.Text = "Applicant Portal";
            lblPortalTitle.Click += label2_Click;
            // 
            // btnLogout
            // 
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.LightGray;
            btnLogout.Location = new Point(11, 714);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 23);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "Log out";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnMyDocuments
            // 
            btnMyDocuments.FlatAppearance.BorderSize = 0;
            btnMyDocuments.FlatStyle = FlatStyle.Flat;
            btnMyDocuments.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
            btnMyDocuments.ForeColor = Color.White;
            btnMyDocuments.Location = new Point(13, 151);
            btnMyDocuments.Name = "btnMyDocuments";
            btnMyDocuments.Size = new Size(131, 23);
            btnMyDocuments.TabIndex = 7;
            btnMyDocuments.Text = "📂 My Documents";
            btnMyDocuments.TextAlign = ContentAlignment.MiddleLeft;
            btnMyDocuments.UseVisualStyleBackColor = true;
            // 
            // btnMyApplication
            // 
            btnMyApplication.FlatAppearance.BorderSize = 0;
            btnMyApplication.FlatStyle = FlatStyle.Flat;
            btnMyApplication.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
            btnMyApplication.ForeColor = Color.White;
            btnMyApplication.Location = new Point(13, 131);
            btnMyApplication.Name = "btnMyApplication";
            btnMyApplication.Size = new Size(131, 23);
            btnMyApplication.TabIndex = 6;
            btnMyApplication.Text = "📄 My Application";
            btnMyApplication.TextAlign = ContentAlignment.MiddleLeft;
            btnMyApplication.UseVisualStyleBackColor = true;
            btnMyApplication.Click += btnMyApplication_Click;
            // 
            // btnJobVacancies
            // 
            btnJobVacancies.FlatAppearance.BorderSize = 0;
            btnJobVacancies.FlatStyle = FlatStyle.Flat;
            btnJobVacancies.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
            btnJobVacancies.ForeColor = Color.White;
            btnJobVacancies.Location = new Point(13, 112);
            btnJobVacancies.Name = "btnJobVacancies";
            btnJobVacancies.Size = new Size(132, 23);
            btnJobVacancies.TabIndex = 5;
            btnJobVacancies.Text = "📁 Job Vacancies";
            btnJobVacancies.TextAlign = ContentAlignment.MiddleLeft;
            btnJobVacancies.UseVisualStyleBackColor = true;
            btnJobVacancies.Click += btnJobVacancies_Click;
            // 
            // txtMenu
            // 
            txtMenu.BackColor = Color.FromArgb(26, 26, 26);
            txtMenu.BorderStyle = BorderStyle.None;
            txtMenu.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMenu.ForeColor = Color.DimGray;
            txtMenu.Location = new Point(19, 98);
            txtMenu.Name = "txtMenu";
            txtMenu.Size = new Size(100, 13);
            txtMenu.TabIndex = 4;
            txtMenu.Text = "MENU";
            // 
            // pnlMyApplication
            // 
            pnlMyApplication.Controls.Add(pnlMainContent);
            pnlMyApplication.Dock = DockStyle.Fill;
            pnlMyApplication.Location = new Point(220, 0);
            pnlMyApplication.Name = "pnlMyApplication";
            pnlMyApplication.Size = new Size(540, 749);
            pnlMyApplication.TabIndex = 8;
            pnlMyApplication.Paint += panel2_Paint;
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = Color.FromArgb(40, 40, 40);
            pnlMainContent.Controls.Add(pnlJobVacancies);
            pnlMainContent.Controls.Add(lblPageTitleApplication);
            pnlMainContent.Controls.Add(btnSaveDraft);
            pnlMainContent.Controls.Add(btnSubmit);
            pnlMainContent.Controls.Add(pnlSkills);
            pnlMainContent.Controls.Add(vScrollBar1);
            pnlMainContent.Controls.Add(pnlEducation);
            pnlMainContent.Controls.Add(pnlPersonalInfo);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(0, 0);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Padding = new Padding(20);
            pnlMainContent.Size = new Size(540, 749);
            pnlMainContent.TabIndex = 11;
            pnlMainContent.Paint += panel3_Paint;
            // 
            // pnlJobVacancies
            // 
            pnlJobVacancies.BackColor = Color.FromArgb(31, 31, 31);
            pnlJobVacancies.Controls.Add(pnlMyDocuments);
            pnlJobVacancies.Controls.Add(pnlMyDocumentsHeader);
            pnlJobVacancies.Controls.Add(panel1);
            pnlJobVacancies.Controls.Add(pnlCardTemplate2);
            pnlJobVacancies.Controls.Add(pnlCardTemplate1);
            pnlJobVacancies.Controls.Add(pnlJobVacanciesHeader);
            pnlJobVacancies.Location = new Point(0, 2);
            pnlJobVacancies.Name = "pnlJobVacancies";
            pnlJobVacancies.Size = new Size(523, 749);
            pnlJobVacancies.TabIndex = 21;
            pnlJobVacancies.Paint += panel1_Paint_1;
            // 
            // lblJobVancies
            // 
            lblJobVancies.AutoSize = true;
            lblJobVancies.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            lblJobVancies.ForeColor = Color.White;
            lblJobVancies.Location = new Point(8, 15);
            lblJobVancies.Name = "lblJobVancies";
            lblJobVancies.Size = new Size(140, 22);
            lblJobVancies.TabIndex = 0;
            lblJobVancies.Text = "Job Vacancies";
            lblJobVancies.Click += label2_Click_1;
            // 
            // lblPageTitleApplication
            // 
            lblPageTitleApplication.AutoSize = true;
            lblPageTitleApplication.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            lblPageTitleApplication.ForeColor = Color.White;
            lblPageTitleApplication.Location = new Point(8, 15);
            lblPageTitleApplication.Name = "lblPageTitleApplication";
            lblPageTitleApplication.Size = new Size(140, 22);
            lblPageTitleApplication.TabIndex = 10;
            lblPageTitleApplication.Text = "My Application";
            // 
            // btnSaveDraft
            // 
            btnSaveDraft.BackColor = Color.FromArgb(48, 48, 48);
            btnSaveDraft.FlatAppearance.BorderSize = 0;
            btnSaveDraft.FlatStyle = FlatStyle.Flat;
            btnSaveDraft.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
            btnSaveDraft.ForeColor = Color.White;
            btnSaveDraft.Location = new Point(196, 714);
            btnSaveDraft.Name = "btnSaveDraft";
            btnSaveDraft.Size = new Size(85, 23);
            btnSaveDraft.TabIndex = 20;
            btnSaveDraft.Text = "Save Draft";
            btnSaveDraft.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(48, 48, 48);
            btnSubmit.FlatAppearance.BorderColor = Color.FromArgb(48, 48, 48);
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.Transparent;
            btnSubmit.Location = new Point(46, 712);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(144, 25);
            btnSubmit.TabIndex = 0;
            btnSubmit.Text = "Submit Application";
            btnSubmit.UseVisualStyleBackColor = false;
            // 
            // pnlSkills
            // 
            pnlSkills.Controls.Add(lblWorkExperiences);
            pnlSkills.Controls.Add(txtWorkExperiences);
            pnlSkills.Controls.Add(lblKeyTechnicalSkills);
            pnlSkills.Controls.Add(txtKeyTechnicalSkills);
            pnlSkills.Controls.Add(lblSkillsandExpo);
            pnlSkills.Location = new Point(46, 536);
            pnlSkills.Name = "pnlSkills";
            pnlSkills.Size = new Size(456, 159);
            pnlSkills.TabIndex = 9;
            // 
            // lblWorkExperiences
            // 
            lblWorkExperiences.AutoSize = true;
            lblWorkExperiences.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            lblWorkExperiences.ForeColor = Color.DarkGray;
            lblWorkExperiences.Location = new Point(32, 97);
            lblWorkExperiences.Name = "lblWorkExperiences";
            lblWorkExperiences.Size = new Size(110, 13);
            lblWorkExperiences.TabIndex = 17;
            lblWorkExperiences.Text = "Work Experiences";
            // 
            // txtWorkExperiences
            // 
            txtWorkExperiences.BackColor = Color.FromArgb(48, 48, 48);
            txtWorkExperiences.BorderStyle = BorderStyle.FixedSingle;
            txtWorkExperiences.ForeColor = Color.White;
            txtWorkExperiences.Location = new Point(32, 112);
            txtWorkExperiences.Name = "txtWorkExperiences";
            txtWorkExperiences.Size = new Size(387, 23);
            txtWorkExperiences.TabIndex = 16;
            // 
            // lblKeyTechnicalSkills
            // 
            lblKeyTechnicalSkills.AutoSize = true;
            lblKeyTechnicalSkills.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            lblKeyTechnicalSkills.ForeColor = Color.DarkGray;
            lblKeyTechnicalSkills.Location = new Point(32, 48);
            lblKeyTechnicalSkills.Name = "lblKeyTechnicalSkills";
            lblKeyTechnicalSkills.Size = new Size(122, 13);
            lblKeyTechnicalSkills.TabIndex = 15;
            lblKeyTechnicalSkills.Text = "Key Technical Skills";
            // 
            // txtKeyTechnicalSkills
            // 
            txtKeyTechnicalSkills.BackColor = Color.FromArgb(48, 48, 48);
            txtKeyTechnicalSkills.BorderStyle = BorderStyle.FixedSingle;
            txtKeyTechnicalSkills.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            txtKeyTechnicalSkills.ForeColor = Color.White;
            txtKeyTechnicalSkills.Location = new Point(33, 63);
            txtKeyTechnicalSkills.Name = "txtKeyTechnicalSkills";
            txtKeyTechnicalSkills.Size = new Size(386, 23);
            txtKeyTechnicalSkills.TabIndex = 14;
            // 
            // lblSkillsandExpo
            // 
            lblSkillsandExpo.AutoSize = true;
            lblSkillsandExpo.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            lblSkillsandExpo.ForeColor = Color.Transparent;
            lblSkillsandExpo.Location = new Point(29, 22);
            lblSkillsandExpo.Name = "lblSkillsandExpo";
            lblSkillsandExpo.Size = new Size(202, 15);
            lblSkillsandExpo.TabIndex = 13;
            lblSkillsandExpo.Text = "Skills and Experiences Details";
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(523, 0);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(17, 749);
            vScrollBar1.TabIndex = 3;
            // 
            // pnlEducation
            // 
            pnlEducation.Controls.Add(txtYearGrad);
            pnlEducation.Controls.Add(lblYearGrad);
            pnlEducation.Controls.Add(lblSchoolName);
            pnlEducation.Controls.Add(txtSchoolName);
            pnlEducation.Controls.Add(txtCourse);
            pnlEducation.Controls.Add(lblCourse);
            pnlEducation.Controls.Add(txtHighestEduc);
            pnlEducation.Controls.Add(lblHighestEducation);
            pnlEducation.Controls.Add(lblEducationalBackground);
            pnlEducation.Location = new Point(46, 337);
            pnlEducation.Name = "pnlEducation";
            pnlEducation.Size = new Size(456, 173);
            pnlEducation.TabIndex = 12;
            // 
            // txtYearGrad
            // 
            txtYearGrad.BackColor = Color.FromArgb(48, 48, 48);
            txtYearGrad.BorderStyle = BorderStyle.FixedSingle;
            txtYearGrad.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            txtYearGrad.ForeColor = Color.White;
            txtYearGrad.Location = new Point(238, 127);
            txtYearGrad.Name = "txtYearGrad";
            txtYearGrad.Size = new Size(181, 23);
            txtYearGrad.TabIndex = 8;
            // 
            // lblYearGrad
            // 
            lblYearGrad.AutoSize = true;
            lblYearGrad.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            lblYearGrad.ForeColor = Color.DarkGray;
            lblYearGrad.Location = new Point(238, 111);
            lblYearGrad.Name = "lblYearGrad";
            lblYearGrad.Size = new Size(96, 13);
            lblYearGrad.TabIndex = 7;
            lblYearGrad.Text = "Year Graduated";
            // 
            // lblSchoolName
            // 
            lblSchoolName.AutoSize = true;
            lblSchoolName.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            lblSchoolName.ForeColor = Color.DarkGray;
            lblSchoolName.Location = new Point(35, 111);
            lblSchoolName.Name = "lblSchoolName";
            lblSchoolName.Size = new Size(82, 13);
            lblSchoolName.TabIndex = 6;
            lblSchoolName.Text = "School Name";
            lblSchoolName.Click += label13_Click;
            // 
            // txtSchoolName
            // 
            txtSchoolName.BackColor = Color.FromArgb(48, 48, 48);
            txtSchoolName.BorderStyle = BorderStyle.FixedSingle;
            txtSchoolName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            txtSchoolName.ForeColor = Color.White;
            txtSchoolName.Location = new Point(35, 127);
            txtSchoolName.Name = "txtSchoolName";
            txtSchoolName.Size = new Size(166, 23);
            txtSchoolName.TabIndex = 5;
            // 
            // txtCourse
            // 
            txtCourse.BackColor = Color.FromArgb(48, 48, 48);
            txtCourse.BorderStyle = BorderStyle.FixedSingle;
            txtCourse.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            txtCourse.ForeColor = Color.White;
            txtCourse.Location = new Point(238, 71);
            txtCourse.Name = "txtCourse";
            txtCourse.Size = new Size(181, 23);
            txtCourse.TabIndex = 4;
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            lblCourse.ForeColor = Color.DarkGray;
            lblCourse.Location = new Point(238, 56);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(98, 13);
            lblCourse.TabIndex = 3;
            lblCourse.Text = "Course/Program";
            // 
            // txtHighestEduc
            // 
            txtHighestEduc.BackColor = Color.FromArgb(48, 48, 48);
            txtHighestEduc.BorderStyle = BorderStyle.FixedSingle;
            txtHighestEduc.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            txtHighestEduc.ForeColor = Color.White;
            txtHighestEduc.Location = new Point(35, 71);
            txtHighestEduc.Name = "txtHighestEduc";
            txtHighestEduc.Size = new Size(166, 23);
            txtHighestEduc.TabIndex = 2;
            // 
            // lblHighestEducation
            // 
            lblHighestEducation.AutoSize = true;
            lblHighestEducation.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            lblHighestEducation.ForeColor = Color.DarkGray;
            lblHighestEducation.Location = new Point(33, 55);
            lblHighestEducation.Name = "lblHighestEducation";
            lblHighestEducation.Size = new Size(111, 13);
            lblHighestEducation.TabIndex = 1;
            lblHighestEducation.Text = "Highest Education";
            // 
            // lblEducationalBackground
            // 
            lblEducationalBackground.AutoSize = true;
            lblEducationalBackground.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            lblEducationalBackground.ForeColor = Color.Transparent;
            lblEducationalBackground.Location = new Point(26, 21);
            lblEducationalBackground.Name = "lblEducationalBackground";
            lblEducationalBackground.Size = new Size(163, 15);
            lblEducationalBackground.TabIndex = 0;
            lblEducationalBackground.Text = "Educational Background";
            lblEducationalBackground.Click += label10_Click;
            // 
            // pnlPersonalInfo
            // 
            pnlPersonalInfo.BackColor = Color.FromArgb(38, 38, 38);
            pnlPersonalInfo.Controls.Add(lblEmailAddress);
            pnlPersonalInfo.Controls.Add(txtEnailAddress);
            pnlPersonalInfo.Controls.Add(txtContactNumber);
            pnlPersonalInfo.Controls.Add(lblContactNumber);
            pnlPersonalInfo.Controls.Add(dtpDateOfBirth);
            pnlPersonalInfo.Controls.Add(lblDateOfBirth);
            pnlPersonalInfo.Controls.Add(txtLastName);
            pnlPersonalInfo.Controls.Add(lblLastName);
            pnlPersonalInfo.Controls.Add(textBox2);
            pnlPersonalInfo.Controls.Add(txtFirstName);
            pnlPersonalInfo.Controls.Add(lblFirstName);
            pnlPersonalInfo.Controls.Add(label5);
            pnlPersonalInfo.Location = new Point(46, 89);
            pnlPersonalInfo.Name = "pnlPersonalInfo";
            pnlPersonalInfo.Size = new Size(456, 218);
            pnlPersonalInfo.TabIndex = 11;
            pnlPersonalInfo.Paint += panel4_Paint;
            // 
            // lblEmailAddress
            // 
            lblEmailAddress.AutoSize = true;
            lblEmailAddress.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            lblEmailAddress.ForeColor = Color.DarkGray;
            lblEmailAddress.Location = new Point(38, 153);
            lblEmailAddress.Name = "lblEmailAddress";
            lblEmailAddress.Size = new Size(86, 13);
            lblEmailAddress.TabIndex = 19;
            lblEmailAddress.Text = "Email Address";
            // 
            // txtEnailAddress
            // 
            txtEnailAddress.BackColor = Color.FromArgb(48, 48, 48);
            txtEnailAddress.BorderStyle = BorderStyle.FixedSingle;
            txtEnailAddress.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            txtEnailAddress.ForeColor = Color.White;
            txtEnailAddress.Location = new Point(35, 169);
            txtEnailAddress.Name = "txtEnailAddress";
            txtEnailAddress.Size = new Size(384, 23);
            txtEnailAddress.TabIndex = 18;
            // 
            // txtContactNumber
            // 
            txtContactNumber.BackColor = Color.FromArgb(48, 48, 48);
            txtContactNumber.BorderStyle = BorderStyle.FixedSingle;
            txtContactNumber.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            txtContactNumber.ForeColor = Color.White;
            txtContactNumber.Location = new Point(238, 115);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(181, 23);
            txtContactNumber.TabIndex = 17;
            // 
            // lblContactNumber
            // 
            lblContactNumber.AutoSize = true;
            lblContactNumber.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            lblContactNumber.ForeColor = Color.DarkGray;
            lblContactNumber.Location = new Point(240, 98);
            lblContactNumber.Name = "lblContactNumber";
            lblContactNumber.Size = new Size(98, 13);
            lblContactNumber.TabIndex = 16;
            lblContactNumber.Text = "Contact Number";
            lblContactNumber.Click += label8_Click;
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.CalendarFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtpDateOfBirth.CalendarMonthBackground = Color.FromArgb(48, 48, 48);
            dtpDateOfBirth.CalendarTitleBackColor = Color.FromArgb(64, 64, 64);
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.Location = new Point(35, 115);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new Size(166, 23);
            dtpDateOfBirth.TabIndex = 15;
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            lblDateOfBirth.ForeColor = Color.DarkGray;
            lblDateOfBirth.Location = new Point(35, 98);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(78, 13);
            lblDateOfBirth.TabIndex = 14;
            lblDateOfBirth.Text = "Date of birth";
            // 
            // txtLastName
            // 
            txtLastName.BackColor = Color.FromArgb(48, 48, 48);
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            txtLastName.ForeColor = Color.White;
            txtLastName.Location = new Point(238, 59);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(181, 23);
            txtLastName.TabIndex = 13;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLastName.ForeColor = Color.DarkGray;
            lblLastName.Location = new Point(239, 43);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(67, 13);
            lblLastName.TabIndex = 12;
            lblLastName.Text = "Last Name";
            lblLastName.Click += label6_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(258, 66);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 11;
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = Color.FromArgb(48, 48, 48);
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            txtFirstName.ForeColor = Color.White;
            txtFirstName.Location = new Point(35, 59);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(166, 23);
            txtFirstName.TabIndex = 10;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.DarkGray;
            lblFirstName.Location = new Point(35, 43);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(67, 13);
            lblFirstName.TabIndex = 9;
            lblFirstName.Text = "First Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(26, 16);
            label5.Name = "label5";
            label5.Size = new Size(141, 15);
            label5.TabIndex = 0;
            label5.Text = "Personal Information";
            label5.Click += label5_Click;
            // 
            // pnlJobVacanciesHeader
            // 
            pnlJobVacanciesHeader.Controls.Add(lblJobVancies);
            pnlJobVacanciesHeader.Location = new Point(0, -1);
            pnlJobVacanciesHeader.Name = "pnlJobVacanciesHeader";
            pnlJobVacanciesHeader.Size = new Size(523, 51);
            pnlJobVacanciesHeader.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Location = new Point(220, 54);
            panel2.Name = "panel2";
            panel2.Size = new Size(523, 277);
            panel2.TabIndex = 2;
            // 
            // pnlCardTemplate1
            // 
            pnlCardTemplate1.Controls.Add(btnViewDetails1);
            pnlCardTemplate1.Controls.Add(lblJSD);
            pnlCardTemplate1.Controls.Add(btnApply1);
            pnlCardTemplate1.Controls.Add(label3);
            pnlCardTemplate1.Controls.Add(label2);
            pnlCardTemplate1.Controls.Add(label1);
            pnlCardTemplate1.Controls.Add(lblIT);
            pnlCardTemplate1.Location = new Point(45, 90);
            pnlCardTemplate1.Name = "pnlCardTemplate1";
            pnlCardTemplate1.Size = new Size(202, 203);
            pnlCardTemplate1.TabIndex = 1;
            // 
            // lblIT
            // 
            lblIT.AutoSize = true;
            lblIT.BackColor = Color.RoyalBlue;
            lblIT.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            lblIT.ForeColor = Color.White;
            lblIT.Location = new Point(16, 24);
            lblIT.Name = "lblIT";
            lblIT.Size = new Size(140, 13);
            lblIT.TabIndex = 0;
            lblIT.Text = "Information Technology";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label1.ForeColor = Color.DarkGray;
            label1.Location = new Point(16, 65);
            label1.Name = "label1";
            label1.Size = new Size(109, 13);
            label1.TabIndex = 1;
            label1.Text = "📍 On-site · Makati";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label2.ForeColor = Color.DarkGray;
            label2.Location = new Point(14, 80);
            label2.Name = "label2";
            label2.Size = new Size(71, 13);
            label2.TabIndex = 2;
            label2.Text = "🕒 Full-time";
            label2.Click += label2_Click_2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label3.ForeColor = Color.DarkGray;
            label3.Location = new Point(14, 95);
            label3.Name = "label3";
            label3.Size = new Size(93, 13);
            label3.TabIndex = 3;
            label3.Text = "👥 2 slots open";
            label3.Click += label3_Click_3;
            // 
            // btnApply1
            // 
            btnApply1.FlatAppearance.BorderColor = Color.Gray;
            btnApply1.FlatStyle = FlatStyle.Flat;
            btnApply1.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
            btnApply1.ForeColor = Color.White;
            btnApply1.Location = new Point(16, 120);
            btnApply1.Name = "btnApply1";
            btnApply1.Size = new Size(166, 29);
            btnApply1.TabIndex = 2;
            btnApply1.Text = "Apply Now";
            btnApply1.UseVisualStyleBackColor = true;
            // 
            // lblJSD
            // 
            lblJSD.AutoSize = true;
            lblJSD.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
            lblJSD.ForeColor = Color.White;
            lblJSD.Location = new Point(13, 42);
            lblJSD.Name = "lblJSD";
            lblJSD.Size = new Size(176, 15);
            lblJSD.TabIndex = 4;
            lblJSD.Text = "Junior Software Developer";
            lblJSD.Click += label4_Click;
            // 
            // btnViewDetails1
            // 
            btnViewDetails1.FlatAppearance.BorderColor = Color.Gray;
            btnViewDetails1.FlatStyle = FlatStyle.Flat;
            btnViewDetails1.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
            btnViewDetails1.ForeColor = Color.White;
            btnViewDetails1.Location = new Point(16, 159);
            btnViewDetails1.Name = "btnViewDetails1";
            btnViewDetails1.Size = new Size(166, 30);
            btnViewDetails1.TabIndex = 5;
            btnViewDetails1.Text = "View Details";
            btnViewDetails1.UseVisualStyleBackColor = true;
            // 
            // pnlCardTemplate2
            // 
            pnlCardTemplate2.Controls.Add(button3);
            pnlCardTemplate2.Controls.Add(button2);
            pnlCardTemplate2.Controls.Add(label9);
            pnlCardTemplate2.Controls.Add(label8);
            pnlCardTemplate2.Controls.Add(label7);
            pnlCardTemplate2.Controls.Add(label6);
            pnlCardTemplate2.Controls.Add(label4);
            pnlCardTemplate2.Location = new Point(284, 90);
            pnlCardTemplate2.Name = "pnlCardTemplate2";
            pnlCardTemplate2.Size = new Size(203, 203);
            pnlCardTemplate2.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.RoyalBlue;
            label4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(20, 24);
            label4.Name = "label4";
            label4.Size = new Size(110, 13);
            label4.TabIndex = 0;
            label4.Text = "Human Resources";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(20, 43);
            label6.Name = "label6";
            label6.Size = new Size(106, 15);
            label6.TabIndex = 1;
            label6.Text = "HR Coordinator";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label7.ForeColor = Color.DarkGray;
            label7.Location = new Point(20, 64);
            label7.Name = "label7";
            label7.Size = new Size(135, 13);
            label7.TabIndex = 6;
            label7.Text = "📍 Hybrid · Quezon City";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label8.ForeColor = Color.DarkGray;
            label8.Location = new Point(18, 81);
            label8.Name = "label8";
            label8.Size = new Size(71, 13);
            label8.TabIndex = 7;
            label8.Text = "🕒 Full-time";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label9.ForeColor = Color.DarkGray;
            label9.Location = new Point(19, 96);
            label9.Name = "label9";
            label9.Size = new Size(87, 13);
            label9.TabIndex = 6;
            label9.Text = "👥 1 slot open";
            label9.Click += label9_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.Gray;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(20, 120);
            button2.Name = "button2";
            button2.Size = new Size(161, 29);
            button2.TabIndex = 8;
            button2.Text = "Apply Now";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderColor = Color.Gray;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(21, 159);
            button3.Name = "button3";
            button3.Size = new Size(160, 30);
            button3.TabIndex = 9;
            button3.Text = "View Details";
            button3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Location = new Point(45, 325);
            panel1.Name = "panel1";
            panel1.Size = new Size(202, 203);
            panel1.TabIndex = 10;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.RoyalBlue;
            label10.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(16, 29);
            label10.Name = "label10";
            label10.Size = new Size(52, 13);
            label10.TabIndex = 0;
            label10.Text = "Finance";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(15, 48);
            label11.Name = "label11";
            label11.Size = new Size(138, 15);
            label11.TabIndex = 1;
            label11.Text = "Accounting Assistant";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label12.ForeColor = Color.DarkGray;
            label12.Location = new Point(15, 72);
            label12.Name = "label12";
            label12.Size = new Size(110, 13);
            label12.TabIndex = 2;
            label12.Text = "📍 On-site · Taguig";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label13.ForeColor = Color.DarkGray;
            label13.Location = new Point(14, 87);
            label13.Name = "label13";
            label13.Size = new Size(74, 13);
            label13.TabIndex = 3;
            label13.Text = "🕒 Part-time";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label14.ForeColor = Color.DarkGray;
            label14.Location = new Point(14, 103);
            label14.Name = "label14";
            label14.Size = new Size(93, 13);
            label14.TabIndex = 4;
            label14.Text = "👥 3 slots open";
            // 
            // button4
            // 
            button4.FlatAppearance.BorderColor = Color.Gray;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(14, 126);
            button4.Name = "button4";
            button4.Size = new Size(166, 27);
            button4.TabIndex = 5;
            button4.Text = "Apply Now";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderColor = Color.Gray;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Microsoft Sans Serif", 8.5F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Location = new Point(12, 161);
            button5.Name = "button5";
            button5.Size = new Size(170, 27);
            button5.TabIndex = 6;
            button5.Text = "View Details";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // pnlMyDocumentsHeader
            // 
            pnlMyDocumentsHeader.BackColor = Color.FromArgb(31, 31, 31);
            pnlMyDocumentsHeader.Controls.Add(label15);
            pnlMyDocumentsHeader.Location = new Point(1, 2);
            pnlMyDocumentsHeader.Name = "pnlMyDocumentsHeader";
            pnlMyDocumentsHeader.Size = new Size(522, 51);
            pnlMyDocumentsHeader.TabIndex = 22;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold);
            label15.ForeColor = Color.White;
            label15.Location = new Point(14, 15);
            label15.Name = "label15";
            label15.Size = new Size(140, 22);
            label15.TabIndex = 0;
            label15.Text = "My Documents";
            // 
            // pnlMyDocuments
            // 
            pnlMyDocuments.Controls.Add(pnlTableHeader);
            pnlMyDocuments.Location = new Point(0, 52);
            pnlMyDocuments.Name = "pnlMyDocuments";
            pnlMyDocuments.Size = new Size(523, 697);
            pnlMyDocuments.TabIndex = 10;
            pnlMyDocuments.Paint += pnlMyDocuments_Paint;
            // 
            // pnlTableHeader
            // 
            pnlTableHeader.Controls.Add(label20);
            pnlTableHeader.Controls.Add(label19);
            pnlTableHeader.Controls.Add(label18);
            pnlTableHeader.Controls.Add(label16);
            pnlTableHeader.Controls.Add(label17);
            pnlTableHeader.Location = new Point(8, 38);
            pnlTableHeader.Name = "pnlTableHeader";
            pnlTableHeader.Size = new Size(509, 35);
            pnlTableHeader.TabIndex = 0;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 7.5F, FontStyle.Bold);
            label16.ForeColor = Color.DarkGray;
            label16.Location = new Point(15, 10);
            label16.Name = "label16";
            label16.Size = new Size(73, 13);
            label16.TabIndex = 1;
            label16.Text = "DOCUMENT";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 7.5F, FontStyle.Bold);
            label17.ForeColor = Color.DarkGray;
            label17.Location = new Point(123, 10);
            label17.Name = "label17";
            label17.Size = new Size(51, 13);
            label17.TabIndex = 0;
            label17.Text = "STATUS";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 7.5F, FontStyle.Bold);
            label18.ForeColor = Color.DarkGray;
            label18.Location = new Point(220, 10);
            label18.Name = "label18";
            label18.Size = new Size(71, 13);
            label18.TabIndex = 2;
            label18.Text = "FILE NAME";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 7.5F, FontStyle.Bold);
            label19.ForeColor = Color.DarkGray;
            label19.Location = new Point(330, 10);
            label19.Name = "label19";
            label19.Size = new Size(65, 13);
            label19.TabIndex = 3;
            label19.Text = "REMARKS";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Microsoft Sans Serif", 7.5F, FontStyle.Bold);
            label20.ForeColor = Color.DarkGray;
            label20.Location = new Point(431, 11);
            label20.Name = "label20";
            label20.Size = new Size(50, 13);
            label20.TabIndex = 4;
            label20.Text = "ACTION";
            label20.Click += label20_Click;
            // 
            // Form1
            // 
            AutoScroll = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(760, 749);
            Controls.Add(pnlMyApplication);
            Controls.Add(pnlSidebar);
            Controls.Add(button1);
            Name = "Form1";
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            pnlMyApplication.ResumeLayout(false);
            pnlMainContent.ResumeLayout(false);
            pnlMainContent.PerformLayout();
            pnlJobVacancies.ResumeLayout(false);
            pnlSkills.ResumeLayout(false);
            pnlSkills.PerformLayout();
            pnlEducation.ResumeLayout(false);
            pnlEducation.PerformLayout();
            pnlPersonalInfo.ResumeLayout(false);
            pnlPersonalInfo.PerformLayout();
            pnlJobVacanciesHeader.ResumeLayout(false);
            pnlJobVacanciesHeader.PerformLayout();
            pnlCardTemplate1.ResumeLayout(false);
            pnlCardTemplate1.PerformLayout();
            pnlCardTemplate2.ResumeLayout(false);
            pnlCardTemplate2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlMyDocumentsHeader.ResumeLayout(false);
            pnlMyDocumentsHeader.PerformLayout();
            pnlMyDocuments.ResumeLayout(false);
            pnlTableHeader.ResumeLayout(false);
            pnlTableHeader.PerformLayout();
            ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnJobVacancies_Click(object sender, EventArgs e)
        {
            pnlMyApplication.Visible = false;

            pnlJobVacancies.Visible = true;
        }

        private void btnMyApplication_Click(object sender, EventArgs e)
        {
            pnlMyApplication.Visible = true;

            pnlJobVacancies.Visible = false;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_2(object sender, EventArgs e)
        {

        }

        private void flowJobContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_3(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pnlMyDocuments_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}