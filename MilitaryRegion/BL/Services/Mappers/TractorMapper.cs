using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.Models;
using MilitaryRegion.ViewModels;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.BL.Interfaces;

namespace MilitaryRegion.BL.Services.Mappers
{
    public class TractorMapper : IModelMapper<MilitaryBaseMachinery, TechnicViewModel>
    {
        public TechnicViewModel MapModel(MilitaryBaseMachinery baseModel, IUnitOfWork db)
        {
            var militarybase = baseModel.MilitaryBase;
            var division = db.Divisions.Get(militarybase.DivisionId);
            var corp = db.Corps.Get(division.CorpId);
            var army = db.Armies.Get(corp.ArmyId);

            var machinery = baseModel.Machinery;

            var tractor = db.Tractors.Find(i => i.MachineryId == machinery.Id).FirstOrDefault();

            var model = new TechnicViewModel
            {
                Id = baseModel.Id,

                DivisionId = division.Id,
                DivisionName = division.Name,

                CorpusId = corp.Id,
                CorpusNumber = corp.Number,

                ArmyId = army.Id,
                ArmyNumber = army.Number,

                MilitaryBaseId = militarybase.Id,
                MilitaryBaseName = militarybase.Name,

                Type = machinery.Name,
                Model = machinery.Model,
                Category = machinery.Category,
                Weight = machinery.Weight,
                CrewAmount = machinery.CrewAmount,
                Amount = baseModel.Amount,

                LoadCapacity = tractor.LoadCapacity

            };
            return model;
        }
    }
}