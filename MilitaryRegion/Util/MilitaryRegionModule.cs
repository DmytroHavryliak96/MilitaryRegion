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
            Bind<IManageServiceman>().To<ManageServiceman>();
            Bind<IManageDislocation>().To<ManageDislocations>();
            Bind<IManageTechnik>().To<ManageTechnic>();

            Bind<IChain>().To<Chain>();
            Bind<IRegionInfo>().To<RegionInfo>();
            Bind<ICategoryInfo>().To<CategoryInfo>();

            Bind<IModelMapper<MilitaryBase, MilitaryBaseViewModel>>().To<MilitaryBaseMapper>();
            Bind<IModelMapper<Officer, OfficerViewModel>>().To<OfficerMapper>();
            Bind<IModelMapper<Sergeant, SergeantViewModel>>().To<SergeantMapper>();
            Bind<IModelMapper<Soldier, SoldierViewModel>>().To<SoldierMapper>();
            Bind<IModelMapper<Serviceman, ServicemanViewModel>>().To<ServicemanMapper>();

            Bind<Func<string, IModelMapper<MilitaryBaseMachinery, TechnicViewModel>>>().ToMethod(
               context =>
               {
                   return (category =>
                   {
                       switch (category)
                       {
                           case "all":
                               return new TechnicMapper();
                           case "БМП":
                               return new BMPMapper();
                           case "Автотранспорт":
                               return new MotorTransportMapper();
                           case "Тягач":
                               return new TractorMapper();
                           default:
                               throw new ArgumentException("cannot find specified category of technic");
                       }
                   }
                   );
               });

         /*   Bind<Func<int, IUnitOfWork, IModelMapper<Machinery, TechnicViewModel>>>().ToMethod(
               context =>
               {
                   return ((type, db) =>
                   {
                       var machineries = db.Machineries.Find(m => m.Id == );
                       var category = 
                       switch (category)
                       {
                           case "all":
                               return new TechnicMapper();
                           case "БМП":
                               return new TechnicMapper();
                           case "Автотранспорт":
                               return new TechnicMapper();
                           case "Тягач":
                               return new TechnicMapper();
                           default:
                               throw new ArgumentException("cannot find specified category of technic");
                       }
                   }
                   );
               });*/

        }
    }
}