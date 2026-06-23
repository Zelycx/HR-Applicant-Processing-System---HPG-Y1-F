using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.DTOs
{
    public class ReportsDTO
    {
        public int ApplicationId { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
        public string Position { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string MissingDocs { get; set; }
    }
}
