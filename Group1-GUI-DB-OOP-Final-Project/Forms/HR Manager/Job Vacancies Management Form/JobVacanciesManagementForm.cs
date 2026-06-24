using Group1_GUI_DB_OOP_Final_Project.Database;
using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Forms.HR_Manager.Job_Vacancies_Management_Form.AddOrEdit;
using Group1_GUI_DB_OOP_Final_Project.Services;
using Group1_GUI_DB_OOP_Final_Project.Services.HRServices;
using MySql.Data.MySqlClient;
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
        private void LoadDepartments()
        {
            cmbDepartment.DataSource = service.Load("departments");
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "Id";
        }

        private DepartmentManagementService service;

        DatabaseConnector db = new DatabaseConnector();

        private string GetSelectedJobStatus()
        {
            if (dgvVacancies.SelectedRows.Count == 0)
                return "";

            var value = dgvVacancies.SelectedRows[0].Cells["Status"].Value;

            if (value == null)
                return "";

            return value.ToString();
        }

        private int GetSelectedJobVacancy()
        {
            if (dgvVacancies.SelectedRows.Count == 0)
                return 0;

            var row = dgvVacancies.SelectedRows[0];

            if (row.Cells["JobVacancyID"].Value == null)
                return 0;

            return Convert.ToInt32(row.Cells["JobVacancyID"].Value);
        }

        private JobVacancyService _service = new JobVacancyService();

        private void LoadVacancies()
        {
            dgvVacancies.DataSource = _service.GetAllVacancies(textBox1.Text);
        }

        public JobVacanciesManagementForm()
        {
            InitializeComponent();
            LoadVacancies();

            string connectionString = "server=localhost;database=your_db;uid=root;pwd=;";

            service = new DepartmentManagementService(connectionString);
        }

        // ════════════════════════════════════════════════════════════
        //  FORM LOAD
        // ════════════════════════════════════════════════════════════

        private void JobVacanciesManagementForm_Load(object sender, EventArgs e)
        {
            dgvVacancies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVacancies.MultiSelect = false;
            dgvVacancies.ReadOnly = true;
            LoadVacancies();
        }

        // ════════════════════════════════════════════════════════════
        //  HELPERS
        // ════════════════════════════════════════════════════════════

        private void LoadVacancies()
        {
            dgvVacancies.DataSource = _service.GetAllVacancies(textBox1.Text.Trim());
        }

        private int GetSelectedJobVacancyId()
        {
            if (dgvVacancies.SelectedRows.Count == 0) return 0;
            var cell = dgvVacancies.SelectedRows[0].Cells["JobVacancyID"].Value;
            return cell == null ? 0 : Convert.ToInt32(cell);
        }

        private string GetSelectedJobStatus()
        {
            if (dgvVacancies.SelectedRows.Count == 0) return "";
            return dgvVacancies.SelectedRows[0].Cells["Status"].Value?.ToString() ?? "";
        }

        // ════════════════════════════════════════════════════════════
        //  BUTTON EVENTS
        // ════════════════════════════════════════════════════════════

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (var form = new AddOrEditForm(0))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadVacancies();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            int id = GetSelectedJobVacancyId();
            if (id == 0)
            {
                MessageBox.Show("Please select a vacancy to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new AddOrEditForm(id))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadVacancies();
            }
        }

        private void CloseOrReopenButton_Click(object sender, EventArgs e)
        {
            int id = GetSelectedJobVacancyId();
            if (id == 0)
            {
                MessageBox.Show("Please select a vacancy.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string status = GetSelectedJobStatus();
            string action = status == "Open" ? "close" : "reopen";

            var confirm = MessageBox.Show(
                $"Are you sure you want to {action} this vacancy?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _service.ToggleJobStatus(id, status);
                    MessageBox.Show($"Vacancy {action}d successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadVacancies();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating status:\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ════════════════════════════════════════════════════════════
        //  SEARCH
        // Wire this to textBox1's TextChanged event in the Designer
        // ════════════════════════════════════════════════════════════

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadVacancies();
            LoadDepartments();
        }
    }
}
