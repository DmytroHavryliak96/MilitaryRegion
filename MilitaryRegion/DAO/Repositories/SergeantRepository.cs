using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class SergeantRepository : IRepository<Sergeant>
    {
        private ApplicationDbContext db;

        public SergeantRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Sergeant item)
        {
            db.Sergeants.Add(item);
        }

        public void Delete(int id)
        {
            Sergeant sergeant = db.Sergeants.Find(id);

            if (sergeant != null)
            {
                db.Sergeants.Remove(sergeant);
            };
        }

        public IEnumerable<Sergeant> Find(Func<Sergeant, bool> predicate)
        {
            return db.Sergeants.Where(predicate).ToList();
        }

        public Sergeant Get(int id)
        {
            return db.Sergeants.Find(id);
        }

        public IEnumerable<Sergeant> GetAll()
        {
            return db.Sergeants;
        }

        public void Update(Sergeant item)
        {
            Sergeant dbEntry = db.Sergeants.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.SergeantRankDate = item.SergeantRankDate;
            }
        }
    }
}