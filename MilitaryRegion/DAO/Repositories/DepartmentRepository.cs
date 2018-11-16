using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.DAO.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private ApplicationDbContext db;

        public DepartmentRepository (ApplicationDbContext context)
        {
            db = context;
        }
        public void Create(Department item)
        {
            db.Departments.Add(item);
        }

        public void Delete(int id)
        {
            Department department = db.Departments.Find(id);

            if (department != null)
            {
                db.Departments.Remove(department);
            }
        }

        public IEnumerable<Department> Find(Func<Department, bool> predicate)
        {
            return db.Departments.Where(predicate).ToList();
        }

        public Department Get(int id)
        {
            return db.Departments.Find(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return db.Departments;
        }

        public void Update(Department item)
        {
            Department dbEntry = db.Departments.Find(item.Id);
            if (dbEntry != null)
            {
                dbEntry.Number = item.Number;
            }
        }
    }
}