using Group1_GUI_DB_OOP_Final_Project.Repositories;
using Group1_GUI_DB_OOP_Final_Project.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Services.UserServices
{
    internal class ApplicantDashboardServices
    {
        private readonly ApplicantDashboardRepository _repository;

        public ApplicantDashboardServices()
        {
            _repository = new ApplicantDashboardRepository();
        }

        public ApplicantDashboardSummary GetDashboardSummary(int applicantAccountId)
        {
            return _repository.GetDashboardSummary(applicantAccountId);
        }

        public List<ApplicantApplicationRowDTO> GetApplications(int applicantAccountId)
        {
            return _repository.GetApplications(applicantAccountId);
        }

        public List<ApplicantMissingRequirementRowDTO> GetMissingRequirements(int applicantAccountId)
        {
            return _repository.GetMissingRequirements(applicantAccountId);
        }

        public ApplicantInterviewDTO GetNearestInterview(int applicantAccountId)
        {
            return _repository.GetNearestInterview(applicantAccountId);
        }

        public string GetApplicantFullName(int applicantAccountId)
        {
            return _repository.GetApplicantFullName(applicantAccountId);
        }

        public DateTime? GetApplicantLastLogin(int applicantAccountId)
        {
            return _repository.GetApplicantLastLogin(applicantAccountId);
        }

        public void UpdateLastLogin(int applicantAccountId)
        {
            _repository.UpdateLastLogin(applicantAccountId);
        }
    }
}
