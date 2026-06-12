using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Models
{
    internal class HiringDecision
    {
        public int HiringDecisionID { get; set; }
        public int ApplicationID { get; set; }
        public int DecidedByUserID { get; set; }
        public string FinalDecision { get; set; }
        public string FinalRemarks { get; set; }
        public DateTime DecisionDate { get; set; }
    }
}
