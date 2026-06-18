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

namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR
{
    public partial class ApplicantReview : Form
    {
        private readonly int _applicationID;
        private readonly HRApplicantReviewService _reviewService;

        public ApplicantReview(int applicationID)
        {
            InitializeComponent();

            _applicationID = applicationID;
            _reviewService = new HRApplicantReviewService();

            this.Load += ApplicantReview_Load;
        }

        private void ApplicantReview_Load(object sender, EventArgs e)
        {
            LoadApplicantData();
        }

        private void LoadApplicantData()
        {
            try
            {
                HRApplicantReviewDTO applicant =
                    _reviewService.GetApplicantReviewByApplicationID(_applicationID);

                if (applicant == null)
                {
                    MessageBox.Show("No data found.");
                    return;
                }

                FNTextBox.Text = applicant.FirstName;
                MNTextBox.Text = applicant.MiddleName;
                LNTextBox.Text = applicant.LastName;

                GenderSelection.Text = applicant.Gender;
                AddressTextBox.Text = applicant.Address;
                ContactNumberTextBox.Text = applicant.ContactNumber;
                EmailTextBox.Text = applicant.Email;

                if (applicant.BirthDate.HasValue)
                    BirthdateSelection.Value = applicant.BirthDate.Value;

                SchoolTextBox.Text = applicant.School;
                CourseTextBox.Text = applicant.Course;
                YearLevelTextBox.Text = applicant.YearLevel;

                ExperienceTextBox.Text = applicant.Experience;
                SkillTextBox.Text = applicant.Skill;

                // NEW: status tracking fields
                ScreenedBy.Text = applicant.ScreenedBy;
                InterviewedBy.Text = applicant.InterviewedBy;
                HiredBy.Text = applicant.HiredBy;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            ApplicantList list = new ApplicantList();
            list.Show();
            this.Close();
        }
    }
}
