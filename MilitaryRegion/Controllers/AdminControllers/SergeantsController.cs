using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MilitaryRegion.BL.Interfaces;

namespace MilitaryRegion.Controllers.AdminControllers
{
    public class SergeantsController : Controller
    {
        private IManageSergeants service;

        public SergeantsController(IManageSergeants _service)
        {
            service = _service;
            ViewBag.Armies = service.GetAllArmies().ToList();
            ViewBag.Corps = service.GetAllCorps().ToList();
            ViewBag.Divisions = service.GetAllDivisions().ToList();
            ViewBag.Bases = service.GetAllMilitaryBases().ToList();
            ViewBag.Ranks = service.GetSergeantRanks().ToList();
        }

        // GET: Sergeants
        public ActionResult Index()
        {
            Session["rankId"] = 0;
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View(service.GetAllSergeants(rankId: (int)Session["rankId"]));
        }

        public ActionResult GetRank(int rankId)
        {
            Session["rankId"] = rankId;
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetAllSergeants(rankId: (int)Session["rankId"]));
        }

        public ActionResult GetSergeantsOfArmy(int armyId)
        {
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetSergeantsOfArmy(armyId, (int)Session["rankId"]));
        }

        public ActionResult GetSergeantsOfCorp(int corpId)
        {
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetSergeantsOfCorp(corpId, (int)Session["rankId"]));
        }

        public ActionResult GetSergeantsOfDivision(int divisionId)
        {
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetSergeantsOfDivision(divisionId, (int)Session["rankId"]));
        }

        public ActionResult GetSergeantsOfBase(int baseId)
        {
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetSergeantsOfBases(baseId, (int)Session["rankId"]));
        }
    }
}