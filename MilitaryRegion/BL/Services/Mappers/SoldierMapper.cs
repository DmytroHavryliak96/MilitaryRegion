using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.Models;
using MilitaryRegion.ViewModels;
using MilitaryRegion.DAO.Interfaces;

namespace MilitaryRegion.BL.Services.Mappers
{
    public class SoldierMapper : IModelMapper<Soldier, SoldierViewModel>
    {
        public SoldierViewModel MapModel(Soldier baseModel, IUnitOfWork db)
        {
            var serviceMan = db.Servicemen.Get(baseModel.ServicemanId);
            var militaryBase = db.MilitaryBases.Get(serviceMan.MilitaryBaseId);
            var division = db.Divisions.Get(serviceMan.DivisionId);
            var corp = db.Corps.Get(serviceMan.CorpId);
            var army = db.Armies.Get(serviceMan.ArmyId);
            var rank = db.Ranks.Get(serviceMan.RankId);

            var soldierViewModel = new SoldierViewModel
            {
                ServicemanId = serviceMan.Id,
                Name = serviceMan.FirstName + " " + serviceMan.SecondName,

                DateOfBirth = serviceMan.DateOfBirth,
                RankName = rank.Name,

                ServiceStartDate = baseModel.ServiceStartDate
            };

            if (army != null)
            {
                soldierViewModel.ArmyId = army.Id;
                soldierViewModel.ArmyNumber = army.Number;
            }

            if (corp != null)
            {
                soldierViewModel.CorpusId = corp.Id;
                soldierViewModel.CorpusNumber = corp.Number;
            }

            if (division != null)
            {
                soldierViewModel.DivisionId = division.Id;
                soldierViewModel.DivisionName = division.Name;
            }

            if (militaryBase != null)
            {
                soldierViewModel.MilitaryBaseId = militaryBase.Id;
                soldierViewModel.MilitaryBaseName = militaryBase.Name;
            }

            return soldierViewModel;
        }
    }
}