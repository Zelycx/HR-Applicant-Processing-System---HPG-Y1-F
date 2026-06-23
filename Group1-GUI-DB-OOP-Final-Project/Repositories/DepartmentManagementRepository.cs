using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Group1_GUI_DB_OOP_Final_Project.DTOs;

namespace Group1_GUI_DB_OOP_Final_Project.Repositories
{
    public class DepartmentManagementRepository
    {
        private string connectionString;

        public DepartmentManagementRepository(string conn)
        {
            connectionString = conn;
        }

        public List<DepartmentManagementDTO> GetAll(string table)
        {
            List<DepartmentManagementDTO> list = new List<DepartmentManagementDTO>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = $"SELECT id, name FROM {table}";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new DepartmentManagementDTO
                    {
                        Id = reader.GetInt32("id"),
                        Name = reader.GetString("name")
                    });
                }
            }

            return list;
        }

        public void Add(string table, string name)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = $"INSERT INTO {table} (name) VALUES (@name)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(string table, int id, string name)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = $"UPDATE {table} SET name=@name WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string table, int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = $"DELETE FROM {table} WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}