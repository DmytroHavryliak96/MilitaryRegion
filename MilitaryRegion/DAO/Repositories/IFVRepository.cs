using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class IFVRepository : IRepository<IFV>
    {
        private ApplicationDbContext db;

        public IFVRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(IFV item)
        {
            db.IFVs.Add(item);
        }

        public void Delete(int id)
        {
            IFV ifv = db.IFVs.Find(id);

            if (ifv != null)
            {
                db.IFVs.Remove(ifv);
            };
        }

        public IEnumerable<IFV> Find(Func<IFV, bool> predicate)
        {
            return db.IFVs.Where(predicate).ToList();
        }

        public IFV Get(int id)
        {
            return db.IFVs.Find(id);
        }

        public IEnumerable<IFV> GetAll()
        {
            return db.IFVs;
        }

        public void Update(IFV item)
        {
            IFV dbEntry = db.IFVs.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.Landing = item.Landing;
                dbEntry.MainCaliber = item.MainCaliber;
            }
        }
    }
}