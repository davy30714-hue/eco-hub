using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Repositories;

namespace Services
{
    public class ExpeditionService
    {
        private readonly IRepository<Expeditions> _expeditionRepo;
        private readonly IRepository<ExpeditionTeams> _teamRepo;
        private readonly IRepository<ExpeditionReports> _reportRepo;

        public ExpeditionService(
            IRepository<Expeditions> expRepo,
            IRepository<ExpeditionTeams> teamRepo,
            IRepository<ExpeditionReports> reportRepo)
        {
            _expeditionRepo = expRepo;
            _teamRepo = teamRepo;
            _reportRepo = reportRepo;
        }

        public IEnumerable<Expeditions> GetAll()
        {
            return _expeditionRepo.GetAll();
        }

        public Expeditions GetById(int id)
        {
            return _expeditionRepo.GetById(id);
        }

        public IEnumerable<Expeditions> GetByDateRange(DateTime start, DateTime end)
        {
            return _expeditionRepo.Find(e => e.StartDate >= start && e.EndDate <= end);
        }

        public IEnumerable<Expeditions> GetActiveExpeditions()
        {
            return _expeditionRepo.Find(e => e.Status == "Planned" || e.Status == "In Progress");
        }

        public IEnumerable<ExpeditionTeams> GetTeamMembers(int expeditionId)
        {
            return _teamRepo.Find(t => t.ExpeditionId == expeditionId);
        }

        public ExpeditionReports GetReport(int expeditionId)
        {
            return _reportRepo.Find(r => r.ExpeditionId == expeditionId).FirstOrDefault();
        }

        public void AddExpedition(Expeditions expedition)
        {
            if (expedition.StartDate < DateTime.Now.Date)
            {
                throw new Exception("Увага: Дата в минулому");
            }
            if (expedition.EndDate < expedition.StartDate)
            {
                throw new Exception("Кінцева дата не може бути раніше початкової дати");
            }

            _expeditionRepo.Add(expedition);
            _expeditionRepo.Save();
        }

        public void UpdateExpedition(Expeditions expedition)
        {
            _expeditionRepo.Update(expedition);
            _expeditionRepo.Save();
        }

        public void DeleteExpedition(int id)
        {
            var exp = _expeditionRepo.GetById(id);
            if (exp != null)
            {
                _expeditionRepo.Delete(exp);
                _expeditionRepo.Save();
            }
        }
    }
}