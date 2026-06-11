using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR_Manager
{
    public partial class HiringDecisionForm : Form
    {
        public HiringDecisionForm()
        {
            InitializeComponent();
        }

        private void HiringDecisionForm_Load(object sender, EventArgs e)
        {
            dgvApplicants.Rows.Add(1, "John Cruz", "Programmer", "Pending", "");
            dgvApplicants.Rows.Add(2, "Maria Santos", "Designer", "Pending", "");
            dgvApplicants.Rows.Add(3, "Jose Reyes", "HR Assistant", "Pending", "");
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (dgvApplicants.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to ACCEPT this applicant?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dgvApplicants.CurrentRow.Cells["Status"].Value = "Accepted";
                    dgvApplicants.CurrentRow.Cells["Remarks"].Value = txtRemarks.Text;

                    lblStatus.Text = "Status: Accepted";

                    MessageBox.Show("Applicant accepted.");
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvApplicants.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to REJECT this applicant?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    dgvApplicants.CurrentRow.Cells["Status"].Value = "Rejected";
                    dgvApplicants.CurrentRow.Cells["Remarks"].Value = txtRemarks.Text;

                    lblStatus.Text = "Status: Rejected";

                    MessageBox.Show("Applicant rejected.");
                }
            }
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            if (dgvApplicants.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show(
                    "Put this applicant ON HOLD?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    dgvApplicants.CurrentRow.Cells["Status"].Value = "On Hold";
                    dgvApplicants.CurrentRow.Cells["Remarks"].Value = txtRemarks.Text;

                    lblStatus.Text = "Status: On Hold";

                    MessageBox.Show("Applicant placed on hold.");
                }
            }
        }

        private void dgvApplicants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvApplicants.CurrentRow != null)
            {
                txtRemarks.Text =
                    dgvApplicants.CurrentRow.Cells["Remarks"].Value?.ToString();
            }
        }
    }
}
