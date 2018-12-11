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
    public class ManageBuilding : IManageBuilding
    {
        private IUnitOfWork Database;

        public ManageBuilding(IUnitOfWork db)
        {
            Database = db;
        }

        public IEnumerable<BuildingViewModel> GetAllBuildings()
        {
            var buildings = Database.MilitaryBaseBuildings.GetAll().ToList();
            for (int i = 0; i < buildings.Count(); i++)
                buildings[i].Building = Database.Buildings.Get(buildings[i].BuildingId);

            List<BuildingViewModel> models = new List<BuildingViewModel>();

            for(int i = 0; i < buildings.Count(); i++)
                models.Add(MapOrdinaryBuilding(buildings[i]));

            return models;
            
        }

        public IEnumerable<BuildingViewModel> GetBuildingsFlag(int flag)
        {
            List<BuildingViewModel> list = new List<BuildingViewModel>();
             
            var buildings = Database.MilitaryBaseBuildings.GetAll().ToList();
            for (int i = 0; i < buildings.Count(); i++)
                buildings[i].Building = Database.Buildings.Get(buildings[i].BuildingId);

            if (flag == 1)
            {
                var predicate = buildings.Where(b => b.Building.Purpose.Equals("Житлова будівля") && b.SquadId != 0).ToList();
                var result = predicate.GroupBy(b => b.BuildingId).Select(g => g.FirstOrDefault());

                foreach(var item in result)
                {
                    var amount = Database.MilitaryBaseBuildings.Find(b => b.BuildingId == item.BuildingId).Count();
                    if (amount > 1)
                    {
                        /*var building = Database.MilitaryBaseBuildings.Get(item.Id);
                        building.Building = Database.Buildings.Get(building.BuildingId);*/
                        list.Add(MapBuilding(item, amount));
                    }
                }

            }
            else
            {
                var predicate = buildings.Where(b => b.Building.Purpose.Equals("Житлова будівля") == false).ToList();

                var result = predicate.GroupBy(b => b.Id).Select(g => g.FirstOrDefault());

                foreach (var item in result)
                {
                    list.Add(MapBuilding(item, 0));
                }
            }

            return list;
        }

        public IEnumerable<BuildingViewModel> GetBuildingsOfBase(int baseId)
        {
            var models = GetAllBuildings();
            var result = models.Where(m => m.MilitaryBaseId == baseId);
            return result;
        }

        private BuildingViewModel MapOrdinaryBuilding(MilitaryBaseBuilding baseModel)
        {
            var building = baseModel.Building;
            var militaryBase = Database.MilitaryBases.Get(baseModel.MilitaryBaseId);
            var squad = Database.Squads.Get(baseModel.SquadId);
            var troop = Database.Troops.Get(baseModel.TroopId);
            var dep = Database.Departments.Get(baseModel.DepartmentId);

            var model = new BuildingViewModel
            {
                Id = baseModel.Id,

                Square = building.Square,
                Height = building.Height,
                Purpose = building.Purpose,
                FloorAmount = building.FloorAmount,

                MilitaryBaseId = militaryBase.Id,
                MilitaryBaseName = militaryBase.Name,

            };

            if (squad != null)
            {
                model.SquadId = squad.Id;
                model.SquadNumber = squad.Number;
            }

            if (troop != null)
            {
                model.TroopId = troop.Id;
                model.TroopNumber = troop.Number;
            }

            if (dep != null)
            {
                model.DepartmentId = dep.Id;
                model.DepartmnetNumber = dep.Number;
            }

            return model;
        }
        
        private BuildingViewModel MapBuilding(MilitaryBaseBuilding baseModel, int amount)
        {
            var building = baseModel.Building;
            var militaryBase = Database.MilitaryBases.Get(baseModel.MilitaryBaseId);

            var model = new BuildingViewModel
            {
                Id = building.Id,

                Square = building.Square,
                Height = building.Height,
                Purpose = building.Purpose,
                FloorAmount = building.FloorAmount,

                MilitaryBaseId = militaryBase.Id,
                MilitaryBaseName = militaryBase.Name,

                UnitsAmount = amount
            };

            return model;
        }
    }
}