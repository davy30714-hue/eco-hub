using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using Services;
using Data.Models;

namespace UI.ViewModels
{
    public class EmployeesViewModel
    {
        private readonly EmployeeService _service;

        public BindingSource EmployeesList { get; private set; }

        public EmployeesViewModel(EmployeeService service)
        {
            _service = service;
            EmployeesList = new BindingSource();
        }

        public void LoadData()
        {
            var data = _service.GetAll().ToList();
            EmployeesList.DataSource = new BindingList<Employees>(data);
        }

        public void Search(string idText, string role, bool onlyAvailable)
        {
            if (int.TryParse(idText, out int id))
            {
                var item = _service.GetById(id);
                EmployeesList.DataSource = item != null ? new List<Employees> { item } : new List<Employees>();
                return;
            }

            var data = _service.GetAll();

            if (!string.IsNullOrEmpty(role))
                data = data.Where(e => e.Role.Contains(role));

            if (onlyAvailable)
                data = _service.GetAvailableStaff();

            EmployeesList.DataSource = data.ToList();
        }

        public void AddEmployee(string name, string role)
        {
            var emp = new Employees
            {
                FullName = name,
                Role = role,
                Status = "Активний",
                ContactInfo = "Н/Д"
            };

            _service.AddEmployee(emp);
            LoadData();
        }

        public void AddFromGrid(Employees selectedRow)
        {
            EmployeesList.EndEdit();

            if (selectedRow == null)
            {
                throw new Exception("Please select a row with data to add, or add a new row in the grid.");
            }

            if (selectedRow.EmployeeId != 0)
            {
                throw new Exception("Selected row is not a new row. Please select a new row (with ID = 0) to add.");
            }

            if (string.IsNullOrWhiteSpace(selectedRow.FullName))
                throw new Exception("Employee name is required.");

            if (string.IsNullOrWhiteSpace(selectedRow.Status))
                selectedRow.Status = "Активний";

            if (string.IsNullOrWhiteSpace(selectedRow.ContactInfo))
                selectedRow.ContactInfo = "Н/Д";

            try
            {
                _service.AddEmployee(selectedRow);
                LoadData();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add employee: {ex.Message}", ex);
            }
        }

        public void DeleteEmployee(Employees emp)
        {
            if (emp == null) return;

            _service.DeleteEmployee(emp.EmployeeId);
            LoadData();
        }

        public void UpdateEmployee(Employees emp)
        {
            _service.UpdateEmployee(emp);
            LoadData();
        }

        public void SaveUpdatesFromGrid()
        {
            EmployeesList.EndEdit();
            var items = EmployeesList.List.Cast<Employees>().Where(e => e.EmployeeId > 0).ToList();

            foreach (var emp in items)
            {
                if (string.IsNullOrWhiteSpace(emp.FullName))
                    throw new Exception("Employee name is required.");

                if (string.IsNullOrWhiteSpace(emp.Status))
                    emp.Status = "Активний";

                if (string.IsNullOrWhiteSpace(emp.ContactInfo))
                    emp.ContactInfo = "Н/Д";

                _service.UpdateEmployee(emp);
            }

            LoadData();
        }

        public string GetEmployeeHistoryInfo(Employees emp)
        {
            var history = _service.GetExpeditionHistory(emp.EmployeeId);

            if (!history.Any())
            {
                return "This employee has not participated in any expeditions yet.";
            }

            return string.Join("\n", history.Select(h =>
                $"Expedition ID: {h.ExpeditionId} - Role: {h.RoleInExpedition}"));
        }
    }
}
