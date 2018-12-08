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

       /* IEnumerable<OfficerViewModel> GetRankOfficers();

        IEnumerable<OfficerViewModel> GetRankOfficersArmy(int armyId);

        IEnumerable<OfficerViewModel> GetRankOfficersCorp(int corpId);

        IEnumerable<OfficerViewModel> GetRankOfficersDivision(int divisionId);*/

        IEnumerable<Army> GetAllArmies();

        IEnumerable<Corp> GetAllCorps();

        IEnumerable<Division> GetAllDivisions();

        IEnumerable<Rank> GetOfficersRanks();


    }
}
