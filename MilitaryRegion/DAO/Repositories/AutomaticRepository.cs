using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class AutomaticRepository : IRepository<Automatic>
    {
        private ApplicationDbContext db;
        public AutomaticRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Automatic item)
        {
            db.Automatics.Add(item);
        }

        public void Delete(int id)
        {
            Automatic automatic = db.Automatics.Find(id);

            if (automatic != null)
            {
                db.Automatics.Remove(automatic);
            }
        }

        public IEnumerable<Automatic> Find(Func<Automatic, bool> predicate)
        {
            return db.Automatics.Where(predicate).ToList();
        }

        public Automatic Get(int id)
        {
            return db.Automatics.Find(id);
        }

        public IEnumerable<Automatic> GetAll()
        {
            return db.Automatics;
        }

        public void Update(Automatic item)
        {
            Automatic dbEntry = db.Automatics.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.FiringSpeed = item.FiringSpeed;
            }
        }
    }
}