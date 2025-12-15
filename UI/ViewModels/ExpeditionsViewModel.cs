using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using Services;
using Data.Models;

namespace UI.ViewModels
{
    public class ExpeditionViewModel
    {
        private readonly ExpeditionService _service;
        public BindingSource ExpeditionList { get; private set; }

        public ExpeditionViewModel(ExpeditionService service)
        {
            _service = service;
            ExpeditionList = new BindingSource();
        }

        public void LoadData()
        {
            var data = _service.GetAll();
            ExpeditionList.DataSource = new BindingList<Expeditions>(data.ToList());
        }

        public int GetNextAvailableId()
        {
            var allExpeditions = _service.GetAll().ToList();
            return allExpeditions.Any() ? allExpeditions.Max(e => e.ExpeditionId) + 1 : 1;
        }

        public void Search(string notes, DateTime startDate, DateTime endDate, bool isActive)
        {
            var data = _service.GetAll();

            data = data.Where(e => e.StartDate >= startDate && e.EndDate <= endDate);

            if (isActive)
            {
                data = data.Where(e => e.Status == "Активна" || e.Status == "Заплановано");
            }

            ExpeditionList.DataSource = new BindingList<Expeditions>(data.ToList());
        }

        public void AddFromGrid(Expeditions selectedRow)
        {
            ExpeditionList.EndEdit();

            if (selectedRow == null)
            {
                throw new Exception("Please select a row with data to add, or add a new row in the grid.");
            }

            if (selectedRow.ExpeditionId != 0)
            {
                throw new Exception("Selected row is not a new row. Please select a new row (with ID = 0) to add.");
            }

            if (selectedRow.LocationId <= 0)
                throw new Exception("Location ID is required and must be greater than 0.");

            if (selectedRow.StartDate == default(DateTime))
                throw new Exception("Start date is required.");

            if (selectedRow.EndDate.HasValue && selectedRow.EndDate.Value < selectedRow.StartDate)
                throw new Exception("End date cannot be earlier than start date.");

            if (string.IsNullOrWhiteSpace(selectedRow.Status))
                selectedRow.Status = "Заплановано";

            selectedRow.StartDate = selectedRow.StartDate.Date;
            if (selectedRow.EndDate.HasValue)
                selectedRow.EndDate = selectedRow.EndDate.Value.Date;

            _service.AddExpedition(selectedRow);
            LoadData();
        }

        public void UpdateExpedition(Expeditions exp)
        {
            _service.UpdateExpedition(exp);
            LoadData();
        }

        public void SaveUpdatesFromGrid()
        {
            ExpeditionList.EndEdit();
            var items = ExpeditionList.List.Cast<Expeditions>().Where(e => e.ExpeditionId > 0).ToList();

            foreach (var exp in items)
            {
                if (exp.LocationId <= 0)
                    throw new Exception("Location ID is required and must be greater than 0.");

                if (exp.StartDate == default(DateTime))
                    throw new Exception("Start date is required.");

                if (exp.EndDate.HasValue && exp.EndDate.Value < exp.StartDate)
                    throw new Exception("End date cannot be earlier than start date.");

                if (string.IsNullOrWhiteSpace(exp.Status))
                    exp.Status = "Заплановано";

                exp.StartDate = exp.StartDate.Date;
                if (exp.EndDate.HasValue)
                    exp.EndDate = exp.EndDate.Value.Date;

                _service.UpdateExpedition(exp);
            }

            LoadData();
        }

        public void DeleteExpedition(Expeditions exp)
        {
            _service.DeleteExpedition(exp.ExpeditionId);
            LoadData();
        }

        public string GetReportInfo(Expeditions exp)
        {
            return $"Expedition Report #{exp.ExpeditionId}\n" +
                   $"Status: {exp.Status}\n" +
                   $"Period: {exp.StartDate:d} - {exp.EndDate:d}\n" +
                   $"Notes: {exp.Notes}";
        }

    }
}
