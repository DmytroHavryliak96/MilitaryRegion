using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // споруди військових частин
    public class MilitaryBaseBuilding
    {
        // id
        public int Id { get; set; }
        // id будівлі
        public int BuildingId { get; set; }
        public Building Building { get; set; }
        // id військової частини
        public int MilitaryBaseId { get; set; }
        public MilitaryBase MilitaryBase { get; set; }
        // id роти
        public int SquadId { get; set; }
        public Squad Squad { get; set; }
        // id взводу
        public int TroopId { get; set; }
        public Troop Troop { get; set; }

        // id відділення
        public int DepartmentId {get; set;}
        public Department Department { get; set; }

    }
}