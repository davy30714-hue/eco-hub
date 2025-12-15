using System.Collections.Generic;
using System.Linq;
using Repositories;
using Data.Models;

namespace Services
{
    public class LocationService
    {
        private readonly IRepository<Locations> _locationRepo;

        public LocationService(IRepository<Locations> locationRepo)
        {
            _locationRepo = locationRepo;
        }

        public IEnumerable<Locations> GetAll() => _locationRepo.GetAll();

        public Locations GetById(int id) => _locationRepo.GetById(id);

        public IEnumerable<Locations> GetByEcosystem(string type)
        {
            return _locationRepo.Find(l => l.EcosystemType == type);
        }

        public IEnumerable<Locations> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return GetAll();
            return _locationRepo.Find(l => l.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public void AddLocation(Locations loc)
        {
            _locationRepo.Add(loc);
            _locationRepo.Save();
        }

        public void UpdateLocation(Locations loc)
        {
            _locationRepo.Update(loc);
            _locationRepo.Save();
        }

        public void DeleteLocation(int id)
        {
            var loc = _locationRepo.GetById(id);
            if (loc != null)
            {
                _locationRepo.Delete(loc);
                _locationRepo.Save();
            }
        }
    }
}