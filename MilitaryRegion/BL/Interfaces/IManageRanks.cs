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
    public interface IManageRanks<T>
    {
        IEnumerable<T> GetAll(int rankId);

        IEnumerable<T> GetRanksOfArmy(int armyId, int rankId);

        IEnumerable<T> GetRanksOfCorp(int corpId, int rankId);

        IEnumerable<T> GetRanksOfDivision(int divisionId, int rankId);

        IEnumerable<T> GetRanksOfBases(int baseId, int rankId);

        IEnumerable<Rank> GetRanks();

        

    }
}
