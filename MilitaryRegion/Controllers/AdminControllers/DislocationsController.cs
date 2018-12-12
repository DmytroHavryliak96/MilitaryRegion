using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MilitaryRegion.BL.Interfaces;

namespace MilitaryRegion.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class DislocationsController : Controller
    {
        private IManageDislocation service;
        private IRegionInfo info;

        public DislocationsController(IManageDislocation _service, IRegionInfo _info)
        {
            service = _service;
            info = _info;

            ViewBag.Armies = info.GetAllArmies().ToList();
            ViewBag.Corps = info.GetAllCorps().ToList();
            ViewBag.Divisions = info.GetAllDivisions().ToList();
            ViewBag.Bases = info.GetAllMilitaryBases().ToList();
        }

        // GET: Dislocations
        public ActionResult Index()
        {
            ViewBag.CurrentUnit = "всі підрозділи";
            return View(service.GetAll());
        }

        public ActionResult GetDislocationsOfArmy(int armyId)
        {
            var result = service.GetArmyDis(armyId);
            ViewBag.CurrentUnit = "Армія = " + info.GetCurrentArmyNumber(armyId);
            return View("Index", result);
        }

        public ActionResult GetDislocationsOfCorp(int corpId)
        {
            var result = service.GetCorpDis(corpId);
            ViewBag.CurrentUnit = "Корпус = " + info.GetCurrentCorpNumber(corpId);
            return View("Index", result);
        }

        public ActionResult GetDislocationsOfDivision(int divisionId)
        {
            var result = service.GetDivDis(divisionId);
            ViewBag.CurrentUnit = "Дивізія = " + info.GetCurrentDivisionName(divisionId);
            return View("Index", result);
        }

        public ActionResult GetDislocationsOfBase(int baseId)
        {
            var result = service.GetBaseDis(baseId);
            ViewBag.CurrentUnit = "Військова частина = " + info.GetCurrentBaseName(baseId);
            return View("Index", result);
        }
    }
}