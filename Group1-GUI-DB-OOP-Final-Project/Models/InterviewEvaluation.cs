using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Models
{
    internal class InterviewEvaluation
    {
        public int InterviewEvaluationID { get; set; }
        public int InterviewScheduleID { get; set; }
        public int EvaluatorUserID { get; set; }
        public decimal? Score { get; set; }
        public string Result { get; set; }
        public string Remarks { get; set; }
        public string Recommendation { get; set; }
        public DateTime EvaluationDate { get; set; }
    }
}
