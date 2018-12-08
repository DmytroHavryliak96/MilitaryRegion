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
    public interface IManageOfficers
    {
        IEnumerable<OfficerViewModel> GetAllOfficers(int rankId);

        IEnumerable<OfficerViewModel> GetOfficersOfArmy(int armyId, int rankId);

        IEnumerable<OfficerViewModel> GetOfficersOfCorp(int corpId, int rankId);

        IEnumerable<OfficerViewModel> GetOfficersOfDivision(int divisionId, int rankId);

        IEnumerable<OfficerViewModel> GetOfficersOfBases(int baseId, int rankId);


        IEnumerable<Army> GetAllArmies();

        IEnumerable<Corp> GetAllCorps();

        IEnumerable<Division> GetAllDivisions();

        IEnumerable<MilitaryBase> GetAllMilitaryBases();

        IEnumerable<Rank> GetOfficersRanks();

        string GetCurrentRank(int rank);


    }
}
