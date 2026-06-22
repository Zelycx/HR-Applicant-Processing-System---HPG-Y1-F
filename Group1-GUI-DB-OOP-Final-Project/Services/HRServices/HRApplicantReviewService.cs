using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Services.HRServices
{
    internal class HRApplicantReviewService
    {
        private readonly HRApplicantReviewRepository _repository;

        public HRApplicantReviewService()
        {
            _repository = new HRApplicantReviewRepository();
        }

        public HRApplicantReviewDTO GetApplicantReviewByApplicationID(int applicationID)
        {
            return _repository.GetApplicantReviewByApplicationID(applicationID);
        }
        public List<HRApplicantDocumentDTO> GetDocumentsByApplicationID(int applicationID)
        {
            return _repository.GetDocumentsByApplicationID(applicationID);
        }
    }
}
