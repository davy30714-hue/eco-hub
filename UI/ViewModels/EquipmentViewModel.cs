using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using Data.Models;
using Services;

namespace UI.ViewModels
{
    public class EquipmentViewModel
    {
        private readonly EquipmentService _service;
        public BindingSource EquipmentList { get; private set; }

        public EquipmentViewModel(EquipmentService service)
        {
            _service = service;
            EquipmentList = new BindingSource();
        }

        public void LoadData()
        {
            EquipmentList.DataSource = new BindingList<Equipment>(_service.GetAll().ToList());
        }

        public int GetNextAvailableId()
        {
            var allEquipment = _service.GetAll().ToList();
            return allEquipment.Any() ? allEquipment.Max(e => e.EquipmentId) + 1 : 1;
        }

        public void Search(string idText, bool showBroken, bool showAvailable)
        {
            if (!string.IsNullOrWhiteSpace(idText) && int.TryParse(idText, out int id))
            {
                var item = _service.GetById(id);
                EquipmentList.DataSource = item != null
                    ? new BindingList<Equipment>(new List<Equipment> { item })
                    : new BindingList<Equipment>();
                return;
            }

            var data = _service.GetAll().AsEnumerable();

            if (showAvailable)
            {
                data = data.Where(e => e.Status == "Робочий" || (e.Status == "Available" && e.EmployeeId == null));
            }

            EquipmentList.DataSource = new BindingList<Equipment>(data.ToList());
        }

        public void AddEquipment(string name, string serial, string type)
        {
            var eq = new Equipment
            {
                Name = name,
                SerialNumber = serial,
                EquipmentType = type,
                Status = "Робочий",
                LastCalibrationDate = System.DateTime.Now.Date
            };

            _service.AddEquipment(eq);
            LoadData();
        }

        public void UpdateEquipment(Equipment eq)
        {
            _service.UpdateEquipment(eq);
            LoadData();
        }

        public void SaveUpdatesFromGrid()
        {
            EquipmentList.EndEdit();
            var items = EquipmentList.List.Cast<Equipment>().Where(e => e.EquipmentId > 0).ToList();

            foreach (var eq in items)
            {
                if (string.IsNullOrWhiteSpace(eq.Name))
                    throw new Exception("Equipment name is required.");

                if (eq.Status == "Available")
                    eq.Status = "Робочий";

                if (eq.LastCalibrationDate.HasValue)
                    eq.LastCalibrationDate = eq.LastCalibrationDate.Value.Date;

                _service.UpdateEquipment(eq);
            }

            LoadData();
        }

        public void AddFromGrid(Equipment selectedRow)
        {
            EquipmentList.EndEdit();

            if (selectedRow == null)
            {
                throw new Exception("Please select a row with data to add, or add a new row in the grid.");
            }

            if (selectedRow.EquipmentId != 0)
            {
                throw new Exception("Selected row is not a new row. Please select a new row (with ID = 0) to add.");
            }

            if (string.IsNullOrWhiteSpace(selectedRow.Name))
                throw new Exception("Equipment name is required.");

            if (string.IsNullOrWhiteSpace(selectedRow.Status))
                selectedRow.Status = "Робочий";
            else if (selectedRow.Status == "Available")
                selectedRow.Status = "Робочий";

            if (selectedRow.LastCalibrationDate.HasValue)
                selectedRow.LastCalibrationDate = selectedRow.LastCalibrationDate.Value.Date;
            else
                selectedRow.LastCalibrationDate = System.DateTime.Now.Date;

            _service.AddEquipment(selectedRow);
            LoadData();
        }

        public void DeleteEquipment(Equipment eq)
        {
            if (eq == null) return;
            _service.DeleteEquipment(eq.EquipmentId);
            LoadData();
        }

        public void AssignToEmployee(Equipment eq, int employeeId)
        {
            _service.AssignEquipmentToEmployee(eq.EquipmentId, employeeId);
            LoadData();
        }

        public void ReturnToStorage(Equipment eq)
        {
            _service.ReturnEquipment(eq.EquipmentId);
            LoadData();
        }
    }
}
