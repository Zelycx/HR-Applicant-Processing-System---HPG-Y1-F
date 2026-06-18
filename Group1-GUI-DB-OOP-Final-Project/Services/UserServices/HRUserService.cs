using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Models;
using Group1_GUI_DB_OOP_Final_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Services.UserServices
{
    internal class HRUserService
    {
        private readonly HRUserRepository _repository;

        public HRUserService()
        {
            _repository = new HRUserRepository();
        }

        public HRLogInResultDTO AuthenticateHR(string username, string password)
        {
            User user = _repository.GetByUsername(username);

            if (user == null)
            {
                return new HRLogInResultDTO
                {
                    Success = false,
                    Message = "Username not found."
                };
            }

            if (!user.IsActive)
            {
                return new HRLogInResultDTO
                {
                    Success = false,
                    Message = "Account is inactive."
                };
            }

            bool passwordMatch =
                BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (!passwordMatch)
            {
                return new HRLogInResultDTO
                {
                    Success = false,
                    Message = "Incorrect password."
                };
            }

            return new HRLogInResultDTO
            {
                Success = true,
                Message = "Login successful.",
                User = user
            };
        }
    }
}
