using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryRegion.DAO.Interfaces;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IModelMapper<T,U>
    {
        U MapModel(T baseModel, IUnitOfWork db);
    }
}
