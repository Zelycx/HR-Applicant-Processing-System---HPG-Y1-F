using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Services.HRServices;
using Group1_GUI_DB_OOP_Final_Project.Services.Session;
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
    public partial class InterviewEval : Form
    {
        // ── Fields ───────────────────────────────────────────────────────
        private readonly int _applicationID;
        private int _interviewScheduleID;
        private readonly InterviewScheduleService _scheduleService;
        private readonly InterviewEvaluationService _evaluationService;

        // ── Constructor ──────────────────────────────────────────────────
        public InterviewEval(int applicationID)
        {
            InitializeComponent();

            _applicationID = applicationID;
            _scheduleService = new InterviewScheduleService();
            _evaluationService = new InterviewEvaluationService();

            EvaluatorName.Text = SessionManager.CurrentHRUser?.Username ?? "Unknown User";

            OverallScore.Text = "--";

            CommunicationSkillsScore.TextChanged += ScoreTextBox_TextChanged;
            TechnicalKnowledgeScore.TextChanged += ScoreTextBox_TextChanged;
            ProblemSolvingScore.TextChanged += ScoreTextBox_TextChanged;
            AttitudeScore.TextChanged += ScoreTextBox_TextChanged;

            this.Load += InterviewEval_Load;
        }

        // ── Form load ────────────────────────────────────────────────────
        private void InterviewEval_Load(object sender, EventArgs e)
        {
            LoadApplicantInfo();
            LoadInterviewScheduleInfo();
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
                ApplicationNo.Text = info.ApplicationID.ToString();
                AppliedPosition.Text = info.JobApplied;
                CurrentStatus.Text = info.CurrentStatus;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading applicant info: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInterviewScheduleInfo()
        {
            try
            {
                InterviewScheduleInfoDTO schedule =
                    _scheduleService.GetInterviewScheduleByApplicationID(_applicationID);

                if (schedule == null)
                {
                    MessageBox.Show("No interview schedule found for this application.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _interviewScheduleID = schedule.InterviewScheduleID;

                Date.Text = schedule.InterviewDate.ToString("MMMM dd, yyyy");
                Interviewer.Text = schedule.InterviewerName;
                Mode.Text = schedule.InterviewMode;
                Location.Text = schedule.InterviewLocation;
                Status.Text = schedule.Status;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading interview schedule: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Overall score calculation ───────────────────────────────────
        private void ScoreTextBox_TextChanged(object sender, EventArgs e)
        {
            CalculateOverallScore();
        }

        private void CalculateOverallScore()
        {
            if (TryGetValidScore(CommunicationSkillsScore.Text, out double communication) &&
                TryGetValidScore(TechnicalKnowledgeScore.Text, out double technical) &&
                TryGetValidScore(ProblemSolvingScore.Text, out double problemSolving) &&
                TryGetValidScore(AttitudeScore.Text, out double attitude))
            {
                double average = (communication + technical + problemSolving + attitude) / 4.0;
                OverallScore.Text = Math.Round(average, 2).ToString();
            }
            else
            {
                OverallScore.Text = "--";
            }
        }

        private bool TryGetValidScore(string text, out double value)
        {
            if (double.TryParse(text, out value) && value >= 0 && value <= 100)
                return true;

            value = 0;
            return false;
        }

        // ── Button handlers ──────────────────────────────────────────────
        private void SaveDraftButton_Click(object sender, EventArgs e)
        {
        }

        private void SubmitResultButton_Click(object sender, EventArgs e)
        {
            if (_interviewScheduleID == 0)
            {
                MessageBox.Show("No interview schedule is linked to this application. Cannot submit evaluation.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!TryGetValidScore(CommunicationSkillsScore.Text, out double communication) ||
                !TryGetValidScore(TechnicalKnowledgeScore.Text, out double technical) ||
                !TryGetValidScore(ProblemSolvingScore.Text, out double problemSolving) ||
                !TryGetValidScore(AttitudeScore.Text, out double attitude))
            {
                MessageBox.Show("Please enter valid scores (0-100) for all four criteria.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(Remarks.Text))
            {
                MessageBox.Show("Remarks are required before submitting.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Remarks.Focus();
                return;
            }

            if (SessionManager.CurrentHRUser == null)
            {
                MessageBox.Show("No HR user session found. Please log in again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double overallScore = Math.Round((communication + technical + problemSolving + attitude) / 4.0, 2);
            string result = overallScore >= 75 ? "Pass" : "Fail"; // adjust threshold as needed

            DialogResult confirm = MessageBox.Show(
                $"Submit evaluation with an overall score of {overallScore} ({result})?\n" +
                "This will move the application to For Final Review.",
                "Confirm Submission", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                bool saved = _evaluationService.SaveEvaluation(
                    _interviewScheduleID,
                    SessionManager.CurrentHRUser.UserID,
                    (decimal)overallScore,
                    result,
                    Remarks.Text.Trim());

                if (saved)
                {
                    MessageBox.Show(
                        "Evaluation submitted. Application status updated to For Final Review.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to submit the evaluation. Please try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while submitting: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
        }
    }
}
