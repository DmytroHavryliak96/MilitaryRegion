using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // ракетне озброєння
    public class MissileArmament
    {
        // ід
        public int Id { get; set; }
        // швидкість снаряду
        public double ShellSpeed { get; set; }
        // ід озброєння
        public int WeaponryId { get; set; }
        public Weaponry Weaponry { get; set; }
    }
}