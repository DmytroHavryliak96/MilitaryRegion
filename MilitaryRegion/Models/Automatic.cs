using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // автоматична зброя
    public class Automatic
    {
        // id
        public int Id { get; set; }
        // кількість пострілів на хвилину
        public double FiringSpeed { get; set; }
        // id озброєння
        public int WeaponryId { get; set; }
        public Weaponry Weaponry { get; set; }
    }
}