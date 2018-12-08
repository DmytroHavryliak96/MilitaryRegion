using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;


namespace MilitaryRegion.DAO.Repositories
{
    public class SquadRepository : IRepository<Squad>
    {
        private ApplicationDbContext db;
        public SquadRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Squad item)
        {
            db.Squads.Add(item);
        }

        public void Delete(int id)
        {
            Squad squad = db.Squads.Find(id);

            if (squad != null)
            {
                db.Squads.Remove(squad);
            };
        }

        public IEnumerable<Squad> Find(Func<Squad, bool> predicate)
        {
            return db.Squads.Where(predicate).ToList();
        }

        public Squad Get(int id)
        {
            return db.Squads.Find(id);
        }

        public IEnumerable<Squad> GetAll()
        {
            return db.Squads;
        }

        public void Update(Squad item)
        {
            Squad dbEntry = db.Squads.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.Number = item.Number;
                dbEntry.SquadCommanderId = item.SquadCommanderId;
            }
            db.SaveChanges();
        }
    }
}