using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRApplicant_system.Forms
{
    public partial class ApplicantList : Form
    {
        public ApplicantList()
        {
            InitializeComponent();
        }

        private void ApplicantList_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("All");
            cmbStatus.Items.Add("Draft");
            cmbStatus.Items.Add("Submitted");
            cmbStatus.Items.Add("Under Review");
            cmbStatus.Items.Add("Shortlisted");
            cmbStatus.Items.Add("For Interview");
            cmbStatus.Items.Add("For Final Review");
            cmbStatus.Items.Add("Accepted");
            cmbStatus.Items.Add("Rejected");
            cmbStatus.SelectedIndex = 0;

            // Setup DataGridView columns manually since no DB yet
            dgvApplicants.Columns.Clear();
            dgvApplicants.Columns.Add("AppID", "App ID");
            dgvApplicants.Columns.Add("FullName", "Full Name");
            dgvApplicants.Columns.Add("JobPosition", "Job Position");
            dgvApplicants.Columns.Add("DateApplied", "Date Applied");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Search will work once DB is connected.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbStatus.SelectedIndex = 0;
        }

        private void btnReviewApplicant_Click(object sender, EventArgs e)
        {
            if (dgvApplicants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an applicant first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ApplicantReview form = new ApplicantReview();
            form.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
