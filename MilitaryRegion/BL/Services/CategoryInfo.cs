using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.BL.Services
{
    public class CategoryInfo : ICategoryInfo
    {
       /* private IEnumerable<> categories;
        private IEnumerable<string> types;*/
        private IUnitOfWork db;

        public CategoryInfo(IUnitOfWork _db)
        {
            db = _db;
           // categories = 
          /*  types = new List<string>();
            db = _db;
            var types = */
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Machinery> GetAllCategories()
        {
            var machineries = db.Machineries.GetAll().GroupBy(m => m.Category).Select(g => g.FirstOrDefault());
            return machineries;
        }

        public IEnumerable<Machinery> GetAllTypes()
        {
            return db.Machineries.GetAll();
        }

        public string GetCurrentCategory(string category)
        {
            switch (category)
            {
                case "БМП":
                    {
                        return "BMP";
                    }
                case "Тягач":
                    {
                        return "Tractor";
                    }
                case "Автотранспорт":
                    {
                        return "MotorTransport";
                    }
                case "all":
                    {
                        return "all";
                    }
                default:
                    break;
            }
            return "what";
        }

        public string GetCurrentCategoryFromTypeId(int typeId)
        {
            return db.Machineries.Find(m => m.Id == typeId).FirstOrDefault().Category;
        }

        public string GetCurrentCategoryFromTypeIdEng(int typeId)
        {
            return GetCurrentCategory(GetCurrentCategoryFromTypeId(typeId));
        }

        public string GetCurrentTypeFormId(int typeId)
        {
            return db.Machineries.Get(typeId).Name;
        }



        /*public int GetCurrentType(string type)
        {
            throw new NotImplementedException();
        }*/
    }
}