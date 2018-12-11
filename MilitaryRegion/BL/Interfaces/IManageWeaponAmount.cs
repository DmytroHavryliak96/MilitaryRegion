using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryRegion.Models;
using MilitaryRegion.ViewModels;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IManageWeaponAmount
    {
        IEnumerable<WeaponryAmountViewModel> GetAllBases();

        IEnumerable<WeaponryAmountViewModel> GetMore10(string type);

        IEnumerable<WeaponryAmountViewModel> GetNone(string type);
    }
}
