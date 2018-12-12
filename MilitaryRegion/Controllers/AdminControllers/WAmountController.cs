using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MilitaryRegion.BL.Interfaces;

namespace MilitaryRegion.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class WAmountController : Controller
    {
        private IManageWeaponAmount service;
        private IWeaponInfo wep;

        public WAmountController(IManageWeaponAmount _service, IWeaponInfo _wep)
        {
            service = _service;
            wep = _wep;

            ViewBag.Types = wep.GetAllTypes().ToList();
        }


        // GET: WAmount
        public ActionResult Index()
        {
            return View(service.GetAllBases().OrderBy(t => t.MilitaryBaseName));
        }

        public ActionResult GetMore10(string typeName)
        {
            return View("Index", service.GetMore10(typeName).OrderBy(t => t.MilitaryBaseName));
        }

        public ActionResult GetNone(string typeName)
        {
            return View("Index", service.GetNone(typeName).OrderBy(t => t.MilitaryBaseName));
        }
    }
}