using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Models
{
    internal class AuditTrail
    {
        public int AuditTrailID { get; set; }
        public int? UserID { get; set; }
        public string ActionType { get; set; }
        public string ModuleName { get; set; }
        public int? RecordID { get; set; }
        public string Description { get; set; }
        public DateTime ActionDateTime { get; set; }
    }
}
