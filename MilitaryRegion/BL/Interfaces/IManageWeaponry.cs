using MilitaryRegion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IManageWeaponry
    {
        IEnumerable<WeaponryViewModel> GetAllWeaponry(string category, string type);

        IEnumerable<WeaponryViewModel> GetWeaponryOfArmy(int armyId, string category, string type);

        IEnumerable<WeaponryViewModel> GetWeaponryOfCorp(int corpId, string category, string type);

        IEnumerable<WeaponryViewModel> GetWeaponryOfDivision(int divisionId, string category, string type);

        IEnumerable<WeaponryViewModel> GetWeaponryOfMilitaryBase(int baseId, string category, string type);

        void Dispose();
    }
}