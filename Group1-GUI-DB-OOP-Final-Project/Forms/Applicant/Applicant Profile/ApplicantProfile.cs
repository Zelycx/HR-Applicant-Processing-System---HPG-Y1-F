using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Forms.Shared.Confirmation;
using Group1_GUI_DB_OOP_Final_Project.Models;
using Group1_GUI_DB_OOP_Final_Project.Services.UserServices;
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
    public partial class ApplicantProfile : Form
    {
        private readonly ApplicantAccounts _account;
        private readonly ApplicantProfileServices _profileService;

        public ApplicantProfile(ApplicantAccounts account)
        {
            InitializeComponent();

            // I tried to use property but it seems to be fixed..
            BirthdateSelection.MaxDate = DateTime.Today.AddYears(-18);

            _account = account;
            _profileService = new ApplicantProfileServices();

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            GenderSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            GenderSelection.Items.Clear();
            GenderSelection.Items.Add("Male");
            GenderSelection.Items.Add("Female");
            GenderSelection.Items.Add("Prefer not to say");

            Load += ApplicantProfile_Load;
        }

        private void ApplicantProfile_Load(object sender, EventArgs e)
        {
            LoadProfileData();
        }

        private void LoadProfileData()
        {
            if (_account == null)
            {
                FNTextBox.Text = "";
                MNTextBox.Text = "";
                LNTextBox.Text = "";
                GenderSelection.SelectedIndex = -1;

                // Use MaxDate instead of Today
                BirthdateSelection.Value = BirthdateSelection.MaxDate;

                AddressTextBox.Text = "";
                ContactNumberTextBox.Text = "";
                EmailTextBox.Text = "";
                SchoolTextBox.Text = "";
                CourseTextBox.Text = "";
                YearLevelTextBox.Text = "";
                SkillTextBox.Text = "";
                ExperienceTextBox.Text = "";
                return;
            }

            ApplicantProfileDTO profile = _profileService.GetProfile(_account.ApplicantAccountID);

            FNTextBox.Text = profile.FirstName ?? "";
            MNTextBox.Text = profile.MiddleName ?? "";
            LNTextBox.Text = profile.LastName ?? "";
            GenderSelection.Text = profile.Gender ?? "";

            if (profile.BirthDate.HasValue)
            {
                DateTime birthDate = profile.BirthDate.Value;

                if (birthDate > BirthdateSelection.MaxDate)
                {
                    BirthdateSelection.Value = BirthdateSelection.MaxDate;
                }
                else if (birthDate < BirthdateSelection.MinDate)
                {
                    BirthdateSelection.Value = BirthdateSelection.MinDate;
                }
                else
                {
                    BirthdateSelection.Value = birthDate;
                }
            }
            else
            {
                BirthdateSelection.Value = BirthdateSelection.MaxDate;
            }

            AddressTextBox.Text = profile.Address ?? "";
            ContactNumberTextBox.Text = profile.ContactNumber ?? "";
            EmailTextBox.Text = string.IsNullOrWhiteSpace(profile.Email) ? (_account.Email ?? "") : profile.Email;
            SchoolTextBox.Text = profile.School ?? "";
            CourseTextBox.Text = profile.Course ?? "";
            YearLevelTextBox.Text = profile.YearLevel ?? "";
            SkillTextBox.Text = profile.Skills ?? "";
            ExperienceTextBox.Text = profile.WorkExperience ?? "";
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (_account != null)
            {
                ApplicantDashboard dashboard = new ApplicantDashboard(_account);
                dashboard.Show();
            }
            else if (Owner != null)
            {
                Owner.Show();
            }

            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_account == null)
            {
                MessageBox.Show("Applicant account is missing.");
                return;
            }

            // ==========================
            // Validation
            // ==========================

            if (string.IsNullOrWhiteSpace(FNTextBox.Text))
            {
                MessageBox.Show("First Name is required.");
                FNTextBox.Focus();
                return;
            }

            if (FNTextBox.Text.Any(char.IsDigit))
            {
                MessageBox.Show("First Name cannot contain numbers.");
                FNTextBox.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(MNTextBox.Text) &&
                MNTextBox.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Middle Name cannot contain numbers.");
                MNTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(LNTextBox.Text))
            {
                MessageBox.Show("Last Name is required.");
                LNTextBox.Focus();
                return;
            }

            if (LNTextBox.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Last Name cannot contain numbers.");
                LNTextBox.Focus();
                return;
            }

            if (GenderSelection.SelectedIndex == -1)
            {
                MessageBox.Show("Please select your gender.");
                GenderSelection.Focus();
                return;
            }

            int age = DateTime.Today.Year - BirthdateSelection.Value.Year;

            if (BirthdateSelection.Value.Date > DateTime.Today.AddYears(-age))
                age--;

            if (age < 18)
            {
                MessageBox.Show("Applicant must be at least 18 years old.");
                BirthdateSelection.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ContactNumberTextBox.Text))
            {
                MessageBox.Show("Contact Number is required.");
                ContactNumberTextBox.Focus();
                return;
            }

            if (!ContactNumberTextBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("Contact Number must contain numbers only.");
                ContactNumberTextBox.Focus();
                return;
            }

            if (ContactNumberTextBox.Text.Length != 11)
            {
                MessageBox.Show("Contact Number must be exactly 11 digits.");
                ContactNumberTextBox.Focus();
                return;
            }

            if (!ContactNumberTextBox.Text.StartsWith("09"))
            {
                MessageBox.Show("Contact Number must start with 09.");
                ContactNumberTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Email is required.");
                EmailTextBox.Focus();
                return;
            }

            try
            {
                var email = new System.Net.Mail.MailAddress(EmailTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid email address.");
                EmailTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(AddressTextBox.Text))
            {
                MessageBox.Show("Address is required.");
                AddressTextBox.Focus();
                return;
            }

            if (AddressTextBox.Text.Trim().Length < 10)
            {
                MessageBox.Show("Please enter a complete address.");
                AddressTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(SchoolTextBox.Text))
            {
                MessageBox.Show("School is required.");
                SchoolTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(CourseTextBox.Text))
            {
                MessageBox.Show("Course/Strand is required.");
                CourseTextBox.Focus();
                return;
            }

            if (CourseTextBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("Please enter a valid Course/Strand.");
                CourseTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(YearLevelTextBox.Text))
            {
                MessageBox.Show("Education Level is required.");
                YearLevelTextBox.Focus();
                return;
            }

            // ==========================
            // Confirmation
            // ==========================

            ConfirmationForm confirm = new ConfirmationForm("Save your profile changes?");

            if (confirm.ShowDialog() != DialogResult.Yes)
            {
                return;
            }

            // ==========================
            // Save
            // ==========================

            ApplicantProfileDTO dto = new ApplicantProfileDTO
            {
                ApplicantAccountID = _account.ApplicantAccountID,
                FirstName = FNTextBox.Text.Trim(),
                MiddleName = MNTextBox.Text.Trim(),
                LastName = LNTextBox.Text.Trim(),
                Gender = GenderSelection.Text.Trim(),
                BirthDate = BirthdateSelection.Value.Date,
                Address = AddressTextBox.Text.Trim(),
                ContactNumber = ContactNumberTextBox.Text.Trim(),
                Email = EmailTextBox.Text.Trim(),
                School = SchoolTextBox.Text.Trim(),
                Course = CourseTextBox.Text.Trim(),
                YearLevel = YearLevelTextBox.Text.Trim(),
                Skills = SkillTextBox.Text.Trim(),
                WorkExperience = ExperienceTextBox.Text.Trim()
            };

            ProfileSaveResultDTO result = _profileService.SaveProfile(dto);

            if (result.Success)
            {
                MessageBox.Show(
                    result.Message,
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadProfileData();
            }
            else
            {
                MessageBox.Show(
                    result.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
