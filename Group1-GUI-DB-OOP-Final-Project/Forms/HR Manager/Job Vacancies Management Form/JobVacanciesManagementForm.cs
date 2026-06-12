using Group1_GUI_DB_OOP_Final_Project.Database;
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
using MySql.Data.MySqlClient;

namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR_Manager
{
    public partial class JobVacanciesManagementForm : Form
    {
        MySqlConnection conn = DatabaseConnector.GetConnection();
        public JobVacanciesManagementForm()
        {
            InitializeComponent();
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

        public void LoadVacancies()
        {
            conn.Open();

            string query = "SELECT * FROM job_vacancy";
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvVacancy.DataSource = dt;

            conn.Close();
        }

        private void JobVacancyForm_Load(object sender, EventArgs e)
        {
            LoadVacancies();
        }

        private void txtRequiredDocuments_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = DatabaseConnector.GetConnection();

            conn.Open();

            string query = "INSERT INTO job_vacancy (job_title, department, qualifications, required_documents, status) VALUES (@job_title, @department, @qualifications, @required_documents, @status)";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@job_title", txtJobTitle.Text);
            cmd.Parameters.AddWithValue("@department", txtDepartment.Text);
            cmd.Parameters.AddWithValue("@qualifications", txtQualifications.Text);
            cmd.Parameters.AddWithValue("@required_documents", txtRequiredDocuments.Text);
            cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Saved to database!");

            LoadVacancies();
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
