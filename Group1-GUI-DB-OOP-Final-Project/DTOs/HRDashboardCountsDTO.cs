using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.DTOs
{
    internal class HRDashboardCountsDTO
    {
        public int TotalApplicants { get; set; }
        public int PendingReview { get; set; }
        public int ForInterview { get; set; }
        public int Accepted { get; set; }
        public int Rejected { get; set; }
        public int OpenVacancies { get; set; }
        public int MissingDocuments { get; set; }
        public int InterviewsToday { get; set; }
    }
}
