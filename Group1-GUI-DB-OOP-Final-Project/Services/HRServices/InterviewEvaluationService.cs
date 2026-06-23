using Group1_GUI_DB_OOP_Final_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Services.HRServices
{
    internal class InterviewEvaluationService
    {
        private readonly InterviewEvaluationRepository _repository;

        public InterviewEvaluationService()
        {
            _repository = new InterviewEvaluationRepository();
        }

        public bool SaveEvaluation(
            int interviewScheduleID,
            int evaluatorUserID,
            decimal score,
            string result,
            string remarks)
        {
            return _repository.SaveEvaluation(interviewScheduleID, evaluatorUserID, score, result, remarks);
        }
    }
}
