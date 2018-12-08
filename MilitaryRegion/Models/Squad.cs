using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int MilitaryBaseId { get; set; }
        public MilitaryBase MilitaryBase { get; set; }

        // id командира роти
        //[ForeignKey("Serviceman")]
        public int SquadCommanderId { get; set; }
        //public Serviceman Serviceman { get; set; }

    }
}