using Group1_GUI_DB_OOP_Final_Project.Forms.HR;
using Group1_GUI_DB_OOP_Final_Project.Forms.Shared.Confirmation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_GUI_DB_OOP_Final_Project.Forms.Shared.UserTypeSelection
{
    public partial class UserTypeSelection : Form
    {
        public UserTypeSelection()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            ConfirmationForm confirm = new ConfirmationForm("Are you sure you want to exit?");

            if (confirm.ShowDialog() == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void HRButton_Click(object sender, EventArgs e)
        {
            HRLogIn hrlogin = new HRLogIn();
            hrlogin.Show();
            this.Hide();
        }
    }
}
