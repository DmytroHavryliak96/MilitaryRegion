using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryRegion.Models;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IWeaponInfo
    {
        IEnumerable<Weaponry> GetAllCategories();

        IEnumerable<Weaponry> GetAllTypes();

        string GetCurrentCategoryFromType(string type);

        string GetCurrentCategoryFromTypeEng(string type);

        string GetCurrentCategory(string category);

        void Dispose();
    }
}
