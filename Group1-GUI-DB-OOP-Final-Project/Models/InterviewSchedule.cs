using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Models
{
    internal class InterviewSchedule
    {
        public int InterviewScheduleID { get; set; }
        public int ApplicationID { get; set; }
        public int ScheduledByUserID { get; set; }
        public DateTime InterviewDate { get; set; }
        public TimeSpan InterviewTime { get; set; }
        public string InterviewerName { get; set; }
        public string InterviewMode { get; set; }
        public string InterviewLocation { get; set; }
        public string Status { get; set; }
    }
}
