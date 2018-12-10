using MilitaryRegion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitaryRegion.ViewModels
{
    public class TechnicViewModel
    {
        // id
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CorpusId { get; set; }
        public int CorpusNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ArmyId { get; set; }
        public int ArmyNumber { get; set; }

        // ід військової частини
        public int MilitaryBaseId { get; set; }
        public string MilitaryBaseName { get; set; }

        // id техніки
        public int MachineryId { get; set; }
        public string Type { get; set; }
        // модель техніки
        public string Model { get; set; }
        // category
        public string Category { get; set; }
        // вага, тонни
        public double Weight { get; set; }
        // кількість екіпажу
        public int CrewAmount { get; set; }

        // кількість
        public int Amount { get; set; }

        // IFVs
        // десант (кількість людей)
        public int Landing { get; set; }
        // величина головного калібру, mm
        public double MainCaliber { get; set; }

        // tractor
        // вантажопідйомність
        public double LoadCapacity { get; set; }
        // id техніки

        // motortransport
        // максимальна швидкість, км/год
        public double MaxSpeed { get; set; }
        // макс. дальність, км
        public double Range { get; set; }

       
        // вибрана користувачем категорія
        public string MachineryInputCategory { get; set; }

        // вибраний користувачем вид техніки
        public string MachineryInputType { get; set; }

        // поточний підрозділ
        public string CurrentUnit { get; set; }
    }
}