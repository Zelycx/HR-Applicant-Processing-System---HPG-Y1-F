using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Services.HRServices
{
    internal class HRApplicantListService
    {
        private readonly HRApplicantListRepository _repository;

        public HRApplicantListService()
        {
            _repository = new HRApplicantListRepository();
        }

        public List<HRApplicantListDTO> GetApplicantList(
            string applicantName,
            string applicantStatus,
            string positionApplied)
        {
            return _repository.GetApplicantList(
                applicantName,
                applicantStatus,
                positionApplied);
        }

        public List<HRApplicantListDTO> GetAllApplicants()
        {
            return _repository.GetApplicantList("", "", "");
        }
    }
}
