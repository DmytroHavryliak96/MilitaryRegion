using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryRegion.Models;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IRegionInfo
    {
        IEnumerable<Army> GetAllArmies();

        IEnumerable<Corp> GetAllCorps();

        IEnumerable<Division> GetAllDivisions();

        IEnumerable<MilitaryBase> GetAllMilitaryBases();

        string GetCurrentRank(int rank);

        int GetCurrentArmyNumber(int armyId);

        int GetCurrentCorpNumber(int corpId);

        string GetCurrentDivisionName (int divId);

        string GetCurrentBaseName(int baseId);

        void Dispose();



    }
}
