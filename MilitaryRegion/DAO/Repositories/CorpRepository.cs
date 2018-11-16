using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class CorpRepository : IRepository<Corp>
    {
        private ApplicationDbContext db;
        public CorpRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Corp item)
        {
            db.Corps.Add(item);
        }

        public void Delete(int id)
        {
            Corp corp = db.Corps.Find(id);

            if (corp != null)
            {
                db.Corps.Remove(corp);
            }
        }

        public IEnumerable<Corp> Find(Func<Corp, bool> predicate)
        {
            return db.Corps.Where(predicate).ToList();
        }

        public Corp Get(int id)
        {
            return db.Corps.Find(id);
        }

        public IEnumerable<Corp> GetAll()
        {
            return db.Corps;
        }

        public void Update(Corp item)
        {
            Corp dbEntry = db.Corps.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.Number = item.Number;
            }
        }
    }
}