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
        }

        // GET: Officers
        public ActionResult Index()
        {
            return View(service.GetAllOfficers(rankId : 0));
        }




    }
}