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
    public class OfficerMapper : IModelMapper<Officer, OfficerViewModel>
    {
        public OfficerViewModel MapModel(Officer baseModel, IUnitOfWork db)
        {
            var serviceMan = db.Servicemen.Get(baseModel.ServicemanId);
            var militaryBase = db.MilitaryBases.Get(serviceMan.MilitaryBaseId);
            var division = db.Divisions.Get(serviceMan.DivisionId);
            var corp = db.Corps.Get(serviceMan.CorpId);
            var army = db.Armies.Get(serviceMan.ArmyId);
            var rank = db.Ranks.Get(serviceMan.RankId);

            var officerViewModel = new OfficerViewModel
            {
                ArmyNumber = army.Number,
                ArmyId = army.Id,

                CorpusNumber = corp.Number,
                CorpusId = corp.Id,

                DivisionName = division.Name,
                DivisionId = division.Id,

                MilitaryBaseName = militaryBase.Name,
                MilitaryBaseId = militaryBase.Id,

                ServicemanId = serviceMan.Id,
                Name = serviceMan.FirstName + " " + serviceMan.SecondName,

                DateOfBirth = serviceMan.DateOfBirth,
                RankName = rank.Name,

                AcademicCompletionDate = baseModel.AcademicCompletionDate,
                OfficerRankDate = baseModel.OfficerRankDate
            };

            return officerViewModel;
        }
    }
}