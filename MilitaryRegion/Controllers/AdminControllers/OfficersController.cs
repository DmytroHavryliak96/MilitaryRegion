using MilitaryRegion.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitaryRegion.Controllers.AdminControllers
{
    public class OfficersController : Controller
    {
        private IManageOfficers service;

        public OfficersController(IManageOfficers _service)
        {
            service = _service;
            ViewBag.Armies = service.GetAllArmies().ToList();
            ViewBag.Corps = service.GetAllCorps().ToList();
            ViewBag.Divisions = service.GetAllDivisions().ToList();
            ViewBag.Bases = service.GetAllMilitaryBases().ToList();
            ViewBag.Ranks = service.GetOfficersRanks().ToList();
            
        }

        // GET: Officers
        public ActionResult Index()
        {
            Session["rankId"] = 0;
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View(service.GetAllOfficers(rankId : (int)Session["rankId"]));
        }

        public ActionResult GetRank(int rankId)
        {
            Session["rankId"] = rankId;
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetAllOfficers(rankId: (int)Session["rankId"]));
        }

        public ActionResult GetOfficersOfArmy(int armyId)
        {
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetOfficersOfArmy(armyId, (int)Session["rankId"]));
        }

        public ActionResult GetOfficersOfCorp(int corpId)
        {
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetOfficersOfCorp(corpId, (int)Session["rankId"]));
        }

        public ActionResult GetOfficersOfDivision(int divisionId)
        {
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetOfficersOfDivision(divisionId, (int)Session["rankId"]));
        }

        public ActionResult GetOfficersOfBase(int baseId)
        {
            ViewBag.CurrentRank = service.GetCurrentRank((int)Session["rankId"]);
            return View("Index", service.GetOfficersOfBases(baseId, (int)Session["rankId"]));
        }



    }
}