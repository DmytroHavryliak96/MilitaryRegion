using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MilitaryRegion.Models;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.ViewModels;
using MilitaryRegion.DAO.Interfaces;

namespace MilitaryRegion.BL.Services.Mappers
{
    public class ManageMachineryAmount : IManageMachineryAmount
    {
        private IUnitOfWork db;

        public ManageMachineryAmount(IUnitOfWork _db)
        {
            db = _db;
        }

        public IEnumerable<MachineryAmountViewModel> GetAllBases()
        {
            var machineries = db.MilitaryBaseMachineries.GetAll().ToList();
            List<MachineryAmountViewModel> list = new List<MachineryAmountViewModel>();

            for (int i = 0; i < machineries.Count(); i++)
            {
                machineries[i].MilitaryBase = db.MilitaryBases.Get(machineries[i].MilitaryBaseId);
                machineries[i].Machinery = db.Machineries.Get(machineries[i].MachineryId);
                list.Add(MapModel(machineries[i], machineries[i].Amount));
            }

            return list;
        }

        public IEnumerable<MachineryAmountViewModel> GetMore5(string type)
        {
            var machineries = db.MilitaryBaseMachineries.GetAll().ToList();

            for (int i = 0; i < machineries.Count(); i++)
            {
                machineries[i].MilitaryBase = db.MilitaryBases.Get(machineries[i].MilitaryBaseId);
                machineries[i].Machinery = db.Machineries.Get(machineries[i].MachineryId);
            }

            var result = machineries.Where(w => w.Machinery.Name.Equals(type)).GroupBy(wp => wp.MilitaryBaseId,
                wp => wp.Amount, (key, g) => new { BaseId = key, Amount = g.ToList().Sum() });


            List<MachineryAmountViewModel> list = new List<MachineryAmountViewModel>();

            foreach (var item in result)
            {
                if (item.Amount > 5)
                {
                    var militarybase = db.MilitaryBases.Find(w => w.Id == item.BaseId).FirstOrDefault();
                    var machinery = db.Machineries.Find(w => w.Name.Equals(type)).FirstOrDefault();
                    list.Add(MapModel(militarybase, machinery, item.Amount));
                }
            }

            return list;
        }

        public IEnumerable<MachineryAmountViewModel> GetNone(string type)
        {
            var machineries = db.MilitaryBaseMachineries.GetAll().ToList();

            for (int i = 0; i < machineries.Count(); i++)
            {
                machineries[i].MilitaryBase = db.MilitaryBases.Get(machineries[i].MilitaryBaseId);
                machineries[i].Machinery = db.Machineries.Get(machineries[i].MachineryId);
            }

            var result = machineries.Where(w => w.Machinery.Name.Equals(type)).GroupBy(wp => wp.MilitaryBaseId).Select(g => g.FirstOrDefault());

            List<MilitaryBase> bases = db.MilitaryBases.GetAll().ToList();
            foreach (var item in result)
            {
                bases.RemoveAll(b => b.Id == item.MilitaryBaseId);
            }


            List<MachineryAmountViewModel> list = new List<MachineryAmountViewModel>();

            foreach (var item in bases)
            {
                var machinery = db.Machineries.Find(w => w.Name.Equals(type)).FirstOrDefault();
                list.Add(MapModel(item, machinery, 0));

            }

            return list;
        }

        private MachineryAmountViewModel MapModel(MilitaryBaseMachinery baseModel, int amount)
        {
            MachineryAmountViewModel model = new MachineryAmountViewModel
            {
                MilitaryBaseId = baseModel.MilitaryBaseId,
                MilitaryBaseName = baseModel.MilitaryBase.Name,
                MachineryType = baseModel.Machinery.Name,
                Amount = amount,
                Model = baseModel.Machinery.Model
            };

            return model;
        }

        private MachineryAmountViewModel MapModel(MilitaryBase baseModel, Machinery machine, int amount)
        {
            MachineryAmountViewModel model = new MachineryAmountViewModel
            {
                MilitaryBaseId = baseModel.Id,
                MilitaryBaseName = baseModel.Name,
                MachineryType = machine.Name,
                Amount = amount,
                Model = ""
            };

            return model;
        }
    }
}