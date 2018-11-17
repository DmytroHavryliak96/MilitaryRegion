using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class ServicemanSpecialtyRepository : IRepository<ServicemanSpecialty>
    {
        private ApplicationDbContext db;
        public ServicemanSpecialtyRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(ServicemanSpecialty item)
        {
            db.ServicemanSpecialties.Add(item);
        }

        public void Delete(int id)
        {
            ServicemanSpecialty specialty = db.ServicemanSpecialties.Find(id);

            if (specialty != null)
            {
                db.ServicemanSpecialties.Remove(specialty);
            };
        }

        public IEnumerable<ServicemanSpecialty> Find(Func<ServicemanSpecialty, bool> predicate)
        {
            return db.ServicemanSpecialties.Where(predicate).ToList();
        }

        public ServicemanSpecialty Get(int id)
        {
            return db.ServicemanSpecialties.Find(id);
        }

        public IEnumerable<ServicemanSpecialty> GetAll()
        {
            return db.ServicemanSpecialties;
        }

        public void Update(ServicemanSpecialty item)
        {
           /* ServicemanSpecialty dbEntry = db.ServicemanSpecialties.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry. = item.DateOfBirth;
                dbEntry.FirstName = item.FirstName;
                dbEntry.SecondName = item.SecondName;
            }*/
        }
    }
}