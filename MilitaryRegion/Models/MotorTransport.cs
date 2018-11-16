using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilitaryRegion.Models
{
    // Автотранспорт
    public class MotorTransport
    {
        // id
        public int Id { get; set; }
        // максимальна швидкість, км/год
        public double MaxSpeed { get; set; }
        // макс. дальність, км
        public  double Range { get; set; }
        // id техніки
        public int MachineryId { get; set; }
        public Machinery Machinery { get; set; }
    }
}