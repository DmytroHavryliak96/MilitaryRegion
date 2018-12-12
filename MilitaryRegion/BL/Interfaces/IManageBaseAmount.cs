using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryRegion.ViewModels;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IManageBaseAmount
    {
        IEnumerable<BaseAmountViewModel> GetArmy();

        IEnumerable<BaseAmountViewModel> GetCorp();

        IEnumerable<BaseAmountViewModel> GetDivision(); 
    }
}
