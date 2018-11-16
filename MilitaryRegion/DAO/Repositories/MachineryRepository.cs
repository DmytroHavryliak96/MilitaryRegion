using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class MachineryRepository : IRepository<Machinery>
    {
        private ApplicationDbContext db;

        public MachineryRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Machinery item)
        {
            db.Machineries.Add(item);
        }

        public void Delete(int id)
        {
            Machinery machinery = db.Machineries.Find(id);

            if (machinery != null)
            {
                db.Machineries.Remove(machinery);
            };
        }

        public IEnumerable<Machinery> Find(Func<Machinery, bool> predicate)
        {
            return db.Machineries.Where(predicate).ToList();
        }

        public Machinery Get(int id)
        {
            return db.Machineries.Find(id);
        }

        public IEnumerable<Machinery> GetAll()
        {
            return db.Machineries;
        }

        public void Update(Machinery item)
        {
            Machinery dbEntry = db.Machineries.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.CrewAmount = item.CrewAmount;
                dbEntry.Model = item.Model;
                dbEntry.Name = item.Name;
                dbEntry.Weight = item.Weight;
            }
        }
    }
}