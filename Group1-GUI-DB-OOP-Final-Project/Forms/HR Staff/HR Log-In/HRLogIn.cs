using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Forms.Shared.UserTypeSelection;
using Group1_GUI_DB_OOP_Final_Project.Services.UserServices;
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

namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR
{
    public partial class HRLogIn : Form
    {
        private readonly HRUserService _userService;
        public HRLogIn()
        {
            InitializeComponent();
            _userService = new HRUserService();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
        private bool isVisible = false;
        private void LogInButton_Click(object sender, EventArgs e)
        {
            HRLogInResultDTO result =
                _userService.AuthenticateHR(
                    EmailTextBox.Text.Trim(),
                    PasswordTextBox.Text);
            if (!result.Success)
            {
                MessageBox.Show(
                    result.Message,
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            SessionManager.SetHRUser(result.User);

            MessageBox.Show(
                result.Message,
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            HRDashboard dashboard = new HRDashboard();
            dashboard.Show();
            this.Hide();
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            UserTypeSelection userTypeSelection = new UserTypeSelection();
            userTypeSelection.Show();
            this.Close();
        }
        private void SeePasswordButton_Click(object sender, EventArgs e)
        {
            isVisible = !isVisible;
            if (isVisible)
            {
                SeePasswordButton.ImageList = SeePassHR;
                SeePasswordButton.ImageIndex = 0;
                PasswordTextBox.PasswordChar = '\0';
                PasswordStatusLabel.Text = "Hide Password";
            }
            else
            {
                SeePasswordButton.ImageList = SeePassHR;
                SeePasswordButton.ImageIndex = 1;
                PasswordTextBox.PasswordChar = '•';
                PasswordStatusLabel.Text = "See Password";
            }
        }
    }
}
