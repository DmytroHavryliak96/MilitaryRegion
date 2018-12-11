using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.ViewModels;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.DAO.Interfaces;

namespace MilitaryRegion.BL.Services
{
    public class ManageSpecialty : IManageSpecialty
    {
        private IUnitOfWork db;
        private IRegionInfo info;

        public ManageSpecialty(IUnitOfWork _db, IRegionInfo _info)
        {
            db = _db;
            info = _info;
        }

        public void Dispose()
        {
            db.Dispose();
            info.Dispose();
        }

        public IEnumerable<SpecialtyViewModel> GetAll()
        {
            var spec = db.ServicemanSpecialties.GetAll().ToList();
            for(int i = 0; i < spec.Count(); i++)
            {
                spec[i].Serviceman = db.Servicemen.Get(spec[i].ServicemanId);
                spec[i].Specialty = db.Specialties.Get(spec[i].SpecialtyId);
            }

            var result = spec.GroupBy(sp => sp.Specialty.Name, sp => sp.ServicemanId, (key, g) => new { Specialty = key, Amount = g.Count() });

            List<SpecialtyViewModel> list = new List<SpecialtyViewModel>();

            foreach(var item in result)
            {
                if(item.Amount >= 4)
                {
                    list.Add(Map(item.Specialty, item.Amount, "весь округ"));
                }
            }
            return list;
        }

        public IEnumerable<SpecialtyViewModel> GetArmy(int armyId)
        {
            var spec = db.ServicemanSpecialties.GetAll().ToList();
            for (int i = 0; i < spec.Count(); i++)
            {
                spec[i].Serviceman = db.Servicemen.Get(spec[i].ServicemanId);
                spec[i].Specialty = db.Specialties.Get(spec[i].SpecialtyId);
            }

            var result = spec.Where(s => s.Serviceman.ArmyId == armyId).GroupBy(
                sp => sp.Specialty.Name, sp => sp.ServicemanId, (key, g) => new { Specialty = key, Amount = g.Count() });

            List<SpecialtyViewModel> list = new List<SpecialtyViewModel>();

            var specAll = db.Specialties.GetAll().ToList();

            foreach (var item in result)
            {
                specAll.RemoveAll(sp => sp.Name == item.Specialty);

                if (item.Amount >= 2)
                {
                    list.Add(Map(item.Specialty, item.Amount, "Армія = " + info.GetCurrentArmyNumber(armyId).ToString()));
                }
            }

            foreach(var item in specAll)
            {
                list.Add(Map(item.Name, 0, "Армія = " + info.GetCurrentArmyNumber(armyId).ToString()));
            }
           

            return list;
        }

        public IEnumerable<SpecialtyViewModel> GetBase(int baseId)
        {
            var spec = db.ServicemanSpecialties.GetAll().ToList();
            for (int i = 0; i < spec.Count(); i++)
            {
                spec[i].Serviceman = db.Servicemen.Get(spec[i].ServicemanId);
                spec[i].Specialty = db.Specialties.Get(spec[i].SpecialtyId);
            }

            var result = spec.Where(s => s.Serviceman.MilitaryBaseId == baseId).GroupBy(
                sp => sp.Specialty.Name, sp => sp.ServicemanId, (key, g) => new { Specialty = key, Amount = g.Count() });

            List<SpecialtyViewModel> list = new List<SpecialtyViewModel>();

            var specAll = db.Specialties.GetAll().ToList();

            foreach (var item in result)
            {
                specAll.RemoveAll(sp => sp.Name == item.Specialty);

                if (item.Amount >= 2)
                {
                    list.Add(Map(item.Specialty, item.Amount, "Військова частина = " + info.GetCurrentBaseName(baseId)));
                }
            }

            foreach (var item in specAll)
            {
                list.Add(Map(item.Name, 0, "Військова частина = " + info.GetCurrentBaseName(baseId)));
            }


            return list;
        }

        public IEnumerable<SpecialtyViewModel> GetCorp(int corpId)
        {
            var spec = db.ServicemanSpecialties.GetAll().ToList();
            for (int i = 0; i < spec.Count(); i++)
            {
                spec[i].Serviceman = db.Servicemen.Get(spec[i].ServicemanId);
                spec[i].Specialty = db.Specialties.Get(spec[i].SpecialtyId);
            }

            var result = spec.Where(s => s.Serviceman.CorpId == corpId).GroupBy(
                sp => sp.Specialty.Name, sp => sp.ServicemanId, (key, g) => new { Specialty = key, Amount = g.Count() });

            List<SpecialtyViewModel> list = new List<SpecialtyViewModel>();

            var specAll = db.Specialties.GetAll().ToList();

            foreach (var item in result)
            {
                specAll.RemoveAll(sp => sp.Name == item.Specialty);

                if (item.Amount >= 2)
                {
                    list.Add(Map(item.Specialty, item.Amount, "Корпус = " + info.GetCurrentCorpNumber(corpId)));
                }
            }

            foreach (var item in specAll)
            {
                list.Add(Map(item.Name, 0, "Корпус = " + info.GetCurrentCorpNumber(corpId)));
            }


            return list;
        }

        public IEnumerable<SpecialtyViewModel> GetDiv(int divId)
        {
            var spec = db.ServicemanSpecialties.GetAll().ToList();
            for (int i = 0; i < spec.Count(); i++)
            {
                spec[i].Serviceman = db.Servicemen.Get(spec[i].ServicemanId);
                spec[i].Specialty = db.Specialties.Get(spec[i].SpecialtyId);
            }

            var result = spec.Where(s => s.Serviceman.DivisionId == divId).GroupBy(
                sp => sp.Specialty.Name, sp => sp.ServicemanId, (key, g) => new { Specialty = key, Amount = g.Count() });

            List<SpecialtyViewModel> list = new List<SpecialtyViewModel>();

            var specAll = db.Specialties.GetAll().ToList();

            foreach (var item in result)
            {
                specAll.RemoveAll(sp => sp.Name == item.Specialty);

                if (item.Amount >= 2)
                {
                    list.Add(Map(item.Specialty, item.Amount, "Дивізія = " + info.GetCurrentDivisionName(divId)));
                }
            }

            foreach (var item in specAll)
            {
                list.Add(Map(item.Name, 0, "Дивізія = " + info.GetCurrentDivisionName(divId)));
            }


            return list;
        }

        private SpecialtyViewModel Map(string Specialty, int amount, string Unit)
        {
            var model = new SpecialtyViewModel
            {
                Specialty = Specialty,
                Amount = amount,
                Unit = Unit
            };
            return model;
        }
    }
}