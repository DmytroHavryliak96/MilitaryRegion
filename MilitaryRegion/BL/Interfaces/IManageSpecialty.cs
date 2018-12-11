using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryRegion.ViewModels;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IManageSpecialty
    {
        IEnumerable<SpecialtyViewModel> GetAll();

        IEnumerable<SpecialtyViewModel> GetArmy(int armyId);

        IEnumerable<SpecialtyViewModel> GetCorp(int corpId);

        IEnumerable<SpecialtyViewModel> GetDiv(int divId);

        IEnumerable<SpecialtyViewModel> GetBase(int baseId);

        void Dispose();
    }
}
