using Group1_GUI_DB_OOP_Final_Project.Database;
using Group1_GUI_DB_OOP_Final_Project.Forms.Applicant;
using Group1_GUI_DB_OOP_Final_Project.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Group1_GUI_DB_OOP_Final_Project.Forms
{
    public partial class Document : Form
    {
        private readonly ApplicantAccounts _account;

        // Holds chosen local file path per requirement before Upload is clicked
        private readonly Dictionary<string, string> _pendingFiles = new Dictionary<string, string>();

        // RequirementName -> RequirementTypeID from DB
        private readonly Dictionary<string, int> _requirementTypeMap = new Dictionary<string, int>();

        private int _applicantID = -1;
        private int _applicationID = -1;
        private bool _isLocked = false;

        public Document(ApplicantAccounts account)
        {
            InitializeComponent();
            _account = account;
        }

        // ══════════════════════════════════════════════════════════════════
        //  FORM LOAD
        // ══════════════════════════════════════════════════════════════════

        private void Document_Load(object sender, EventArgs e)
        {
            LoadApplicantAndApplication();
            BuildRequirementTypeMap();
            LoadDocuments();
            ApplyLockState();
        }

        // ══════════════════════════════════════════════════════════════════
        //  DATA LOADING
        // ══════════════════════════════════════════════════════════════════

        private void LoadApplicantAndApplication()
        {
            try
            {
                using (var conn = new DatabaseConnector().GetConnection())
                {
                    conn.Open();

                    // Resolve ApplicantID
                    string sqlApplicant = @"
                        SELECT ApplicantID FROM applicants
                        WHERE ApplicantAccountID = @id LIMIT 1";
                    using (var cmd = new MySqlCommand(sqlApplicant, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _account.ApplicantAccountID);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                            _applicantID = Convert.ToInt32(result);
                    }

                    if (_applicantID == -1) return;

                    // Resolve latest active ApplicationID
                    string sqlApp = @"
                        SELECT ApplicationID, IsLocked
                        FROM applications
                        WHERE ApplicantID = @aid
                          AND CurrentStatus NOT IN ('Withdrawn')
                        ORDER BY ApplicationDate DESC LIMIT 1";
                    using (var cmd = new MySqlCommand(sqlApp, conn))
                    {
                        cmd.Parameters.AddWithValue("@aid", _applicantID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _applicationID = Convert.ToInt32(reader["ApplicationID"]);
                                _isLocked = Convert.ToBoolean(reader["IsLocked"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading applicant data:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuildRequirementTypeMap()
        {
            try
            {
                using (var conn = new DatabaseConnector().GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT RequirementTypeID, RequirementName FROM requirementtypes";
                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _requirementTypeMap[reader["RequirementName"].ToString()] =
                                Convert.ToInt32(reader["RequirementTypeID"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading requirement types:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDocuments()
        {
            dataGridView1.Rows.Clear();

            if (_applicationID == -1)
            {
                // No application yet — show all requirement types as Missing
                foreach (var kvp in _requirementTypeMap)
                {
                    dataGridView1.Rows.Add(
                        DBNull.Value,
                        kvp.Key,
                        "(not uploaded)",
                        DBNull.Value,
                        "Missing"
                    );
                }
                return;
            }

            try
            {
                using (var conn = new DatabaseConnector().GetConnection())
                {
                    conn.Open();

                    // All requirement types LEFT JOINed with any submitted doc
                    string sql = @"
                        SELECT
                            rt.RequirementTypeID,
                            rt.RequirementName,
                            ad.ApplicantDocumentID,
                            ad.FileName,
                            ad.UploadedAt
                        FROM requirementtypes rt
                        LEFT JOIN applicantdocuments ad
                            ON ad.RequirementTypeID = rt.RequirementTypeID
                           AND ad.ApplicationID = @appID
                        ORDER BY rt.RequirementTypeID";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@appID", _applicationID);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bool hasDoc =
                                    !reader.IsDBNull(reader.GetOrdinal("ApplicantDocumentID"));

                                dataGridView1.Rows.Add(
                                    hasDoc ? reader["ApplicantDocumentID"] : (object)DBNull.Value,
                                    reader["RequirementName"].ToString(),
                                    hasDoc ? reader["FileName"].ToString() : "(not uploaded)",
                                    hasDoc ? reader["UploadedAt"] : (object)DBNull.Value,
                                    hasDoc ? "Submitted" : "Missing"
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading documents:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyLockState()
        {
            bool canEdit = !_isLocked && _applicationID != -1;

            // UploadRequiredDocumentsPanel browse buttons  (exact names from Designer)
            ResumeBrowseButton.Enabled = canEdit;
            ValidIBrowseButton.Enabled = canEdit;   // ValidIBrowseButton (note: ValidI not ValidID)
            TORBrowseButton.Enabled = canEdit;
            DiplomaBrowseButton.Enabled = canEdit;

            // UploadedDocumentsPanel action buttons
            UploadButton.Enabled = canEdit;
            RemoveButton.Enabled = canEdit;
        }

        // ══════════════════════════════════════════════════════════════════
        //  BROWSE BUTTONS  — exact names: ResumeBrowseButton, ValidIBrowseButton,
        //                    TORBrowseButton, DiplomaBrowseButton
        // ══════════════════════════════════════════════════════════════════

        private void ResumeBrowseButton_Click(object sender, EventArgs e)
            => BrowseFile("Resume", ResumeTextBox);

        private void ValidIBrowseButton_Click(object sender, EventArgs e)
            => BrowseFile("Valid ID", ValidIDTextBox);

        private void TORBrowseButton_Click(object sender, EventArgs e)
            => BrowseFile("Transcript of Record", TORTextBox);

        private void DiplomaBrowseButton_Click(object sender, EventArgs e)
            => BrowseFile("Diploma", DiplomaTextBox);

        private void BrowseFile(string requirementName, TextBox targetTextBox)
        {
            if (_isLocked || _applicationID == -1) return;

            openFileDialog1.Title = $"Select {requirementName}";
            openFileDialog1.Filter = "Allowed Files|*.pdf;*.jpg;*.jpeg;*.png;*.doc;*.docx|All Files|*.*";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                targetTextBox.Text = openFileDialog1.FileName;
                _pendingFiles[requirementName] = openFileDialog1.FileName;
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  UPLOAD BUTTON
        // ══════════════════════════════════════════════════════════════════

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (_isLocked)
            {
                MessageBox.Show("Your application is locked. You cannot upload documents.",
                    "Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_applicationID == -1)
            {
                MessageBox.Show("No active application found. Please apply for a job first.",
                    "No Application", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_pendingFiles.Count == 0)
            {
                MessageBox.Show("Please select at least one file using a Browse button first.",
                    "No File Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int successCount = 0, failCount = 0;

            foreach (var kvp in _pendingFiles)
            {
                string reqName = kvp.Key;
                string localPath = kvp.Value;

                if (!File.Exists(localPath)) { failCount++; continue; }

                int reqTypeID = ResolveRequirementTypeID(reqName);
                if (reqTypeID == -1) { failCount++; continue; }

                string savedPath = CopyFileToUploads(localPath);
                if (savedPath == null) { failCount++; continue; }

                if (UpsertDocument(_applicationID, reqTypeID,
                        Path.GetFileName(localPath), savedPath))
                    successCount++;
                else
                    failCount++;
            }

            _pendingFiles.Clear();
            ClearTextBoxes();
            LoadDocuments();

            if (failCount == 0)
                MessageBox.Show($"{successCount} document(s) uploaded successfully.",
                    "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show($"{successCount} uploaded, {failCount} failed.",
                    "Upload Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private int ResolveRequirementTypeID(string name)
        {
            if (_requirementTypeMap.TryGetValue(name, out int id)) return id;

            // Partial-match fallback (e.g. "Transcript of Record" vs "TOR")
            foreach (var kvp in _requirementTypeMap)
            {
                if (kvp.Key.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    name.IndexOf(kvp.Key, StringComparison.OrdinalIgnoreCase) >= 0)
                    return kvp.Value;
            }
            return -1;
        }

        private string CopyFileToUploads(string sourcePath)
        {
            try
            {
                string folder = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Uploads", $"App_{_applicationID}");
                Directory.CreateDirectory(folder);

                string dest = Path.Combine(folder,
                    $"{Path.GetFileNameWithoutExtension(sourcePath)}" +
                    $"_{DateTime.Now:yyyyMMddHHmmss}" +
                    $"{Path.GetExtension(sourcePath)}");

                File.Copy(sourcePath, dest, overwrite: true);
                return dest;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save file:\n" + ex.Message,
                    "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private bool UpsertDocument(int applicationID, int reqTypeID,
                                    string fileName, string filePath)
        {
            try
            {
                using (var conn = new DatabaseConnector().GetConnection())
                {
                    conn.Open();

                    // Check if a record already exists for this requirement
                    int existingID = -1;
                    string sqlCheck = @"
                        SELECT ApplicantDocumentID FROM applicantdocuments
                        WHERE ApplicationID = @appID AND RequirementTypeID = @rtID LIMIT 1";
                    using (var cmd = new MySqlCommand(sqlCheck, conn))
                    {
                        cmd.Parameters.AddWithValue("@appID", applicationID);
                        cmd.Parameters.AddWithValue("@rtID", reqTypeID);
                        var r = cmd.ExecuteScalar();
                        if (r != null) existingID = Convert.ToInt32(r);
                    }

                    if (existingID > 0)
                    {
                        // Replace existing document
                        string sqlUpdate = @"
                            UPDATE applicantdocuments
                            SET FileName = @fn, FilePath = @fp, UploadedAt = @now
                            WHERE ApplicantDocumentID = @docID";
                        using (var cmd = new MySqlCommand(sqlUpdate, conn))
                        {
                            cmd.Parameters.AddWithValue("@fn", fileName);
                            cmd.Parameters.AddWithValue("@fp", filePath);
                            cmd.Parameters.AddWithValue("@now", DateTime.Now);
                            cmd.Parameters.AddWithValue("@docID", existingID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Insert new document record
                        string sqlInsert = @"
                            INSERT INTO applicantdocuments
                                (ApplicationID, RequirementTypeID, FileName, FilePath, UploadedAt)
                            VALUES (@appID, @rtID, @fn, @fp, @now)";
                        using (var cmd = new MySqlCommand(sqlInsert, conn))
                        {
                            cmd.Parameters.AddWithValue("@appID", applicationID);
                            cmd.Parameters.AddWithValue("@rtID", reqTypeID);
                            cmd.Parameters.AddWithValue("@fn", fileName);
                            cmd.Parameters.AddWithValue("@fp", filePath);
                            cmd.Parameters.AddWithValue("@now", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error saving document:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  REMOVE BUTTON
        // ══════════════════════════════════════════════════════════════════

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (_isLocked)
            {
                MessageBox.Show("Your application is locked. Documents cannot be removed.",
                    "Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a document row to remove.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string status = row.Cells["StatusColumn"].Value?.ToString();

            if (status != "Submitted")
            {
                MessageBox.Show("Only submitted documents can be removed.",
                    "Nothing to Remove", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            object docIDObj = row.Cells["DocumentIDColumn"].Value;
            if (docIDObj == null || docIDObj == DBNull.Value) return;

            int docID = Convert.ToInt32(docIDObj);
            string docType = row.Cells["DocumentTypeColumn"].Value?.ToString();

            if (MessageBox.Show($"Remove '{docType}'? This cannot be undone.",
                    "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;

            try
            {
                using (var conn = new DatabaseConnector().GetConnection())
                {
                    conn.Open();

                    // Get file path before deleting
                    string filePath = null;
                    using (var cmd = new MySqlCommand(
                        "SELECT FilePath FROM applicantdocuments WHERE ApplicantDocumentID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", docID);
                        var r = cmd.ExecuteScalar();
                        if (r != null) filePath = r.ToString();
                    }

                    // Delete DB record
                    using (var cmd = new MySqlCommand(
                        "DELETE FROM applicantdocuments WHERE ApplicantDocumentID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", docID);
                        cmd.ExecuteNonQuery();
                    }

                    // Delete physical file (non-critical)
                    if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                        try { File.Delete(filePath); } catch { }
                }

                MessageBox.Show("Document removed successfully.",
                    "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDocuments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing document:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════════════
        //  REFRESH BUTTON
        // ══════════════════════════════════════════════════════════════════

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            _pendingFiles.Clear();
            ClearTextBoxes();
            LoadApplicantAndApplication();
            LoadDocuments();
            ApplyLockState();
        }

        // ══════════════════════════════════════════════════════════════════
        //  NAVIGATION BUTTONS
        //  Exact names from Designer image:
        //    DashboardButton, MyProfileButton, JobVacanciesButton,
        //    MyApplicationButton, MyDocumentsActiveButton, ApplicationsStatusButton
        // ══════════════════════════════════════════════════════════════════

        private void BackButton_Click(object sender, EventArgs e)
        {
            ApplicantDashboard dashboard = new ApplicantDashboard(_account);
            dashboard.Show();
            Close();
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            ApplicantDashboard dashboard = new ApplicantDashboard(_account);
            dashboard.Show();
            Close();
        }

        private void MyProfileButton_Click(object sender, EventArgs e)
        {
            ApplicantProfile profile = new ApplicantProfile(_account);
            profile.Show();
            Close();
        }

        private void JobVacanciesButton_Click(object sender, EventArgs e)
        {
            JobVacanciesWindow jobs = new JobVacanciesWindow(_account);
            jobs.Show();
            Close();
        }

        private void MyApplicationButton_Click(object sender, EventArgs e)
        {
            Group1_GUI_DB_OOP_Final_Project.Forms.Applicant.Application app =
                new Group1_GUI_DB_OOP_Final_Project.Forms.Applicant.Application(_account);
            app.Show();
            Close();
        }

        private void ApplicationsStatusButton_Click(object sender, EventArgs e)
        {
            ApplicationStatus status = new ApplicationStatus(_account);
            status.Show();
            Close();
        }

        // This button is "active" (current page) — no navigation needed
        private void MyDocumentsActiveButton_Click(object sender, EventArgs e) { }

        // ══════════════════════════════════════════════════════════════════
        //  UTILITY
        // ══════════════════════════════════════════════════════════════════

        private void ClearTextBoxes()
        {
            ResumeTextBox.Clear();
            ValidIDTextBox.Clear();
            TORTextBox.Clear();
            DiplomaTextBox.Clear();
        }
    }
}