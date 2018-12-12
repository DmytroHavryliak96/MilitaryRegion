using MilitaryRegion.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitaryRegion.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class SpecialtyController : Controller
    {
        private IManageSpecialty service;
        private IRegionInfo info;

        public SpecialtyController(IManageSpecialty _service, IRegionInfo _info)
        {
            service = _service;
            info = _info;

            ViewBag.Armies = info.GetAllArmies().ToList();
            ViewBag.Corps = info.GetAllCorps().ToList();
            ViewBag.Divisions = info.GetAllDivisions().ToList();
            ViewBag.Bases = info.GetAllMilitaryBases().ToList();
        }

        // GET: Specialty
        public ActionResult Index()
        {
            return View(service.GetAll());
        }

        public ActionResult GetArmy(int armyId)
        {
  
            return View("Index", service.GetArmy(armyId));
        }

        public ActionResult GetCorp(int corpId)
        {
            return View("Index", service.GetCorp(corpId));
        }

        public ActionResult GetDivision(int divisionId)
        {
            return View("Index", service.GetDiv(divisionId));
        }

        public ActionResult GetBase(int baseId)
        {
            return View("Index", service.GetBase(baseId));
        }
    }
}