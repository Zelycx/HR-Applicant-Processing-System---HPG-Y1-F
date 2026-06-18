using Group1_GUI_DB_OOP_Final_Project.Database;
using Group1_GUI_DB_OOP_Final_Project.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Repositories
{
    internal class HRUserRepository
    {
        private readonly DatabaseConnector _databaseConnector;

        public HRUserRepository()
        {
            _databaseConnector = new DatabaseConnector();
        }

        public User GetByUsername(string login)
        {
            User user = null;

            using (MySqlConnection conn = _databaseConnector.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT *
                    FROM users
                    WHERE Username = @Login
                       OR Email = @Login
                    LIMIT 1";


                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Login", login);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                RoleID = Convert.ToInt32(reader["RoleID"]),
                                Username = reader["Username"].ToString(),
                                Email = reader["Email"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };
                        }
                    }
                }
            }

            return user;
        }
    }
}
