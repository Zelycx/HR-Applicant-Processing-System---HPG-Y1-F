using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRApplicant_system.Forms
{
    public partial class HRDashboard : Form
    {
        public HRDashboard()
        {
            InitializeComponent();
        }

        private void HRDashboard_Load(object sender, EventArgs e)
        {
            // Stats will be connected by the DB member later
            lblTotalApplicants.Text = "0";
            lblPendingReview.Text = "0";
            lblShortlisted.Text = "0";
        }

        private void btnViewApplicants_Click(object sender, EventArgs e)
        {
            ApplicantList form = new ApplicantList();
            form.Show();
        }

        private void btnScreening_Click(object sender, EventArgs e)
        {
            Screening form = new Screening();
            form.Show();
        }

        private void btnInterviewScheduling_Click(object sender, EventArgs e)
        {
            InterviewScheduling form = new InterviewScheduling();
            form.Show();
        }

        private void btnInterviewEvaluation_Click(object sender, EventArgs e)
        {
            InterviewEvaluation form = new InterviewEvaluation();
            form.Show();
        }

        private void btnJobVacancies_Click(object sender, EventArgs e)
        {
            JobVacancies form = new JobVacancies();
            form.Show();
        }

        private void btnHiringDecision_Click(object sender, EventArgs e)
        {
            HiringDecision form = new HiringDecision();
            form.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports form = new Reports();
            form.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
