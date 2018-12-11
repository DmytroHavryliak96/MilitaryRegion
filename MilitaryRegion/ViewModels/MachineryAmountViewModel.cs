using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.ViewModels
{
    public class MachineryAmountViewModel
    {
        public int MilitaryBaseId { get; set; }

        public string MilitaryBaseName { get; set; }

        public string MachineryType { get; set; }

        public int Amount { get; set; }

        public string Model { get; set; }
    }
}