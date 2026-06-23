using Group1_GUI_DB_OOP_Final_Project.Models;
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
    public partial class Application : Form
    {
        public Application()
        {
            InitializeComponent();
        }

        private readonly ApplicantAccounts _account;

        public Application(ApplicantAccounts account)
        {
            InitializeComponent();

            _account = account;
        }

        private void Application_Load(object sender, EventArgs e)
        {
            StatusTextBox.ReadOnly = true;
            JobTitleTextBox.ReadOnly = true;
            DepartmentTextBox.ReadOnly = true;
            JobTypeTextBox.ReadOnly = true;

            PrefferedInterviewTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            PrefferedInterviewTypeComboBox.Items.Clear();

            PrefferedInterviewTypeComboBox.Items.Add("Face-to-Face");
            PrefferedInterviewTypeComboBox.Items.Add("Online");
            PrefferedInterviewTypeComboBox.Items.Add("Phone Call");

            PrefferedInterviewTypeComboBox.SelectedIndex = 0;

            StartDatedateTimePicker.MinDate = DateTime.Today;

            SaveDraftButton.Enabled = false;
            EditApplicationButton.Enabled = false;
            SubmitApplicationButton.Enabled = false;
        }

        private void StartDraftButton_Click(object sender, EventArgs e)
        {
            StatusTextBox.Text = "Draft";

            SaveDraftButton.Enabled = true;
            EditApplicationButton.Enabled = true;
            SubmitApplicationButton.Enabled = true;

            ExpectedSalaryTextBox.Focus();

            MessageBox.Show("Draft application created.");
        }

        private void SaveDraftButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ExpectedSalaryTextBox.Text))
            {
                MessageBox.Show("Enter your expected salary.");
                return;
            }

            if (!decimal.TryParse(ExpectedSalaryTextBox.Text, out decimal salary))
            {
                MessageBox.Show("Invalid salary.");
                return;
            }

            MessageBox.Show("Draft saved successfully.");
        }

        private void EditApplicationButton_Click(object sender, EventArgs e)
        {
            ExpectedSalaryTextBox.ReadOnly = false;

            CoverLetterTextBox.ReadOnly = false;

            PrefferedInterviewTypeComboBox.Enabled = true;

            StartDatedateTimePicker.Enabled = true;

            MessageBox.Show("Editing enabled.");
        }

        private void ExpectedSalaryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
       !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CoverLetterTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CoverLetterTextBox.Text == "Optional: Tell us why you're interested in this position...")
            {
                CoverLetterTextBox.Text = "";
                CoverLetterTextBox.ForeColor = Color.Black;
            }
        }

        private void CoverLetterTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CoverLetterTextBox.Text))
            {
                CoverLetterTextBox.Text = "Optional: Tell us why you're interested in this position...";
                CoverLetterTextBox.ForeColor = Color.Gray;
            }
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            ApplicantDashboard dashboard = new ApplicantDashboard(_account);
            dashboard.Show();
            Close();
        }

        private void MyProfileButtom_Click(object sender, EventArgs e)
        {
            ApplicantProfile profile = new ApplicantProfile(_account);
            profile.Show();
            Close();
        }

        private void JobVacanciesButton_Click(object sender, EventArgs e)
        {
            JobVacanciesWindow jobs = new JobVacanciesWindow(_account);
            jobs.Show();
            Close();
        }

        private void MyDocumentsButton_Click(object sender, EventArgs e)
        {
            Group1_GUI_DB_OOP_Final_Project.Forms.Document docs =
       new Group1_GUI_DB_OOP_Final_Project.Forms.Document(_account);
            docs.Show();
            Close();
        }
    }
}
