using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // Взвод
    public class Troop
    {
        // ід
        public int Id { get; set; }

        // номер взводу
        public int Number { get; set; }

        // ід роти
        public int SquadId { get; set; }
        public Squad Squad { get; set; }

        // id командира взводу
        public int ServicemanId { get; set; }
        public Serviceman Serviceman { get; set; }
    }
}