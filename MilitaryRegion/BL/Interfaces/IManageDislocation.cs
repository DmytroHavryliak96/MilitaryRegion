using MilitaryRegion.Models;
using MilitaryRegion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IManageDislocation
    {
        IEnumerable<Dislocation> GetAll();

        IEnumerable<Dislocation> GetArmyDis(int armyId);

        IEnumerable<Dislocation> GetCorpDis(int corpId);

        IEnumerable<Dislocation> GetDivDis(int divisionId);

        IEnumerable<Dislocation> GetBaseDis(int baseId);

        void Dispose();
    }
}