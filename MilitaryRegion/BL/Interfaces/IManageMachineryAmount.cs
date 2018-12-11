using MilitaryRegion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IManageMachineryAmount
    {
        IEnumerable<MachineryAmountViewModel> GetAllBases();

        IEnumerable<MachineryAmountViewModel> GetMore5(string type);

        IEnumerable<MachineryAmountViewModel> GetNone(string type);
    }
}
