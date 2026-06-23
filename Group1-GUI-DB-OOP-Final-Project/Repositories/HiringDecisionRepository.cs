using MySql.Data.MySqlClient;
using Group1_GUI_DB_OOP_Final_Project.DTOs;
using System;
using System.Collections.Generic;

namespace Group1_GUI_DB_OOP_Final_Project.Repositories
{
    public class HiringDecisionRepository
    {
        private string connectionString = "server=localhost;database=your_db;uid=root;pwd=;";

        public List<HiringDecisionDTO> GetAllApplications()
        {
            List<HiringDecisionDTO> list = new List<HiringDecisionDTO>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM applications";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new HiringDecisionDTO
                    {
                        ApplicationId = Convert.ToInt32(reader["application_id"]),
                        ApplicantName = reader["applicant_name"].ToString(),
                        Position = reader["position"].ToString(),
                        Status = reader["status"].ToString(),
                        Remarks = reader["remarks"].ToString(),
                        DateApplied = Convert.ToDateTime(reader["date_applied"])
                    });
                }
            }

            return list;
        }

        public void UpdateStatus(int id, string status, string remarks)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    UPDATE applications 
                    SET status = @status,
                        remarks = @remarks
                    WHERE application_id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@remarks", remarks);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public List<object> GetAuditTrail()
        {
            List<object> list = new List<object>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM hiring_audit_trail ORDER BY action_date DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new
                    {
                        AuditId = reader["audit_id"],
                        ApplicationId = reader["application_id"],
                        Action = reader["action"],
                        Remarks = reader["remarks"],
                        ActionDate = reader["action_date"]
                    });
                }
            }

            return list;
        }

        public void InsertAuditTrail(int applicationId, string action, string remarks)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

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
}