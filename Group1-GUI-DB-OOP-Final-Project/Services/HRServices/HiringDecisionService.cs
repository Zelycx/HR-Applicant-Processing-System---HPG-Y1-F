using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Repositories;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Group1_GUI_DB_OOP_Final_Project.Services
{
    public class HiringDecisionService
    {
        private string connectionString;

        public HiringDecisionService(string conn)
        {
            connectionString = conn;
        }

        public List<object> LoadApplications()
        {
            List<object> list = new List<object>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM applicants";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new
                    {
                        ApplicationId = reader["application_id"],
                        Name = reader["full_name"],
                        Status = reader["status"]
                    });
                }
            }

            return list;
        }

        public void AcceptApplicant(int id, string remarks)
        {
            UpdateStatus(id, "Accepted", remarks);
        }

        public void RejectApplicant(int id, string remarks)
        {
            UpdateStatus(id, "Rejected", remarks);
        }

        public void HoldApplicant(int id, string remarks)
        {
            UpdateStatus(id, "Hold", remarks);
        }

        private void UpdateStatus(int id, string status, string remarks)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE applicants SET status=@status WHERE application_id=@id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                InsertAuditTrail(conn, id, status, remarks);
            }
        }

        private void InsertAuditTrail(MySqlConnection conn, int applicationId, string action, string remarks)
        {
            string query = @"
                INSERT INTO hiring_audit_trail (application_id, action, remarks)
                VALUES (@appId, @action, @remarks)";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@appId", applicationId);
            cmd.Parameters.AddWithValue("@action", action);
            cmd.Parameters.AddWithValue("@remarks", remarks);

            cmd.ExecuteNonQuery();
        }
    }
}