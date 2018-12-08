using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class RankRepository : IRepository<Rank>
    {
        private ApplicationDbContext db;
        public RankRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Rank item)
        {
            db.Ranks.Add(item);
        }

        public void Delete(int id)
        {
            Rank rank = db.Ranks.Find(id);

            if (rank != null)
            {
                db.Ranks.Remove(rank);
            };
        }

        public IEnumerable<Rank> Find(Func<Rank, bool> predicate)
        {
            return db.Ranks.Where(predicate).ToList();
        }

        public Rank Get(int id)
        {
            return db.Ranks.Find(id);
        }

        public IEnumerable<Rank> GetAll()
        {
            return db.Ranks.ToList();
        }

        public void Update(Rank item)
        {
            Rank dbEntry = db.Ranks.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.Name = item.Name;
            }
        }
    }
}