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
    internal class InterviewScheduleRepository
    {
        private readonly DatabaseConnector _databaseConnector;

        public InterviewScheduleRepository()
        {
            _databaseConnector = new DatabaseConnector();
        }

        // ── READ ─────────────────────────────────────────────────────────
        public InterviewApplicantInfoDTO GetApplicantInfoByApplicationID(int applicationID)
        {
            using (MySqlConnection conn = _databaseConnector.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT
                        ap.ApplicationID,
                        CONCAT(a.FirstName, ' ',
                               IFNULL(CONCAT(a.MiddleName, ' '), ''),
                               a.LastName) AS ApplicantName,
                        ap.CurrentStatus,
                        jv.JobTitle
                    FROM applications ap
                    INNER JOIN applicants a  ON ap.ApplicantID  = a.ApplicantID
                    INNER JOIN jobvacancies jv ON ap.JobVacancyID = jv.JobVacancyID
                    WHERE ap.ApplicationID = @ApplicationID
                    LIMIT 1;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", applicationID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new InterviewApplicantInfoDTO
                            {
                                ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                                ApplicantName = reader["ApplicantName"]?.ToString(),
                                CurrentStatus = reader["CurrentStatus"]?.ToString(),
                                JobApplied = reader["JobTitle"]?.ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        // ── READ: latest interview schedule for an application ────────────
        public InterviewScheduleInfoDTO GetLatestScheduleByApplicationID(int applicationID)
        {
            using (MySqlConnection conn = _databaseConnector.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT
                        InterviewScheduleID,
                        InterviewDate,
                        InterviewTime,
                        InterviewerName,
                        InterviewMode,
                        InterviewLocation,
                        Status
                    FROM interviewschedules
                    WHERE ApplicationID = @ApplicationID
                    ORDER BY InterviewScheduleID DESC
                    LIMIT 1;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicationID", applicationID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new InterviewScheduleInfoDTO
                            {
                                InterviewScheduleID = Convert.ToInt32(reader["InterviewScheduleID"]),
                                InterviewDate = Convert.ToDateTime(reader["InterviewDate"]),
                                InterviewTime = (TimeSpan)reader["InterviewTime"],
                                InterviewerName = reader["InterviewerName"]?.ToString(),
                                InterviewMode = reader["InterviewMode"]?.ToString(),
                                InterviewLocation = reader["InterviewLocation"]?.ToString(),
                                Status = reader["Status"]?.ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        // ── SAVE (single transaction: schedule + status update + history) ─
        public bool SaveInterviewSchedule(
            int applicationID,
            int scheduledByUserID,
            DateTime interviewDate,
            TimeSpan interviewTime,
            string interviewerName,
            string interviewMode,
            string interviewLocation,
            string status)
        {
            using (MySqlConnection conn = _databaseConnector.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert schedule row
                        string insertSchedule = @"
                            INSERT INTO interviewschedules
                                (ApplicationID, ScheduledByUserID,
                                 InterviewDate, InterviewTime,
                                 InterviewerName, InterviewMode,
                                 InterviewLocation, Status)
                            VALUES
                                (@ApplicationID, @ScheduledByUserID,
                                 @InterviewDate, @InterviewTime,
                                 @InterviewerName, @InterviewMode,
                                 @InterviewLocation, @Status);";

                        using (MySqlCommand cmd = new MySqlCommand(insertSchedule, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                            cmd.Parameters.AddWithValue("@ScheduledByUserID", scheduledByUserID);
                            cmd.Parameters.AddWithValue("@InterviewDate", interviewDate.Date);
                            cmd.Parameters.AddWithValue("@InterviewTime", interviewTime);
                            cmd.Parameters.AddWithValue("@InterviewerName", interviewerName);
                            cmd.Parameters.AddWithValue("@InterviewMode", interviewMode);
                            cmd.Parameters.AddWithValue("@InterviewLocation", interviewLocation);
                            cmd.Parameters.AddWithValue("@Status", status);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Capture old status for history log
                        string oldStatus = "";
                        string getOld = "SELECT CurrentStatus FROM applications WHERE ApplicationID = @ApplicationID;";
                        using (MySqlCommand cmd = new MySqlCommand(getOld, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                            object result = cmd.ExecuteScalar();
                            oldStatus = result?.ToString() ?? "";
                        }

                        // 3. Update application status → For Interview
                        string updateApp = @"
                            UPDATE applications
                            SET    CurrentStatus = 'For Interview'
                            WHERE  ApplicationID  = @ApplicationID;";

                        using (MySqlCommand cmd = new MySqlCommand(updateApp, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                            cmd.ExecuteNonQuery();
                        }

                        // 4. Insert status history record
                        string insertHistory = @"
                            INSERT INTO applicationstatushistory
                                (ApplicationID, OldStatus, NewStatus,
                                 ChangedByUserID, Remarks, ChangedAt)
                            VALUES
                                (@ApplicationID, @OldStatus, 'For Interview',
                                 @ChangedByUserID, 'Interview scheduled.', @ChangedAt);";

                        using (MySqlCommand cmd = new MySqlCommand(insertHistory, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                            cmd.Parameters.AddWithValue("@OldStatus", oldStatus);
                            cmd.Parameters.AddWithValue("@ChangedByUserID", scheduledByUserID);
                            cmd.Parameters.AddWithValue("@ChangedAt", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return true;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

    }
}
