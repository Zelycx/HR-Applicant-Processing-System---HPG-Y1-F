using Group1_GUI_DB_OOP_Final_Project.Database;
using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Repositories
{
    internal class HRDashboardRepository
    {
        private readonly DatabaseConnector _databaseConnector;

        public HRDashboardRepository()
        {
            _databaseConnector = new DatabaseConnector();
        }

        public HRDashboardCountsDTO GetDashboardCounts()
        {
            using (MySqlConnection conn = _databaseConnector.GetConnection())
            {
                conn.Open();

                return new HRDashboardCountsDTO
                {
                    TotalApplicants = GetCount(conn, @"
                        SELECT COUNT(*)
                        FROM applicants;"),

                    PendingReview = GetCount(conn, @"
                        SELECT COUNT(*)
                        FROM applications
                        WHERE CurrentStatus = 'Submitted';"),

                    ForInterview = GetCount(conn, @"
                        SELECT COUNT(*)
                        FROM applications
                        WHERE CurrentStatus = 'For Interview';"),

                    Accepted = GetCount(conn, @"
                        SELECT COUNT(*)
                        FROM applications
                        WHERE CurrentStatus = 'Accepted';"),

                    Rejected = GetCount(conn, @"
                        SELECT COUNT(*)
                        FROM applications
                        WHERE CurrentStatus = 'Rejected';"),

                    OpenVacancies = GetCount(conn, @"
                        SELECT COUNT(*)
                        FROM jobvacancies
                        WHERE Status = 'Open';"),

                    MissingDocuments = GetCount(conn, @"
                        SELECT COUNT(*)
                        FROM (
                            SELECT a.ApplicationID, jr.RequirementTypeID
                            FROM applications a
                            INNER JOIN jobrequirements jr
                                ON jr.JobVacancyID = a.JobVacancyID
                               AND jr.IsRequired = 1
                            LEFT JOIN applicantdocuments ad
                                ON ad.ApplicationID = a.ApplicationID
                               AND ad.RequirementTypeID = jr.RequirementTypeID
                            WHERE ad.ApplicantDocumentID IS NULL
                        ) AS MissingDocs;"),

                    InterviewsToday = GetCount(conn, @"
                        SELECT COUNT(*)
                        FROM interviewschedules
                        WHERE InterviewDate = CURDATE()
                          AND Status = 'Scheduled';")
                };
            }
        }

        private int GetCount(MySqlConnection conn, string query)
        {
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return 0;

                return Convert.ToInt32(result);
            }
        }
    }
}
