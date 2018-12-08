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
    public class MilitaryBaseMapper : IModelMapper<MilitaryBase, MilitaryBaseViewModel>
    {
        public MilitaryBaseViewModel MapModel(MilitaryBase mBase, IUnitOfWork Database)
        {
            var division = Database.Divisions.Get(mBase.DivisionId);
            var corp = Database.Corps.Get(division.Id);
            var army = Database.Armies.Get(corp.Id);
            var dislocation = Database.Dislocations.Get(mBase.DislocationId);
            var commander = Database.Servicemen.Get(mBase.MilitaryBaseCommanderId);

            var baseViewModel = new MilitaryBaseViewModel
            {
                Id = mBase.Id,

                ArmyNumber = army.Number,
                ArmyId = army.Id,

                CorpusNumber = corp.Number,
                CorpusId = corp.Id,

                DivisionName = division.Name,
                DivisionId = division.Id,

                City = dislocation.City,

                Name = mBase.Name,
                Number = mBase.Number,

                Commander = commander.SecondName + " " +  commander.FirstName
            };

            return baseViewModel;
        }
    }
}