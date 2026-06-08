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
    public partial class InterviewScheduling : Form
    {
        public InterviewScheduling()
        {
            InitializeComponent();
        }

        private void InterviewScheduling_Load(object sender, EventArgs e)
        {
            dgvScheduling.Columns.Clear();
            dgvScheduling.Columns.Add("AppID", "App ID");
            dgvScheduling.Columns.Add("ApplicantName", "Applicant Name");
            dgvScheduling.Columns.Add("Position", "Position");

            cmbMode.Items.Clear();
            cmbMode.Items.Add("Face to Face");
            cmbMode.Items.Add("Online");
            cmbMode.Items.Add("Phone Call");
            cmbMode.SelectedIndex = 0;

            dtpInterviewDate.MinDate = DateTime.Today;

            lblApplicant.Text = "-";
        }

        private void dgvScheduling_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvScheduling.SelectedRows.Count == 0) return;

            lblApplicant.Text = dgvScheduling.SelectedRows[0].Cells["ApplicantName"].Value?.ToString() ?? "-";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Search will work once DB is connected.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnScheduleInterview_Click(object sender, EventArgs e)
        {
            if (dgvScheduling.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an applicant first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpInterviewDate.Value < DateTime.Today)
            {
                MessageBox.Show("Interview date cannot be in the past.", "Invalid Date",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLocationLink.Text))
            {
                MessageBox.Show("Please enter a Location or Link.", "Required Field",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Interview Scheduled successfully.", "Scheduled",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
