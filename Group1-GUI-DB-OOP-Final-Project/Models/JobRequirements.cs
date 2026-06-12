using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Models
{
    internal class JobRequirements
    {
        public int JobRequirementID { get; set; }
        public int JobVacancyID { get; set; }
        public int RequirementTypeID { get; set; }
        public bool IsRequired { get; set; }
    }
}
