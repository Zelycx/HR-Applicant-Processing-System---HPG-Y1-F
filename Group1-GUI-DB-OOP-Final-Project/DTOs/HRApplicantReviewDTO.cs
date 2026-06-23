using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.DTOs
{
    internal class HRApplicantReviewDTO
    {
        public int ApplicationID { get; set; }

        // Personal Info
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }

        // Education (UPDATED - includes EducationLevel)
        public string EducationLevel { get; set; }
        public string School { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }

        // Work
        public string Experience { get; set; }
        public string Skill { get; set; }

        // HR FLOW
        public string ScreenedBy { get; set; }
        public string InterviewedBy { get; set; }
        public string HiredBy { get; set; }
        public string CurrentStatus { get; set; }
    }
}
