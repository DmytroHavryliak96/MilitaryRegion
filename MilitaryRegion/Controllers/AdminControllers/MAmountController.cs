using MilitaryRegion.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitaryRegion.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class MAmountController : Controller
    {
        private IManageMachineryAmount service;
        private ICategoryInfo wep;

        public MAmountController(IManageMachineryAmount _service, ICategoryInfo _wep)
        {
            service = _service;
            wep = _wep;

            ViewBag.Types = wep.GetAllTypes().ToList();
        }

        // GET: MAmount
        public ActionResult Index()
        {
            return View(service.GetAllBases().OrderBy(t => t.MilitaryBaseName));
        }

        public ActionResult GetMore5(string typeName)
        {
            return View("Index", service.GetMore5(typeName).OrderBy(t => t.MilitaryBaseName));
        }

        public ActionResult GetNone(string typeName)
        {
            return View("Index", service.GetNone(typeName).OrderBy(t => t.MilitaryBaseName));
        }
    }
}