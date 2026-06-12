using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_GUI_DB_OOP_Final_Project.Forms.Shared.SharedFunctions.Notifications
{
    public partial class NotificationBox : Form
    {
        public NotificationBox(string message)
        {
            InitializeComponent();
            MessageBox.Text = message;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
