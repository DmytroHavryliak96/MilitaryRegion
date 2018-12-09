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
    public class ManageSoldiersService : IManageRanks<SoldierViewModel>
    {
        private IUnitOfWork Database { get; set; }
        private IModelMapper<Soldier, SoldierViewModel> mapper;

        public ManageSoldiersService(IUnitOfWork db, IModelMapper<Soldier, SoldierViewModel> mp)
        {
            Database = db;
            mapper = mp;
        }

        public IEnumerable<SoldierViewModel> GetAll(int rankId)
        {
            List<Soldier> soldiers = new List<Soldier>();

            if (rankId == 0)
                soldiers = Database.Soldiers.GetAll().ToList();
            else
            {
                var serviceman = Database.Servicemen.Find(s => s.RankId == rankId).ToList();
                for (int i = 0; i < serviceman.Count(); i++)
                {
                    soldiers.Add(Database.Soldiers.Find(o => o.ServicemanId == serviceman[i].Id).FirstOrDefault());
                }
            }

            List<SoldierViewModel> models = new List<SoldierViewModel>();
            foreach (var soldier in soldiers)
            {
                models.Add(mapper.MapModel(soldier, Database));
            }
            return models;
        }

        public IEnumerable<Rank> GetRanks()
        {
            return Database.Ranks.Find(r => r.Name.Equals("Єфрейтор") || r.Name.Equals("Солдат"));
        }

        public IEnumerable<SoldierViewModel> GetRanksOfArmy(int armyId, int rankId)
        {
            var models = GetAll(rankId);
            var result = models.Where(o => o.ArmyId == armyId);
            return result;
        }

        public IEnumerable<SoldierViewModel> GetRanksOfBases(int baseId, int rankId)
        {
            var models = GetAll(rankId);
            var result = models.Where(o => o.MilitaryBaseId == baseId);
            return result;
        }

        public IEnumerable<SoldierViewModel> GetRanksOfCorp(int corpId, int rankId)
        {
            var models = GetAll(rankId);
            var result = models.Where(o => o.CorpusId == corpId);
            return result;
        }

        public IEnumerable<SoldierViewModel> GetRanksOfDivision(int divisionId, int rankId)
        {
            var models = GetAll(rankId);
            var result = models.Where(o => o.DivisionId == divisionId);
            return result;
        }
    }
}