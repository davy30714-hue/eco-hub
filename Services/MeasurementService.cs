using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Repositories;

namespace Services
{
    public class MeasurementService
    {
        private readonly IRepository<Measurements> _repo;

        public MeasurementService(IRepository<Measurements> repo)
        {
            _repo = repo;
        }

        public IEnumerable<Measurements> GetAll() => _repo.GetAll();

        public Measurements GetById(int id) => _repo.GetById(id);

        public IEnumerable<Measurements> GetByDateRange(DateTime start, DateTime end)
        {
            return _repo.Find(m => m.Timestamp >= start && m.Timestamp <= end);
        }

        public IEnumerable<Measurements> Filter(DateTime start, DateTime end, int? locationId)
        {
            if (start > end)
            {
                var temp = start;
                start = end;
                end = temp;
            }

            start = start.Date;
            end = end.Date.AddDays(1).AddTicks(-1); // include the full end day

            var query = _repo.Find(m => m.Timestamp >= start && m.Timestamp <= end);

            if (locationId.HasValue)
            {
                query = query.Where(m => m.LocationId == locationId.Value);
            }
            return query;
        }

        public int AddMeasurement(Measurements measurement)
        {
            if (measurement.Value < 0 && measurement.ParameterType == "pH")
                throw new Exception("pH не може бути від'ємним!");

            _repo.Add(measurement);
            int rowsAffected = _repo.Save();
            return rowsAffected;
        }

        public void UpdateMeasurement(Measurements measurement)
        {
            _repo.Update(measurement);
            _repo.Save();
        }

        public void DeleteMeasurement(int id)
        {
            var m = _repo.GetById(id);
            if (m != null)
            {
                _repo.Delete(m);
                _repo.Save();
            }
        }

        public string GetStats(DateTime start, DateTime end, int? locationId)
        {
            var data = Filter(start, end, locationId).ToList();
            if (!data.Any()) return "No data";

            return $"Count: {data.Count}";
        }
    }
}