using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.DTOs
{
    internal class JobVacancyListDTO
    {
        public int JobVacancyID { get; set; }
        public string JobTitle { get; set; }
        public string DepartmentName { get; set; }
        public string EmploymentTypeName { get; set; }
        public string Status { get; set; }
        public string ApplicationStatus { get; set; }
    }
}
