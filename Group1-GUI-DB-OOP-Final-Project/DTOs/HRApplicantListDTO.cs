using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.DTOs
{
    internal class HRApplicantListDTO
    {
        public int ApplicationID { get; set; }
        public string ApplicantName { get; set; }
        public string PositionApplied { get; set; }
        public string Status { get; set; }
        public string DateApplied { get; set; }
    }
}
