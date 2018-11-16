using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // рядовий склад
    public class Soldier
    {
        // id
        public int Id { get; set; }
        // id військовослужбовця
        public int ServicemanId { get; set; }
        public Serviceman Serviceman { get; set; }

        // дата початку служби
        public DateTime ServiceStartDate { get; set; }
    }
}