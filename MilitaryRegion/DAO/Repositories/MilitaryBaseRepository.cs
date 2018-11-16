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
            throw new NotImplementedException();
        }

        public IEnumerable<MilitaryBase> Find(Func<MilitaryBase, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public MilitaryBase Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MilitaryBase> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(MilitaryBase item)
        {
            throw new NotImplementedException();
        }
    }
}