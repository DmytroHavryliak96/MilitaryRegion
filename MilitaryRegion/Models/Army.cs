using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // армія
    public class Army
    {
        // ід
        public int Id { get; set; }

        // номер армії
        public int Number { get; set; }

        // id командира армії
        public int ArmyCommanderId { get; set; }
       // public Serviceman Serviceman { get; set; }
    }
}