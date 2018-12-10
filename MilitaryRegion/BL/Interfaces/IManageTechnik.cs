using MilitaryRegion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IManageTechnik 
    {
        IEnumerable<TechnicViewModel> GetAllTechnik(string category, int typeId);

        IEnumerable<TechnicViewModel> GetTechnikOfArmy(int armyId, string category, int typeId);

        IEnumerable<TechnicViewModel> GetTechnikOfCorp(int corpId, string category, int typeId);

        IEnumerable<TechnicViewModel> GetTechnikOfDivision(int divisionId, string category, int typeId);

        IEnumerable<TechnicViewModel> GetTechnikOfMilitaryBase(int baseId, string category, int typeId);

        void Dispose();
    }
}
