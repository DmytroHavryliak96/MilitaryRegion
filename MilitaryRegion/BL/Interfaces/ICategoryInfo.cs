using MilitaryRegion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryRegion.BL.Interfaces
{
    public interface ICategoryInfo
    {
        /*int GetCurrentCategory(string category);

        int GetCurrentType(string type);*/

        IEnumerable<Machinery> GetAllCategories();

        IEnumerable<Machinery> GetAllTypes();

        string GetCurrentCategoryFromTypeId(int typeId);

        string GetCurrentCategoryFromTypeIdEng(int typeId);

        string GetCurrentCategory(string category);

        string GetCurrentTypeFormId(int typeId);

        void Dispose();
    }
}
