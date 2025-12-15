using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Repositories;

namespace Services
{
    public class EquipmentService
    {
        private readonly IRepository<Equipment> _repo;
        private readonly IRepository<Employees> _empRepo;

        public EquipmentService(IRepository<Equipment> repo, IRepository<Employees> empRepo)
        {
            _repo = repo;
            _empRepo = empRepo;
        }

        public IEnumerable<Equipment> GetAll() => _repo.GetAll();

        public Equipment GetById(int id) => _repo.GetById(id);

        public IEnumerable<Equipment> GetBrokenEquipment()
        {
            return _repo.Find(e => e.Status == "Needs Repair" || e.Status == "Broken");
        }

        public IEnumerable<Equipment> GetAvailableEquipment()
        {
            return _repo.Find(e => (e.Status == "Робочий" || e.Status == "Available") && e.EmployeeId == null);
        }

        public void AddEquipment(Equipment e)
        {
            _repo.Add(e);
            _repo.Save();
        }

        public void UpdateEquipment(Equipment e)
        {
            _repo.Update(e);
            _repo.Save();
        }

        public void DeleteEquipment(int id)
        {
            var item = _repo.GetById(id);
            if (item != null)
            {
                _repo.Delete(item);
                _repo.Save();
            }
        }

        public void AssignEquipmentToEmployee(int eqId, int empId)
        {
            var eq = _repo.GetById(eqId);
            var emp = _empRepo.GetById(empId);

            if (eq == null) throw new Exception("Обладнання не знайдено");
            if (emp == null) throw new Exception("Працівника не знайдено");

            eq.EmployeeId = empId;
            eq.Status = "In Use"; // Keep as is when assigned

            _repo.Update(eq);
            _repo.Save();
        }

        public void ReturnEquipment(int eqId)
        {
            var eq = _repo.GetById(eqId);
            if (eq == null) return;

            eq.EmployeeId = null;
            eq.Status = "Робочий"; // Use Ukrainian status

            _repo.Update(eq);
            _repo.Save();
        }
    }
}