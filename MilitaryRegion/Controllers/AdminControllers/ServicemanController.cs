using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MilitaryRegion.BL.Interfaces;
using MilitaryRegion.ViewModels;

namespace MilitaryRegion.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class ServicemanController : Controller
    {
        private IManageServiceman service;
        private IRegionInfo info;

        public ServicemanController(IManageServiceman _service, IRegionInfo _info)
        {
            service = _service;
            info = _info;
 
            ViewBag.Armies = info.GetAllArmies().ToList();
            ViewBag.Corps = info.GetAllCorps().ToList();
            ViewBag.Divisions = info.GetAllDivisions().ToList();
            ViewBag.Bases = info.GetAllMilitaryBases().ToList();
            ViewBag.Squads = info.GetAllSquads().ToList();
            ViewBag.Troops = info.GetAllTroops().ToList();
            ViewBag.Departments = info.GetAllDepartments().ToList();
            ViewBag.Specialties = service.GetSpecialties().ToList();
        }
        // GET: Serviceman
        public ActionResult Index()
        {
            Session["specialtyId"] = 0;
            ViewBag.CurrentSpecialty = info.GetCurrentSpecialty((int)Session["specialtyId"]);
            ViewBag.CurrentUnit = "всі підрозділи";
            return View(service.GetAll((int)Session["specialtyId"]));
        }

        public ActionResult GetSpecialty(int specialtyId)
        {
            Session["specialtyId"] = specialtyId;
            ViewBag.CurrentSpecialty = info.GetCurrentSpecialty((int)Session["specialtyId"]);
            ViewBag.CurrentUnit = "всі підрозділи";
            return View("Index", service.GetAll((int)Session["specialtyId"]));
        }

        public ActionResult GetServicemanOfArmy(int armyId)
        {
            ViewBag.CurrentSpecialty = info.GetCurrentSpecialty((int)Session["specialtyId"]);
            var result = service.GetServicemanOfArmy(armyId, (int)Session["specialtyId"]);
            ViewBag.CurrentUnit = "Армія = " + info.GetCurrentArmyNumber(armyId);
            return View("Index", result);
        }

        public ActionResult GetServicemanOfCorp(int corpId)
        {
            ViewBag.CurrentSpecialty = info.GetCurrentSpecialty((int)Session["specialtyId"]);
            var result = service.GetServicemanOfCorp(corpId, (int)Session["specialtyId"]);
            ViewBag.CurrentUnit = "Корпус = " + info.GetCurrentCorpNumber(corpId);
            return View("Index", result);
        }

        public ActionResult GetServicemanOfDivision(int divisionId)
        {
            ViewBag.CurrentSpecialty = info.GetCurrentSpecialty((int)Session["specialtyId"]);
            var result = service.GetServicemanOfDivision(divisionId, (int)Session["specialtyId"]);
            ViewBag.CurrentUnit = "Дивізія = " + info.GetCurrentDivisionName(divisionId);
            return View("Index", result);
        }

        public ActionResult GetServicemanOfBase(int baseId)
        {
            ViewBag.CurrentSpecialty = info.GetCurrentSpecialty((int)Session["specialtyId"]);
            var result = service.GetServicemanOfBases(baseId, (int)Session["specialtyId"]);
            ViewBag.CurrentUnit = "Військова частина = " + info.GetCurrentBaseName(baseId);
            return View("Index", result);
        }

        public ActionResult GetServicemanOfSquad(int squadId)
        {
            ViewBag.CurrentSpecialty = info.GetCurrentSpecialty((int)Session["specialtyId"]);
            var result = service.GetServicemanOfSquad(squadId, (int)Session["specialtyId"]);
            ViewBag.CurrentUnit = "Рота = " + info.GetCurrentSquadNumber(squadId);
            return View("Index", result);
        }

        public ActionResult GetServicemanOfTroop(int troopId)
        {
            ViewBag.CurrentSpecialty = info.GetCurrentSpecialty((int)Session["specialtyId"]);
            var result = service.GetServicemanOfTroop(troopId, (int)Session["specialtyId"]);
            ViewBag.CurrentUnit = "Взвод = " + info.GetCurrentTroopNumber(troopId);
            return View("Index", result);
        }

        public ActionResult GetServicemanOfDepartment(int depId)
        {
            ViewBag.CurrentSpecialty = info.GetCurrentSpecialty((int)Session["specialtyId"]);
            var result = service.GetServicemanOfDepartment(depId, (int)Session["specialtyId"]);
            ViewBag.CurrentUnit = "Відділ = " + info.GetCurrentDepNumber(depId);
            return View("Index", result);
        }

        public ActionResult GetChain(int manId)
        {
            ViewBag.CurrentServiceman = info.GetCurrentManName(manId);
            return View(service.GetChain(manId));
        }

    }
}