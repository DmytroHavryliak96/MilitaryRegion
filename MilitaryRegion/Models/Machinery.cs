using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // техніка
    public class Machinery
    {
        // id
        public int Id { get; set; }
        // назва техніки
        public string Name { get; set; }
        // модель техніки
        public string Model { get; set; }
        // вага, тонни
        public double Weight { get; set; }
        // категорія техніки
        public string Category { get; set; }
        // кількість екіпажу
        public int CrewAmount { get; set; }


    }
}