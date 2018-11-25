using MilitaryRegion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitaryRegion.ViewModels
{
    public class MilitaryBaseViewModel
    {

        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Number { get; set; }

        public string City { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CorpusId { get; set; }
        public int CorpusNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ArmyId { get; set; }
        public int ArmyNumber { get; set; }

        public string Commander { get; set; }
    }
}