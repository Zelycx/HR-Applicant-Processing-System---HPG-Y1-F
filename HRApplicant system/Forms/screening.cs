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
    public partial class Screening : Form
    {
        public Screening()
        {
            InitializeComponent();
        }

        private void Screening_Load(object sender, EventArgs e)
        {
            dgvScreening.Columns.Clear();
            dgvScreening.Columns.Add("AppID", "App ID");
            dgvScreening.Columns.Add("ApplicantName", "Applicant Name");
            dgvScreening.Columns.Add("Position", "Position");

            lblApplicant.Text = "-";
            lblPosition.Text = "-";
        }

        private void dgvScreening_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvScreening.SelectedRows.Count == 0) return;

            lblApplicant.Text = dgvScreening.SelectedRows[0].Cells["ApplicantName"].Value?.ToString() ?? "-";
            lblPosition.Text = dgvScreening.SelectedRows[0].Cells["Position"].Value?.ToString() ?? "-";
            txtScreeningRemarks.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Search will work once DB is connected.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMarkQualified_Click(object sender, EventArgs e)
        {
            if (dgvScreening.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an applicant first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtScreeningRemarks.Text))
            {
                MessageBox.Show("Please enter Screening Remarks.", "Remarks Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Applicant marked as Qualified.", "Screening Updated",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtScreeningRemarks.Clear();
        }

        private void btnMarkNotQualified_Click(object sender, EventArgs e)
        {
            if (dgvScreening.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an applicant first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtScreeningRemarks.Text))
            {
                MessageBox.Show("Please enter Screening Remarks.", "Remarks Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Mark this applicant as Not Qualified?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                MessageBox.Show("Applicant marked as Not Qualified.", "Screening Updated",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtScreeningRemarks.Clear();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
