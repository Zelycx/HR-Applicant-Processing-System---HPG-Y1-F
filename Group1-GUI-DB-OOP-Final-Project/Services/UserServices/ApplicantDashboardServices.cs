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

        public ApplicantDashboardSummary GetSummary(int applicantAccountId)
        {
            return _repository.GetSummary(applicantAccountId);
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
    }
}
