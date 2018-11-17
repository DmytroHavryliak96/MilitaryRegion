using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class TroopRepository : IRepository<Troop>
    {
        private ApplicationDbContext db;

        public TroopRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Troop item)
        {
            db.Troops.Add(item);
        }

        public void Delete(int id)
        {
            Troop troop = db.Troops.Find(id);

            if (troop != null)
            {
                db.Troops.Remove(troop);
            };
        }

        public IEnumerable<Troop> Find(Func<Troop, bool> predicate)
        {
            return db.Troops.Where(predicate).ToList();
        }

        public Troop Get(int id)
        {
            return db.Troops.Find(id);
        }

        public IEnumerable<Troop> GetAll()
        {
            return db.Troops;
        }

        public void Update(Troop item)
        {
            Troop dbEntry = db.Troops.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.Number = item.Number;
            }
        }
    }
}