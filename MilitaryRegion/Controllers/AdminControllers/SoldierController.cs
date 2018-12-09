using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MilitaryRegion.BL.Interfaces;

namespace MilitaryRegion.Controllers.AdminControllers
{
    public class SoldierController : Controller
    {
        private IManageSoldiers service;

        public SoldierController(IManageSoldiers _service)
        {
            service = _service;
            ViewBag.Armies = service.GetAllArmies().ToList();
            ViewBag.Corps = service.GetAllCorps().ToList();
            ViewBag.Divisions = service.GetAllDivisions().ToList();
            ViewBag.Bases = service.GetAllMilitaryBases().ToList();
            ViewBag.Ranks = service.GetSoldierRanks().ToList();
        }

        // GET: Soldier
        public ActionResult Index()
        {
            Session["rankId"] = 0;
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View(service.GetAllSoldiers(rankId: (int)Session["rankId"]));
        }

        public ActionResult GetRank(int rankId)
        {
            Session["rankId"] = rankId;
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetAllSoldiers(rankId: (int)Session["rankId"]));
        }

        public ActionResult GetSoldiersOfArmy(int armyId)
        {
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetSoldiersOfArmy(armyId, (int)Session["rankId"]));
        }

        public ActionResult GetSoldiersOfCorp(int corpId)
        {
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetSoldiersOfCorp(corpId, (int)Session["rankId"]));
        }

        public ActionResult GetSoldiersOfDivision(int divisionId)
        {
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetSoldiersOfDivision(divisionId, (int)Session["rankId"]));
        }

        public ActionResult GetSoldiersOfBase(int baseId)
        {
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetSoldiersOfBases(baseId, (int)Session["rankId"]));
        }
    }
}