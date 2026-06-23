using Group1_GUI_DB_OOP_Final_Project.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_GUI_DB_OOP_Final_Project.Forms.Administrator
{
    public partial class DepartmentManagement : Form
    {
        private DepartmentManagementService service;

        private void LoadData()
        {
            dgvMaintenance.DataSource = service.Load(cmbModule.Text);
        }
        private void DepartmentManagement_Load(object sender, EventArgs e)
        {
            cmbModule.Items.Add("departments");
            cmbModule.Items.Add("positions");
            cmbModule.Items.Add("employment_types");
            cmbModule.Items.Add("requirement_types");
            cmbModule.Items.Add("interview_types");
            cmbModule.Items.Add("assessment_types");

            cmbModule.SelectedIndex = 0;

            LoadData();
        }
        public DepartmentManagement()
        {
            InitializeComponent();

            string connectionString = "server=localhost;database=your_db;uid=root;pwd=;";

            service = new DepartmentManagementService(connectionString);
        }

        private void cmbModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required.");
                return;
            }

            service.Add(cmbModule.Text, txtName.Text);
            LoadData();
            txtName.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMaintenance.CurrentRow == null)
            {
                MessageBox.Show("Select a record first.");
                return;
            }

            int id = Convert.ToInt32(dgvMaintenance.CurrentRow.Cells["Id"].Value);

            service.Update(cmbModule.Text, id, txtName.Text);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMaintenance.CurrentRow == null)
            {
                MessageBox.Show("Select a record first.");
                return;
            }

            int id = Convert.ToInt32(dgvMaintenance.CurrentRow.Cells["Id"].Value);

            service.Delete(cmbModule.Text, id);
            LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
        }

        private void dgvMaintenance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMaintenance.CurrentRow != null)
            {
                txtName.Text = dgvMaintenance.CurrentRow.Cells["Name"].Value.ToString();
            }
        }
    }
}
