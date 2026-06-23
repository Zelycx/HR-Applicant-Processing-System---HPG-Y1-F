using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group1_GUI_DB_OOP_Final_Project.Services.HRServices
{
    internal class JobVacancyService
    {
        private readonly JobVacancyRepository _repo = new JobVacancyRepository();

        public List<JobVacancyListDTO> GetOpenJobs(int applicantAccountId, string searchText)
        {
            return _repo.GetOpenJobs(applicantAccountId, searchText);
        }

        public JobVacancyDetailsDTO GetJobDetails(int applicantAccountId, int jobVacancyId)
        {
            return _repo.GetJobDetails(applicantAccountId, jobVacancyId);
        }

        public OperationResultDTO Apply(int applicantAccountId, int jobVacancyId)
        {
            return _repo.Apply(applicantAccountId, jobVacancyId);
        }

        public List<JobVacancyListDTO> GetAllVacancies(string searchText)
        {
            return _repo.GetAllVacancies(searchText);
        }

        public void AddVacancy(string jobTitle, string jobDescription, string qualifications, int departmentId, int employmentTypeId)
        {
            _repo.AddVacancy(jobTitle, jobDescription, qualifications, departmentId, employmentTypeId);
        }

        public void UpdateVacancy(int jobVacancyId, string jobTitle, string jobDescription, string qualifications, int departmentId, int employmentTypeId)
        {
            _repo.UpdateVacancy(jobVacancyId, jobTitle, jobDescription, qualifications, departmentId, employmentTypeId);
        }
    }
}
