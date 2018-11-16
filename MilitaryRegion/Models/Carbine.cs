using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // карабіни
    public class Carbine
    {
        // id
        public int Id { get; set; }
        // час перезарядки, сек
        public double RechargeTime { get; set; }
        // id озброєння
        public int WeaponryId { get; set; }
        public Weaponry Weaponry { get; set; }
    }
}