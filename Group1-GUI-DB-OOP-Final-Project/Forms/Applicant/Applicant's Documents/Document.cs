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

namespace Group1_GUI_DB_OOP_Final_Project.Forms
{
    public partial class Document : Form
    {
        private readonly ApplicantAccounts _account;
        public Document(ApplicantAccounts account)
        {
            InitializeComponent();
            _account = account;
        }
    }
}
