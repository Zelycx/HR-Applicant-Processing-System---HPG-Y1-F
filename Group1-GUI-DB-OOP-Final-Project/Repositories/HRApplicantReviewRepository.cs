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
    internal class HRApplicantReviewRepository
    {
        private readonly DatabaseConnector _databaseConnector;

        public HRApplicantReviewRepository()
        {
            _databaseConnector = new DatabaseConnector();
        }

        public HRApplicantReviewDTO GetApplicantReviewByApplicationID(int applicationID)
        {
            using (MySqlConnection conn = _databaseConnector.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT
                        ap.ApplicationID,
                        a.FirstName,
                        a.MiddleName,
                        a.LastName,
                        a.Gender,
                        a.Address,
                        a.Phone,
                        aa.Email,
                        a.BirthDate,
                        a.School,
                        a.Course,
                        a.EducationLevel,
                        a.WorkExperience,
                        a.Skills
                    FROM applications ap
                    INNER JOIN applicants a
                        ON ap.ApplicantID = a.ApplicantID
                    INNER JOIN applicantaccounts aa
                        ON a.ApplicantAccountID = aa.ApplicantAccountID
                    WHERE ap.ApplicationID = @ApplicationID
                    LIMIT 1;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", applicationID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new HRApplicantReviewDTO
                            {
                                ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                                FirstName = reader["FirstName"]?.ToString(),
                                MiddleName = reader["MiddleName"]?.ToString(),
                                LastName = reader["LastName"]?.ToString(),
                                Gender = reader["Gender"]?.ToString(),
                                Address = reader["Address"]?.ToString(),
                                ContactNumber = reader["Phone"]?.ToString(),
                                Email = reader["Email"]?.ToString(),
                                BirthDate = reader["BirthDate"] == DBNull.Value
                                    ? null
                                    : Convert.ToDateTime(reader["BirthDate"]),
                                School = reader["School"]?.ToString(),
                                Course = reader["Course"]?.ToString(),
                                YearLevel = reader["EducationLevel"]?.ToString(),
                                Experience = reader["WorkExperience"]?.ToString(),
                                Skill = reader["Skills"]?.ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
