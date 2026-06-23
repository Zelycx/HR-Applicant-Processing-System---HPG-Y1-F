using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.DTOs
{
    public class HiringDecisionDTO
    {
        public int ApplicationId { get; set; }
        public string ApplicantName { get; set; }
        public string Position { get; set; }
        public string Status { get; set; } // Pending / Accepted / Rejected / Hold
        public string Remarks { get; set; }
        public DateTime DateApplied { get; set; }
    }
}
