using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MilitaryRegion.ViewModels
{
    public class ServicemanViewModel
    {
        public int ServicemanId { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string RankName { get; set; }

        public DateTime SergeantRankDate { get; set; }

        public string SpecialtyName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int DepartmentId { get; set; }
        public int DepartmnetNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int TroopId { get; set; }
        public int TroopNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int SquadId { get; set; }
        public int SquadNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int MilitaryBaseId { get; set; }
        public string MilitaryBaseName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CorpusId { get; set; }
        public int CorpusNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ArmyId { get; set; }
        public int ArmyNumber { get; set; }
    }
}