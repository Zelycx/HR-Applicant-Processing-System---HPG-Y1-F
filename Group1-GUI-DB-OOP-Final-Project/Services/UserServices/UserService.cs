using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail; // For checking the email
using Group1_GUI_DB_OOP_Final_Project.Repositories;
using Group1_GUI_DB_OOP_Final_Project.Models;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;
using Group1_GUI_DB_OOP_Final_Project.DTOs;

namespace Group1_GUI_DB_OOP_Final_Project.Services.UserServices
{
    internal class UserService
    {
        private readonly ApplicantAccountRepository _repository;

        public UserService()
        {
            _repository = new ApplicantAccountRepository();
        }

        public bool EmailIsValid(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public LogInResult AuthenticateApplicant(string email, string password)
        {
            ApplicantAccounts account = _repository.GetByEmail(email);

            if (account == null)
            {
                return new LogInResult
                {
                    Success = false,
                    Message = "Email not found."
                };
            }

            if (!account.IsActive)
            {
                return new LogInResult
                {
                    Success = false,
                    Message = "Your account is inactive."
                };
            }

            bool passwordMatch = BCrypt.Net.BCrypt.Verify(password, account.PasswordHash);

            if (!passwordMatch)
            {
                return new LogInResult
                {
                    Success = false,
                    Message = "Incorrect password."
                };
            }

            return new LogInResult
            {
                Success = true,
                Message = "Login successful!",
                Account = account
            };
        }

        public RegistrationResult RegisterApplicant(RegistrationDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
            {
                return new RegistrationResult
                {
                    Success = false,
                    Message = "Please enter your email."
                };
            }

            if (string.IsNullOrWhiteSpace(dto.Password))
            {
                return new RegistrationResult
                {
                    Success = false,
                    Message = "Please enter your password."
                };
            }

            if (string.IsNullOrWhiteSpace(dto.ConfirmPassword))
            {
                return new RegistrationResult
                {
                    Success = false,
                    Message = "Please confirm your password."
                };
            }

            if (!EmailIsValid(dto.Email))
            {
                return new RegistrationResult
                {
                    Success = false,
                    Message = "Please enter a valid email address."
                };
            }

            if (_repository.EmailExists(dto.Email))
            {
                return new RegistrationResult
                {
                    Success = false,
                    Message = "Email already exists."
                };
            }

            if (dto.Password != dto.ConfirmPassword)
            {
                return new RegistrationResult
                {
                    Success = false,
                    Message = "Passwords do not match."
                };
            }

            if (dto.Password.Length < 8)
            {
                return new RegistrationResult
                {
                    Success = false,
                    Message = "Password must be at least 8 characters."
                };
            }

            string hashedPassword =
                BCrypt.Net.BCrypt.HashPassword(dto.Password);

            _repository.CreateAccount(
                dto.Email,
                hashedPassword);

            return new RegistrationResult
            {
                Success = true,
                Message = "Registration successful."
            };
        }

        public void UpdateLastLogin(int applicantAccountId)
        {
            ApplicantDashboardServices dashboardService =
                new ApplicantDashboardServices();

            dashboardService.UpdateLastLogin(applicantAccountId);
        }
    }
}
