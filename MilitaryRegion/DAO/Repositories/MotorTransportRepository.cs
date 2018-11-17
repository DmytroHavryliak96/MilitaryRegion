using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;


namespace MilitaryRegion.DAO.Repositories
{
    public class MotorTransportRepository : IRepository<MotorTransport>
    {
        private ApplicationDbContext db;
        public MotorTransportRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(MotorTransport item)
        {
            db.MotorTransports.Add(item);
        }

        public void Delete(int id)
        {
            MotorTransport mTransport = db.MotorTransports.Find(id);

            if (mTransport != null)
            {
                db.MotorTransports.Remove(mTransport);
            };
        }

        public IEnumerable<MotorTransport> Find(Func<MotorTransport, bool> predicate)
        {
            return db.MotorTransports.Where(predicate).ToList();
        }

        public MotorTransport Get(int id)
        {
            return db.MotorTransports.Find(id);
        }

        public IEnumerable<MotorTransport> GetAll()
        {
            return db.MotorTransports;
        }

        public void Update(MotorTransport item)
        {
            MotorTransport dbEntry = db.MotorTransports.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.MaxSpeed = item.MaxSpeed;
                dbEntry.Range = item.Range;
            }
        }
    }
}