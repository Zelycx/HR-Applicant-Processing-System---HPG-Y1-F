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

        public ApplicantDashboard(ApplicantAccounts account)
        {
            InitializeComponent();

            _account = account;
            _dashboardService = new ApplicantDashboardServices();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            // I can't find this inside the properties window T-T
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
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                LoadApplications();
                LoadMissingRequirements();
                LoadNearestInterview();
                LoadSummaryLabels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadApplications()
        {
            List<ApplicantApplicationRowDTO> applications =
                _dashboardService.GetApplications(
                    _account.ApplicantAccountID);

            Applications.DataSource = null;
            Applications.DataSource = applications;
        }

        private void LoadMissingRequirements()
        {
            List<ApplicantMissingRequirementRowDTO> missingRequirements =
                _dashboardService.GetMissingRequirements(
                    _account.ApplicantAccountID);

            MissingRequirements.DataSource = null;
            MissingRequirements.DataSource = missingRequirements;
        }

        private void LoadNearestInterview()
        {
            ApplicantInterviewDTO interview =
                _dashboardService.GetNearestInterview(
                    _account.ApplicantAccountID);

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

        private void LoadSummaryLabels()
        {
            List<ApplicantApplicationRowDTO> applications =
                _dashboardService.GetApplications(
                    _account.ApplicantAccountID);

            PlaceHolderApp.Text = applications.Count.ToString();

            PlaceHolderIntv.Text =
                _dashboardService.GetNearestInterview(
                    _account.ApplicantAccountID) != null
                    ? "1"
                    : "0";

            if (applications.Count > 0)
            {
                PlaceHolderCS.Text = applications[0].StatusColumn;
            }
            else
            {
                PlaceHolderCS.Text = "No Applications";
            }
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            ConfirmationForm confirm = new ConfirmationForm("Are you sure you want to Log Out??");

            if (confirm.ShowDialog() == DialogResult.Yes)
            {
                ApplicantLogIn applicantLogIn = new ApplicantLogIn();

                applicantLogIn.Show();
                this.Close();
            }
        }

        private void GoToMyProfile_Click(object sender, EventArgs e)
        {
            ApplicantProfile applicantPrf = new ApplicantProfile();

            applicantPrf.Show();
            this.Close();
        }

        private void GoToJobVacancies_Click(object sender, EventArgs e)
        {
            JobVacanciesWindow jobVacanciesWindow = new JobVacanciesWindow();

            jobVacanciesWindow.Show();
            this.Close();
        }

        private void GoToMyDocuments_Click(object sender, EventArgs e)
        {
            Document applicantDocument =
                new Document();

            applicantDocument.Show();
            this.Close();
        }

        private void GoToStatusTracking_Click(object sender, EventArgs e)
        {
            ApplicationStatus applicationStatus =
                new ApplicationStatus();

            applicationStatus.Show();
            this.Close();
        }
    }
}