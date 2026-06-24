using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.DTOs
{
    internal class JobVacancyEditDTO
    {
        public int JobVacancyID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string Qualifications { get; set; }
        public int DepartmentID { get; set; }
        public int EmploymentTypeID { get; set; }
        public List<int> RequirementTypeIDs { get; set; } = new List<int>();
    }
}
