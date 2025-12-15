using System;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using Data.Models;
using Services;
using System.Collections.Generic;

namespace UI.ViewModels
{
    public class MeasurementViewModel
    {
        private readonly MeasurementService _service;
        public BindingSource MeasurementList { get; private set; }

        public MeasurementViewModel(MeasurementService service)
        {
            _service = service;
            MeasurementList = new BindingSource();
        }

        public void LoadData()
        {
            MeasurementList.DataSource = new BindingList<Measurements>(_service.GetAll().ToList());
        }

        public int GetNextAvailableId()
        {
            var allMeasurements = _service.GetAll().ToList();
            return allMeasurements.Any() ? allMeasurements.Max(m => m.MeasurementId) + 1 : 1;
        }

        public void Search(string locationIdText, DateTime start, DateTime end)
        {
            if (!string.IsNullOrWhiteSpace(locationIdText) && int.TryParse(locationIdText, out int measId))
            {
                var item = _service.GetById(measId);
                MeasurementList.DataSource = item != null
                    ? new BindingList<Measurements>(new List<Measurements> { item })
                    : new BindingList<Measurements>();
                return;
            }

            int? locId = null;
            if (!string.IsNullOrWhiteSpace(locationIdText) && int.TryParse(locationIdText, out int locIdValue)) 
                locId = locIdValue;

            var data = _service.Filter(start, end, locId);
            MeasurementList.DataSource = new BindingList<Measurements>(data.ToList());
        }

        public string GetStatistics(string locationIdText, DateTime start, DateTime end)
        {
            if (!string.IsNullOrWhiteSpace(locationIdText) && int.TryParse(locationIdText, out int measId))
            {
                var count = MeasurementList.List.Cast<Measurements>().Count();
                return count > 0 ? $"Count: {count}" : "No data";
            }

            int? locId = null;
            if (!string.IsNullOrWhiteSpace(locationIdText) && int.TryParse(locationIdText, out int locIdValue)) 
                locId = locIdValue;

            return _service.GetStats(start, end, locId);
        }

        public void AddMeasurement(string type, double val, string unit, int locationId, int expeditionId, int equipId, int empId)
        {
            var m = new Measurements
            {
                ParameterType = type,
                Value = val,
                Unit = unit,
                Timestamp = DateTime.Now,
                LocationId = locationId,
                ExpeditionId = expeditionId,
                EquipmentId = equipId,
                EmployeeId = empId
            };
            _service.AddMeasurement(m);
            LoadData();
        }

        public void AddFromGrid(Measurements selectedRow)
        {
            MeasurementList.EndEdit();

            if (selectedRow == null)
            {
                throw new Exception("Please select a row with data to add, or add a new row in the grid.");
            }

            if (selectedRow.MeasurementId != 0)
            {
                throw new Exception("Selected row is not a new row. Please select a new row (with ID = 0) to add.");
            }

            if (string.IsNullOrWhiteSpace(selectedRow.ParameterType))
                throw new Exception("Parameter type is required.");

            if (selectedRow.LocationId <= 0)
                throw new Exception("Location ID is required and must be greater than 0.");

            if (selectedRow.Timestamp == default(DateTime))
                selectedRow.Timestamp = DateTime.Now;

            int rowsAffected = _service.AddMeasurement(selectedRow);
            if (rowsAffected == 0)
            {
                throw new Exception("Failed to add new measurement. No rows were affected in the database.");
            }
            LoadData();
        }

        public void SaveUpdatesFromGrid()
        {
            MeasurementList.EndEdit();
            var items = MeasurementList.List.Cast<Measurements>().Where(m => m.MeasurementId > 0).ToList();

            foreach (var m in items)
            {
                if (string.IsNullOrWhiteSpace(m.ParameterType))
                    throw new Exception("Parameter type is required.");

                if (m.LocationId <= 0)
                    throw new Exception("Location ID is required.");

                _service.UpdateMeasurement(m);
            }

            LoadData();
        }

        public void DeleteMeasurement(Measurements m)
        {
            if (m == null) return;
            _service.DeleteMeasurement(m.MeasurementId);
            LoadData();
        }
    }
}
