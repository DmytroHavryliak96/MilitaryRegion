using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class MilitaryBaseMachineryRepository : IRepository<MilitaryBaseMachinery>
    {
        private ApplicationDbContext db;
        public MilitaryBaseMachineryRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(MilitaryBaseMachinery item)
        {
            db.MilitaryBaseMachineries.Add(item);
        }

        public void Delete(int id)
        {
            MilitaryBaseMachinery bMachinery = db.MilitaryBaseMachineries.Find(id);

            if (bMachinery != null)
            {
                db.MilitaryBaseMachineries.Remove(bMachinery);
            };
        }

        public IEnumerable<MilitaryBaseMachinery> Find(Func<MilitaryBaseMachinery, bool> predicate)
        {
            return db.MilitaryBaseMachineries.Where(predicate).ToList();
        }

        public MilitaryBaseMachinery Get(int id)
        {
            return db.MilitaryBaseMachineries.Find(id);
        }

        public IEnumerable<MilitaryBaseMachinery> GetAll()
        {
            return db.MilitaryBaseMachineries;
        }

        public void Update(MilitaryBaseMachinery item)
        {
            MilitaryBaseMachinery dbEntry = db.MilitaryBaseMachineries.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.Amount = item.Amount;
            }
        }
    }
}