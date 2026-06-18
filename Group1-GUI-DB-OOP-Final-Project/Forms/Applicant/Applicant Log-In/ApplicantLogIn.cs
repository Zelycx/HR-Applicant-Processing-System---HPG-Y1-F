using Group1_GUI_DB_OOP_Final_Project.Forms.Shared.UserTypeSelection;
using Group1_GUI_DB_OOP_Final_Project.Forms.Applicant.Applicant_LogIn;
using Group1_GUI_DB_OOP_Final_Project.Services.UserServices;
using Group1_GUI_DB_OOP_Final_Project.Forms.Shared.SharedFunctions.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Group1_GUI_DB_OOP_Final_Project.Forms.Applicant;
using Group1_GUI_DB_OOP_Final_Project.DTOs;

namespace Group1_GUI_DB_OOP_Final_Project.Forms.Applicant.Applicant_LogIn
{
    public partial class ApplicantLogIn : Form
    {
        private bool isVisible = false;

        public ApplicantLogIn()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            UserTypeSelection userTypeSelection = new UserTypeSelection();
            userTypeSelection.Show();
            Close();
        }

        private void SeePasswordButton_Click(object sender, EventArgs e)
        {
            isVisible = !isVisible;

            if (isVisible)
            {
                SeePasswordButton.ImageList = SeePassword;
                SeePasswordButton.ImageIndex = 0;
                PasswordTextBox.PasswordChar = '\0';
                PasswordStatusLabel.Text = "Hide Password";
            }
            else
            {
                SeePasswordButton.ImageList = SeePassword;
                SeePasswordButton.ImageIndex = 1;
                PasswordTextBox.PasswordChar = '•';
                PasswordStatusLabel.Text = "See Password";
            }
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text.Trim();
            string password = PasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                new NotificationBox("Please enter your email.").ShowDialog();
                EmailTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                new NotificationBox("Please enter your password.").ShowDialog();
                PasswordTextBox.Focus();
                return;
            }

            UserService userService = new UserService();

            if (!userService.EmailIsValid(email))
            {
                new NotificationBox("Please enter a valid email address.").ShowDialog();
                EmailTextBox.Focus();
                return;
            }

            try
            {
                LogInResult result = userService.AuthenticateApplicant(email, password);

                if (!result.Success)
                {
                    new NotificationBox(result.Message).ShowDialog();
                    return;
                }

                userService.UpdateLastLogin(result.Account.ApplicantAccountID);

                new NotificationBox(result.Message).ShowDialog();

                ApplicantDashboard dashboard = new ApplicantDashboard(result.Account);
                dashboard.Show();
                Hide();
            }
            catch (Exception ex)
            {
                new NotificationBox(ex.Message).ShowDialog();
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            ApplicantRegistration applicantRegistration = new ApplicantRegistration();
            applicantRegistration.Show();
            Close();
        }
    }
}