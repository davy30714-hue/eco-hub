using System;
using System.Collections.Generic;
using System.Linq;
using Repositories;
using Data.Models;

namespace Services
{
    public class EmployeeService
    {
        private readonly IRepository<Employees> _employeeRepo;
        private readonly IRepository<ExpeditionTeams> _teamRepo;

        public EmployeeService(IRepository<Employees> empRepo, IRepository<ExpeditionTeams> teamRepo)
        {
            _employeeRepo = empRepo;
            _teamRepo = teamRepo;
        }

        public IEnumerable<Employees> GetAll()
        {
            return _employeeRepo.GetAll();
        }

        public Employees GetById(int id)
        {
            return _employeeRepo.GetById(id);
        }

        public IEnumerable<Employees> SearchByName(string partialName)
        {
            if (string.IsNullOrWhiteSpace(partialName))
            {
                return GetAll();
            }
            return _employeeRepo.Find(e => e.FullName.Contains(partialName));
        }

        public IEnumerable<Employees> GetByRole(string role)
        {
            return _employeeRepo.Find(e => e.Role.Contains(role));
        }

        public IEnumerable<Employees> GetAvailableStaff()
        {
            return _employeeRepo.Find(e => e.Status == "Активний");
        }

        public IEnumerable<ExpeditionTeams> GetExpeditionHistory(int employeeId)
        {
            return _teamRepo.Find(t => t.EmployeeId == employeeId);
        }

        public void AddEmployee(Employees emp)
        {
            if (string.IsNullOrEmpty(emp.FullName))
            {
                throw new Exception("Ім'я не може бути пустим");
            }

            _employeeRepo.Add(emp);
            _employeeRepo.Save();
        }

        public void UpdateEmployee(Employees emp)
        {
            _employeeRepo.Update(emp);
            _employeeRepo.Save();
        }

        public void DeleteEmployee(int id)
        {
            var emp = _employeeRepo.GetById(id);
            if (emp != null)
            {
                _employeeRepo.Delete(emp);
                _employeeRepo.Save();
            }
        }
    }
}