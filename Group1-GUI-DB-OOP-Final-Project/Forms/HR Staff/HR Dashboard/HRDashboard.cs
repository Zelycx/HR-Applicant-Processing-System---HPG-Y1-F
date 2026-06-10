using Group1_GUI_DB_OOP_Final_Project.Forms.Administrator;
using Group1_GUI_DB_OOP_Final_Project.Forms.HR_Manager;
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
    public partial class HRDashboard : Form
    {
        public HRDashboard()
        {
            InitializeComponent();
        }

        private void HRDashboard_Load(object sender, EventArgs e)
        {

        }

        private void HRDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            HRLogIn loginForm = new HRLogIn();
            loginForm.Show();

            this.Hide();
        }

        private void btnApplicants_Click(object sender, EventArgs e)
        {

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports rep = new Reports();
            rep.Show();
            this.Hide();
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {

        }

        private void btnJobVacancy_Click(object sender, EventArgs e)
        {
            JobVacanciesManagementForm job = new JobVacanciesManagementForm();
            job.Show();
            this.Hide();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UserManagement user = new UserManagement();
            user.Show();
            this.Hide();
        }
    }
}
