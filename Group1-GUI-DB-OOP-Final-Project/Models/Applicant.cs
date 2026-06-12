using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Models
{
    internal class Applicant
    {
        public int ApplicantID { get; set; }
        public int ApplicantAccountID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string EducationLevel { get; set; }
        public string School { get; set; }
        public string Course { get; set; }
        public string Skills { get; set; }
        public string WorkExperience { get; set; }
    }
}
