using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class MilitaryBaseWeaponryRepository : IRepository<MilitaryBaseWeaponry>
    {
        private ApplicationDbContext db;
        public MilitaryBaseWeaponryRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(MilitaryBaseWeaponry item)
        {
            db.MilitaryBaseWeaponries.Add(item);
        }

        public void Delete(int id)
        {
            MilitaryBaseWeaponry bWeaponry = db.MilitaryBaseWeaponries.Find(id);

            if (bWeaponry != null)
            {
                db.MilitaryBaseWeaponries.Remove(bWeaponry);
            };
        }

        public IEnumerable<MilitaryBaseWeaponry> Find(Func<MilitaryBaseWeaponry, bool> predicate)
        {
            return db.MilitaryBaseWeaponries.Where(predicate).ToList();
        }

        public MilitaryBaseWeaponry Get(int id)
        {
            return db.MilitaryBaseWeaponries.Find(id);
        }

        public IEnumerable<MilitaryBaseWeaponry> GetAll()
        {
            return db.MilitaryBaseWeaponries;
        }

        public void Update(MilitaryBaseWeaponry item)
        {
            MilitaryBaseWeaponry dbEntry = db.MilitaryBaseWeaponries.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.Amount = item.Amount;
            }
        }
    }
}