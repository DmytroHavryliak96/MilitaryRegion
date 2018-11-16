using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // спеціальності військовослужбовців
    public class ServicemanSpecialty
    {
        // id
        public int Id { get; set; }

        // id військовослужбовця
        public int ServicemanId { get; set; }
        public Serviceman Serviceman { get; set; }

        // id спеціальності
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
    }
}