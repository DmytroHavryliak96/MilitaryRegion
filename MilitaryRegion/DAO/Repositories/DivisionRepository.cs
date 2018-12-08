using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class DivisionRepository : IRepository<Division>
    {
        private ApplicationDbContext db;

        public DivisionRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Division item)
        {
            db.Divisions.Add(item);
        }

        public void Delete(int id)
        {
            Division division = db.Divisions.Find(id);

            if (division != null)
            {
                db.Divisions.Remove(division);
            };
        }

        public IEnumerable<Division> Find(Func<Division, bool> predicate)
        {
            return db.Divisions.Where(predicate);
        }

        public Division Get(int id)
        {
            return db.Divisions.Find(id);
        }

        public IEnumerable<Division> GetAll()
        {
            return db.Divisions.ToList();
        }

        public void Update(Division item)
        {
            Division dbEntry = db.Divisions.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.Name = item.Name;
                dbEntry.Number = item.Number;
                dbEntry.DivisionCommanderId = item.DivisionCommanderId;
            }
            db.SaveChanges();
        }
    }
}