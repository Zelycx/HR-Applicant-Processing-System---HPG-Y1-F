using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Services.HRServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            LoadApplicantDocuments();
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
                ApplicantStatusLabel.Text = applicant.CurrentStatus;
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

        private void Documents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadApplicantDocuments()
        {
            try
            {
                Documents.Items.Clear();
                Documents.View = View.Details;

                List<HRApplicantDocumentDTO> docs =
                    _reviewService.GetDocumentsByApplicationID(_applicationID);

                foreach (var doc in docs)
                {
                    ListViewItem item = new ListViewItem(doc.FileName);
                    item.SubItems.Add(doc.RequirementType);
                    item.Tag = doc.FilePath; // store full path for opening later
                    Documents.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Documents_DoubleClick(object sender, EventArgs e)
        {
            if (Documents.SelectedItems.Count == 0)
                return;

            string filePath = Documents.SelectedItems[0].Tag as string;

            if (string.IsNullOrWhiteSpace(filePath) || !System.IO.File.Exists(filePath))
            {
                MessageBox.Show("File not found.");
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open file: " + ex.Message);
            }
        }

    }
}
