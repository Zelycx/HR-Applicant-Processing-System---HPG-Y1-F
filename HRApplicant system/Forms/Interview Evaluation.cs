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
    public partial class InterviewEvaluation : Form
    {
        public InterviewEvaluation()
        {
            InitializeComponent();
        }

        private void InterviewEvaluation_Load(object sender, EventArgs e)
        {
            dgvEvaluation.Columns.Clear();
            dgvEvaluation.Columns.Add("InterviewID", "Interview ID");
            dgvEvaluation.Columns.Add("ApplicantName", "Applicant Name");
            dgvEvaluation.Columns.Add("ScheduledDate", "Scheduled Date");

            cmbResult.Items.Clear();
            cmbResult.Items.Add("Pass");
            cmbResult.Items.Add("Fail");
            cmbResult.SelectedIndex = 0;

            nudScore.Minimum = 0;
            nudScore.Maximum = 100;
            nudScore.Value = 0;

            lblApplicant.Text = "-";
        }

        private void dgvEvaluation_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEvaluation.SelectedRows.Count == 0) return;

            lblApplicant.Text = dgvEvaluation.SelectedRows[0].Cells["ApplicantName"].Value?.ToString() ?? "-";
            nudScore.Value = 0;
            cmbResult.SelectedIndex = 0;
            txtRemarks.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Search will work once DB is connected.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveEvaluation_Click(object sender, EventArgs e)
        {
            if (dgvEvaluation.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an applicant first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                MessageBox.Show("Please enter Remarks before saving.", "Remarks Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                "Evaluation saved!\nScore: " + nudScore.Value + "\nResult: " + cmbResult.SelectedItem.ToString(),
                "Evaluation Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            nudScore.Value = 0;
            cmbResult.SelectedIndex = 0;
            txtRemarks.Clear();
            lblApplicant.Text = "-";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
