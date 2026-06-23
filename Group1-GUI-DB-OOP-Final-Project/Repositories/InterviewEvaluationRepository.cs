using Group1_GUI_DB_OOP_Final_Project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Repositories
{
    internal class InterviewEvaluationRepository
    {
        private readonly DatabaseConnector _databaseConnector;

        public InterviewEvaluationRepository()
        {
            _databaseConnector = new DatabaseConnector();
        }

        // ── SAVE (single transaction: evaluation + schedule status + app status + history) ─
        public bool SaveEvaluation(
            int interviewScheduleID,
            int evaluatorUserID,
            decimal score,
            string result,
            string remarks)
        {
            using (MySqlConnection conn = _databaseConnector.GetConnection())
            {
                conn.Open();
                using (MySqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert evaluation row
                        string insertEval = @"
                            INSERT INTO interviewevaluations
                                (InterviewScheduleID, EvaluatorUserID, Score, Result, Remarks)
                            VALUES
                                (@InterviewScheduleID, @EvaluatorUserID, @Score, @Result, @Remarks);";

                        using (MySqlCommand cmd = new MySqlCommand(insertEval, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@InterviewScheduleID", interviewScheduleID);
                            cmd.Parameters.AddWithValue("@EvaluatorUserID", evaluatorUserID);
                            cmd.Parameters.AddWithValue("@Score", score);
                            cmd.Parameters.AddWithValue("@Result", result);
                            cmd.Parameters.AddWithValue("@Remarks", remarks);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Mark the interview schedule as Completed
                        string updateSchedule = @"
                            UPDATE interviewschedules
                            SET    Status = 'Completed'
                            WHERE  InterviewScheduleID = @InterviewScheduleID;";

                        using (MySqlCommand cmd = new MySqlCommand(updateSchedule, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@InterviewScheduleID", interviewScheduleID);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Get the ApplicationID tied to this schedule
                        int applicationID;
                        string getAppID = "SELECT ApplicationID FROM interviewschedules WHERE InterviewScheduleID = @InterviewScheduleID;";
                        using (MySqlCommand cmd = new MySqlCommand(getAppID, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@InterviewScheduleID", interviewScheduleID);
                            applicationID = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 4. Capture old status for history log
                        string oldStatus;
                        string getOld = "SELECT CurrentStatus FROM applications WHERE ApplicationID = @ApplicationID;";
                        using (MySqlCommand cmd = new MySqlCommand(getOld, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                            object res = cmd.ExecuteScalar();
                            oldStatus = res?.ToString() ?? "";
                        }

                        // 5. Update application status → For Final Review
                        string updateApp = @"
                            UPDATE applications
                            SET    CurrentStatus = 'For Final Review'
                            WHERE  ApplicationID = @ApplicationID;";

                        using (MySqlCommand cmd = new MySqlCommand(updateApp, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                            cmd.ExecuteNonQuery();
                        }

                        // 6. Insert status history record
                        string insertHistory = @"
                            INSERT INTO applicationstatushistory
                                (ApplicationID, OldStatus, NewStatus,
                                 ChangedByUserID, Remarks, ChangedAt)
                            VALUES
                                (@ApplicationID, @OldStatus, 'For Final Review',
                                 @ChangedByUserID, 'Interview evaluated.', @ChangedAt);";

                        using (MySqlCommand cmd = new MySqlCommand(insertHistory, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
                            cmd.Parameters.AddWithValue("@OldStatus", oldStatus);
                            cmd.Parameters.AddWithValue("@ChangedByUserID", evaluatorUserID);
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
