using Group1_GUI_DB_OOP_Final_Project.Forms.HR_Staff.Screening;
using Group1_GUI_DB_OOP_Final_Project.Models;
using Group1_GUI_DB_OOP_Final_Project.Forms.HR_Staff.Interview_Management;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Services.HRServices;
using Group1_GUI_DB_OOP_Final_Project.Services.Session;

namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR
{
    public partial class ApplicantList : Form
    {
        private readonly HRApplicantListService _applicantListService;

        public ApplicantList()
        {
            InitializeComponent();
            _applicantListService = new HRApplicantListService();
            this.Load += ApplicantList_Load;
        }

        private void ApplicantList_Load(object sender, EventArgs e)
        {
            LoadApplicantList();
        }

        // =========================
        // LOAD DATA
        // =========================
        private void LoadApplicantList()
        {
            try
            {
                var applicantList = _applicantListService.GetApplicantList("", "", "");
                BindApplicantList(applicantList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to load applicant list.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // GRID BINDING
        // =========================
        private void BindApplicantList(List<HRApplicantListDTO> applicantList)
        {
            ApplicatListTable.AutoGenerateColumns = false;

            if (ApplicatListTable.Columns.Count == 0)
            {
                ApplicatListTable.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ApplicationID",
                    DataPropertyName = "ApplicationID",
                    Visible = false
                });

                ApplicatListTable.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "ApplicantName",
                    HeaderText = "Applicant Name",
                    DataPropertyName = "ApplicantName",
                    Width = 250
                });

                ApplicatListTable.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "PositionApplied",
                    HeaderText = "Position Applied",
                    DataPropertyName = "PositionApplied",
                    Width = 250
                });

                ApplicatListTable.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Status",
                    DataPropertyName = "Status",
                    Width = 150
                });

                ApplicatListTable.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "DateApplied",
                    HeaderText = "Date Applied",
                    DataPropertyName = "DateApplied",
                    Width = 150
                });
            }

            ApplicatListTable.DataSource = null;
            ApplicatListTable.DataSource = applicantList;
        }

        // =========================
        // SAFE SELECTOR
        // =========================
        private int? GetSelectedApplicationID()
        {
            if (ApplicatListTable.CurrentRow == null)
            {
                MessageBox.Show("Please select an applicant first.");
                return null;
            }

            if (ApplicatListTable.CurrentRow.DataBoundItem is HRApplicantListDTO row)
            {
                return row.ApplicationID;
            }

            MessageBox.Show("Invalid selection.");
            return null;
        }

        // =========================
        // BUTTONS (SAFE NAVIGATION)
        // =========================

        private void ReviewApplicantButton_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedApplicationID();
            if (id == null) return;

            new ApplicantReview(id.Value).Show();
            this.Close();
        }

        private void ScreeningButton_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedApplicationID();
            if (id == null) return;

            new ScreeningForm(id.Value).Show();
            this.Close();
        }

        private void IntSchedButton_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedApplicationID();
            if (id == null) return;

            int userID = SessionManager.CurrentHRUser?.UserID ?? 0;
            new InterviewSched(id.Value, userID).Show();
            this.Close();
        }

        private void IntEvaButton_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedApplicationID();
            if (id == null) return;

            new InterviewEval(id.Value).Show();
            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new HRDashboard().Show();
            this.Close();
        }

        // =========================
        // SEARCH
        // =========================
        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _applicantListService.GetApplicantList(
                    SearchBox.Text.Trim(),
                    ApplicantStatus.Text.Trim(),
                    PositionApplied.Text.Trim());

                BindApplicantList(result);

                if (result.Count == 0)
                {
                    MessageBox.Show("No matching applicants found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error:\n" + ex.Message);
            }
        }
    }
}
