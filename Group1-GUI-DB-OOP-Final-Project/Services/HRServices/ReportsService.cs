using System;
using System.Collections.Generic;
using Group1_GUI_DB_OOP_Final_Project.DTOs;
using MySql.Data.MySqlClient;

namespace Group1_GUI_DB_OOP_Final_Project.Services
{
    public class ReportsService
    {
        private string connectionString;

        public ReportsService(string conn)
        {
            connectionString = conn;
        }

        public List<ReportsDTO> LoadReports()
        {
            List<ReportsDTO> list = new List<ReportsDTO>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM applicants";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new ReportsDTO
                    {
                        ApplicationId = Convert.ToInt32(reader["application_id"]),
                        FullName = reader["full_name"].ToString(),
                        Status = reader["status"].ToString(),

                        // SAFE NULL HANDLING
                        Position = reader["position"] == DBNull.Value ? "" : reader["position"].ToString(),
                        MissingDocs = reader["missing_docs"] == DBNull.Value ? "" : reader["missing_docs"].ToString()
                    });
                }
            }

            return list;
        }
    }
}