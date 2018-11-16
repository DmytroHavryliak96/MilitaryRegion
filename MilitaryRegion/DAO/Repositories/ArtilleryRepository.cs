using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{

    public class ArtilleryRepository : IRepository<Artillery>
    {
        private ApplicationDbContext db;
        public ArtilleryRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Artillery item)
        {
            db.Artilleries.Add(item);
        }

        public void Delete(int id)
        {
            Artillery artillery = db.Artilleries.Find(id);

            if (artillery != null)
            {
                db.Artilleries.Remove(artillery);
            }
        }

        public IEnumerable<Artillery> Find(Func<Artillery, bool> predicate)
        {
            return db.Artilleries.Where(predicate).ToList();
        }

        public Artillery Get(int id)
        {
            return db.Artilleries.Find(id);
        }

        public IEnumerable<Artillery> GetAll()
        {
            return db.Artilleries;
        }

        public void Update(Artillery item)
        {
            Artillery dbEntry = db.Artilleries.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.ShootingRange = item.ShootingRange;
            }
        }
    }
}