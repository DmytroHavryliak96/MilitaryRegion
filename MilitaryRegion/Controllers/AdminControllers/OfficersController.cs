﻿using MilitaryRegion.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MilitaryRegion.ViewModels;

namespace MilitaryRegion.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class OfficersController : Controller
    {
        private IManageRanks<OfficerViewModel> service;
        private IRegionInfo info;

        public OfficersController(IManageRanks<OfficerViewModel> _service, IRegionInfo _info)
        {
            service = _service;
            info = _info;
            ViewBag.Armies = info.GetAllArmies().ToList();
            ViewBag.Corps = info.GetAllCorps().ToList();
            ViewBag.Divisions = info.GetAllDivisions().ToList();
            ViewBag.Bases = info.GetAllMilitaryBases().ToList();
            ViewBag.Ranks = service.GetRanks().ToList();
            
        }

        // GET: Officers
        public ActionResult Index()
        {
            Session["rankId"] = 0;
            ViewBag.CurrentRank = info.GetCurrentRank((int)Session["rankId"]);
            ViewBag.CurrentUnit = "всі підрозділи";
            return View(service.GetAll(rankId : (int)Session["rankId"]));
        }

        public ActionResult GetRank(int rankId)
        {
            Session["rankId"] = rankId;
            ViewBag.CurrentRank = info.GetCurrentRank((int)Session["rankId"]);
            ViewBag.CurrentUnit = "всі підрозділи";
            return View("Index", service.GetAll(rankId: (int)Session["rankId"]));
        }

        public ActionResult GetOfficersOfArmy(int armyId)
        {
            ViewBag.CurrentRank = info.GetCurrentRank((int)Session["rankId"]);
            var result = service.GetRanksOfArmy(armyId, (int)Session["rankId"]);
            ViewBag.CurrentUnit = "Армія = " + info.GetCurrentArmyNumber(armyId);
            return View("Index", result);
        }

        public ActionResult GetOfficersOfCorp(int corpId)
        {
            ViewBag.CurrentRank = info.GetCurrentRank((int)Session["rankId"]);
            var result = service.GetRanksOfCorp(corpId, (int)Session["rankId"]);
            ViewBag.CurrentUnit = "Корпус = " + info.GetCurrentCorpNumber(corpId);
            return View("Index", result);
        }

        public ActionResult GetOfficersOfDivision(int divisionId)
        {
            ViewBag.CurrentRank = info.GetCurrentRank((int)Session["rankId"]);
            var result = service.GetRanksOfDivision(divisionId, (int)Session["rankId"]);
            ViewBag.CurrentUnit = "Дивізія = " + info.GetCurrentDivisionName(divisionId);
            return View("Index", result);
        }

        public ActionResult GetOfficersOfBase(int baseId)
        {
            ViewBag.CurrentRank = info.GetCurrentRank((int)Session["rankId"]);
            var result = service.GetRanksOfBases(baseId, (int)Session["rankId"]);
            ViewBag.CurrentUnit = "Військова частина = " + info.GetCurrentBaseName(baseId);
            return View("Index", result);
        }



    }
}