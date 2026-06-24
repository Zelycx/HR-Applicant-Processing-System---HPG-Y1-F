using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Services;

namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR
{
    public partial class Reports : Form
    {
        public static Reports Instance;

        private ReportsService service;

        public Reports()
        {
            InitializeComponent();

            string conn = "server=localhost;database=yourdb;uid=root;pwd=;";
            service = new ReportsService(conn);

            Instance = this;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            SetupFilter();
            ReloadReports();
        }

        private void SetupFilter()
        {
            cmbFilterStatus.Items.Add("All");
            cmbFilterStatus.Items.Add("Pending");
            cmbFilterStatus.Items.Add("Interviewed");
            cmbFilterStatus.Items.Add("Accepted");
            cmbFilterStatus.Items.Add("Rejected");
            cmbFilterStatus.Items.Add("Missing Documents");
            cmbFilterStatus.SelectedIndex = 0;
        }

        public void ReloadReports()
        {
            var data = service.LoadReports();

            dgvReports.DataSource = data;

            ApplySummary(data);
        }

        private void ApplySummary(List<ReportsDTO> data)
        {
            lblTotal.Text = "Total: " + data.Count;
            lblPending.Text = "Pending: " + data.Count(x => x.Status == "Pending");
            lblInterview.Text = "Interview: " + data.Count(x => x.Status == "Interview");
            lblAccepted.Text = "Accepted: " + data.Count(x => x.Status == "Accepted");
            lblRejected.Text = "Rejected: " + data.Count(x => x.Status == "Rejected");
        }
        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = service.LoadReports();

            string status = cmbFilterStatus.SelectedItem.ToString();

            if (status != "All")
            {
                data = data.Where(x => x.Status == status).ToList();
            }

            dgvReports.DataSource = data;
            ApplySummary(data);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var data = service.LoadReports();

            string keyword = txtSearch.Text.ToLower();

            data = data
                .Where(x => x.FullName != null && x.FullName.ToLower().Contains(keyword))
                .ToList();

            dgvReports.DataSource = data;
            ApplySummary(data);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReloadReports();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Instance = null;
            base.OnFormClosed(e);
        }
    }
}