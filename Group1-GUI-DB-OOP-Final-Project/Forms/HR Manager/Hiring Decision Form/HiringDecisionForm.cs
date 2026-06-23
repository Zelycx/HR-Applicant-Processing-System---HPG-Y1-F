using Group1_GUI_DB_OOP_Final_Project.Forms.HR;
using Group1_GUI_DB_OOP_Final_Project.Services;
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
    public partial class HiringDecisionForm : Form
    {
        private HiringDecisionService service;
        private string connectionString = "server=localhost;database=yourdb;uid=root;pwd=;";

        public HiringDecisionForm()
        {
            InitializeComponent();
            service = new HiringDecisionService(connectionString);
        }

        private void HiringDecisionForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            dgvApplications.DataSource = service.LoadApplications();
        }

        private int GetSelectedApplicationId()
        {
            if (dgvApplications.CurrentRow == null)
            {
                MessageBox.Show("Please select an applicant first.");
                return -1;
            }

            return Convert.ToInt32(dgvApplications.CurrentRow.Cells["ApplicationId"].Value);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            int id = GetSelectedApplicationId();
            if (id == -1) return;

            service.AcceptApplicant(id, txtRemarks.Text);

            MessageBox.Show("Accepted!");

            RefreshData();
            Reports.Instance?.ReloadReports();

            this.Close();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            int id = GetSelectedApplicationId();
            if (id == -1) return;

            service.RejectApplicant(id, txtRemarks.Text);

            MessageBox.Show("Rejected!");

            RefreshData();
            Reports.Instance?.ReloadReports();

            this.Close();
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            int id = GetSelectedApplicationId();
            if (id == -1) return;

            service.HoldApplicant(id, txtRemarks.Text);

            MessageBox.Show("Put on Hold!");

            RefreshData();
            Reports.Instance?.ReloadReports();

            this.Close();
        }
    }
}