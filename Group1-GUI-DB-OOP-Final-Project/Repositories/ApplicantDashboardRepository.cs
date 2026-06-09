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
    internal class ApplicantDashboardRepository
    {
        private readonly DatabaseConnector _databaseConnector;

        public ApplicantDashboardRepository()
        {
            _databaseConnector = new DatabaseConnector();
        }

        private int? GetApplicantIdByAccountId(MySqlConnection connection, int applicantAccountId)
        {
            string query = @"
                SELECT ApplicantID
                FROM applicants
                WHERE ApplicantAccountID = @ApplicantAccountID
                LIMIT 1";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ApplicantAccountID", applicantAccountId);

                object result = command.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                {
                    return null;
                }

                return Convert.ToInt32(result);
            }
        }

        public ApplicantDashboardSummary GetSummary(int applicantAccountId)
        {
            try
            {
                using (MySqlConnection connection = _databaseConnector.GetConnection())
                {
                    connection.Open();

                    int? applicantId = GetApplicantIdByAccountId(connection, applicantAccountId);

                    if (applicantId == null)
                    {
                        return new ApplicantDashboardSummary
                        {
                            ApplicationCount = 0,
                            UpcomingInterviewCount = 0,
                            LatestStatus = "No Applications"
                        };
                    }

                    int applicationCount = 0;
                    int upcomingInterviewCount = 0;
                    string latestStatus = "No Applications";

                    string applicationCountQuery = @"
                        SELECT COUNT(*)
                        FROM applications
                        WHERE ApplicantID = @ApplicantID";

                    using (MySqlCommand command = new MySqlCommand(applicationCountQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantID", applicantId.Value);
                        applicationCount = Convert.ToInt32(command.ExecuteScalar());
                    }

                    string upcomingInterviewQuery = @"
                        SELECT COUNT(*)
                        FROM interviewschedules i
                        INNER JOIN applications a ON i.ApplicationID = a.ApplicationID
                        WHERE a.ApplicantID = @ApplicantID
                          AND i.Status = 'Scheduled'
                          AND (i.InterviewDate > CURDATE()
                               OR (i.InterviewDate = CURDATE() AND i.InterviewTime >= CURTIME()))";

                    using (MySqlCommand command = new MySqlCommand(upcomingInterviewQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantID", applicantId.Value);
                        upcomingInterviewCount = Convert.ToInt32(command.ExecuteScalar());
                    }

                    string latestStatusQuery = @"
                        SELECT CurrentStatus
                        FROM applications
                        WHERE ApplicantID = @ApplicantID
                        ORDER BY ApplicationDate DESC
                        LIMIT 1";

                    using (MySqlCommand command = new MySqlCommand(latestStatusQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantID", applicantId.Value);

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            latestStatus = result.ToString();
                        }
                    }

                    return new ApplicantDashboardSummary
                    {
                        ApplicationCount = applicationCount,
                        UpcomingInterviewCount = upcomingInterviewCount,
                        LatestStatus = latestStatus
                    };
                }
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 1042:
                        throw new Exception("Unable to connect to the database. Please start XAMPP/MySQL.");
                    case 1045:
                        throw new Exception("Incorrect database credentials.");
                    case 1049:
                        throw new Exception("Database was not found.");
                    default:
                        throw new Exception("Database error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error: " + ex.Message);
            }
        }

        public List<ApplicantApplicationRowDTO> GetApplications(int applicantAccountId)
        {
            try
            {
                List<ApplicantApplicationRowDTO> applications = new List<ApplicantApplicationRowDTO>();

                using (MySqlConnection connection = _databaseConnector.GetConnection())
                {
                    connection.Open();

                    int? applicantId = GetApplicantIdByAccountId(connection, applicantAccountId);
                    if (applicantId == null)
                    {
                        return applications;
                    }

                    string query = @"
                        SELECT
                            j.JobTitle AS PositionColumn,
                            DATE_FORMAT(a.ApplicationDate, '%M %d, %Y') AS DateAppliedColumn,
                            a.CurrentStatus AS StatusColumn
                        FROM applications a
                        INNER JOIN jobvacancies j ON a.JobVacancyID = j.JobVacancyID
                        WHERE a.ApplicantID = @ApplicantID
                        ORDER BY a.ApplicationDate DESC";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantID", applicantId.Value);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                applications.Add(new ApplicantApplicationRowDTO
                                {
                                    PositionColumn = reader["PositionColumn"].ToString(),
                                    DateAppliedColumn = reader["DateAppliedColumn"].ToString(),
                                    StatusColumn = reader["StatusColumn"].ToString()
                                });
                            }
                        }
                    }
                }

                return applications;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 1042:
                        throw new Exception("Unable to connect to the database. Please start XAMPP/MySQL.");
                    case 1045:
                        throw new Exception("Incorrect database credentials.");
                    case 1049:
                        throw new Exception("Database was not found.");
                    default:
                        throw new Exception("Database error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error: " + ex.Message);
            }
        }

        public List<ApplicantMissingRequirementRowDTO> GetMissingRequirements(int applicantAccountId)
        {
            try
            {
                List<ApplicantMissingRequirementRowDTO> missingRequirements = new List<ApplicantMissingRequirementRowDTO>();

                using (MySqlConnection connection = _databaseConnector.GetConnection())
                {
                    connection.Open();

                    int? applicantId = GetApplicantIdByAccountId(connection, applicantAccountId);
                    if (applicantId == null)
                    {
                        return missingRequirements;
                    }

                    string query = @"
                        SELECT
                            j.JobTitle AS JobRow,
                            rt.RequirementName AS MissReqRow
                        FROM applications a
                        INNER JOIN jobvacancies j ON a.JobVacancyID = j.JobVacancyID
                        INNER JOIN jobrequirements jr ON j.JobVacancyID = jr.JobVacancyID
                        INNER JOIN requirementtypes rt ON jr.RequirementTypeID = rt.RequirementTypeID
                        LEFT JOIN applicantdocuments ad
                            ON ad.ApplicationID = a.ApplicationID
                           AND ad.RequirementTypeID = jr.RequirementTypeID
                        WHERE a.ApplicantID = @ApplicantID
                          AND jr.IsRequired = 1
                          AND ad.ApplicantDocumentID IS NULL
                        ORDER BY j.JobTitle, rt.RequirementName";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantID", applicantId.Value);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                missingRequirements.Add(new ApplicantMissingRequirementRowDTO
                                {
                                    JobRow = reader["JobRow"].ToString(),
                                    MissReqRow = reader["MissReqRow"].ToString()
                                });
                            }
                        }
                    }
                }

                return missingRequirements;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 1042:
                        throw new Exception("Unable to connect to the database. Please start XAMPP/MySQL.");
                    case 1045:
                        throw new Exception("Incorrect database credentials.");
                    case 1049:
                        throw new Exception("Database was not found.");
                    default:
                        throw new Exception("Database error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error: " + ex.Message);
            }
        }

        public ApplicantInterviewDTO GetNearestInterview(int applicantAccountId)
        {
            try
            {
                using (MySqlConnection connection = _databaseConnector.GetConnection())
                {
                    connection.Open();

                    int? applicantId = GetApplicantIdByAccountId(connection, applicantAccountId);
                    if (applicantId == null)
                    {
                        return null;
                    }

                    string query = @"
                        SELECT
                            j.JobTitle AS PositionShower,
                            DATE_FORMAT(i.InterviewDate, '%M %d, %Y') AS DateShower,
                            TIME_FORMAT(i.InterviewTime, '%h:%i %p') AS TimeShower,
                            i.InterviewMode AS ModeShower
                        FROM interviewschedules i
                        INNER JOIN applications a ON i.ApplicationID = a.ApplicationID
                        INNER JOIN jobvacancies j ON a.JobVacancyID = j.JobVacancyID
                        WHERE a.ApplicantID = @ApplicantID
                          AND i.Status = 'Scheduled'
                          AND (i.InterviewDate > CURDATE()
                               OR (i.InterviewDate = CURDATE() AND i.InterviewTime >= CURTIME()))
                        ORDER BY i.InterviewDate ASC, i.InterviewTime ASC
                        LIMIT 1";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApplicantID", applicantId.Value);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ApplicantInterviewDTO
                                {
                                    PositionShower = reader["PositionShower"].ToString(),
                                    DateShower = reader["DateShower"].ToString(),
                                    TimeShower = reader["TimeShower"].ToString(),
                                    ModeShower = reader["ModeShower"].ToString()
                                };
                            }
                        }
                    }
                }

                return null;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 1042:
                        throw new Exception("Unable to connect to the database. Please start XAMPP/MySQL.");
                    case 1045:
                        throw new Exception("Incorrect database credentials.");
                    case 1049:
                        throw new Exception("Database was not found.");
                    default:
                        throw new Exception("Database error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected error: " + ex.Message);
            }
        }
    }
}
