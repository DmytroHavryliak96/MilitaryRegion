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
    public class ManageWeaponry : IManageWeaponry
    {
        private IUnitOfWork Database;
        private Func<string, IModelMapper<MilitaryBaseWeaponry, WeaponryViewModel>> resolver;

        public ManageWeaponry(IUnitOfWork _db, Func<string, IModelMapper<MilitaryBaseWeaponry, WeaponryViewModel>> _resolver)
        {
            Database = _db;
            resolver = _resolver;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<WeaponryViewModel> GetAllWeaponry(string category, string type)
        {
            var mapper = resolver(category);
            var weaponries = Database.MilitaryBaseWeaponries.GetAll().ToList();
            List<WeaponryViewModel> models = new List<WeaponryViewModel>();

            for (int i = 0; i < weaponries.Count(); i++)
            {
                weaponries[i].Weaponry = Database.Weaponry.Get(weaponries[i].WeaponryId);
                weaponries[i].MilitaryBase = Database.MilitaryBases.Get(weaponries[i].MilitaryBaseId);
            }


            if (category.Equals("all"))
            {
                for (int i = 0; i < weaponries.Count(); i++)
                    models.Add(mapper.MapModel(weaponries[i], Database));

                return models;
            }
            else
            {
                List<MilitaryBaseWeaponry> sortWeaponries = new List<MilitaryBaseWeaponry>();
                if (type.Equals("none"))
                {
                    sortWeaponries = weaponries.Where(m => m.Weaponry.Category.Equals(category)).ToList();
                }
                else
                {
                    sortWeaponries = weaponries.Where(m => m.Weaponry.Name.Equals(type)).ToList();
                }

                for (int i = 0; i < sortWeaponries.Count(); i++)
                    models.Add(mapper.MapModel(sortWeaponries[i], Database));

                return models;
            }
        }

        public IEnumerable<WeaponryViewModel> GetWeaponryOfArmy(int armyId, string category, string type)
        {
            var models = GetAllWeaponry(category, type);
            var result = models.Where(o => o.ArmyId == armyId);
            return result;
        }

        public IEnumerable<WeaponryViewModel> GetWeaponryOfCorp(int corpId, string category, string type)
        {
            var models = GetAllWeaponry(category, type);
            var result = models.Where(o => o.CorpusId == corpId);
            return result;
        }

        public IEnumerable<WeaponryViewModel> GetWeaponryOfDivision(int divisionId, string category, string type)
        {
            var models = GetAllWeaponry(category, type);
            var result = models.Where(o => o.DivisionId == divisionId);
            return result;
        }

        public IEnumerable<WeaponryViewModel> GetWeaponryOfMilitaryBase(int baseId, string category, string type)
        {
            var models = GetAllWeaponry(category, type);
            var result = models.Where(o => o.MilitaryBaseId == baseId);
            return result;
        }
    }
}