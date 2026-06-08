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
    public partial class ApplicantReview : Form
    {
        public ApplicantReview()
        {
            InitializeComponent();
        }

        private void ApplicantReview_Load(object sender, EventArgs e)
        {
            // Buttons enabled by default for UI testing
            btnStartReview.Enabled = true;
            btnShortlistApplicant.Enabled = false;
            btnRejectApplicant.Enabled = true;
        }

        private void btnStartReview_Click(object sender, EventArgs e)
        {
            lblCurrentStatus.Text = "Under Review";
            btnStartReview.Enabled = false;
            btnShortlistApplicant.Enabled = true;

            MessageBox.Show("Application is now Under Review.", "Status Updated",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnShortlistApplicant_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHRRemarks.Text))
            {
                MessageBox.Show("Please enter HR Remarks before shortlisting.", "Remarks Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblCurrentStatus.Text = "Shortlisted";
            btnShortlistApplicant.Enabled = false;
            btnRejectApplicant.Enabled = false;

            MessageBox.Show("Applicant has been Shortlisted.", "Status Updated",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRejectApplicant_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHRRemarks.Text))
            {
                MessageBox.Show("Please enter HR Remarks before rejecting.", "Remarks Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to reject this applicant?",
                "Confirm Rejection",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                lblCurrentStatus.Text = "Rejected";
                btnStartReview.Enabled = false;
                btnShortlistApplicant.Enabled = false;
                btnRejectApplicant.Enabled = false;

                MessageBox.Show("Applicant has been Rejected.", "Status Updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
