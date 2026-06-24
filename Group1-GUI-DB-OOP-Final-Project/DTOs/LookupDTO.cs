using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.DTOs
{
    internal class LookupDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }
}
