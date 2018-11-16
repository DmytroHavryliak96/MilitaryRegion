using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // озброєння військових частин
    public class MilitaryBaseWeaponry
    {
        // id
        public int Id { get; set; }
        // id військової частини
        public int MilitaryBaseId { get; set; }
        public MilitaryBase MilitaryBase { get; set; }

        // id озброєння
        public int WeaponryId { get; set; }
        public Weaponry Weaponry { get; set; }

        // кількість озброєння
        public int Amount { get; set; }
    }
}