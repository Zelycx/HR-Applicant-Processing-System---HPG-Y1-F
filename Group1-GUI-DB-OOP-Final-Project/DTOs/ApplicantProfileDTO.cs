using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.DTOs
{
    internal class ApplicantProfileDTO
    {
        public int ApplicantAccountID { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public string School { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }

        public string Skills { get; set; }
        public string WorkExperience { get; set; }
    }
}
