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

        // ════════════════════════════════════════════════════════════
        //  APPLICANT-SIDE
        // ════════════════════════════════════════════════════════════

        public List<JobVacancyListDTO> GetOpenJobs(int applicantAccountId, string searchText)
        {
            var jobs = new List<JobVacancyListDTO>();

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

                    var reqs = new List<string>();

                    using (MySqlCommand cmd = new MySqlCommand(reqSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                reqs.Add(reader["RequirementName"].ToString());
                        }
                    }

                    job.RequiredDocuments = reqs.Count > 0
                        ? string.Join(Environment.NewLine, reqs)
                        : "None";
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
                        InsertStatusHistory(conn, tx, applicationId, null, "Submitted", null,
                            "Applicant submitted the application.");

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

        // ════════════════════════════════════════════════════════════
        //  PRIVATE HELPERS (used by Apply)
        // ════════════════════════════════════════════════════════════

        private int GetApplicantId(MySqlConnection conn, MySqlTransaction tx, int applicantAccountId)
        {
            string sql = @"SELECT ApplicantID FROM applicants
                           WHERE ApplicantAccountID = @ApplicantAccountID LIMIT 1;";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ApplicantAccountID", applicantAccountId);
                object result = cmd.ExecuteScalar();
                return result == null ? 0 : Convert.ToInt32(result);
            }
        }

        private bool IsJobOpen(MySqlConnection conn, MySqlTransaction tx, int jobVacancyId)
        {
            string sql = @"SELECT Status FROM jobvacancies
                           WHERE JobVacancyID = @JobVacancyID LIMIT 1;";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);
                object result = cmd.ExecuteScalar();
                return result != null && result.ToString() == "Open";
            }
        }

        private bool HasDuplicateApplication(MySqlConnection conn, MySqlTransaction tx,
            int applicantId, int jobVacancyId)
        {
            string sql = @"
                SELECT ApplicationID FROM applications
                WHERE ApplicantID  = @ApplicantID
                  AND JobVacancyID = @JobVacancyID
                LIMIT 1;";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ApplicantID", applicantId);
                cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);
                return cmd.ExecuteScalar() != null;
            }
        }

        private int InsertApplication(MySqlConnection conn, MySqlTransaction tx,
            int applicantId, int jobVacancyId)
        {
            string sql = @"
                INSERT INTO applications
                    (ApplicantID, JobVacancyID, ApplicationDate, CurrentStatus, IsLocked)
                VALUES
                    (@ApplicantID, @JobVacancyID, NOW(), 'Submitted', 0);
                SELECT LAST_INSERT_ID();";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@ApplicantID", applicantId);
                cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void InsertStatusHistory(MySqlConnection conn, MySqlTransaction tx,
            int applicationId, string oldStatus, string newStatus,
            int? changedByUserId, string remarks)
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

        // ════════════════════════════════════════════════════════════
        //  HR-SIDE: LIST
        // ════════════════════════════════════════════════════════════

        public List<JobVacancyListDTO> GetAllVacancies(string searchText)
        {
            var jobs = new List<JobVacancyListDTO>();

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

        // ════════════════════════════════════════════════════════════
        //  HR-SIDE: LOOKUPS (for dropdowns / CheckedListBox)
        // ════════════════════════════════════════════════════════════

        public JobVacancyEditDTO GetVacancyForEdit(int jobVacancyId)
        {
            JobVacancyEditDTO job = null;

            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT JobVacancyID, JobTitle, JobDescription, Qualifications,
                           DepartmentID, EmploymentTypeID
                    FROM jobvacancies
                    WHERE JobVacancyID = @JobVacancyID
                    LIMIT 1;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            job = new JobVacancyEditDTO
                            {
                                JobVacancyID = Convert.ToInt32(reader["JobVacancyID"]),
                                JobTitle = reader["JobTitle"].ToString(),
                                JobDescription = reader["JobDescription"]?.ToString() ?? "",
                                Qualifications = reader["Qualifications"]?.ToString() ?? "",
                                DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                                EmploymentTypeID = Convert.ToInt32(reader["EmploymentTypeID"])
                            };
                        }
                    }
                }

                if (job != null)
                {
                    string reqSql = @"
                        SELECT RequirementTypeID FROM jobrequirements
                        WHERE JobVacancyID = @JobVacancyID AND IsRequired = 1;";

                    using (MySqlCommand cmd = new MySqlCommand(reqSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                job.RequirementTypeIDs.Add(Convert.ToInt32(reader["RequirementTypeID"]));
                        }
                    }
                }
            }

            return job;
        }

        public List<LookupDTO> GetDepartments()
        {
            var list = new List<LookupDTO>();

            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT DepartmentID, DepartmentName
                               FROM departments ORDER BY DepartmentName;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new LookupDTO
                        {
                            ID = Convert.ToInt32(reader["DepartmentID"]),
                            Name = reader["DepartmentName"].ToString()
                        });
                }
            }

            return list;
        }

        public List<LookupDTO> GetEmploymentTypes()
        {
            var list = new List<LookupDTO>();

            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT EmploymentTypeID, EmploymentTypeName
                               FROM employmenttypes ORDER BY EmploymentTypeName;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new LookupDTO
                        {
                            ID = Convert.ToInt32(reader["EmploymentTypeID"]),
                            Name = reader["EmploymentTypeName"].ToString()
                        });
                }
            }

            return list;
        }

        public List<LookupDTO> GetRequirementTypes()
        {
            var list = new List<LookupDTO>();

            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"SELECT RequirementTypeID, RequirementName
                               FROM requirementtypes ORDER BY RequirementName;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(new LookupDTO
                        {
                            ID = Convert.ToInt32(reader["RequirementTypeID"]),
                            Name = reader["RequirementName"].ToString()
                        });
                }
            }

            return list;
        }

        // ════════════════════════════════════════════════════════════
        //  HR-SIDE: SAVE (Add / Update with requirements)
        // ════════════════════════════════════════════════════════════

        // Wipes and re-inserts jobrequirements inside a transaction
        private void SaveJobRequirements(MySqlConnection conn, MySqlTransaction tx,
            int jobVacancyId, List<int> requirementTypeIds)
        {
            string deleteSql = @"DELETE FROM jobrequirements WHERE JobVacancyID = @JobVacancyID;";
            using (MySqlCommand cmd = new MySqlCommand(deleteSql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);
                cmd.ExecuteNonQuery();
            }

            foreach (int rtId in requirementTypeIds)
            {
                string insertSql = @"
                    INSERT INTO jobrequirements (JobVacancyID, RequirementTypeID, IsRequired)
                    VALUES (@JobVacancyID, @RequirementTypeID, 1);";

                using (MySqlCommand cmd = new MySqlCommand(insertSql, conn, tx))
                {
                    cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);
                    cmd.Parameters.AddWithValue("@RequirementTypeID", rtId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddVacancy(string jobTitle, string jobDescription, string qualifications,
            int departmentId, int employmentTypeId, int createdByUserId,
            List<int> requirementTypeIds)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = @"
                            INSERT INTO jobvacancies
                                (JobTitle, JobDescription, Qualifications, DepartmentID,
                                 EmploymentTypeID, Status, PostedDate, CreatedByUserID)
                            VALUES
                                (@JobTitle, @JobDescription, @Qualifications, @DepartmentID,
                                 @EmploymentTypeID, 'Open', NOW(), @CreatedByUserID);
                            SELECT LAST_INSERT_ID();";

                        int newId;
                        using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@JobTitle", jobTitle);
                            cmd.Parameters.AddWithValue("@JobDescription", jobDescription);
                            cmd.Parameters.AddWithValue("@Qualifications", qualifications);
                            cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                            cmd.Parameters.AddWithValue("@EmploymentTypeID", employmentTypeId);
                            cmd.Parameters.AddWithValue("@CreatedByUserID", createdByUserId);
                            newId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        SaveJobRequirements(conn, tx, newId, requirementTypeIds);
                        tx.Commit();
                    }
                    catch
                    {
                        try { tx.Rollback(); } catch { }
                        throw;
                    }
                }
            }
        }

        public void UpdateVacancy(int jobVacancyId, string jobTitle, string jobDescription,
            string qualifications, int departmentId, int employmentTypeId,
            List<int> requirementTypeIds)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = @"
                            UPDATE jobvacancies
                            SET JobTitle         = @JobTitle,
                                JobDescription   = @JobDescription,
                                Qualifications   = @Qualifications,
                                DepartmentID     = @DepartmentID,
                                EmploymentTypeID = @EmploymentTypeID
                            WHERE JobVacancyID = @JobVacancyID;";

                        using (MySqlCommand cmd = new MySqlCommand(sql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);
                            cmd.Parameters.AddWithValue("@JobTitle", jobTitle);
                            cmd.Parameters.AddWithValue("@JobDescription", jobDescription);
                            cmd.Parameters.AddWithValue("@Qualifications", qualifications);
                            cmd.Parameters.AddWithValue("@DepartmentID", departmentId);
                            cmd.Parameters.AddWithValue("@EmploymentTypeID", employmentTypeId);
                            cmd.ExecuteNonQuery();
                        }

                        SaveJobRequirements(conn, tx, jobVacancyId, requirementTypeIds);
                        tx.Commit();
                    }
                    catch
                    {
                        try { tx.Rollback(); } catch { }
                        throw;
                    }
                }
            }
        }

        // ════════════════════════════════════════════════════════════
        //  HR-SIDE: STATUS TOGGLE
        // ════════════════════════════════════════════════════════════

        public void UpdateJobStatus(int jobVacancyId, string status)
        {
            using (MySqlConnection conn = _db.GetConnection())
            {
                conn.Open();
                string sql = @"UPDATE jobvacancies SET Status = @Status
                               WHERE JobVacancyID = @JobVacancyID;";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@JobVacancyID", jobVacancyId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Kept for backward compatibility — delegates to UpdateJobStatus
        public void UpdateStatus(int jobVacancyId, string status)
            => UpdateJobStatus(jobVacancyId, status);
    }
}
