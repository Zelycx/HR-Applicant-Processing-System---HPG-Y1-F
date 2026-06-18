using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Models;
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

namespace Group1_GUI_DB_OOP_Final_Project.Forms.Applicant
{
    public partial class JobVacanciesWindow : Form
    {
        private readonly ApplicantAccounts _account;
        private readonly JobVacancyService _service = new JobVacancyService();
        private List<JobVacancyListDTO> _jobs = new List<JobVacancyListDTO>();

        public JobVacanciesWindow(ApplicantAccounts account)
        {
            InitializeComponent();
            _account = account;
        }

        private void JobVacanciesWindow_Load(object sender, EventArgs e)
        {
            JobVacanciesGrid.AutoGenerateColumns = true;
            JobVacanciesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            JobVacanciesGrid.MultiSelect = false;
            JobVacanciesGrid.ReadOnly = true;
            JobVacanciesGrid.AllowUserToAddRows = false;

            LoadJobs();
        }

        private void LoadJobs()
        {
            string searchText = SearchBox.Text.Trim();

            _jobs = _service.GetOpenJobs(
                _account.ApplicantAccountID,
                searchText
            );

            JobVacanciesGrid.DataSource = null;
            JobVacanciesGrid.DataSource = _jobs;

            if (_jobs.Count > 0)
            {
                JobVacanciesGrid.ClearSelection();
                JobVacanciesGrid.Rows[0].Selected = true;
                ShowSelectedJob();
            }
            else
            {
                DetailsTextBox.Text = "No job vacancies found.";
                ApplyButton.Enabled = false;
            }
        }

        private void ShowSelectedJob()
        {
            if (JobVacanciesGrid.CurrentRow == null)
                return;

            JobVacancyListDTO selected =
                JobVacanciesGrid.CurrentRow.DataBoundItem as JobVacancyListDTO;

            if (selected == null)
                return;

            JobVacancyDetailsDTO details =
                _service.GetJobDetails(
                    _account.ApplicantAccountID,
                    selected.JobVacancyID
                );

            if (details == null)
            {
                DetailsTextBox.Text = "Unable to load job details.";
                ApplyButton.Enabled = false;
                return;
            }

            DetailsTextBox.Text =
                "Job Title: " + details.JobTitle + Environment.NewLine +
                "Department: " + details.DepartmentName + Environment.NewLine +
                "Employment Type: " + details.EmploymentTypeName + Environment.NewLine +
                "Status: " + details.Status + Environment.NewLine +
                Environment.NewLine +
                "Description:" + Environment.NewLine + details.JobDescription + Environment.NewLine +
                Environment.NewLine +
                "Qualifications:" + Environment.NewLine + details.Qualifications + Environment.NewLine +
                Environment.NewLine +
                "Required Documents:" + Environment.NewLine + details.RequiredDocuments + Environment.NewLine +
                Environment.NewLine +
                "Application Status: " + details.ApplicationStatus;

            ApplyButton.Enabled =
                details.Status == "Open" &&
                details.ApplicationStatus == "Not Applied";

            ApplyButton.Text =
                details.ApplicationStatus == "Not Applied"
                    ? "Apply"
                    : "Already Applied";
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            LoadJobs();
        }

        private void JobVacanciesGrid_SelectionChanged(object sender, EventArgs e)
        {
            ShowSelectedJob();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (JobVacanciesGrid.CurrentRow == null)
            {
                MessageBox.Show("Please select a job first.");
                return;
            }

            JobVacancyListDTO selected = JobVacanciesGrid.CurrentRow.DataBoundItem as JobVacancyListDTO;
            if (selected == null)
                return;

            OperationResultDTO result = _service.Apply(_account.ApplicantAccountID, selected.JobVacancyID);

            MessageBox.Show(result.Message);

            if (result.Success)
            {
                LoadJobs();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            ApplicantDashboard dashboard = new ApplicantDashboard(_account);
            dashboard.Show();
            Close();
        }
    }
}
