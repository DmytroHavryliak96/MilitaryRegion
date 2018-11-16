using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // тягачі
    public class Tractor
    {
        // id
        public int Id { get; set; }
        // вантажопідйомність
        public double LoadCapacity { get; set; }
        // id техніки
        public int MachineryId { get; set; }
        public Machinery Machinery { get; set; }
    }
}