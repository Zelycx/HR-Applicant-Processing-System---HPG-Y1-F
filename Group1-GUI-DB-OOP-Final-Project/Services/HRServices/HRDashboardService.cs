using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Services.HRServices
{
    internal class HRDashboardService
    {
        private readonly HRDashboardRepository _repository;

        public HRDashboardService()
        {
            _repository = new HRDashboardRepository();
        }

        public HRDashboardCountsDTO GetDashboardCounts()
        {
            return _repository.GetDashboardCounts();
        }
    }
}
