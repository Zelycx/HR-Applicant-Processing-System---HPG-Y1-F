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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            LoadReports("ALL");
        }

        private void LoadReports(string statusFilter)
        {
            dgvReports.Rows.Clear();

            var applicants = new List<(int id, string name, string position, string status)>
        {
            (1, "John Cruz", "Programmer", "Accepted"),
            (2, "Maria Santos", "Designer", "Pending"),
            (3, "Jose Reyes", "HR Assistant", "Rejected"),
            (4, "Ana Lim", "Accountant", "On Hold")
        };

            foreach (var a in applicants)
            {
                if (statusFilter == "ALL" || a.status == statusFilter)
                {
                    dgvReports.Rows.Add(a.id, a.name, a.position, a.status);
                }
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            LoadReports("ALL");
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            LoadReports("ALL");
        }

        private void btnAccepted_Click(object sender, EventArgs e)
        {
            LoadReports("ALL");
        }

        private void btnRejected_Click(object sender, EventArgs e)
        {
            LoadReports("ALL");
        }

        private void btnOnHold_Click(object sender, EventArgs e)
        {
            LoadReports("ALL");
        }
    }
}
