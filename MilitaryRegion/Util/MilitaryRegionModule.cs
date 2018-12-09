using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.DAO.Repositories;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.Models;
using MilitaryRegion.ViewModels;
using MilitaryRegion.BL.Services.Mappers;
using MilitaryRegion.BL.Services;

namespace MilitaryRegion.Util
{
    public class MilitaryRegionModule : NinjectModule
    {
        private string connectionString;

        public MilitaryRegionModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
            Bind<IManageMilitaryBases>().To<ManageMilitaryBasesService>();
            Bind<IManageRanks<OfficerViewModel>>().To<ManageOfficersService>();
            Bind<IManageRanks<SergeantViewModel>>().To<ManageSergeantsService>();
            Bind<IManageRanks<SoldierViewModel>>().To<ManageSoldiersService>();
            Bind<IRegionInfo>().To<RegionInfo>();
            Bind<IModelMapper<MilitaryBase, MilitaryBaseViewModel>>().To<MilitaryBaseMapper>();
            Bind<IModelMapper<Officer, OfficerViewModel>>().To<OfficerMapper>();
            Bind<IModelMapper<Sergeant, SergeantViewModel>>().To<SergeantMapper>();
            Bind<IModelMapper<Soldier, SoldierViewModel>>().To<SoldierMapper>();


        }
    }
}