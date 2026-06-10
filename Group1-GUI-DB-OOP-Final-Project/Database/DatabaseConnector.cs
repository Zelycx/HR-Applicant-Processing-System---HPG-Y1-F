using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Group1_GUI_DB_OOP_Final_Project.Database
{
    public class DatabaseConnector
    {
        private static string connectionString = "Server=localhost;Database=hrapplicantsystem;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
