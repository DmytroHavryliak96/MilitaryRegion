using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.ViewModels;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IManageSoldiers
    {
        IEnumerable<SoldierViewModel> GetAllSoldiers(int rankId);

        IEnumerable<SoldierViewModel> GetSoldiersOfArmy(int armyId, int rankId);

        IEnumerable<SoldierViewModel> GetSoldiersOfCorp(int corpId, int rankId);

        IEnumerable<SoldierViewModel> GetSoldiersOfDivision(int divisionId, int rankId);

        IEnumerable<SoldierViewModel> GetSoldiersOfBases(int baseId, int rankId);


        IEnumerable<Army> GetAllArmies();

        IEnumerable<Corp> GetAllCorps();

        IEnumerable<Division> GetAllDivisions();

        IEnumerable<MilitaryBase> GetAllMilitaryBases();

        IEnumerable<Rank> GetSoldierRanks();

        string GetCurrentRank(int rank);
    }
}
