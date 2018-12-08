using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class OfficerRepository : IRepository<Officer>
    {
        private ApplicationDbContext db;
        public OfficerRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Officer item)
        {
            db.Officers.Add(item);
        }

        public void Delete(int id)
        {
            Officer officer = db.Officers.Find(id);

            if (officer != null)
            {
                db.Officers.Remove(officer);
            };
        }

        public IEnumerable<Officer> Find(Func<Officer, bool> predicate)
        {
            return db.Officers.Where(predicate).ToList();
        }

        public Officer Get(int id)
        {
            return db.Officers.Find(id);
        }

        public IEnumerable<Officer> GetAll()
        {
            return db.Officers.ToList();
        }

        public void Update(Officer item)
        {
            Officer dbEntry = db.Officers.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.AcademicCompletionDate = item.AcademicCompletionDate;
                dbEntry.OfficerRankDate = item.OfficerRankDate;
            }
        }
    }
}