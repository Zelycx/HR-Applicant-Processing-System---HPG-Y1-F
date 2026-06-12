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
    public partial class Screening : Form
    {
        public Screening()
        {
            InitializeComponent();
        }

        private void Screening_Load(object sender, EventArgs e)
        {
            dgvScreening.Rows.Add("A001", "Juan Dela Cruz", "IT Staff", "Pending");
            dgvScreening.Rows.Add("A002", "Maria Santos", "HR Assistant", "Pending");
            dgvScreening.Rows.Add("A003", "Jose Reyes", "Developer", "Pending");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
