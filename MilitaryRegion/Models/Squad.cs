using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // рота
    public class Squad
    {
        // id
        public int Id { get; set; }
        // номер роти
        public int Number { get; set; }

        // id військової частини
        public MilitaryBase MilitaryBaseId { get; set; }
        public MilitaryBase MilitaryBase { get; set; }

        // id командира роти
        public int ServicemanId { get; set; }
        public Serviceman Serviceman { get; set; }

    }
}