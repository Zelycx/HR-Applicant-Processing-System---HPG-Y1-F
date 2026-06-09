using Group1_GUI_DB_OOP_Final_Project.Forms.Shared.Confirmation;
using Group1_GUI_DB_OOP_Final_Project.Forms.Applicant.Applicant_LogIn;
using Group1_GUI_DB_OOP_Final_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_GUI_DB_OOP_Final_Project.Forms.Applicant
{
    public partial class ApplicantDashboard : Form
    {
        private readonly ApplicantAccounts _account;

        public ApplicantDashboard(ApplicantAccounts account)
        {
            InitializeComponent();

            _account = account;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            // I can't find this inside the properties window T-T
            Applications.EnableHeadersVisualStyles = false;
            Applications.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            MissingRequirements.EnableHeadersVisualStyles = false;
            MissingRequirements.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            ConfirmationForm confirm = new ConfirmationForm("Are you sure you want to Log Out??");

            if (confirm.ShowDialog() == DialogResult.Yes)
            {
                ApplicantLogIn applicantLogIn = new ApplicantLogIn();
                applicantLogIn.Show();
                this.Close();
            }
        }
    }
}
