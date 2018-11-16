using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;


namespace MilitaryRegion.DAO.Repositories
{
    public class DislocationRepository : IRepository<Dislocation>
    {
        private ApplicationDbContext db;

        public DislocationRepository (ApplicationDbContext context)
        {
            db = context;
        }

        public void Create(Dislocation item)
        {
            db.Dislocations.Add(item);
        }

        public void Delete(int id)
        {
            Dislocation dislocations = db.Dislocations.Find(id);

            if (dislocations != null)
            {
                db.Dislocations.Remove(dislocations);
            };
        }

        public IEnumerable<Dislocation> Find(Func<Dislocation, bool> predicate)
        {
            return db.Dislocations.Where(predicate).ToList();
        }

        public Dislocation Get(int id)
        {
            return db.Dislocations.Find(id);
        }

        public IEnumerable<Dislocation> GetAll()
        {
            return db.Dislocations;
        }

        public void Update(Dislocation item)
        {
            Dislocation dbEntry = db.Dislocations.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.City = item.City;
            }
        }
    }
}