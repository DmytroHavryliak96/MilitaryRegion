using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitaryRegion.ViewModels
{
    public class WeaponryViewModel
    {
        // id
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CorpusId { get; set; }
        public int CorpusNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ArmyId { get; set; }
        public int ArmyNumber { get; set; }

        // ід військової частини
        public int MilitaryBaseId { get; set; }
        public string MilitaryBaseName { get; set; }

        // type
        public string Type { get; set; }
        // модель
        public string Model { get; set; }
        // боєзапас
        public int Ammunition { get; set; }
        // калібр, мм
        public double Caliber { get; set; }
        // category
        public string Category { get; set; }
        // amount
        public int Amount { get; set; }

        // carbines
        // довжина, мм
        public double Length { get; set; }

        // automatics
        // кількість пострілів на хвилину
        public double FiringSpeed { get; set; }

        // artillery
        // дальність пострілу, km
        public double ShootingRange { get; set; }

        // missile
        // швидкість снаряду, m/s
        public double ShellSpeed { get; set; }
    }
}