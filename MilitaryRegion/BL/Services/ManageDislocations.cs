using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.ViewModels;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;


namespace MilitaryRegion.BL.Services
{
    public class ManageDislocations : IManageDislocation
    {
        private IUnitOfWork Database;

        public ManageDislocations(IUnitOfWork ui)
        {
            Database = ui;
        }

        public IEnumerable<Dislocation> GetArmyDis(int armyId)
        {
            var army = Database.Armies.Get(armyId);
            var division = Database.Corps.Get(army.Id);
            var bases = Database.MilitaryBases.Find(b => b.DivisionId == division.Id).ToList();
            return Map(bases);
        }

        private IEnumerable<Dislocation> Map(List<MilitaryBase> bases)
        {
            for (int i = 0; i < bases.Count(); i++)
                bases[i].Dislocation = Database.Dislocations.Get(bases[i].DislocationId);

            var list = bases.GroupBy(b => b.Dislocation.City).Select(g => g.FirstOrDefault()).ToList();

            List<Dislocation> dislocations = new List<Dislocation>();

            foreach (var baseItem in list)
            {
                dislocations.Add(Database.Dislocations.Get(baseItem.DislocationId));
            }
            return dislocations;
        }

        public IEnumerable<Dislocation> GetAll()
        {
            var bases = Database.MilitaryBases.GetAll().ToList();
            return Map(bases);
            
        }

        public IEnumerable<Dislocation> GetBaseDis(int baseId)
        {
            var bases = Database.MilitaryBases.Find(b => b.Id == baseId).ToList();
            return Map(bases);
        }

        public IEnumerable<Dislocation> GetCorpDis(int corpId)
        {
            var division = Database.Corps.Get(corpId);
            var bases = Database.MilitaryBases.Find(b => b.DivisionId == division.Id).ToList();
            return Map(bases);

        }

        public IEnumerable<Dislocation> GetDivDis(int divisionId)
        {
            var bases = Database.MilitaryBases.Find(b => b.DivisionId == divisionId).ToList();
            return Map(bases);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}