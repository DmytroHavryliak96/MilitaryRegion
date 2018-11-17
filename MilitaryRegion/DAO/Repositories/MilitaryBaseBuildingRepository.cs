using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class MilitaryBaseBuildingRepository : IRepository<MilitaryBaseBuilding>
    {
        private ApplicationDbContext db;
        public MilitaryBaseBuildingRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(MilitaryBaseBuilding item)
        {
            db.MilitaryBaseBuildings.Add(item);
        }

        public void Delete(int id)
        {
            MilitaryBaseBuilding mBuilding = db.MilitaryBaseBuildings.Find(id);

            if (mBuilding != null)
            {
                db.MilitaryBaseBuildings.Remove(mBuilding);
            };
        }

        public IEnumerable<MilitaryBaseBuilding> Find(Func<MilitaryBaseBuilding, bool> predicate)
        {
            return db.MilitaryBaseBuildings.Where(predicate).ToList();
        }

        public MilitaryBaseBuilding Get(int id)
        {
            return db.MilitaryBaseBuildings.Find(id);
        }

        public IEnumerable<MilitaryBaseBuilding> GetAll()
        {
            return db.MilitaryBaseBuildings;
        }

        public void Update(MilitaryBaseBuilding item)
        {
            /*MilitaryBaseBuilding dbEntry = db.MilitaryBaseBuildings.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry. = item.CrewAmount;
                dbEntry.Model = item.Model;
                dbEntry.Name = item.Name;
                dbEntry.Weight = item.Weight;
            }*/
        }
    }
}