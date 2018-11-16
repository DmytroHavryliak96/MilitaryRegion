using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // озброєння
    public class Weaponry
    {
        // id
        public int Id { get; set; }
        // назва
        public string Name { get; set; }
        // модель
        public string Model { get; set; }
        // боєзапас
        public int Ammunition { get; set; }
        // калібр, мм
        public double Caliber { get; set; }
    }
}