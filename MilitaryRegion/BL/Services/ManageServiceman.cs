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
    public class ManageServiceman : IManageServiceman
    {
        private IUnitOfWork Database { get; set; }
        private IModelMapper<Serviceman, ServicemanViewModel> mapper;
        private IChain chain;

        public ManageServiceman(IUnitOfWork db, IModelMapper<Serviceman, ServicemanViewModel> mp, IChain _chain)
        {
            Database = db;
            mapper = mp;
            chain = _chain;
        }

        public IEnumerable<ServicemanViewModel> GetAll(int specialtyId)
        {
            List<Serviceman> servicemen = new List<Serviceman>();
            var spcialty = Database.Specialties.Get(specialtyId);
            var servicemanSpecilaties = Database.ServicemanSpecialties.Find(sp => sp.SpecialtyId == specialtyId).ToList();

            if (specialtyId == 0)
                servicemen = Database.Servicemen.GetAll().ToList();
            else
            {

                for(int i = 0; i < servicemanSpecilaties.Count(); i++)
                {
                    servicemen.Add(Database.Servicemen.Get(servicemanSpecilaties[i].ServicemanId));
                }
            }

            List<ServicemanViewModel> models = new List<ServicemanViewModel>();
            foreach (var serviceman in servicemen)
            {
                models.Add(mapper.MapModel(serviceman, Database));
            }
            return models;
        }

        public IEnumerable<ServicemanViewModel> GetServicemanOfArmy(int armyId, int specialtyId)
        {
            var models = GetAll(specialtyId);
            var result = models.Where(o => o.ArmyId == armyId);
            return result;
        }

        public IEnumerable<ServicemanViewModel> GetServicemanOfBases(int baseId, int specialtyId)
        {
            var models = GetAll(specialtyId);
            var result = models.Where(o => o.MilitaryBaseId == baseId);
            return result;
        }

        public IEnumerable<ServicemanViewModel> GetServicemanOfCorp(int corpId, int specialtyId)
        {
            var models = GetAll(specialtyId);
            var result = models.Where(o => o.CorpusId == corpId);
            return result;
        }

        public IEnumerable<ServicemanViewModel> GetServicemanOfDepartment(int departmentId, int specialtyId)
        {
            var models = GetAll(specialtyId);
            var result = models.Where(o => o.DepartmentId == departmentId);
            return result;
        }

        public IEnumerable<ServicemanViewModel> GetServicemanOfDivision(int divisionId, int specialtyId)
        {
            var models = GetAll(specialtyId);
            var result = models.Where(o => o.DivisionId == divisionId);
            return result;
        }

        public IEnumerable<ServicemanViewModel> GetServicemanOfSquad(int squadId, int specialtyId)
        {
            var models = GetAll(specialtyId);
            var result = models.Where(o => o.SquadId == squadId);
            return result;
        }

        public IEnumerable<ServicemanViewModel> GetServicemanOfTroop(int troopId, int specialtyId)
        {
            var models = GetAll(specialtyId);
            var result = models.Where(o => o.TroopId == troopId);
            return result;
        }

        public IEnumerable<Specialty> GetSpecialties()
        {
            return Database.Specialties.GetAll();
        }

        public IEnumerable<ServicemanViewModel> GetChain(int manId)
        {
            return chain.GetChain(manId);
        }
    }
}