﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // Дивізія
    public class Division
    {
        // ід
        public int Id { get; set; }

        // номер дивізії
        public int Number { get; set; }

        // назва дивізії
        public string Name { get; set; }

        // ід корпусу
        public int CorpId { get; set; }

        public Corp Corp { get; set; }

        // id командира дивізії
        //[ForeignKey("Serviceman")]
        public int DivisionCommanderId { get; set; }
       // public Serviceman Serviceman { get; set; }
    }
}