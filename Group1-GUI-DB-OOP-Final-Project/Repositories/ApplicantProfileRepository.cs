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
    internal class ApplicantProfileRepository
    {
        private readonly DatabaseConnector _databaseConnector;

        public ApplicantProfileRepository()
        {
            _databaseConnector = new DatabaseConnector();
        }

        public ApplicantProfileDTO GetProfileByAccountId(int applicantAccountId)
        {
            using (MySqlConnection connection = _databaseConnector.GetConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        aa.ApplicantAccountID,
                        aa.Email,
                        a.FirstName,
                        a.MiddleName,
                        a.LastName,
                        a.Gender,
                        a.BirthDate,
                        a.Phone,
                        a.Address,
                        a.EducationLevel,
                        a.School,
                        a.Course,
                        a.Skills,
                        a.WorkExperience
                    FROM applicantaccounts aa
                    LEFT JOIN applicants a
                        ON aa.ApplicantAccountID = a.ApplicantAccountID
                    WHERE aa.ApplicantAccountID = @ApplicantAccountID
                    LIMIT 1";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicantAccountID", applicantAccountId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ApplicantProfileDTO
                            {
                                ApplicantAccountID = Convert.ToInt32(reader["ApplicantAccountID"]),
                                Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString(),
                                FirstName = reader["FirstName"] == DBNull.Value ? "" : reader["FirstName"].ToString(),
                                MiddleName = reader["MiddleName"] == DBNull.Value ? "" : reader["MiddleName"].ToString(),
                                LastName = reader["LastName"] == DBNull.Value ? "" : reader["LastName"].ToString(),
                                Gender = reader["Gender"] == DBNull.Value ? "" : reader["Gender"].ToString(),
                                BirthDate = reader["BirthDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["BirthDate"]),
                                Address = reader["Address"] == DBNull.Value ? "" : reader["Address"].ToString(),
                                ContactNumber = reader["Phone"] == DBNull.Value ? "" : reader["Phone"].ToString(),
                                School = reader["School"] == DBNull.Value ? "" : reader["School"].ToString(),
                                Course = reader["Course"] == DBNull.Value ? "" : reader["Course"].ToString(),
                                YearLevel = reader["EducationLevel"] == DBNull.Value ? "" : reader["EducationLevel"].ToString(),
                                Skills = reader["Skills"] == DBNull.Value ? "" : reader["Skills"].ToString(),
                                WorkExperience = reader["WorkExperience"] == DBNull.Value ? "" : reader["WorkExperience"].ToString()
                            };
                        }
                    }
                }

                return new ApplicantProfileDTO
                {
                    ApplicantAccountID = applicantAccountId,
                    Email = ""
                };
            }
        }

        public bool EmailExistsForOtherAccount(string email, int applicantAccountId)
        {
            using (MySqlConnection connection = _databaseConnector.GetConnection())
            {
                connection.Open();

                string query = @"
                    SELECT COUNT(*)
                    FROM applicantaccounts
                    WHERE Email = @Email
                      AND ApplicantAccountID <> @ApplicantAccountID";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@ApplicantAccountID", applicantAccountId);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public ProfileSaveResultDTO SaveOrUpdateProfile(ApplicantProfileDTO dto)
        {
            using (MySqlConnection connection = _databaseConnector.GetConnection())
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int? applicantId = null;

                        string getApplicantQuery = @"
                            SELECT ApplicantID
                            FROM applicants
                            WHERE ApplicantAccountID = @ApplicantAccountID
                            LIMIT 1";

                        using (MySqlCommand command = new MySqlCommand(getApplicantQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ApplicantAccountID", dto.ApplicantAccountID);

                            object result = command.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                applicantId = Convert.ToInt32(result);
                            }
                        }

                        if (string.IsNullOrWhiteSpace(dto.FirstName))
                        {
                            return new ProfileSaveResultDTO
                            {
                                Success = false,
                                Message = "Please enter your first name."
                            };
                        }

                        if (string.IsNullOrWhiteSpace(dto.LastName))
                        {
                            return new ProfileSaveResultDTO
                            {
                                Success = false,
                                Message = "Please enter your last name."
                            };
                        }

                        if (applicantId.HasValue)
                        {
                            string updateQuery = @"
                                UPDATE applicants
                                SET
                                    FirstName = @FirstName,
                                    MiddleName = @MiddleName,
                                    LastName = @LastName,
                                    Gender = @Gender,
                                    BirthDate = @BirthDate,
                                    Phone = @Phone,
                                    Address = @Address,
                                    EducationLevel = @EducationLevel,
                                    School = @School,
                                    Course = @Course,
                                    Skills = @Skills,
                                    WorkExperience = @WorkExperience
                                WHERE ApplicantAccountID = @ApplicantAccountID";

                            using (MySqlCommand command = new MySqlCommand(updateQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@FirstName", dto.FirstName.Trim());
                                command.Parameters.AddWithValue("@MiddleName", string.IsNullOrWhiteSpace(dto.MiddleName) ? (object)DBNull.Value : dto.MiddleName.Trim());
                                command.Parameters.AddWithValue("@LastName", dto.LastName.Trim());
                                command.Parameters.AddWithValue("@Gender", string.IsNullOrWhiteSpace(dto.Gender) ? (object)DBNull.Value : dto.Gender.Trim());
                                command.Parameters.AddWithValue("@BirthDate", dto.BirthDate.HasValue ? dto.BirthDate.Value.Date : (object)DBNull.Value);
                                command.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(dto.ContactNumber) ? (object)DBNull.Value : dto.ContactNumber.Trim());
                                command.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(dto.Address) ? (object)DBNull.Value : dto.Address.Trim());
                                command.Parameters.AddWithValue("@EducationLevel", string.IsNullOrWhiteSpace(dto.YearLevel) ? (object)DBNull.Value : dto.YearLevel.Trim());
                                command.Parameters.AddWithValue("@School", string.IsNullOrWhiteSpace(dto.School) ? (object)DBNull.Value : dto.School.Trim());
                                command.Parameters.AddWithValue("@Course", string.IsNullOrWhiteSpace(dto.Course) ? (object)DBNull.Value : dto.Course.Trim());
                                command.Parameters.AddWithValue("@Skills", string.IsNullOrWhiteSpace(dto.Skills) ? (object)DBNull.Value : dto.Skills.Trim());
                                command.Parameters.AddWithValue("@WorkExperience", string.IsNullOrWhiteSpace(dto.WorkExperience) ? (object)DBNull.Value : dto.WorkExperience.Trim());
                                command.Parameters.AddWithValue("@ApplicantAccountID", dto.ApplicantAccountID);

                                command.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string insertQuery = @"
                                INSERT INTO applicants
                                (
                                    ApplicantAccountID,
                                    FirstName,
                                    MiddleName,
                                    LastName,
                                    Gender,
                                    BirthDate,
                                    Phone,
                                    Address,
                                    EducationLevel,
                                    School,
                                    Course,
                                    Skills,
                                    WorkExperience
                                )
                                VALUES
                                (
                                    @ApplicantAccountID,
                                    @FirstName,
                                    @MiddleName,
                                    @LastName,
                                    @Gender,
                                    @BirthDate,
                                    @Phone,
                                    @Address,
                                    @EducationLevel,
                                    @School,
                                    @Course,
                                    @Skills,
                                    @WorkExperience
                                )";

                            using (MySqlCommand command = new MySqlCommand(insertQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@ApplicantAccountID", dto.ApplicantAccountID);
                                command.Parameters.AddWithValue("@FirstName", dto.FirstName.Trim());
                                command.Parameters.AddWithValue("@MiddleName", string.IsNullOrWhiteSpace(dto.MiddleName) ? (object)DBNull.Value : dto.MiddleName.Trim());
                                command.Parameters.AddWithValue("@LastName", dto.LastName.Trim());
                                command.Parameters.AddWithValue("@Gender", string.IsNullOrWhiteSpace(dto.Gender) ? (object)DBNull.Value : dto.Gender.Trim());
                                command.Parameters.AddWithValue("@BirthDate", dto.BirthDate.HasValue ? dto.BirthDate.Value.Date : (object)DBNull.Value);
                                command.Parameters.AddWithValue("@Phone", string.IsNullOrWhiteSpace(dto.ContactNumber) ? (object)DBNull.Value : dto.ContactNumber.Trim());
                                command.Parameters.AddWithValue("@Address", string.IsNullOrWhiteSpace(dto.Address) ? (object)DBNull.Value : dto.Address.Trim());
                                command.Parameters.AddWithValue("@EducationLevel", string.IsNullOrWhiteSpace(dto.YearLevel) ? (object)DBNull.Value : dto.YearLevel.Trim());
                                command.Parameters.AddWithValue("@School", string.IsNullOrWhiteSpace(dto.School) ? (object)DBNull.Value : dto.School.Trim());
                                command.Parameters.AddWithValue("@Course", string.IsNullOrWhiteSpace(dto.Course) ? (object)DBNull.Value : dto.Course.Trim());
                                command.Parameters.AddWithValue("@Skills", string.IsNullOrWhiteSpace(dto.Skills) ? (object)DBNull.Value : dto.Skills.Trim());
                                command.Parameters.AddWithValue("@WorkExperience", string.IsNullOrWhiteSpace(dto.WorkExperience) ? (object)DBNull.Value : dto.WorkExperience.Trim());

                                command.ExecuteNonQuery();
                            }
                        }

                        string updateEmailQuery = @"
                            UPDATE applicantaccounts
                            SET Email = @Email
                            WHERE ApplicantAccountID = @ApplicantAccountID";

                        using (MySqlCommand command = new MySqlCommand(updateEmailQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Email", dto.Email.Trim());
                            command.Parameters.AddWithValue("@ApplicantAccountID", dto.ApplicantAccountID);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        return new ProfileSaveResultDTO
                        {
                            Success = true,
                            Message = "Profile saved successfully."
                        };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        return new ProfileSaveResultDTO
                        {
                            Success = false,
                            Message = "Failed to save profile: " + ex.Message
                        };
                    }
                }
            }
        }
    }
}
