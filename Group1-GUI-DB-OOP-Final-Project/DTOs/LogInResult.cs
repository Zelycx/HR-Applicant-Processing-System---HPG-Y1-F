using Group1_GUI_DB_OOP_Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.DTOs
{
    internal class LogInResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ApplicantAccounts Account { get; set; }
    }
}
