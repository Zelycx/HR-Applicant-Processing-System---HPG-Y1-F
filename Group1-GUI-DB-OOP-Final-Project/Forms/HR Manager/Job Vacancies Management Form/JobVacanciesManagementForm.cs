using Group1_GUI_DB_OOP_Final_Project.Forms.HR;
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
    public partial class JobVacanciesManagementForm : Form
    {
        public JobVacanciesManagementForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HRDashboard dashboard = new HRDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void dgvVacancy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvVacancy.AllowUserToAddRows = false;
            dgvVacancy.ReadOnly = true;

            dgvVacancy.Columns.Add("JobTitle", "Job Title");
            dgvVacancy.Columns.Add("Department", "Department");
            dgvVacancy.Columns.Add("Qualifications", "Qualifications");
            dgvVacancy.Columns.Add("Documents", "Required Documents");
            dgvVacancy.Columns.Add("Status", "Status");
        }

        private void txtRequiredDocuments_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvVacancy.Rows.Add(
            txtJobTitle.Text,
            txtDepartment.Text,
            txtQualifications.Text,
            txtRequiredDocuments.Text,
            cmbStatus.Text
            );

            MessageBox.Show("Vacancy Added Successfully!");

            // OPTIONAL: clear fields after adding
            txtJobTitle.Clear();
            txtDepartment.Clear();
            txtQualifications.Clear();
            txtRequiredDocuments.Clear();
            cmbStatus.SelectedIndex = -1;
        }

        private void dgvVacancy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVacancy.Rows[e.RowIndex];

                txtJobTitle.Text = row.Cells[0].Value.ToString();
                txtDepartment.Text = row.Cells[1].Value.ToString();
                txtQualifications.Text = row.Cells[2].Value.ToString();
                txtRequiredDocuments.Text = row.Cells[3].Value.ToString();
                cmbStatus.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvVacancy.CurrentRow != null)
            {
                dgvVacancy.CurrentRow.Cells[0].Value = txtJobTitle.Text;
                dgvVacancy.CurrentRow.Cells[1].Value = txtDepartment.Text;
                dgvVacancy.CurrentRow.Cells[2].Value = txtQualifications.Text;
                dgvVacancy.CurrentRow.Cells[3].Value = txtRequiredDocuments.Text;
                dgvVacancy.CurrentRow.Cells[4].Value = cmbStatus.Text;

                MessageBox.Show("Vacancy Updated Successfully!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (dgvVacancy.CurrentRow != null)
            {
                dgvVacancy.CurrentRow.Cells[4].Value = "Closed";

                MessageBox.Show("Vacancy Closed Successfully!");
            }
        }

        private void btnReopen_Click(object sender, EventArgs e)
        {
            if (dgvVacancy.CurrentRow != null)
            {
                dgvVacancy.CurrentRow.Cells[4].Value = "Active";

                MessageBox.Show("Vacancy Reopened Successfully!");
            }
        }
    }
}
