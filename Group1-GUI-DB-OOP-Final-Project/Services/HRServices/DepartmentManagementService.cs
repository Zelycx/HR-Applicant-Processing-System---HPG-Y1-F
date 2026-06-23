using System.Collections.Generic;
using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Repositories;

namespace Group1_GUI_DB_OOP_Final_Project.Services
{
    public class DepartmentManagementService
    {
        private DepartmentManagementRepository repo;

        public DepartmentManagementService(string conn)
        {
            repo = new DepartmentManagementRepository(conn);
        }

        public List<DepartmentManagementDTO> Load(string table)
        {
            return repo.GetAll(table);
        }

        public void Add(string table, string name)
        {
            repo.Add(table, name);
        }

        public void Update(string table, int id, string name)
        {
            repo.Update(table, id, name);
        }

        public void Delete(string table, int id)
        {
            repo.Delete(table, id);
        }
    }
}