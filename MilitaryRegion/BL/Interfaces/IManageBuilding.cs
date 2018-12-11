using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.Models;
using MilitaryRegion.ViewModels;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IManageBuilding
    {
        IEnumerable<BuildingViewModel> GetAllBuildings();

        IEnumerable<BuildingViewModel> GetBuildingsOfBase(int baseId);

        IEnumerable<BuildingViewModel> GetBuildingsFlag(int flag);
    }
}