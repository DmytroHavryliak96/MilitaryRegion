using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.Models;
using MilitaryRegion.DAO.Interfaces;

namespace MilitaryRegion.BL.Interfaces
{
    public class RegionInfo : IRegionInfo
    {
        private IUnitOfWork Database;
        
        public RegionInfo(IUnitOfWork _db)
        {
            Database = _db;
        } 

        public IEnumerable<Army> GetAllArmies()
        {
            return Database.Armies.GetAll();
        }

        public IEnumerable<Corp> GetAllCorps()
        {
            return Database.Corps.GetAll();
        }

        public IEnumerable<Division> GetAllDivisions()
        {
            return Database.Divisions.GetAll();
        }

        public IEnumerable<MilitaryBase> GetAllMilitaryBases()
        {
            return Database.MilitaryBases.GetAll();
        }

        public string GetCurrentRank(int rank)
        {
            if (rank == 0)
                return "увесь склад";
            return "звання = " + Database.Ranks.Get(rank).Name;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public int GetCurrentArmyNumber(int armyId)
        {
            return Database.Armies.Get(armyId).Number;
        }

        public int GetCurrentCorpNumber(int corpId)
        {
            return Database.Corps.Get(corpId).Number;
        }

        public string GetCurrentDivisionName(int divId)
        {
            return Database.Divisions.Get(divId).Name;
        }

        public string GetCurrentBaseName(int baseId)
        {
            return Database.MilitaryBases.Get(baseId).Name;
        }

        public string GetCurrentSpecialty(int specialtyId)
        {
            if (specialtyId == 0)
                return "усі спеціальності";
            return "спеціальність = " + Database.Specialties.Get(specialtyId).Name;
        }

        public IEnumerable<Squad> GetAllSquads()
        {
            return Database.Squads.GetAll();
        }

        public IEnumerable<Troop> GetAllTroops()
        {
            return Database.Troops.GetAll();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return Database.Departments.GetAll();
        }

        public int GetCurrentSquadNumber(int squadId)
        {
            return Database.Squads.Get(squadId).Number;
        }

        public int GetCurrentTroopNumber(int troopId)
        {
            return Database.Troops.Get(troopId).Number;
        }

        public int GetCurrentDepNumber(int depId)
        {
            return Database.Departments.Get(depId).Number;
        }

        public string GetCurrentManName(int manId)
        {
            var man = Database.Servicemen.Get(manId);
            return man.FirstName + " " + man.SecondName; 
        }
    }
}
