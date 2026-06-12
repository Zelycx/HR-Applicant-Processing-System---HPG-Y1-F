using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Models
{
    internal class ApplicantStatusHistory
    {
        public int StatusHistoryID { get; set; }
        public int ApplicationID { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public int? ChangedByUserID { get; set; }
        public string Remarks { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}
