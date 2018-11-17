using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class MissileArmamentRepository : IRepository<MissileArmament>
    {
        private ApplicationDbContext db;
        public MissileArmamentRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(MissileArmament item)
        {
            db.MissileArmaments.Add(item);
        }

        public void Delete(int id)
        {
            MissileArmament mArmament = db.MissileArmaments.Find(id);

            if (mArmament != null)
            {
                db.MissileArmaments.Remove(mArmament);
            };
        }

        public IEnumerable<MissileArmament> Find(Func<MissileArmament, bool> predicate)
        {
            return db.MissileArmaments.Where(predicate).ToList();
        }

        public MissileArmament Get(int id)
        {
            return db.MissileArmaments.Find(id);
        }

        public IEnumerable<MissileArmament> GetAll()
        {
            return db.MissileArmaments;
        }

        public void Update(MissileArmament item)
        {
            MissileArmament dbEntry = db.MissileArmaments.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.ShellSpeed = item.ShellSpeed;
            }
        }
    }
}