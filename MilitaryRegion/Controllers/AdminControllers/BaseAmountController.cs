using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MilitaryRegion.BL.Interfaces;

namespace MilitaryRegion.Controllers.AdminControllers
{
    [Authorize(Roles = "Admin")]
    public class BaseAmountController : Controller
    {
        private IManageBaseAmount service;

        public BaseAmountController(IManageBaseAmount _service)
        {
            service = _service;
        }

        // GET: BaseAmount
        public ActionResult Index()
        {
            return View(service.GetArmy());
        }

        public ActionResult GetCorp()
        {
            return View("Index", service.GetCorp());
        }

        public ActionResult GetDiv()
        {
            return View("Index", service.GetDivision());
        }
    }
}