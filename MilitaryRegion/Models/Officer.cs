using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // офіцерський склад
    public class Officer
    {
        // id
        public int Id { get; set; }
        // id військовослужбовця
        public int ServicemanId { get; set; }
        public Serviceman Serviceman { get; set; }

        // дата завершення академії
        public DateTime AcademicCompletionDate { get; set; }
        // дата отримання офіцерського звання
        public DateTime OfficerRankDate { get; set; }

    }
}