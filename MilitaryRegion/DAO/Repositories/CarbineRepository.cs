using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class CarbineRepository : IRepository<Carbine>
    {
        private ApplicationDbContext db;
        public CarbineRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Carbine item)
        {
            db.Carbines.Add(item);
        }

        public void Delete(int id)
        {

            Carbine carbine = db.Carbines.Find(id);

            if (carbine != null)
            {
                db.Carbines.Remove(carbine);
            }
        }

        public IEnumerable<Carbine> Find(Func<Carbine, bool> predicate)
        {
            return db.Carbines.Where(predicate).ToList();
        }

        public Carbine Get(int id)
        {
            return db.Carbines.Find(id);
        }

        public IEnumerable<Carbine> GetAll()
        {
            return db.Carbines;
        }

        public void Update(Carbine item)
        {
            Carbine dbEntry = db.Carbines.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.RechargeTime = item.RechargeTime;
            }
        }
    }
}