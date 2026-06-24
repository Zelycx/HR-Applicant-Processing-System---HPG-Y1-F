using Group1_GUI_DB_OOP_Final_Project.Forms.Applicant.Applicant_LogIn;
using Group1_GUI_DB_OOP_Final_Project.Forms.Administrator;
using Group1_GUI_DB_OOP_Final_Project.Forms.HR_Manager;
using Group1_GUI_DB_OOP_Final_Project.Forms.Shared.Confirmation;
using Group1_GUI_DB_OOP_Final_Project.Services.HRServices;
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
    public partial class HRDashboard : Form
    {
        private readonly HRDashboardService _dashboardService;

        public HRDashboard()
        {
            InitializeComponent();

            _dashboardService = new HRDashboardService();
        }

        private void LoadDashboardCounts()
        {
            try
            {
                if (_dashboardService == null)
                {
                    MessageBox.Show(
                        "Dashboard service is not initialized.",
                        "Dashboard Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    SetAllLabelsToZero();
                    return;
                }

                var counts = _dashboardService.GetDashboardCounts();

                if (counts == null)
                {
                    MessageBox.Show(
                        "No dashboard data was returned.",
                        "Dashboard Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    SetAllLabelsToZero();
                    return;
                }

                TotalApplicant.Text = counts.TotalApplicants.ToString();
                PendingReview.Text = counts.PendingReview.ToString();
                ForInterview.Text = counts.ForInterview.ToString();
                Accepted.Text = counts.Accepted.ToString();
                Rejected.Text = counts.Rejected.ToString();
                OpenVacancies.Text = counts.OpenVacancies.ToString();
                MissingDocuments.Text = counts.MissingDocuments.ToString();
                InterviewsToday.Text = counts.InterviewsToday.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load dashboard counts.\n\n" + ex.Message,
                    "Dashboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                SetAllLabelsToZero();
            }
        }

        private void SetAllLabelsToZero()
        {
            TotalApplicant.Text = "0";
            PendingReview.Text = "0";
            ForInterview.Text = "0";
            Accepted.Text = "0";
            Rejected.Text = "0";
            OpenVacancies.Text = "0";
            MissingDocuments.Text = "0";
            InterviewsToday.Text = "0";
        }

        private void HRDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardCounts();
        }

        private void HRDashboardButton_Click(object sender, EventArgs e)
        {
            LoadDashboardCounts();
        }

        private void ApplicantsButton_Click(object sender, EventArgs e)
        {
            ApplicantList applicantList = new ApplicantList();
            applicantList.Show();
            this.Close();
        }

        private void JobVacButton_Click(object sender, EventArgs e)
        {
            JobVacanciesManagementForm jobvac = new JobVacanciesManagementForm();
            jobvac.Show();
            this.Close();
        }

        private void ReportsButton_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Close();
        }

        private void HiringButton_Click(object sender, EventArgs e)
        {
            HiringDecisionForm hiring = new HiringDecisionForm();
            hiring.Show();
            this.Close();
        }

        private void UserManagerButton_Click(object sender, EventArgs e)
        {
            UserManagement userManagement = new UserManagement();
            userManagement.Show();
            this.Close();
        }

        private void MaintenanceButton_Click(object sender, EventArgs e)
        {
            DepartmentManagement departmentManagement = new DepartmentManagement();
            departmentManagement.Show();
            this.Close();
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            ConfirmationForm confirm = new ConfirmationForm("Are you sure you want to Log Out??");

            if (confirm.ShowDialog() == DialogResult.Yes)
            {
                ApplicantLogIn applicantLogIn = new ApplicantLogIn();
                applicantLogIn.Show();
                Close();
            }
        }
    }
}
