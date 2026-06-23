using Group1_GUI_DB_OOP_Final_Project.Database;
using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Forms.HR_Manager.Job_Vacancies_Management_Form.AddOrEdit;
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
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddOrEditForm form = new AddOrEditForm(0);
            form.ShowDialog();
            LoadVacancies();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            int id = GetSelectedJobVacancy();

            if (id == 0) return;

            AddOrEditForm form = new AddOrEditForm(id);
            form.ShowDialog();

            LoadVacancies();
        }

        private void CloseOrReopenButton_Click(object sender, EventArgs e)
        {
            int id = GetSelectedJobVacancy();
            if (id == 0) return;

            string status = GetSelectedJobStatus();

            _service.ToggleJobStatus(id, status);

            MessageBox.Show("Job status updated successfully.");
            LoadVacancies();
        }

        private void JobVacanciesManagementForm_Load(object sender, EventArgs e)
        {
            dgvVacancies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVacancies.MultiSelect = false;

            LoadVacancies();
        }
    }
}
