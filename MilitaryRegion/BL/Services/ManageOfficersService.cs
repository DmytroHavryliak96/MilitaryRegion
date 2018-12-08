using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.ViewModels;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.BL.Services
{
    public class ManageOfficersService : IManageOfficers
    {
        private IUnitOfWork Database { get; set; }
        private IModelMapper<Officer, OfficerViewModel> mapper;

        public ManageOfficersService(IUnitOfWork db, IModelMapper<Officer, OfficerViewModel> mp)
        {
            Database = db;
            mapper = mp;
        }

        public IEnumerable<Army> GetAllArmies()
        {
            return Database.Armies.GetAll();
        }

        public IEnumerable<Corp> GetAllCorps()
        {
            return Database.Corps.GetAll();
        }

        public IEnumerable<Division> GetAllDivisions()
        {
            return Database.Divisions.GetAll();
        }

        public IEnumerable<Rank> GetOfficersRanks()
        {
            return Database.Ranks.Find(r => r.Name.Equals("Генерал") || r.Name.Equals("Полковник") || r.Name.Equals("Підполковник") || r.Name.Equals("Майор") ||
                r.Name.Equals("Лейтенант"));
        }

        public IEnumerable<OfficerViewModel> GetAllOfficers(int rankId)
        {
            List<Officer> officers = new List<Officer>();

            if (rankId == 0)
                officers = Database.Officers.GetAll().ToList();
            else {
                var serviceman = Database.Servicemen.Find(s => s.RankId == rankId).ToList();
                for(int i = 0; i < serviceman.Count(); i++)
                {
                    officers.Add(Database.Officers.Find(o => o.ServicemanId == serviceman[i].Id).FirstOrDefault());
                }
            }

            List<OfficerViewModel> models = new List<OfficerViewModel>();
            foreach (var officer in officers)
            {
                models.Add(mapper.MapModel(officer, Database));
            }
            return models;
        }

        public IEnumerable<OfficerViewModel> GetOfficersOfArmy(int armyId, int rankId)
        {
            var models = GetAllOfficers(rankId);
            var result = models.Where(o => o.ArmyId == armyId);
            return result;
        }

        public IEnumerable<OfficerViewModel> GetOfficersOfCorp(int corpId, int rankId)
        {
            var models = GetAllOfficers(rankId);
            var result = models.Where(o => o.CorpusId == corpId);
            return result;
        }

        public IEnumerable<OfficerViewModel> GetOfficersOfDivision(int divisionId, int rankId)
        {
            var models = GetAllOfficers(rankId);
            var result = models.Where(o => o.DivisionId == divisionId);
            return result;
        }

        public string GetCurrentRank(int rank)
        {
            if (rank == 0)
                return "увесь склад";
            return "звання = " + Database.Ranks.Get(rank).Name;
        }

        public IEnumerable<OfficerViewModel> GetOfficersOfBases(int baseId, int rankId)
        {
            var models = GetAllOfficers(rankId);
            var result = models.Where(o => o.MilitaryBaseId == baseId);
            return result;
        }

        public IEnumerable<MilitaryBase> GetAllMilitaryBases()
        {
            return Database.MilitaryBases.GetAll();
        }
    }
}