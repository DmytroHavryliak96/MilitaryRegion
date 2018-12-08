using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryRegion.Models;
using MilitaryRegion.ViewModels;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IManageMilitaryBases
    {
        IEnumerable<MilitaryBaseViewModel> GetAllMilitaryBases();

        IEnumerable<MilitaryBaseViewModel> GetMilitaryBasesOfArmy(int armyId);

        IEnumerable<MilitaryBaseViewModel> GetMilitaryBasesOfCorp(int corpId);

        IEnumerable<MilitaryBaseViewModel> GetMilitaryBasesOfDivision(int divisionId);

        IEnumerable<Army> GetAllArmies();

        IEnumerable<Corp> GetAllCorps();

        IEnumerable<Division> GetAllDivisions();

    }
}
