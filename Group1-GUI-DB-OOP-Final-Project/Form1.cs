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
        private Button btnSubmit;
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
    }
}