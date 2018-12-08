using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class ArmyRepository : IRepository<Army>
    {
        private ApplicationDbContext db;

        public ArmyRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Army item)
        {
            db.Armies.Add(item);
        }

        public void Delete(int id)
        {
            Army army = db.Armies.Find(id);

            if (army != null)
            {
                db.Armies.Remove(army);
            }
        }

        public IEnumerable<Army> Find(Func<Army, bool> predicate)
        {
            return db.Armies.Where(predicate).ToList();
        }

        public Army Get(int id)
        {
           return db.Armies.Find(id);
        }

        public IEnumerable<Army> GetAll()
        {
            return db.Armies.ToList();
        }

        public void Update(Army item)
        {
            Army dbEntry = db.Armies.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.Number = item.Number;
                dbEntry.ArmyCommanderId = item.ArmyCommanderId;
            }

            db.SaveChanges();
        }
    }
}