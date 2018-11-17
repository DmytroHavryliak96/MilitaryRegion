using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class SpecialtyRepository : IRepository<Specialty>
    {
        private ApplicationDbContext db;
        public SpecialtyRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Specialty item)
        {
            db.Specialties.Add(item);
        }

        public void Delete(int id)
        {
            Specialty specialty = db.Specialties.Find(id);

            if (specialty != null)
            {
                db.Specialties.Remove(specialty);
            };
        }

        public IEnumerable<Specialty> Find(Func<Specialty, bool> predicate)
        {
            return db.Specialties.Where(predicate).ToList();
        }

        public Specialty Get(int id)
        {
            return db.Specialties.Find(id);
        }

        public IEnumerable<Specialty> GetAll()
        {
            return db.Specialties;
        }

        public void Update(Specialty item)
        {
            Specialty dbEntry = db.Specialties.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.Name = item.Name;
            }
        }
    }
}