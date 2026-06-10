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
    }
}
