using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitaryRegion.ViewModels
{
    public class BuildingViewModel
    {
        public int Id { get; set; }

        // площа, m^2
        public double Square { get; set; }
        // висота, m
        public double Height { get; set; }
        // призначення
        public string Purpose { get; set; }
        // кількість поверхів 
        public int FloorAmount { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int DepartmentId { get; set; }
        public int DepartmnetNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int TroopId { get; set; }
        public int TroopNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int SquadId { get; set; }
        public int SquadNumber { get; set; }

        // ід військової частини
        public int MilitaryBaseId { get; set; }
        public string MilitaryBaseName { get; set; }

        // кількість підрозділів
        public int UnitsAmount { get; set; }
    }
}