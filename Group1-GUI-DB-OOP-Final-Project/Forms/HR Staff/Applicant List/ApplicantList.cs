using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR
{
    public partial class ApplicantList : Form
    {
        public ApplicantList()
        {
            InitializeComponent();
        }

        private void ApplicantList_Load(object sender, EventArgs e)
        {
            dgvApplicants.Rows.Add("A001", "Juan Dela Cruz", "IT Staff", "IT", "Pending");
            dgvApplicants.Rows.Add("A002", "Maria Santos", "HR Assistant", "HR", "Screening");
            dgvApplicants.Rows.Add("A003", "Jose Reyes", "Developer", "IT", "Interview");
        }

        private void dgvApplicants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();

            dgvApplicants.ClearSelection();

            foreach (DataGridViewRow row in dgvApplicants.Rows)
            {
                bool match = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null &&
                        cell.Value.ToString().ToLower().Contains(keyword))
                    {
                        match = true;
                        break;
                    }
                }

                row.Visible = match;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            foreach (DataGridViewRow row in dgvApplicants.Rows)
            {
                row.Visible = true;
            }
        }

        private void dgvApplicants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvApplicants.Rows[e.RowIndex];

                txtFullName.Text = row.Cells[1].Value.ToString();
                txtPosition.Text = row.Cells[2].Value.ToString();
                txtDepartment.Text = row.Cells[3].Value.ToString();
                txtStatus.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}
