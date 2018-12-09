using MilitaryRegion.Models;
using MilitaryRegion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IChain
    {
        IEnumerable<ServicemanViewModel> GetChain(int manId);

        /*Serviceman GetDepartmentCommander(int depId);

        Serviceman GetTroopCommander(int troopId);

        Serviceman GetSquadCommander(int squadId);

        Serviceman GetMilitaryBaseCommander(int baseId);

        Serviceman GetDivisionCommander(int divId);

        Serviceman GetCorpCommander(int corpId);

        Serviceman GetArmyCommander(int armyId);*/

        ServicemanViewModel MapChainModel(Serviceman baseModel);

        void Dispose();

    }
}
