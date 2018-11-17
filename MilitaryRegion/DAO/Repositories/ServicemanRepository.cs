using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class ServicemanRepository : IRepository<Serviceman>
    {
        private ApplicationDbContext db;
        public ServicemanRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Serviceman item)
        {
            db.Servicemen.Add(item);
        }

        public void Delete(int id)
        {
            Serviceman serviceman = db.Servicemen.Find(id);

            if (serviceman != null)
            {
                db.Servicemen.Remove(serviceman);
            };
        }

        public IEnumerable<Serviceman> Find(Func<Serviceman, bool> predicate)
        {
            return db.Servicemen.Where(predicate).ToList();
        }

        public Serviceman Get(int id)
        {
            return db.Servicemen.Find(id);
        }

        public IEnumerable<Serviceman> GetAll()
        {
            return db.Servicemen;
        }

        public void Update(Serviceman item)
        {
            Serviceman dbEntry = db.Servicemen.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.DateOfBirth = item.DateOfBirth;
                dbEntry.FirstName = item.FirstName;
                dbEntry.SecondName = item.SecondName;
            }
        }
    }
}