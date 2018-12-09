using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.Models;
using MilitaryRegion.ViewModels;
using MilitaryRegion.DAO.Interfaces;

namespace MilitaryRegion.BL.Services.Mappers
{
    public class ServicemanMapper : IModelMapper<Serviceman, ServicemanViewModel>
    {
        public ServicemanViewModel MapModel(Serviceman baseModel, IUnitOfWork db)
        {
            var specialties = db.ServicemanSpecialties.Find(sp => sp.ServicemanId == baseModel.Id).ToList();
            string specialtyString = "";

            foreach (var specialty in specialties)
            {
                specialtyString += db.Specialties.Find(s => s.Id == specialty.SpecialtyId).FirstOrDefault().Name + ", ";
            }

            var department = db.Departments.Get(baseModel.DepartmentId);
            var troop = db.Troops.Get(baseModel.TroopId);
            var squad = db.Squads.Get(baseModel.SquadId);
            var militaryBase = db.MilitaryBases.Get(baseModel.MilitaryBaseId);
            var division = db.Divisions.Get(baseModel.DivisionId);
            var corp = db.Corps.Get(baseModel.CorpId);
            var army = db.Armies.Get(baseModel.ArmyId);
            var rank = db.Ranks.Get(baseModel.RankId);

            var servicemanViewModel = new ServicemanViewModel
            {
                ServicemanId = baseModel.Id,
                Name = baseModel.FirstName + " " + baseModel.SecondName,

                DateOfBirth = baseModel.DateOfBirth,
                RankName = rank.Name,

                SpecialtyName = specialtyString
            };

            if (army != null)
            {
                servicemanViewModel.ArmyId = army.Id;
                servicemanViewModel.ArmyNumber = army.Number;
            }

            if (corp != null)
            {
                servicemanViewModel.CorpusId = corp.Id;
                servicemanViewModel.CorpusNumber = corp.Number;
            }

            if (division != null)
            {
                servicemanViewModel.DivisionId = division.Id;
                servicemanViewModel.DivisionName = division.Name;
            }

            if (militaryBase != null)
            {
                servicemanViewModel.MilitaryBaseId = militaryBase.Id;
                servicemanViewModel.MilitaryBaseName = militaryBase.Name;
            }

            if (squad != null)
            {
                servicemanViewModel.SquadId = squad.Id;
                servicemanViewModel.SquadNumber = squad.Number;
            }

            if (troop != null)
            {
                servicemanViewModel.TroopId = troop.Id;
                servicemanViewModel.TroopNumber = troop.Number;
            }

            if (department != null)
            {
                servicemanViewModel.DepartmentId = department.Id;
                servicemanViewModel.DepartmnetNumber = department.Number;
            }

            return servicemanViewModel;
        }
    }
}