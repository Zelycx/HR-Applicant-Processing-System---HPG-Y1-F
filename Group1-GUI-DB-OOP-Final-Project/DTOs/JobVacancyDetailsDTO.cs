using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.DTOs
{
    internal class JobVacancyDetailsDTO : JobVacancyListDTO
    {
        public string JobDescription { get; set; }
        public string Qualifications { get; set; }
        public string RequiredDocuments { get; set; }
    }
}
