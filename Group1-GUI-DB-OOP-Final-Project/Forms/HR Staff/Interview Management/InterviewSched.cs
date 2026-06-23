using Group1_GUI_DB_OOP_Final_Project.DTOs;
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

namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR_Staff.Interview_Management
{
    public partial class InterviewSched : Form
    {
        // ── Fields ───────────────────────────────────────────────────────
        private readonly int _applicationID;
        private readonly int _scheduledByUserID;
        private readonly InterviewScheduleService _scheduleService;

        // ── Constructor ──────────────────────────────────────────────────
        public InterviewSched(int applicationID, int scheduledByUserID)
        {
            InitializeComponent();

            _applicationID = applicationID;
            _scheduledByUserID = scheduledByUserID;
            _scheduleService = new InterviewScheduleService();

            this.Load += InterviewSched_Load;
        }

        // ── Form load ────────────────────────────────────────────────────
        private void InterviewSched_Load(object sender, EventArgs e)
        {
            PopulateScheduleStatusDropdown();
            LoadApplicantInfo();
        }

        private void PopulateScheduleStatusDropdown()
        {
            Status.Items.Clear();
            Status.Items.Add("Scheduled");
            Status.Items.Add("Completed");
            Status.Items.Add("Cancelled");
            Status.SelectedIndex = 0;

            // Safe defaults for the date/time pickers
            InterviewDate.Value = DateTime.Today;
            InterviewTime.Value = DateTime.Today.Date.AddHours(9); // 9:00 AM
        }

        private void LoadApplicantInfo()
        {
            try
            {
                InterviewApplicantInfoDTO info =
                    _scheduleService.GetApplicantInfoByApplicationID(_applicationID);

                if (info == null)
                {
                    MessageBox.Show("No applicant data found for this application.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ApplicantName.Text = info.ApplicantName;
                ApplicantId.Text = info.ApplicationID.ToString();
                CurrentStatus.Text = info.CurrentStatus;
                JobApplied.Text = info.JobApplied;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading applicant info: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Save button ──────────────────────────────────────────────────
        private void SaveScheduleButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                string selectedStatus = Status.SelectedItem?.ToString() ?? "Scheduled";

                bool saved = _scheduleService.SaveInterviewSchedule(
                    _applicationID,
                    _scheduledByUserID,
                    InterviewDate.Value.Date,
                    InterviewTime.Value.TimeOfDay,
                    InterviewerName.Text.Trim(),
                    InterviewMode.Text.Trim(),
                    InterviewLocation.Text.Trim(),
                    selectedStatus);

                if (saved)
                {
                    MessageBox.Show(
                        "Interview schedule saved. Application status updated to For Interview.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save the schedule. Please try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Validation ───────────────────────────────────────────────────
        private bool ValidateInputs()
        {
            if (InterviewDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Interview date cannot be in the past.",
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(InterviewerName.Text))
            {
                MessageBox.Show("Interviewer name is required.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InterviewerName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(InterviewMode.Text))
            {
                MessageBox.Show("Interview mode is required.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InterviewMode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(InterviewLocation.Text))
            {
                MessageBox.Show("Interview location is required.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InterviewLocation.Focus();
                return false;
            }

            if (Status.SelectedItem == null)
            {
                MessageBox.Show("Please select a schedule status.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

    }
}
