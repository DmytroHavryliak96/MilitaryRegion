using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.ViewModels;
using MilitaryRegion.DAO.Interfaces;

namespace MilitaryRegion.BL.Services
{
    public class ManageMilitaryBasesService : IManageMilitaryBases
    {
        private IUnitOfWork Database;

        public ManageMilitaryBasesService (IUnitOfWork db)
        {
            Database = db;
        }

        public IEnumerable<MilitaryBaseViewModel> GetAllMilitaryBases()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MilitaryBaseViewModel> GetMilitaryBasesOfArmy(int armyId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MilitaryBaseViewModel> GetMilitaryBasesOfCorp(int corpId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MilitaryBaseViewModel> GetMilitaryBasesOfDivision(int divisionId)
        {
            throw new NotImplementedException();
        }
    }
}