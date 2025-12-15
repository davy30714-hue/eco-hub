using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows.Forms;
using Data.Models;
using Services;

namespace UI.ViewModels
{
    public class LocationViewModel
    {
        private readonly LocationService _service;
        public BindingSource LocationList { get; private set; }

        public LocationViewModel(LocationService service)
        {
            _service = service;
            LocationList = new BindingSource();
        }

        public void LoadData()
        {
            LocationList.DataSource = new BindingList<Locations>(_service.GetAll().ToList());
        }

        public int GetNextAvailableId()
        {
            var allLocations = _service.GetAll().ToList();
            return allLocations.Any() ? allLocations.Max(l => l.LocationId) + 1 : 1;
        }

        public void Search(string idText, string ecosystem)
        {
            if (int.TryParse(idText, out int id))
            {
                var item = _service.GetById(id);
                LocationList.DataSource = item != null
                    ? new BindingList<Locations>(new List<Locations> { item })
                    : new BindingList<Locations>();
                return;
            }

            var data = _service.GetAll();

            if (!string.IsNullOrWhiteSpace(idText))
                data = _service.SearchByName(idText);

            if (!string.IsNullOrWhiteSpace(ecosystem))
                data = _service.GetByEcosystem(ecosystem);

            LocationList.DataSource = new BindingList<Locations>(data.ToList());
        }

        public void AddLocation(string name, string ecosystem, double lat, double lon)
        {
            var loc = new Locations
            {
                Name = name,
                EcosystemType = ecosystem,
                GpsLatitude = lat,
                GpsLongitude = lon,
                Description = "New Location"
            };
            _service.AddLocation(loc);
            LoadData();
        }

        public void AddFromGrid(Locations selectedRow)
        {
            LocationList.EndEdit();

            if (selectedRow == null)
            {
                throw new Exception("Please select a row with data to add, or add a new row in the grid.");
            }

            if (selectedRow.LocationId != 0)
            {
                throw new Exception("Selected row is not a new row. Please select a new row (with ID = 0) to add.");
            }

            if (string.IsNullOrWhiteSpace(selectedRow.Name))
                throw new Exception("Location name cannot be empty.");

            if (string.IsNullOrWhiteSpace(selectedRow.EcosystemType))
                selectedRow.EcosystemType = "Unknown";

            selectedRow.Description ??= "New Location";

            _service.AddLocation(selectedRow);
            LoadData();
        }

        public void SaveUpdatesFromGrid()
        {
            LocationList.EndEdit();
            var items = LocationList.List.Cast<Locations>().Where(l => l.LocationId > 0).ToList();

            foreach (var loc in items)
            {
                if (string.IsNullOrWhiteSpace(loc.Name))
                    throw new Exception("Location name cannot be empty.");

                _service.UpdateLocation(loc);
            }

            LoadData();
        }

        public void UpdateLocation(Locations loc)
        {
            _service.UpdateLocation(loc);
            LoadData();
        }

        public void DeleteLocation(Locations loc)
        {
            if (loc == null) return;
            _service.DeleteLocation(loc.LocationId);
            LoadData();
        }
    }
}
