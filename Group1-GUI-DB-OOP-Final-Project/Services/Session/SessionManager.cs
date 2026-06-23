using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group1_GUI_DB_OOP_Final_Project.Models;


namespace Group1_GUI_DB_OOP_Final_Project.Services.Session
{
    internal class SessionManager
    {
        public static User CurrentHRUser { get; private set; }

        public static void SetHRUser(User user)
        {
            CurrentHRUser = user;
        }

        public static void Clear()
        {
            CurrentHRUser = null;
        }
    }
}
