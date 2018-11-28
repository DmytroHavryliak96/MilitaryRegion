using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // артилерія
    public class Artillery
    {
        // id
        public int Id { get; set; }
        // дальність пострілу, km
        public double ShootingRange { get; set; }
        // id озброєння
        public int WeaponryId { get; set; }
        public Weaponry Weaponry { get; set; }
    }
}