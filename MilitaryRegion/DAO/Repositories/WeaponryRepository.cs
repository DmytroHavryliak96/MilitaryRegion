using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class WeaponryRepository : IRepository<Weaponry>
    {
        private ApplicationDbContext db;
        public WeaponryRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Weaponry item)
        {
            db.Weaponries.Add(item);
        }

        public void Delete(int id)
        {
            Weaponry weaponry = db.Weaponries.Find(id);

            if (weaponry != null)
            {
                db.Weaponries.Remove(weaponry);
            };
        }

        public IEnumerable<Weaponry> Find(Func<Weaponry, bool> predicate)
        {
            return db.Weaponries.Where(predicate);
        }

        public Weaponry Get(int id)
        {
            return db.Weaponries.Find(id);
        }

        public IEnumerable<Weaponry> GetAll()
        {
            return db.Weaponries;
        }

        public void Update(Weaponry item)
        {
            Weaponry dbEntry = db.Weaponries.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.Ammunition = item.Ammunition;
                dbEntry.Caliber = item.Caliber;
                dbEntry.Model = item.Model;
                dbEntry.Name = item.Name;
            }
        }
    }
}