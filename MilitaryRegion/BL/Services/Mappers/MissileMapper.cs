using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;
using MilitaryRegion.ViewModels;

namespace MilitaryRegion.BL.Services.Mappers
{
    public class MissileMapper : IModelMapper<MilitaryBaseWeaponry, WeaponryViewModel>
    {
        public WeaponryViewModel MapModel(MilitaryBaseWeaponry baseModel, IUnitOfWork db)
        {
            var militarybase = baseModel.MilitaryBase;
            var division = db.Divisions.Get(militarybase.DivisionId);
            var corp = db.Corps.Get(division.CorpId);
            var army = db.Armies.Get(corp.ArmyId);

            var weaponry = baseModel.Weaponry;
            var missile = db.MissileArmament.Find(a => a.WeaponryId == weaponry.Id).FirstOrDefault();

            var model = new WeaponryViewModel
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

                Type = weaponry.Name,
                Model = weaponry.Model,
                Ammunition = weaponry.Ammunition,
                Caliber = weaponry.Caliber,
                Category = weaponry.Category,
                Amount = baseModel.Amount,

                ShellSpeed = missile.ShellSpeed

            };
            return model;
        }
    }
}