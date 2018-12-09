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
    public class Chain : IChain
    {
        private IUnitOfWork db;

        public Chain(IUnitOfWork _db)
        {
            db = _db;
        }

        public IEnumerable<ServicemanViewModel> GetChain(int manId)
        {
            var currentman = db.Servicemen.Get(manId);

            Dictionary<int, int> chain = new Dictionary<int, int>();
            chain.Add(1, currentman.DepartmentId == 0 ? 0 : db.Departments.Get(currentman.DepartmentId).DepartmentCommanderId);
            chain.Add(2, currentman.TroopId == 0 ? 0 : db.Troops.Get(currentman.TroopId).TroopCommanderId);
            chain.Add(3, currentman.SquadId == 0 ? 0 : db.Squads.Get(currentman.SquadId).SquadCommanderId);
            chain.Add(4, currentman.MilitaryBaseId == 0 ? 0 : db.MilitaryBases.Get(currentman.MilitaryBaseId).MilitaryBaseCommanderId);
            chain.Add(5, currentman.DivisionId == 0 ? 0 : db.Divisions.Get(currentman.DivisionId).DivisionCommanderId);
            chain.Add(6, currentman.CorpId == 0 ? 0 : db.Corps.Get(currentman.CorpId).CorpCommanderId);
            chain.Add(7, db.Armies.Get(currentman.ArmyId).ArmyCommanderId);

            var improved = chain.Where(c => c.Value != 0);

            List<ServicemanViewModel> models = new List<ServicemanViewModel>();

            foreach(var value in improved)
            {
                var commander = db.Servicemen.Get(value.Value);
                var model = MapChainModel(commander);
                model.CurrentId = value.Key;
                models.Add(model);
            }

            var man = models.Find(m => m.ServicemanId == manId);
            if(man == null)
            {
                var model = MapChainModel(currentman);
                model.CurrentId = 0;
                models.Add(model);
            }

            var orderedModel = models.OrderBy(m => m.CurrentId).ToList();

            int orderId = orderedModel.Count();

            orderedModel.Last().CurrentId = orderId;
            orderedModel.Last().CommanderName = "";
            orderId--;

            if (orderedModel.Count() >= 2)
            {
                for (int i = orderedModel.Count() - 2; i >= 0; i--)
                {
                    orderedModel[i].CurrentId = orderId;
                    orderId--;
                    orderedModel[i].CommanderName = orderedModel[i + 1].Name;
                }
            }

            //orderedModel.OrderBy(m => m.CurrentId);

            return orderedModel;
           
        }

      /*  public Serviceman GetArmyCommander(int armyId)
        {
            var commanderId = db.Armies.Get(armyId).ArmyCommanderId;
            return db.Servicemen.Get(commanderId);
        }


        public Serviceman GetCorpCommander(int corpId)
        {
            var comId = db.Corps.Get(corpId).CorpCommanderId;
            return db.Servicemen.Get(comId);
        }

        public Serviceman GetDepartmentCommander(int depId)
        {
            var comId = db.Departments.Get(depId).DepartmentCommanderId;
            return db.Servicemen.Get(comId);
        }

        public Serviceman GetDivisionCommander(int divId)
        {
            var comId = db.Divisions.Get(divId).DivisionCommanderId;
            return db.Servicemen.Get(comId);
        }

        public Serviceman GetMilitaryBaseCommander(int baseId)
        {
            var comId = db.MilitaryBases.Get(baseId).MilitaryBaseCommanderId;
            return db.Servicemen.Get(comId);
        }

        public Serviceman GetSquadCommander(int squadId)
        {
            var comId = db.Squads.Get(squadId).SquadCommanderId;
            return db.Servicemen.Get(comId);
        }

        public Serviceman GetTroopCommander(int troopId)
        {
            var comId = db.Troops.Get(troopId).TroopCommanderId;
            return db.Servicemen.Get(comId);
        }*/

        public void Dispose()
        {
            db.Dispose();
        }

        public ServicemanViewModel MapChainModel(Serviceman baseModel)
        {
            var department = db.Departments.Get(baseModel.DepartmentId);
            var troop = db.Troops.Get(baseModel.TroopId);
            var squad = db.Squads.Get(baseModel.SquadId);
            var militaryBase = db.MilitaryBases.Get(baseModel.MilitaryBaseId);
            var division = db.Divisions.Get(baseModel.DivisionId);
            var corp = db.Corps.Get(baseModel.CorpId);
            var army = db.Armies.Get(baseModel.ArmyId);
            var rank = db.Ranks.Get(baseModel.RankId);

            var servicemanViewModel = new ServicemanViewModel
            {
                ServicemanId = baseModel.Id,
                Name = baseModel.FirstName + " " + baseModel.SecondName,

                DateOfBirth = baseModel.DateOfBirth,
                RankName = rank.Name,
            };

            if (army != null)
            {
                servicemanViewModel.ArmyId = army.Id;
                servicemanViewModel.ArmyNumber = army.Number;
            }

            if (corp != null)
            {
                servicemanViewModel.CorpusId = corp.Id;
                servicemanViewModel.CorpusNumber = corp.Number;
            }

            if (division != null)
            {
                servicemanViewModel.DivisionId = division.Id;
                servicemanViewModel.DivisionName = division.Name;
            }

            if (militaryBase != null)
            {
                servicemanViewModel.MilitaryBaseId = militaryBase.Id;
                servicemanViewModel.MilitaryBaseName = militaryBase.Name;
            }

            if (squad != null)
            {
                servicemanViewModel.SquadId = squad.Id;
                servicemanViewModel.SquadNumber = squad.Number;
            }

            if (troop != null)
            {
                servicemanViewModel.TroopId = troop.Id;
                servicemanViewModel.TroopNumber = troop.Number;
            }

            if (department != null)
            {
                servicemanViewModel.DepartmentId = department.Id;
                servicemanViewModel.DepartmnetNumber = department.Number;
            }

            return servicemanViewModel;
        }

        private bool isCommander(int manId, int unitCommanderId)
        {
            if (manId == unitCommanderId)
                return true;
            return false;
        }
    }
}