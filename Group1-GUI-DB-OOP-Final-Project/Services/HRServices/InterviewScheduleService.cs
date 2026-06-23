using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Group1_GUI_DB_OOP_Final_Project.Services.HRServices
{
    internal class InterviewScheduleService
    {
        private readonly InterviewScheduleRepository _repository;
        public InterviewScheduleService()
        {
            _repository = new InterviewScheduleRepository();
        }
        public InterviewApplicantInfoDTO GetApplicantInfoByApplicationID(int applicationID)
        {
            return _repository.GetApplicantInfoByApplicationID(applicationID);
        }
        public InterviewScheduleInfoDTO GetInterviewScheduleByApplicationID(int applicationID)
        {
            return _repository.GetLatestScheduleByApplicationID(applicationID);
        }
        public bool SaveInterviewSchedule(
            int applicationID,
            int scheduledByUserID,
            DateTime interviewDate,
            TimeSpan interviewTime,
            string interviewerName,
            string interviewMode,
            string interviewLocation,
            string status)
        {
            return _repository.SaveInterviewSchedule(
                applicationID,
                scheduledByUserID,
                interviewDate,
                interviewTime,
                interviewerName,
                interviewMode,
                interviewLocation,
                status);
        }
    }
}
