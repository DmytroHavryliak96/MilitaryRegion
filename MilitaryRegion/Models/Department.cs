using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // відділ
    public class Department
    {
        // id
        public int Id { get; set; }
        // номер відділу
        public int Number { get; set; }

        // id взводу
        public int TroopId { get; set; }
        public Troop Troop { get; set; }

        // id командира
        //[ForeignKey("Serviceman")]
        public int DepartmentCommanderId { get; set; }
        //public Serviceman Serviceman { get; set; }
    }
}