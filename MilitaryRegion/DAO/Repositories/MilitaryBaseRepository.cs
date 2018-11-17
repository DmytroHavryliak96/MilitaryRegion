using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;


namespace MilitaryRegion.DAO.Repositories
{
    public class MilitaryBaseRepository : IRepository<MilitaryBase>
    {
        private ApplicationDbContext db;

        public MilitaryBaseRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(MilitaryBase item)
        {
            db.MilitaryBases.Add(item);
        }

        public void Delete(int id)
        {
            MilitaryBase mBase = db.MilitaryBases.Find(id);

            if (mBase != null)
            {
                db.MilitaryBases.Remove(mBase);
            };
        }

        public IEnumerable<MilitaryBase> Find(Func<MilitaryBase, bool> predicate)
        {
            return db.MilitaryBases.Where(predicate).ToList();
        }

        public MilitaryBase Get(int id)
        {
            return db.MilitaryBases.Find(id);
        }

        public IEnumerable<MilitaryBase> GetAll()
        {
            return db.MilitaryBases;
        }

        public void Update(MilitaryBase item)
        {
            MilitaryBase dbEntry = db.MilitaryBases.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.Name = item.Name;
                dbEntry.Number = item.Number;
            }
        }
    }
}