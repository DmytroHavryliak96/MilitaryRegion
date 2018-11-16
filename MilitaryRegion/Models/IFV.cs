using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // БМП
    public class IFV
    {
        // id
        public int Id { get; set; }
        // десант (кількість людей)
        public int Landing { get; set; }
        // величина головного калібру, mm
        public double MainCaliber { get; set; }
        // id техніки
        public int MachineryId { get; set; }
        public Machinery Machinery { get; set; }
    }
}