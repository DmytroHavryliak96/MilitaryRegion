using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class TractorRepository : IRepository<Tractor>
    {
        private ApplicationDbContext db;
        public TractorRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Tractor item)
        {
            db.Tractors.Add(item);
        }

        public void Delete(int id)
        {
            Tractor tractor = db.Tractors.Find(id);

            if (tractor != null)
            {
                db.Tractors.Remove(tractor);
            };
        }

        public IEnumerable<Tractor> Find(Func<Tractor, bool> predicate)
        {
            return db.Tractors.Where(predicate).ToList();
        }

        public Tractor Get(int id)
        {
            return db.Tractors.Find(id);
        }

        public IEnumerable<Tractor> GetAll()
        {
            return db.Tractors;
        }

        public void Update(Tractor item)
        {
           Tractor dbEntry = db.Tractors.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.LoadCapacity = item.LoadCapacity;
            }
        }
    }
}