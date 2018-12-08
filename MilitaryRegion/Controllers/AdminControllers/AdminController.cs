using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MilitaryRegion.BL.Interfaces;

namespace MilitaryRegion.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IManageMilitaryBases service;

        public AdminController(IManageMilitaryBases _service)
        {
            service = _service;
            ViewBag.Armies = service.GetAllArmies().ToList();
            ViewBag.Corps = service.GetAllCorps().ToList();
            ViewBag.Divisions = service.GetAllDivisions().ToList();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ManageMilitaryBases()
        {
            return View(service.GetAllMilitaryBases());
        }

        public ActionResult GetBasesOfArmy(int armyId)
        {
            return View("ManageMilitaryBases", service.GetMilitaryBasesOfArmy(armyId));       
        }

        public ActionResult GetBasesOfCorp(int corpId)
        {
            return View("ManageMilitaryBases", service.GetMilitaryBasesOfCorp(corpId));
        }

        public ActionResult GetBasesOfDivision(int divisionId)
        {
            return View("ManageMilitaryBases", service.GetMilitaryBasesOfDivision(divisionId));
        }
    }


}