using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.ViewModels;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.DAO.Interfaces;

namespace MilitaryRegion.BL.Services
{
    public class ManageBaseAmount : IManageBaseAmount
    {
        private IUnitOfWork db;

        public ManageBaseAmount(IUnitOfWork _db)
        {
            db = _db;
        }

        public IEnumerable<BaseAmountViewModel> GetArmy()
        {
            var bases = db.MilitaryBases.GetAll().ToList();
            for (int i = 0; i< bases.Count(); i++)
            {
                bases[i].Division = db.Divisions.Get(bases[i].DivisionId);
                bases[i].Division.Corp = db.Corps.Get(bases[i].Division.CorpId);
                bases[i].Division.Corp.Army = db.Armies.Get(bases[i].Division.Corp.ArmyId);
            }

            var result = bases.GroupBy(b => b.Division.Corp.Army.Number, b => b.Id, (key, g) => new { ArmyNumber = key, BaseCount = g.Count() });

            var maxCount = result.Max(r => r.BaseCount);
            var minCount = result.Min(r => r.BaseCount);

            var maxRes = result.Where(r => r.BaseCount == maxCount);
            var minRes = result.Where(r => r.BaseCount == minCount);

            List<BaseAmountViewModel> list = new List<BaseAmountViewModel>();

            foreach (var item in maxRes)
            {
                list.Add(new BaseAmountViewModel { Unit = "Максимальна кількість. Армія = " + item.ArmyNumber, BaseAmount = item.BaseCount });
            }

            foreach (var item in minRes)
            {
                list.Add(new BaseAmountViewModel { Unit = "Мінімальна кількість. Армія = " + item.ArmyNumber, BaseAmount = item.BaseCount });
            }

            return list;

        }

        public IEnumerable<BaseAmountViewModel> GetCorp()
        {
            var bases = db.MilitaryBases.GetAll().ToList();
            for (int i = 0; i < bases.Count(); i++)
            {
                bases[i].Division = db.Divisions.Get(bases[i].DivisionId);
                bases[i].Division.Corp = db.Corps.Get(bases[i].Division.CorpId);
            }

            var result = bases.GroupBy(b => b.Division.Corp.Number, b => b.Id, (key, g) => new { CorpNumber = key, BaseCount = g.Count() });

            var maxCount = result.Max(r => r.BaseCount);
            var minCount = result.Min(r => r.BaseCount);

            var maxRes = result.Where(r => r.BaseCount == maxCount);
            var minRes = result.Where(r => r.BaseCount == minCount);

            List<BaseAmountViewModel> list = new List<BaseAmountViewModel>();

            foreach (var item in maxRes)
            {
                list.Add(new BaseAmountViewModel { Unit = "Максимальна кількість. Корпус = " + item.CorpNumber, BaseAmount = item.BaseCount });
            }

            foreach (var item in minRes)
            {
                list.Add(new BaseAmountViewModel { Unit = "Мінімальна кількість. Корпус = " + item.CorpNumber, BaseAmount = item.BaseCount });
            }

            return list;
        }

        public IEnumerable<BaseAmountViewModel> GetDivision()
        {
            var bases = db.MilitaryBases.GetAll().ToList();
            for (int i = 0; i < bases.Count(); i++)
            {
                bases[i].Division = db.Divisions.Get(bases[i].DivisionId);
            }

            var result = bases.GroupBy(b => b.Division.Name, b => b.Id, (key, g) => new { DivisionName = key, BaseCount = g.Count() });

            var maxCount = result.Max(r => r.BaseCount);
            var minCount = result.Min(r => r.BaseCount);

            var maxRes = result.Where(r => r.BaseCount == maxCount);
            var minRes = result.Where(r => r.BaseCount == minCount);

            List<BaseAmountViewModel> list = new List<BaseAmountViewModel>();

            foreach (var item in maxRes)
            {
                list.Add(new BaseAmountViewModel { Unit = "Максимальна кількість. Дивізія = " + item.DivisionName, BaseAmount = item.BaseCount });
            }

            foreach (var item in minRes)
            {
                list.Add(new BaseAmountViewModel { Unit = "Мінімальна кількість. Дивізія = " + item.DivisionName, BaseAmount = item.BaseCount });
            }

            return list;
        }
    }
}