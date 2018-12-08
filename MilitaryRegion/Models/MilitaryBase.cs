using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // Військова частина
    public class MilitaryBase
    {
        // id
        public int Id { get; set; }
        // назва частини
        public string Name { get; set; }
        // номер частини
        public int Number { get; set; }

        // дислокація
        public int DislocationId { get; set; }
        public Dislocation Dislocation { get; set; }

        // id дивізії
        public int DivisionId { get; set; }
        public Division Division { get; set; }

        // id командира військової частини
        //[ForeignKey("Serviceman")]
        public int MilitaryBaseCommanderId { get; set; }
        //public Serviceman Serviceman { get; set; }
    }
}