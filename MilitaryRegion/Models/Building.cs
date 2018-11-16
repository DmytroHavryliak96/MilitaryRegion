using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // споруди воєнного округу
    public class Building
    {
        // ід
        public int Id { get; set; }
        // площа
        public double Square { get; set; }
        // висота
        public double Height { get; set; }
        // призначення
        public string Purpose { get; set; }
        // кількість поверхів 
        public int FloorAmount { get; set; }
    }
}