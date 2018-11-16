using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // Військовослужбовець
    public class Serviceman
    {
        // ід
        public int Id { get; set; }
        // ім'я
        public string FirstName { get; set; }
        // прізвище
        public string SecondName { get; set; }
        // дата народження
        public DateTime DateOfBirth { get; set; }

        // звання
        public int RankId { get; set; }
        public Rank Rank { get; set; }

        // армія
        public int ArmyId { get; set; }
        public Army Army { get; set; }
        
        // корпус
        public int CorpId { get; set; }
        public Corp Corp { get; set; }

        // дивізія 
        public int DivisionId { get; set; }
        public Division Division { get; set; }

        // військова частина
        public int MilitaryBaseId { get; set; }
        public MilitaryBase MilitaryBase { get; set; }

        // рота
        public int SquadId { get; set; }
        public Squad Squad { get; set; }

        // взвод
        public int TroopId { get; set; }
        public Troop Troop { get; set; }

        // відділ 
        public int DepartmentId { get; set; }
        public Department Department { get; set; }


    }
}