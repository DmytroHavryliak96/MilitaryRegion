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
                ServicemanId = serviceMan.Id,
                Name = serviceMan.FirstName + " " + serviceMan.SecondName,

                DateOfBirth = serviceMan.DateOfBirth,
                RankName = rank.Name,

                AcademicCompletionDate = baseModel.AcademicCompletionDate,
                OfficerRankDate = baseModel.OfficerRankDate
            };

            if (army != null)
            {
                officerViewModel.ArmyId = army.Id;
                officerViewModel.ArmyNumber = army.Number;
            }

            if (corp != null)
            {
                officerViewModel.CorpusId = corp.Id;
                officerViewModel.CorpusNumber = corp.Number;
            }
      
            if (division != null)
            {
                officerViewModel.DivisionId = division.Id;
                officerViewModel.DivisionName = division.Name;
            }

            if (militaryBase != null)
            {
                officerViewModel.MilitaryBaseId = militaryBase.Id;
                officerViewModel.MilitaryBaseName = militaryBase.Name;
            }
         
            return officerViewModel;
        }
    }
}