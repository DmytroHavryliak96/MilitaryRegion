using MilitaryRegion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.ViewModels
{
    public class TechnicViewModel
    {
        // id
        public int Id { get; set; }

        // ід військової частини
        public int MilitaryBaseId { get; set; }
        public string MilitaryBaseName { get; set; }

        // id техніки
        public int MachineryId { get; set; }
        public string Name { get; set; }
        // модель техніки
        public string Model { get; set; }
        // вага, тонни
        public double Weight { get; set; }
        // кількість екіпажу
        public int CrewAmount { get; set; }

        // кількість
        public int Amount { get; set; }

    }
}