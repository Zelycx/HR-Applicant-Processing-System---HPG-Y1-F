using Group1_GUI_DB_OOP_Final_Project.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Repositories
{
    internal class UserRepository
    {
        private readonly string connectionString = "server=localhost;database=hrapplicantsystem;uid=root;pwd=;";

        public User GetByUsernameOrEmail(string login)
        {
            User user = null;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT *
                FROM users
                WHERE Username = @login
                   OR Email = @login
                LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);

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

        public string GetRoleName(int roleId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT RoleName FROM roles WHERE RoleID = @RoleID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@RoleID", roleId);

                    object result = cmd.ExecuteScalar();

                    return result?.ToString();
                }
            }
        }
    }
}
