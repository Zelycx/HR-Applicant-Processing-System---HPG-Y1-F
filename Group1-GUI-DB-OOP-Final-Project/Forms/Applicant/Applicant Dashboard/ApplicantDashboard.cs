using Group1_GUI_DB_OOP_Final_Project.Forms.Shared.Confirmation;
using Group1_GUI_DB_OOP_Final_Project.Forms.Applicant.Applicant_LogIn;
using Group1_GUI_DB_OOP_Final_Project.Models;
using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Services.UserServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Windows.Forms;

namespace Group1_GUI_DB_OOP_Final_Project.Forms.Applicant
{
    public partial class ApplicantDashboard : Form
    {
        private readonly ApplicantAccounts _account;
        private readonly ApplicantDashboardServices _dashboardService;
        private bool _dashboardLoaded = false;

        public ApplicantDashboard(ApplicantAccounts account)
        {
            InitializeComponent();

            _account = account;
            _dashboardService = new ApplicantDashboardServices();

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            Applications.EnableHeadersVisualStyles = false;
            Applications.ColumnHeadersDefaultCellStyle.BackColor = Color.White;

            MissingRequirements.EnableHeadersVisualStyles = false;
            MissingRequirements.ColumnHeadersDefaultCellStyle.BackColor = Color.White;

            ConfigureApplicationsGrid();
            ConfigureMissingRequirementsGrid();
        }

        private void ConfigureApplicationsGrid()
        {
            Applications.AutoGenerateColumns = false;
            PositionColumn.DataPropertyName = "PositionColumn";
            DateAppliedColumn.DataPropertyName = "DateAppliedColumn";
            StatusColumn.DataPropertyName = "StatusColumn";
        }

        private void ConfigureMissingRequirementsGrid()
        {
            MissingRequirements.AutoGenerateColumns = false;
            JobRow.DataPropertyName = "JobRow";
            MissReqRow.DataPropertyName = "MissReqRow";
        }

        private void ApplicantDashboard_Load(object sender, EventArgs e)
        {
            if (_dashboardLoaded)
            {
                return;
            }

            LoadDashboardData();
            _dashboardLoaded = true;
        }

        private void LoadDashboardData()
        {
            try
            {
                LoadSummaryLabels();
            }
            catch
            {
                PlaceHolderApp.Text = "0";
                PlaceHolderIntv.Text = "0";
                PlaceHolderCS.Text = "No Applications";
            }

            try
            {
                LoadNameAndLastLogin();
            }
            catch
            {
                PlaceHolderForName.Text = "Applicant";
                ApplicantLastLog.Text = "-";
            }

            try
            {
                LoadApplications();
            }
            catch
            {
                Applications.DataSource = null;
            }

            try
            {
                LoadMissingRequirements();
            }
            catch
            {
                MissingRequirements.DataSource = null;
            }

            try
            {
                LoadNearestInterview();
            }
            catch
            {
                PositionShower.Text = "";
                DateShower.Text = "";
                TimeShower.Text = "";
                ModeShower.Text = "";
            }
        }

        private void LoadSummaryLabels()
        {
            ApplicantDashboardSummary summary =
                _dashboardService.GetDashboardSummary(_account.ApplicantAccountID);

            PlaceHolderApp.Text = summary.ApplicationCount.ToString();
            PlaceHolderIntv.Text = summary.UpcomingInterviewCount.ToString();
            PlaceHolderCS.Text = string.IsNullOrWhiteSpace(summary.LatestStatus)
                ? "No Applications"
                : summary.LatestStatus;
        }

        private void LoadNameAndLastLogin()
        {
            string fullName =
                _dashboardService.GetApplicantFullName(_account.ApplicantAccountID);

            PlaceHolderForName.Text =
                string.IsNullOrWhiteSpace(fullName) ? "Applicant" : fullName;

            DateTime? lastLogin =
                _dashboardService.GetApplicantLastLogin(_account.ApplicantAccountID);

            ApplicantLastLog.Text =
                lastLogin.HasValue
                    ? lastLogin.Value.ToString("MMMM dd, yyyy hh:mm tt")
                    : "-";
        }

        private void LoadApplications()
        {
            List<ApplicantApplicationRowDTO> applications =
                _dashboardService.GetApplications(_account.ApplicantAccountID);

            Applications.DataSource = null;
            Applications.DataSource = applications;
        }

        private void LoadMissingRequirements()
        {
            List<ApplicantMissingRequirementRowDTO> missingRequirements =
                _dashboardService.GetMissingRequirements(_account.ApplicantAccountID);

            MissingRequirements.DataSource = null;
            MissingRequirements.DataSource = missingRequirements;
        }

        private void LoadNearestInterview()
        {
            ApplicantInterviewDTO interview =
                _dashboardService.GetNearestInterview(_account.ApplicantAccountID);

            if (interview == null)
            {
                PositionShower.Text = "N/A";
                DateShower.Text = "N/A";
                TimeShower.Text = "N/A";
                ModeShower.Text = "N/A";
                return;
            }

            PositionShower.Text = interview.PositionShower;
            DateShower.Text = interview.DateShower;
            TimeShower.Text = interview.TimeShower;
            ModeShower.Text = interview.ModeShower;
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

        private void GoToMyProfile_Click(object sender, EventArgs e)
        {
            ApplicantProfile applicantPrf = new ApplicantProfile(_account);
            applicantPrf.Show();
            Close();
        }

        private void GoToJobVacancies_Click(object sender, EventArgs e)
        {
            JobVacanciesWindow jobVacanciesWindow = new JobVacanciesWindow();
            jobVacanciesWindow.Show();
            Close();
        }

        private void GoToMyDocuments_Click(object sender, EventArgs e)
        {
            Document applicantDocument = new Document();
            applicantDocument.Show();
            Close();
        }

        private void GoToStatusTracking_Click(object sender, EventArgs e)
        {
            ApplicationStatus applicationStatus = new ApplicationStatus();
            applicationStatus.Show();
            Close();
        }
    }
}