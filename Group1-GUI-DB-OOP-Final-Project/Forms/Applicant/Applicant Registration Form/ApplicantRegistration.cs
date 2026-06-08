using Group1_GUI_DB_OOP_Final_Project.Forms.Shared.User_Type_Selection;
using Group1_GUI_DB_OOP_Final_Project.Forms.Shared.UserTypeSelection;
using Group1_GUI_DB_OOP_Final_Project.Forms.Shared.SharedFunctions.Notifications;
using Group1_GUI_DB_OOP_Final_Project.Services.UserServices;
using Group1_GUI_DB_OOP_Final_Project.DTOs;
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
    public partial class ApplicantRegistration : Form
    {
        public ApplicantRegistration()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            UserTypeSelection userTypeSelection = new UserTypeSelection();
            userTypeSelection.Show();
            this.Close();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            ApplicantLogIn applicantLogIn = new ApplicantLogIn();
            applicantLogIn.Show();
            this.Close();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            try
            {
                UserService userService =
                    new UserService();

                var dto =
                    new RegistrationDTO
                    {
                        Email =
                            EmailTextBox.Text.Trim(),

                        Password =
                            PasswordTextBox.Text,

                        ConfirmPassword =
                            ConfirmationTextBox.Text
                    };

                var result =
                    userService.RegisterApplicant(dto);

                new NotificationBox(result.Message).ShowDialog();

                if (result.Success)
                {
                    ApplicantLogIn login =
                        new ApplicantLogIn();

                    login.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                new NotificationBox(ex.Message).ShowDialog();
            }
        }
    }
}
