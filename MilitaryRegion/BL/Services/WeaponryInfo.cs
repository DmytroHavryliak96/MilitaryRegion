using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.BL.Services
{
    public class WeaponryInfo : IWeaponInfo
    {
        private IUnitOfWork db;

        public WeaponryInfo(IUnitOfWork _db)
        {
            db = _db;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Weaponry> GetAllCategories()
        {
            var weaponries = db.Weaponry.GetAll().GroupBy(m => m.Category).Select(g => g.FirstOrDefault());
            return weaponries;
        }

        public IEnumerable<Weaponry> GetAllTypes()
        {
            var weaponries = db.Weaponry.GetAll().GroupBy(m => m.Name).Select(g => g.FirstOrDefault());
            return weaponries;
        }

        public string GetCurrentCategory(string category)
        {
            switch (category)
            {
                case "Автоматична зброя":
                    {
                        return "Automatic";
                    }
                case "Карабіни":
                    {
                        return "Carbine";
                    }
                case "Ракетне озброєння":
                    {
                        return "Missile";
                    }
                case "Артилерія":
                    {
                        return "Artillety";
                    }
                case "all":
                    {
                        return "all";
                    }
                default:
                    break;
            }
            return "what";
        }

        public string GetCurrentCategoryFromType(string type)
        {
            return db.Weaponry.Find(w => w.Name.Equals(type)).FirstOrDefault().Category;
        }

        public string GetCurrentCategoryFromTypeEng(string type)
        {
            return GetCurrentCategory(GetCurrentCategoryFromType(type));
        }
    }
}