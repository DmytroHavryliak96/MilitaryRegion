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
    public class ManageSergeantsService : IManageRanks<SergeantViewModel>
    {
        private IUnitOfWork Database { get; set; }
        private IModelMapper<Sergeant, SergeantViewModel> mapper;

        public ManageSergeantsService(IUnitOfWork db, IModelMapper<Sergeant, SergeantViewModel> mp)
        {
            Database = db;
            mapper = mp;
        }

        public IEnumerable<SergeantViewModel> GetAll(int rankId)
        {
            List<Sergeant> sergeants = new List<Sergeant>();

            if (rankId == 0)
                sergeants = Database.Sergeants.GetAll().ToList();
            else
            {
                var serviceman = Database.Servicemen.Find(s => s.RankId == rankId).ToList();
                for (int i = 0; i < serviceman.Count(); i++)
                {
                    sergeants.Add(Database.Sergeants.Find(o => o.ServicemanId == serviceman[i].Id).FirstOrDefault());
                }
            }

            List<SergeantViewModel> models = new List<SergeantViewModel>();
            foreach (var sergeant in sergeants)
            {
                models.Add(mapper.MapModel(sergeant, Database));
            }
            return models;
        }

        public IEnumerable<SergeantViewModel> GetRanksOfArmy(int armyId, int rankId)
        {
            var models = GetAll(rankId);
            var result = models.Where(o => o.ArmyId == armyId);
            return result;
        }

        public IEnumerable<SergeantViewModel> GetRanksOfBases(int baseId, int rankId)
        {
            var models = GetAll(rankId);
            var result = models.Where(o => o.MilitaryBaseId == baseId);
            return result;
        }

        public IEnumerable<SergeantViewModel> GetRanksOfCorp(int corpId, int rankId)
        {
            var models = GetAll(rankId);
            var result = models.Where(o => o.CorpusId == corpId);
            return result;
        }

        public IEnumerable<SergeantViewModel> GetRanksOfDivision(int divisionId, int rankId)
        {
            var models = GetAll(rankId);
            var result = models.Where(o => o.DivisionId == divisionId);
            return result;
        }

        public IEnumerable<Rank> GetRanks()
        {
            return Database.Ranks.Find(r => r.Name.Equals("Старшина") || r.Name.Equals("Сержант") || r.Name.Equals("Прапорщик"));
        }
    }
}