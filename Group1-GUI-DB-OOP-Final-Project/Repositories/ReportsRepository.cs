using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using Group1_GUI_DB_OOP_Final_Project.DTOs;

namespace Group1_GUI_DB_OOP_Final_Project.Repositories
{
    public class ReportsRepository
    {
        private string connectionString;

        public ReportsRepository(string conn)
        {
            connectionString = conn;
        }

        public List<ReportsDTO> GetAllReports()
        {
            List<ReportsDTO> list = new List<ReportsDTO>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT 
                    a.applicant_id,
                    CONCAT(a.first_name, ' ', a.last_name) AS full_name,
                    v.position,
                    a.status,
                    a.application_date,
                    a.missing_docs
                FROM applicants a
                LEFT JOIN vacancies v ON a.vacancy_id = v.id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new ReportsDTO
                    {
                        ApplicationId = Convert.ToInt32(reader["applicant_id"]),
                        FullName = reader["full_name"]?.ToString() ?? "",
                        Position = reader["position"]?.ToString() ?? "",
                        Status = reader["status"]?.ToString() ?? "",

                        ApplicationDate = reader["application_date"] == DBNull.Value
                            ? DateTime.MinValue
                            : Convert.ToDateTime(reader["application_date"]),

                        MissingDocs = reader["missing_docs"]?.ToString() ?? ""
                    });
                }
            }

            return list;
        }
    }
}