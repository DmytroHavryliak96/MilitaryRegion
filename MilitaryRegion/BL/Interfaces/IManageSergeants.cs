using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryRegion.ViewModels;
using MilitaryRegion.Models;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IManageSergeants
    {
        IEnumerable<SergeantViewModel> GetAllSergeants(int rankId);

        IEnumerable<SergeantViewModel> GetSergeantsOfArmy(int armyId, int rankId);

        IEnumerable<SergeantViewModel> GetSergeantsOfCorp(int corpId, int rankId);

        IEnumerable<SergeantViewModel> GetSergeantsOfDivision(int divisionId, int rankId);

        IEnumerable<SergeantViewModel> GetSergeantsOfBases(int baseId, int rankId);


        IEnumerable<Army> GetAllArmies();

        IEnumerable<Corp> GetAllCorps();

        IEnumerable<Division> GetAllDivisions();

        IEnumerable<MilitaryBase> GetAllMilitaryBases();

        IEnumerable<Rank> GetSergeantRanks();

        string GetCurrentRank(int rank);
    }
}
