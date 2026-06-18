using Group1_GUI_DB_OOP_Final_Project.Database;
using Group1_GUI_DB_OOP_Final_Project.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Repositories
{
    internal class HRScreeningRepository
    {
        private readonly DatabaseConnector _databaseConnector;

        public HRScreeningRepository()
        {
            _databaseConnector = new DatabaseConnector();
        }

        public DataTable GetScreeningRequirements(int applicationID)
        {
            DataTable table = new DataTable();

            using (MySqlConnection conn = _databaseConnector.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT
                        rt.RequirementName AS Requirements,

                        CASE
                            WHEN ad.ApplicantDocumentID IS NOT NULL
                                THEN '✓ Submitted'
                            ELSE '✗ Missing'
                        END AS ApplicantInventory

                    FROM applications ap

                    INNER JOIN jobrequirements jr
                        ON ap.JobVacancyID = jr.JobVacancyID

                    INNER JOIN requirementtypes rt
                        ON jr.RequirementTypeID = rt.RequirementTypeID

                    LEFT JOIN applicantdocuments ad
                        ON ad.ApplicationID = ap.ApplicationID
                        AND ad.RequirementTypeID = rt.RequirementTypeID

                    WHERE ap.ApplicationID = @ApplicationID
                ";

                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(query, conn);

                adapter.SelectCommand.Parameters.AddWithValue(
                    "@ApplicationID",
                    applicationID);

                adapter.Fill(table);
            }

            return table;
        }

        public void SaveScreeningDecision(
            int applicationID,
            int screenedByUserID,
            string screeningStatus,
            string remarks)
        {
            using (MySqlConnection conn =
                _databaseConnector.GetConnection())
            {
                conn.Open();

                MySqlTransaction transaction =
                    conn.BeginTransaction();

                try
                {
                    //--------------------------------------------------
                    // Screening Result
                    //--------------------------------------------------

                    string screeningQuery = @"
                        INSERT INTO screeningresults
                        (
                            ApplicationID,
                            ScreenedByUserID,
                            ScreeningStatus,
                            Remarks
                        )
                        VALUES
                        (
                            @ApplicationID,
                            @ScreenedByUserID,
                            @ScreeningStatus,
                            @Remarks
                        )
                    ";

                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            screeningQuery,
                            conn,
                            transaction))
                    {
                        cmd.Parameters.AddWithValue(
                            "@ApplicationID",
                            applicationID);

                        cmd.Parameters.AddWithValue(
                            "@ScreenedByUserID",
                            screenedByUserID);

                        cmd.Parameters.AddWithValue(
                            "@ScreeningStatus",
                            screeningStatus);

                        cmd.Parameters.AddWithValue(
                            "@Remarks",
                            remarks);

                        cmd.ExecuteNonQuery();
                    }

                    //--------------------------------------------------
                    // Application Status
                    //--------------------------------------------------

                    string newStatus =
                        screeningStatus == "Qualified"
                        ? "Shortlisted"
                        : "Rejected";

                    string updateQuery = @"
                        UPDATE applications
                        SET CurrentStatus = @Status
                        WHERE ApplicationID = @ApplicationID
                    ";

                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            updateQuery,
                            conn,
                            transaction))
                    {
                        cmd.Parameters.AddWithValue(
                            "@Status",
                            newStatus);

                        cmd.Parameters.AddWithValue(
                            "@ApplicationID",
                            applicationID);

                        cmd.ExecuteNonQuery();
                    }

                    //--------------------------------------------------
                    // Status History
                    //--------------------------------------------------

                    string historyQuery = @"
                        INSERT INTO applicationstatushistory
                        (
                            ApplicationID,
                            NewStatus,
                            ChangedByUserID,
                            Remarks
                        )
                        VALUES
                        (
                            @ApplicationID,
                            @NewStatus,
                            @ChangedByUserID,
                            @Remarks
                        )
                    ";

                    using (MySqlCommand cmd =
                        new MySqlCommand(
                            historyQuery,
                            conn,
                            transaction))
                    {
                        cmd.Parameters.AddWithValue(
                            "@ApplicationID",
                            applicationID);

                        cmd.Parameters.AddWithValue(
                            "@NewStatus",
                            newStatus);

                        cmd.Parameters.AddWithValue(
                            "@ChangedByUserID",
                            screenedByUserID);

                        cmd.Parameters.AddWithValue(
                            "@Remarks",
                            remarks);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
