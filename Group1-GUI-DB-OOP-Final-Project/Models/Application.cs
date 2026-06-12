using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Models
{
    internal class Application
    {
        public int ApplicationID { get; set; }
        public int ApplicantID { get; set; }
        public int JobVacancyID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string CurrentStatus { get; set; }
        public bool IsLocked { get; set; }
    }
}
