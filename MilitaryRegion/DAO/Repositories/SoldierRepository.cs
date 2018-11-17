using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories 
{
    public class SoldierRepository : IRepository<Soldier>
    {
        private ApplicationDbContext db;
        public SoldierRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Soldier item)
        {
            db.Soldiers.Add(item);
        }

        public void Delete(int id)
        {
            Soldier soldier = db.Soldiers.Find(id);

            if (soldier != null)
            {
                db.Soldiers.Remove(soldier);
            };
        }

        public IEnumerable<Soldier> Find(Func<Soldier, bool> predicate)
        {
            return db.Soldiers.Where(predicate).ToList();
        }

        public Soldier Get(int id)
        {
            return db.Soldiers.Find(id);
        }

        public IEnumerable<Soldier> GetAll()
        {
            return db.Soldiers;
        }

        public void Update(Soldier item)
        {
            Soldier dbEntry = db.Soldiers.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.ServiceStartDate = item.ServiceStartDate;
            }
        }
    }
}