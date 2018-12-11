using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.Models;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.ViewModels;
using MilitaryRegion.DAO.Interfaces;

namespace MilitaryRegion.BL.Services
{
    public class ManageWeaponryAmount : IManageWeaponAmount
    {
        private IUnitOfWork db;

        public ManageWeaponryAmount(IUnitOfWork _db)
        {
            db = _db;
        }

        public IEnumerable<WeaponryAmountViewModel> GetAllBases()
        {
            var weaponries = db.MilitaryBaseWeaponries.GetAll().ToList();
            List<WeaponryAmountViewModel> list = new List<WeaponryAmountViewModel>();

            for (int i = 0; i < weaponries.Count(); i++)
            {
                weaponries[i].MilitaryBase = db.MilitaryBases.Get(weaponries[i].MilitaryBaseId);
                weaponries[i].Weaponry = db.Weaponry.Get(weaponries[i].WeaponryId);
                list.Add(MapModel(weaponries[i], weaponries[i].Amount));
            }

            return list;
        }

        public IEnumerable<WeaponryAmountViewModel> GetMore10(string type)
        {
            var weaponries = db.MilitaryBaseWeaponries.GetAll().ToList();

            for (int i = 0; i < weaponries.Count(); i++)
            {
                weaponries[i].MilitaryBase = db.MilitaryBases.Get(weaponries[i].MilitaryBaseId);
                weaponries[i].Weaponry = db.Weaponry.Get(weaponries[i].WeaponryId);
            }

            var result = weaponries.Where(w => w.Weaponry.Name.Equals(type)).GroupBy(wp => wp.MilitaryBaseId,
                wp => wp.Amount, (key, g) => new { BaseId = key, Amount = g.ToList().Sum() });


            List<WeaponryAmountViewModel> list = new List<WeaponryAmountViewModel>();

            foreach (var item in result)
            {
                if (item.Amount > 10)
                {
                    var militarybase = db.MilitaryBases.Find(w => w.Id == item.BaseId).FirstOrDefault();
                    var weaponry = db.Weaponry.Find(w => w.Name.Equals(type)).FirstOrDefault();
                    //weaponry.Weaponry = db.Weaponry.Get(weaponry.WeaponryId);
                    list.Add(MapModel(militarybase, weaponry, item.Amount));
                }
            }

            return list;
        }

        public IEnumerable<WeaponryAmountViewModel> GetNone(string type)
        {
            var weaponries = db.MilitaryBaseWeaponries.GetAll().ToList();

            for (int i = 0; i < weaponries.Count(); i++)
            {
                weaponries[i].MilitaryBase = db.MilitaryBases.Get(weaponries[i].MilitaryBaseId);
                weaponries[i].Weaponry = db.Weaponry.Get(weaponries[i].WeaponryId);
            }

            var result = weaponries.Where(w => w.Weaponry.Name.Equals(type)).GroupBy(wp => wp.MilitaryBaseId).Select(g => g.FirstOrDefault());

            List<MilitaryBase> bases = db.MilitaryBases.GetAll().ToList();
            foreach (var item in result)
            {
                bases.RemoveAll(b => b.Id == item.MilitaryBaseId);                    
            }


            List<WeaponryAmountViewModel> list = new List<WeaponryAmountViewModel>();

            foreach (var item in bases)
            {
                //var militarybase = db.MilitaryBases.Find(w => w.Id == item.Id).FirstOrDefault();
                var weaponry = db.Weaponry.Find(w => w.Name.Equals(type)).FirstOrDefault();
                //weaponry.Weaponry = db.Weaponry.Get(weaponry.WeaponryId);
                list.Add(MapModel(item, weaponry, 0));

            }

            return list;
        }

        private WeaponryAmountViewModel MapModel(MilitaryBaseWeaponry baseModel, int amount)
        {
            WeaponryAmountViewModel model = new WeaponryAmountViewModel
            {
                MilitaryBaseId = baseModel.MilitaryBaseId,
                MilitaryBaseName = baseModel.MilitaryBase.Name,
                WeaponryType = baseModel.Weaponry.Name,
                Amount = amount,
                Model = baseModel.Weaponry.Model
            };

            return model;
        }

        private WeaponryAmountViewModel MapModel(MilitaryBase baseModel, Weaponry weapon, int amount)
        {
            WeaponryAmountViewModel model = new WeaponryAmountViewModel
            {
                MilitaryBaseId = baseModel.Id,
                MilitaryBaseName = baseModel.Name,
                WeaponryType = weapon.Name,
                Amount = amount,
                Model = ""
            };

            return model;
        }
    }
}