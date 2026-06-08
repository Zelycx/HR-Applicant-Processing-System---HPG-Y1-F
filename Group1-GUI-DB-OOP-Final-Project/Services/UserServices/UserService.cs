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
                MailAddress address = new MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public ApplicantAccounts AuthenticateApplicant(string email, string password)
        {
            ApplicantAccounts account = _repository.GetByEmail(email);

            if (account == null)
                return null;

            if (!account.IsActive)
                return null;

            if (!BCrypt.Net.BCrypt.Verify(password, account.PasswordHash))
                return null;

            return account;
        }
    }
}
