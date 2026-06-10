using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Services.UserServices
{
    internal class ApplicantProfileServices
    {
        private readonly ApplicantProfileRepository _repository;

        public ApplicantProfileServices()
        {
            _repository = new ApplicantProfileRepository();
        }

        public ApplicantProfileDTO GetProfile(int applicantAccountId)
        {
            return _repository.GetProfileByAccountId(applicantAccountId);
        }

        public ProfileSaveResultDTO SaveProfile(ApplicantProfileDTO dto)
        {
            if (dto == null)
            {
                return new ProfileSaveResultDTO
                {
                    Success = false,
                    Message = "Profile data is missing."
                };
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

            if (string.IsNullOrWhiteSpace(dto.Gender))
            {
                return new ProfileSaveResultDTO
                {
                    Success = false,
                    Message = "Please select your gender."
                };
            }

            if (!dto.BirthDate.HasValue)
            {
                return new ProfileSaveResultDTO
                {
                    Success = false,
                    Message = "Please select your birthdate."
                };
            }

            if (string.IsNullOrWhiteSpace(dto.Address))
            {
                return new ProfileSaveResultDTO
                {
                    Success = false,
                    Message = "Please enter your address."
                };
            }

            if (string.IsNullOrWhiteSpace(dto.ContactNumber))
            {
                return new ProfileSaveResultDTO
                {
                    Success = false,
                    Message = "Please enter your contact number."
                };
            }

            if (string.IsNullOrWhiteSpace(dto.Email))
            {
                return new ProfileSaveResultDTO
                {
                    Success = false,
                    Message = "Please enter your email."
                };
            }

            if (!EmailIsValid(dto.Email))
            {
                return new ProfileSaveResultDTO
                {
                    Success = false,
                    Message = "Please enter a valid email address."
                };
            }

            if (string.IsNullOrWhiteSpace(dto.School))
            {
                return new ProfileSaveResultDTO
                {
                    Success = false,
                    Message = "Please enter your school."
                };
            }

            if (string.IsNullOrWhiteSpace(dto.Course))
            {
                return new ProfileSaveResultDTO
                {
                    Success = false,
                    Message = "Please enter your course."
                };
            }

            if (string.IsNullOrWhiteSpace(dto.YearLevel))
            {
                return new ProfileSaveResultDTO
                {
                    Success = false,
                    Message = "Please enter your year level."
                };
            }

            if (_repository.EmailExistsForOtherAccount(
                dto.Email.Trim(),
                dto.ApplicantAccountID))
            {
                return new ProfileSaveResultDTO
                {
                    Success = false,
                    Message = "Email already exists."
                };
            }

            return _repository.SaveOrUpdateProfile(dto);
        }

        private bool EmailIsValid(string email)
        {
            try
            {
                MailAddress addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
