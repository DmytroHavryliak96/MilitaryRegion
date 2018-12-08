using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // корпус
    public class Corp
    {
        // ідентифікатор
        public int Id { get; set; }

        // номер корпусу
        public int Number { get; set; }

        // ід армії
        public int ArmyId { get; set; }

        public Army Army { get; set; }

        // id командира корпусу
        //[ForeignKey("Serviceman")]
        public int CorpCommanderId { get; set; }
       // public Serviceman Serviceman { get; set; }


    }
}