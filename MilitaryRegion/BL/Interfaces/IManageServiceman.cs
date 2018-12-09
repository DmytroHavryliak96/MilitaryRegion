using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.ViewModels;
using MilitaryRegion.DAO.Interfaces;
using MilitaryRegion.Models;

namespace MilitaryRegion.BL.Interfaces
{
    public interface IManageServiceman
    {
        IEnumerable<ServicemanViewModel> GetAll(int specilaltyId);

        IEnumerable<ServicemanViewModel> GetServicemanOfArmy(int armyId, int specialtyId);

        IEnumerable<ServicemanViewModel> GetServicemanOfCorp(int corpId, int specialtyId);

        IEnumerable<ServicemanViewModel> GetServicemanOfDivision(int divisionId, int specialtyId);

        IEnumerable<ServicemanViewModel> GetServicemanOfBases(int baseId, int specialtyId);

        IEnumerable<ServicemanViewModel> GetServicemanOfSquad(int squadId, int specialtyId);

        IEnumerable<ServicemanViewModel> GetServicemanOfTroop(int troopId, int specialtyId);

        IEnumerable<ServicemanViewModel> GetServicemanOfDepartment(int departmentId, int specialtyId);

        IEnumerable<Specialty> GetSpecialties();

        IEnumerable<ServicemanViewModel> GetChain(int manId);


    }
}