using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.DTOs
{
    internal class HRScreeningResultDTO
    {
        public int ApplicationID { get; set; }
        public int ScreenedByUserID { get; set; }
        public string ScreeningStatus { get; set; }
        public string NewApplicationStatus { get; set; }
        public string Remarks { get; set; }
    }
}
