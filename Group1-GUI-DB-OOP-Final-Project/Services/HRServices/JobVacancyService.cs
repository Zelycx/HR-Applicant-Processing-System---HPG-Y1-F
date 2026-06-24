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

        // ════════════════════════════════════════════════════════════
        //  APPLICANT-SIDE
        // ════════════════════════════════════════════════════════════

        public List<JobVacancyListDTO> GetOpenJobs(int applicantAccountId, string searchText)
            => _repo.GetOpenJobs(applicantAccountId, searchText);

        public JobVacancyDetailsDTO GetJobDetails(int applicantAccountId, int jobVacancyId)
            => _repo.GetJobDetails(applicantAccountId, jobVacancyId);

        public OperationResultDTO Apply(int applicantAccountId, int jobVacancyId)
            => _repo.Apply(applicantAccountId, jobVacancyId);

        // ════════════════════════════════════════════════════════════
        //  HR-SIDE: LIST & LOOKUPS
        // ════════════════════════════════════════════════════════════

        public List<JobVacancyListDTO> GetAllVacancies(string searchText)
            => _repo.GetAllVacancies(searchText);

        public JobVacancyEditDTO GetVacancyForEdit(int jobVacancyId)
            => _repo.GetVacancyForEdit(jobVacancyId);

        public List<LookupDTO> GetDepartments()
            => _repo.GetDepartments();

        public List<LookupDTO> GetEmploymentTypes()
            => _repo.GetEmploymentTypes();

        public List<LookupDTO> GetRequirementTypes()
            => _repo.GetRequirementTypes();

        // ════════════════════════════════════════════════════════════
        //  HR-SIDE: SAVE
        // ════════════════════════════════════════════════════════════

        public void AddVacancy(string jobTitle, string jobDescription, string qualifications,
            int departmentId, int employmentTypeId, int createdByUserId,
            List<int> requirementTypeIds)
        {
            _repo.AddVacancy(jobTitle, jobDescription, qualifications,
                departmentId, employmentTypeId, createdByUserId, requirementTypeIds);
        }

        public void UpdateVacancy(int jobVacancyId, string jobTitle, string jobDescription,
            string qualifications, int departmentId, int employmentTypeId,
            List<int> requirementTypeIds)
        {
            _repo.UpdateVacancy(jobVacancyId, jobTitle, jobDescription, qualifications,
                departmentId, employmentTypeId, requirementTypeIds);
        }

        // ════════════════════════════════════════════════════════════
        //  HR-SIDE: STATUS TOGGLE
        // ════════════════════════════════════════════════════════════

        public void ToggleJobStatus(int jobVacancyId, string currentStatus)
        {
            string newStatus;

            if (currentStatus == "Open")
                newStatus = "Closed";
            else if (currentStatus == "Closed")
                newStatus = "Open";
            else
                throw new Exception("Invalid job status: " + currentStatus);

            _repo.UpdateJobStatus(jobVacancyId, newStatus);
        }
    }
}
