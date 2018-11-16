using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // техніка військових частин
    public class MilitaryBaseMachinery
    {
        // id
        public int Id { get; set; }
        // ід військової частини
        public int MilitaryBaseId { get; set; }
        public MilitaryBase MilitaryBase { get; set; }
        // id техніки
        public int MachineryId { get; set; }
        public Machinery Machinery { get; set; }
        // кількість
        public int Amount { get; set; }
    }
}