using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class BuildingRepository : IRepository<Building>
    {
        private ApplicationDbContext db;
        public BuildingRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Building item)
        {
            db.Buildings.Add(item);
        }

        public void Delete(int id)
        {
            Building building = db.Buildings.Find(id);

            if (building != null)
            {
                db.Buildings.Remove(building);
            }
        }

        public IEnumerable<Building> Find(Func<Building, bool> predicate)
        {
            return db.Buildings.Where(predicate).ToList();
        }

        public Building Get(int id)
        {
            return db.Buildings.Find(id);
        }

        public IEnumerable<Building> GetAll()
        {
            return db.Buildings;
        }

        public void Update(Building item)
        {
            Building dbEntry = db.Buildings.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.FloorAmount = item.FloorAmount;
                dbEntry.Height = item.Height;
                dbEntry.Purpose = item.Purpose;
                dbEntry.Square = item.Square;
            }
        }
    }
}