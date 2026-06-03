using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Group1_GUI_DB_OOP_Final_Project.Database
{
    internal class DatabaseConnector
    {
        private readonly string connectionString = "Server=localhost;Database=hrapplicantsystem;Uid=root;Pwd=;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
