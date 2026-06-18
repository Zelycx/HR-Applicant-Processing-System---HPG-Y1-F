using Group1_GUI_DB_OOP_Final_Project.Database;
using Group1_GUI_DB_OOP_Final_Project.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Repositories
{
    internal class HRApplicantListRepository
    {
        private readonly DatabaseConnector _databaseConnector;

        public HRApplicantListRepository()
        {
            _databaseConnector = new DatabaseConnector();
        }

        public List<HRApplicantListDTO> GetApplicantList(
            string applicantName,
            string applicantStatus,
            string positionApplied)
        {
            List<HRApplicantListDTO> applicants = new List<HRApplicantListDTO>();

            using (MySqlConnection conn = _databaseConnector.GetConnection())
            {
                conn.Open();

                StringBuilder query = new StringBuilder(@"
                    SELECT
                        ap.ApplicationID,
                        CONCAT_WS(' ', a.FirstName, a.MiddleName, a.LastName) AS ApplicantName,
                        j.JobTitle AS PositionApplied,
                        ap.CurrentStatus AS Status,
                        DATE_FORMAT(ap.ApplicationDate, '%M %d, %Y') AS DateApplied
                    FROM applications ap
                    INNER JOIN applicants a ON ap.ApplicantID = a.ApplicantID
                    INNER JOIN jobvacancies j ON ap.JobVacancyID = j.JobVacancyID
                    WHERE 1=1
                ");

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(applicantName))
                {
                    query.Append(@"
                        AND CONCAT_WS(' ', a.FirstName, a.MiddleName, a.LastName)
                        LIKE @name
                    ");
                    cmd.Parameters.AddWithValue("@name", "%" + applicantName + "%");
                }

                if (!string.IsNullOrWhiteSpace(applicantStatus) && applicantStatus != "All")
                {
                    query.Append(" AND ap.CurrentStatus = @status ");
                    cmd.Parameters.AddWithValue("@status", applicantStatus);
                }

                if (!string.IsNullOrWhiteSpace(positionApplied) && positionApplied != "All")
                {
                    query.Append(" AND j.JobTitle = @position ");
                    cmd.Parameters.AddWithValue("@position", positionApplied);
                }

                query.Append(" ORDER BY ap.ApplicationDate DESC ");
                cmd.CommandText = query.ToString();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    applicants.Add(new HRApplicantListDTO
                    {
                        ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                        ApplicantName = reader["ApplicantName"].ToString(),
                        PositionApplied = reader["PositionApplied"].ToString(),
                        Status = reader["Status"].ToString(),
                        DateApplied = reader["DateApplied"].ToString()
                    });
                }
            }

            return applicants;
        }
    }
}
