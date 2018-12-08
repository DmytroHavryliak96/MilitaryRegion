using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.ViewModels;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;
using MilitaryRegion.BL.Services.Mappers;

namespace MilitaryRegion.BL.Services
{
    public class ManageMilitaryBasesService : IManageMilitaryBases
    {
        private IUnitOfWork Database;
        private IModelMapper<MilitaryBase, MilitaryBaseViewModel> mapper;

        public ManageMilitaryBasesService (IUnitOfWork db, IModelMapper<MilitaryBase, MilitaryBaseViewModel> mp)
        {
            Database = db;
            mapper = mp;
        }

        public IEnumerable<MilitaryBaseViewModel> GetAllMilitaryBases()
        {
            var bases = Database.MilitaryBases.GetAll();
            List<MilitaryBaseViewModel> models = new List<MilitaryBaseViewModel>();
            foreach(var mbase in bases)
            {
                models.Add(mapper.MapModel(mbase, Database));
            }
            return models;
        }

        public IEnumerable<MilitaryBaseViewModel> GetMilitaryBasesOfArmy(int armyId)
        {
            var models = GetAllMilitaryBases();
            var result = models.Where(model => model.ArmyId == armyId);
            return result;
        }

        public IEnumerable<MilitaryBaseViewModel> GetMilitaryBasesOfCorp(int corpId)
        {
            var models = GetAllMilitaryBases();
            var result = models.Where(model => model.CorpusId == corpId);
            return result;
        }

        public IEnumerable<MilitaryBaseViewModel> GetMilitaryBasesOfDivision(int divisionId)
        {
            var models = GetAllMilitaryBases();
            var result = models.Where(model => model.DivisionId == divisionId);
            return result;
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
    }
}