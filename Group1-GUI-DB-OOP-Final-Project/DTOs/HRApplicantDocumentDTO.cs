using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.DTOs
{
    internal class HRApplicantDocumentDTO
    {
        public int ApplicantDocumentID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string RequirementType { get; set; }
    }
}
