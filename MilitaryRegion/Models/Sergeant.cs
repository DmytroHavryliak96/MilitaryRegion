using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // сержантський склад
    public class Sergeant
    {
        // id
        public int Id { get; set; }
        // id військовослужбовця
        public int ServicemanId { get; set; }
        public Serviceman Serviceman { get; set; }

        // дата отримання сержантського звання
        public DateTime SergeantRankDate { get; set; }
    }
}