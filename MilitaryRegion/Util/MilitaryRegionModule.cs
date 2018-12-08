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
            Bind<IManageOfficers>().To<ManageOfficersService>();
            Bind<IModelMapper<MilitaryBase, MilitaryBaseViewModel>>().To<MilitaryBaseMapper>();
            Bind<IModelMapper<Officer, OfficerViewModel>>().To<OfficerMapper>();


        }
    }
}