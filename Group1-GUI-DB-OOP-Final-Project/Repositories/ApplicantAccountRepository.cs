using Group1_GUI_DB_OOP_Final_Project.Database;
using Group1_GUI_DB_OOP_Final_Project.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Repositories
{
    public class ApplicantAccountRepository
    {
        private readonly DatabaseConnector databaseConnector;

        public ApplicantAccountRepository()
        {
            databaseConnector = new DatabaseConnector();
        }

        public ApplicantAccounts GetByEmail(string email)
        {
            try
            {
                using (MySqlConnection connection =
                       databaseConnector.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            ApplicantAccountID,
                            Email,
                            PasswordHash,
                            IsActive,
                            CreatedAt
                        FROM applicantaccounts
                        WHERE Email = @Email
                        LIMIT 1";

                    using (MySqlCommand command =
                           new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@Email",
                            email);

                        using (MySqlDataReader reader =
                               command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ApplicantAccounts
                                {
                                    ApplicantAccountID =
                                        Convert.ToInt32(
                                            reader["ApplicantAccountID"]),

                                    Email =
                                        reader["Email"].ToString(),

                                    PasswordHash =
                                        reader["PasswordHash"].ToString(),

                                    IsActive =
                                        Convert.ToBoolean(
                                            reader["IsActive"]),

                                    CreatedAt =
                                        Convert.ToDateTime(
                                            reader["CreatedAt"])
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
                        throw new Exception(
                            "Please start XAMPP/MySQL.");

                    case 1045:
                        throw new Exception(
                            "Incorrect DB credentials.");

                    case 1049:
                        throw new Exception(
                            "Database was not found.");

                    default:
                        throw new Exception(
                            "Database error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Unexpected error: " + ex.Message);
            }
        }

        public bool EmailExists(string email)
        {
            try
            {
                using (MySqlConnection connection =
                       databaseConnector.GetConnection())
                {
                    connection.Open();

                    string query = @"
                        SELECT COUNT(*)
                        FROM applicantaccounts
                        WHERE Email = @Email";

                    using (MySqlCommand command =
                           new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@Email",
                            email);

                        int count =
                            Convert.ToInt32(
                                command.ExecuteScalar());

                        return count > 0;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}