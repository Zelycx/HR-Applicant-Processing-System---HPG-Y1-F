using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Services.HRServices
{
    internal class HRScreeningService
    {
        private readonly HRScreeningRepository _repository;

        public HRScreeningService()
        {
            _repository = new HRScreeningRepository();
        }

        public DataTable GetScreeningRequirements(
            int applicationID)
        {
            return _repository.GetScreeningRequirements(
                applicationID);
        }

        public void SaveScreeningDecision(
            int applicationID,
            int screenedByUserID,
            string screeningStatus,
            string remarks)
        {
            _repository.SaveScreeningDecision(
                applicationID,
                screenedByUserID,
                screeningStatus,
                remarks);
        }
    }
}
