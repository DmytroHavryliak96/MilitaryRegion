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
    public class ManageTechnic : IManageTechnik
    {
        private IUnitOfWork Database;
        private Func<string, IModelMapper<MilitaryBaseMachinery, TechnicViewModel>> resolver;

        public ManageTechnic(IUnitOfWork db, Func<string, IModelMapper<MilitaryBaseMachinery, TechnicViewModel>> _resolver)
        {
            Database = db;
            resolver = _resolver;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<TechnicViewModel> GetAllTechnik(string category, int typeId)
        {
            var mapper = resolver(category);
            var machineries = Database.MilitaryBaseMachineries.GetAll().ToList();
            List<TechnicViewModel> models = new List<TechnicViewModel>();

            for (int i = 0; i < machineries.Count(); i++)
            {
                machineries[i].Machinery = Database.Machineries.Get(machineries[i].MachineryId);
                machineries[i].MilitaryBase = Database.MilitaryBases.Get(machineries[i].MilitaryBaseId);
            }


            if (category.Equals("all"))
            {
                for (int i = 0; i < machineries.Count(); i++)
                    models.Add(mapper.MapModel(machineries[i], Database));

                return models;
            }
            else
            {
                List<MilitaryBaseMachinery> sortMachineries = new List<MilitaryBaseMachinery>();
                if (typeId == 0)
                {
                    sortMachineries = machineries.Where(m => m.Machinery.Category.Equals(category)).ToList();
                }
                else
                {
                    sortMachineries = machineries.Where(m => m.Machinery.Id == typeId).ToList();
                }

                for (int i = 0; i < sortMachineries.Count(); i++)
                    models.Add(mapper.MapModel(sortMachineries[i], Database));

                return models;
            }
        }

        public IEnumerable<TechnicViewModel> GetTechnikOfArmy(int armyId, string category, int typeId)
        {
            var models = GetAllTechnik(category, typeId);
            var result = models.Where(o => o.ArmyId == armyId);
            return result;
        }

        public IEnumerable<TechnicViewModel> GetTechnikOfCorp(int corpId, string category, int typeId)
        {
            var models = GetAllTechnik(category, typeId);
            var result = models.Where(o => o.CorpusId == corpId);
            return result;
        }

        public IEnumerable<TechnicViewModel> GetTechnikOfDivision(int divisionId, string category, int typeId)
        {
            var models = GetAllTechnik(category, typeId);
            var result = models.Where(o => o.DivisionId == divisionId);
            return result;
        }

        public IEnumerable<TechnicViewModel> GetTechnikOfMilitaryBase(int baseId, string category, int typeId)
        {
            var models = GetAllTechnik(category, typeId);
            var result = models.Where(o => o.MilitaryBaseId == baseId);
            return result;
        }
    }
}