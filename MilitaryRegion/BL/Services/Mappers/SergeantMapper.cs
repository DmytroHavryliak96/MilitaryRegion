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
    public class SergeantMapper : IModelMapper<Sergeant, SergeantViewModel>
    {
        public SergeantViewModel MapModel(Sergeant baseModel, IUnitOfWork db)
        {
            var serviceMan = db.Servicemen.Get(baseModel.ServicemanId);
            var militaryBase = db.MilitaryBases.Get(serviceMan.MilitaryBaseId);
            var division = db.Divisions.Get(serviceMan.DivisionId);
            var corp = db.Corps.Get(serviceMan.CorpId);
            var army = db.Armies.Get(serviceMan.ArmyId);
            var rank = db.Ranks.Get(serviceMan.RankId);

            var sergeantViewModel = new SergeantViewModel
            {
                ServicemanId = serviceMan.Id,
                Name = serviceMan.FirstName + " " + serviceMan.SecondName,

                DateOfBirth = serviceMan.DateOfBirth,
                RankName = rank.Name,

                SergeantRankDate = baseModel.SergeantRankDate
            };

            if (army != null)
            {
                sergeantViewModel.ArmyId = army.Id;
                sergeantViewModel.ArmyNumber = army.Number;
            }

            if (corp != null)
            {
                sergeantViewModel.CorpusId = corp.Id;
                sergeantViewModel.CorpusNumber = corp.Number;
            }

            if (division != null)
            {
                sergeantViewModel.DivisionId = division.Id;
                sergeantViewModel.DivisionName = division.Name;
            }

            if (militaryBase != null)
            {
                sergeantViewModel.MilitaryBaseId = militaryBase.Id;
                sergeantViewModel.MilitaryBaseName = militaryBase.Name;
            }

            return sergeantViewModel;
        }
    }
}