using Group1_GUI_DB_OOP_Final_Project.Database;
using Group1_GUI_DB_OOP_Final_Project.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Repositories
{
    internal class JobVacancyRepository
    {
        private readonly DatabaseConnector _db = new DatabaseConnector();

        public List<JobVacancyListDTO> GetOpenJobs(int applicantAccountId, string searchText)
        {
            List<JobVacancyListDTO> jobs = new List<JobVacancyListDTO>();

            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        j.JobVacancyID,
                        j.JobTitle,
                        d.DepartmentName,
                        e.EmploymentTypeName,
                        j.Status,
                        COALESCE(a.CurrentStatus, 'Not Applied') AS ApplicationStatus
                    FROM jobvacancies j
                    INNER JOIN departments d ON j.DepartmentID = d.DepartmentID
                    INNER JOIN employmenttypes e ON j.EmploymentTypeID = e.EmploymentTypeID
                    LEFT JOIN applications a 
                        ON a.JobVacancyID = j.JobVacancyID
                    LEFT JOIN applicants ap
                        ON ap.ApplicantID = a.ApplicantID
                    WHERE j.Status = 'Open'
                      AND (@SearchText = '' OR j.JobTitle LIKE CONCAT('%', @SearchText, '%'))
                    ORDER BY j.PostedDate DESC, j.JobTitle ASC;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchText", searchText ?? "");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jobs.Add(new JobVacancyListDTO
                            {
                                JobVacancyID = Convert.ToInt32(reader["JobVacancyID"]),
                                JobTitle = reader["JobTitle"].ToString(),
                                DepartmentName = reader["DepartmentName"].ToString(),
                                EmploymentTypeName = reader["EmploymentTypeName"].ToString(),
                                Status = reader["Status"].ToString(),
                                ApplicationStatus = reader["ApplicationStatus"].ToString()
                            });
                        }
                    }
                }
            }

            return jobs;
        }

        public JobVacancyDetailsDTO GetJobDetails(int applicantAccountId, int jobVacancyId)
        {
            JobVacancyDetailsDTO job = null;

            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT 
                        j.JobVacancyID,
                        j.JobTitle,
                        d.DepartmentName,
                        e.EmploymentTypeName,
                        j.Status,
                        j.JobDescription,
                        j.Qualifications,
                        COALESCE(a.CurrentStatus, 'Not Applied') AS ApplicationStatus
                    FROM jobvacancies j
                    INNER JOIN departments d ON j.DepartmentID = d.DepartmentID
                    INNER JOIN employmenttypes e ON j.EmploymentTypeID = e.EmploymentTypeID
                    LEFT JOIN applications a 
                        ON a.JobVacancyID = j.JobVacancyID
                    WHERE j.JobVacancyID = @JobVacancyID
                    LIMIT 1;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            job = new JobVacancyDetailsDTO
                            {
                                JobVacancyID = Convert.ToInt32(reader["JobVacancyID"]),
                                JobTitle = reader["JobTitle"].ToString(),
                                DepartmentName = reader["DepartmentName"].ToString(),
                                EmploymentTypeName = reader["EmploymentTypeName"].ToString(),
                                Status = reader["Status"].ToString(),
                                JobDescription = reader["JobDescription"].ToString(),
                                Qualifications = reader["Qualifications"].ToString(),
                                ApplicationStatus = reader["ApplicationStatus"].ToString()
                            };
                        }
                    }
                }

                if (job != null)
                {
                    string reqSql = @"
                        SELECT rt.RequirementName
                        FROM jobrequirements jr
                        INNER JOIN requirementtypes rt ON jr.RequirementTypeID = rt.RequirementTypeID
                        WHERE jr.JobVacancyID = @JobVacancyID
                          AND jr.IsRequired = 1
                        ORDER BY rt.RequirementName;";

                    List<string> reqs = new List<string>();

                    using (MySqlCommand cmd = new MySqlCommand(reqSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reqs.Add(reader["RequirementName"].ToString());
                            }
                        }
                    }

                    job.RequiredDocuments = reqs.Count > 0 ? string.Join(Environment.NewLine, reqs) : "None";
                }
            }

            return job;
        }

        public OperationResultDTO Apply(int applicantAccountId, int jobVacancyId)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        int applicantId = GetApplicantId(conn, tx, applicantAccountId);
                        if (applicantId == 0)
                        {
                            tx.Rollback();
                            return new OperationResultDTO
                            {
                                Success = false,
                                Message = "Please complete your applicant profile first."
                            };
                        }

                        if (!IsJobOpen(conn, tx, jobVacancyId))
                        {
                            tx.Rollback();
                            return new OperationResultDTO
                            {
                                Success = false,
                                Message = "This job is already closed."
                            };
                        }

                        if (HasDuplicateApplication(conn, tx, applicantId, jobVacancyId))
                        {
                            tx.Rollback();
                            return new OperationResultDTO
                            {
                                Success = false,
                                Message = "You already applied for this job."
                            };
                        }

                        int applicationId = InsertApplication(conn, tx, applicantId, jobVacancyId);
                        InsertStatusHistory(conn, tx, applicationId, null, "Submitted", null, "Applicant submitted the application.");

                        tx.Commit();

                        return new OperationResultDTO
                        {
                            Success = true,
                            Message = "Application submitted successfully."
                        };
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); } catch { }
                        return new OperationResultDTO
                        {
                            Success = false,
                            Message = ex.Message
                        };
                    }
                }
            }
        }

        private int GetApplicantId(MySqlConnection conn, MySqlTransaction tx, int applicantAccountId)
        {
            string sql = "SELECT ApplicantID FROM applicants WHERE ApplicantAccountID = @ApplicantAccountID LIMIT 1;";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ApplicantAccountID", applicantAccountId);
                object result = cmd.ExecuteScalar();
                return result == null ? 0 : Convert.ToInt32(result);
            }
        }

        private bool IsJobOpen(MySqlConnection conn, MySqlTransaction tx, int jobVacancyId)
        {
            string sql = "SELECT Status FROM jobvacancies WHERE JobVacancyID = @JobVacancyID LIMIT 1;";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);
                object result = cmd.ExecuteScalar();
                return result != null && result.ToString() == "Open";
            }
        }

        private bool HasDuplicateApplication(MySqlConnection conn, MySqlTransaction tx, int applicantId, int jobVacancyId)
        {
            string sql = @"
                SELECT ApplicationID
                FROM applications
                WHERE ApplicantID = @ApplicantID
                  AND JobVacancyID = @JobVacancyID
                LIMIT 1;";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ApplicantID", applicantId);
                cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);
                object result = cmd.ExecuteScalar();
                return result != null;
            }
        }

        private int InsertApplication(MySqlConnection conn, MySqlTransaction tx, int applicantId, int jobVacancyId)
        {
            string sql = @"
                INSERT INTO applications (ApplicantID, JobVacancyID, ApplicationDate, CurrentStatus, IsLocked)
                VALUES (@ApplicantID, @JobVacancyID, NOW(), 'Submitted', 0);
                SELECT LAST_INSERT_ID();";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ApplicantID", applicantId);
                cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void InsertStatusHistory(MySqlConnection conn, MySqlTransaction tx, int applicationId, string oldStatus, string newStatus, int? changedByUserId, string remarks)
        {
            string sql = @"
                INSERT INTO applicationstatushistory
                (ApplicationID, OldStatus, NewStatus, ChangedByUserID, Remarks, ChangedAt)
                VALUES
                (@ApplicationID, @OldStatus, @NewStatus, @ChangedByUserID, @Remarks, NOW());";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ApplicationID", applicationId);
                cmd.Parameters.AddWithValue("@OldStatus", (object)oldStatus ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NewStatus", newStatus);
                cmd.Parameters.AddWithValue("@ChangedByUserID", (object)changedByUserId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Remarks", remarks);
                cmd.ExecuteNonQuery();
            }
        }
        public List<JobVacancyListDTO> GetAllVacancies(string searchText)
        {
            List<JobVacancyListDTO> jobs = new List<JobVacancyListDTO>();

            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string sql = @"
            SELECT 
                j.JobVacancyID,
                j.JobTitle,
                d.DepartmentName,
                e.EmploymentTypeName,
                j.Status
            FROM jobvacancies j
            INNER JOIN departments d ON j.DepartmentID = d.DepartmentID
            INNER JOIN employmenttypes e ON j.EmploymentTypeID = e.EmploymentTypeID
            WHERE (@SearchText = '' OR j.JobTitle LIKE CONCAT('%', @SearchText, '%'))
            ORDER BY j.PostedDate DESC;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchText", searchText ?? "");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jobs.Add(new JobVacancyListDTO
                            {
                                JobVacancyID = Convert.ToInt32(reader["JobVacancyID"]),
                                JobTitle = reader["JobTitle"].ToString(),
                                DepartmentName = reader["DepartmentName"].ToString(),
                                EmploymentTypeName = reader["EmploymentTypeName"].ToString(),
                                Status = reader["Status"].ToString()
                            });
                        }
                    }
                }
            }

            return jobs;
        }
        public void UpdateStatus(int jobVacancyId, string status)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string sql = @"UPDATE jobvacancies 
                       SET Status = @Status 
                       WHERE JobVacancyID = @JobVacancyID";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddVacancy(string jobTitle, string jobDescription, string qualifications, int departmentId, int employmentTypeId)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string sql = @"
            INSERT INTO jobvacancies
            (JobTitle, JobDescription, Qualifications, DepartmentID, EmploymentTypeID, Status, PostedDate)
            VALUES
            (@JobTitle, @JobDescription, @Qualifications, @DepartmentID, @EmploymentTypeID, 'Open', NOW());";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@JobTitle", jobTitle);
                    cmd.Parameters.AddWithValue("@JobDescription", jobDescription);
                    cmd.Parameters.AddWithValue("@Qualifications", qualifications);
                    cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                    cmd.Parameters.AddWithValue("@EmploymentTypeID", employmentTypeId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateVacancy(int jobVacancyId, string jobTitle, string jobDescription, string qualifications, int departmentId, int employmentTypeId)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string sql = @"
            UPDATE jobvacancies
            SET 
                JobTitle = @JobTitle,
                JobDescription = @JobDescription,
                Qualifications = @Qualifications,
                DepartmentID = @DepartmentID,
                EmploymentTypeID = @EmploymentTypeID
            WHERE JobVacancyID = @JobVacancyID;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);
                    cmd.Parameters.AddWithValue("@JobTitle", jobTitle);
                    cmd.Parameters.AddWithValue("@JobDescription", jobDescription);
                    cmd.Parameters.AddWithValue("@Qualifications", qualifications);
                    cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                    cmd.Parameters.AddWithValue("@EmploymentTypeID", employmentTypeId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
