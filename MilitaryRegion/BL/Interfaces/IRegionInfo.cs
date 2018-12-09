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

        IEnumerable<Squad> GetAllSquads();

        IEnumerable<Troop> GetAllTroops();

        IEnumerable<Department> GetAllDepartments();

        string GetCurrentRank(int rank);

        string GetCurrentSpecialty(int specialtyId);

        int GetCurrentArmyNumber(int armyId);

        int GetCurrentCorpNumber(int corpId);

        string GetCurrentDivisionName (int divId);

        string GetCurrentBaseName(int baseId);

        int GetCurrentSquadNumber(int squadId);

        int GetCurrentTroopNumber(int troopId);

        int GetCurrentDepNumber(int depId);

        void Dispose();



    }
}
