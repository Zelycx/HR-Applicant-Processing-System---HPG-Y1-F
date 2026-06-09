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
    }
}
