using MilitaryRegion.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitaryRegion.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class BuildingController : Controller
    {
        private IManageBuilding service;
        private IRegionInfo info;

        public BuildingController(IManageBuilding _service, IRegionInfo _info)
        {
            service = _service;
            info = _info;

            ViewBag.Bases = info.GetAllMilitaryBases().ToList();
        }

        // GET: Building
        public ActionResult Index()
        {
            ViewBag.CurrentCategory = "Ordinary";
            ViewBag.CurrentUnit = "всі військові частини";

            return View(service.GetAllBuildings().OrderBy(t => t.MilitaryBaseName));
        }

        public ActionResult GetBuildingOfBase(int baseId)
        {
            ViewBag.CurrentCategory = "Ordinary";
            ViewBag.CurrentUnit = "Військова частина = " + info.GetCurrentBaseName(baseId);

            var result = service.GetBuildingsOfBase(baseId);

            return View("Index", result);
        }

        public ActionResult GetCategory(int flag)
        {
            ViewBag.CurrentCategory = "Flag";

            if (flag == 1)
                ViewBag.CurrentUnit = "будівлі, де дислоковано більше 1 підрозділу";
            else
            {
                ViewBag.CurrentUnit = "будівлі, де не дислоковано жодного підрозділу";
            }

            return View("Index", service.GetBuildingsFlag(flag));
        }


    }
}