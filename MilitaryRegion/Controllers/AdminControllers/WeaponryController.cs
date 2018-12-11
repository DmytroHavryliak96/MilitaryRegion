using MilitaryRegion.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitaryRegion.Controllers.AdminControllers
{
    public class WeaponryController : Controller
    {
        private IManageWeaponry service;
        private IRegionInfo info;
        private IWeaponInfo wep;

        public WeaponryController(IManageWeaponry _service, IRegionInfo _info, IWeaponInfo _wep)
        {
            service = _service;
            info = _info;
            wep = _wep;

            ViewBag.Armies = info.GetAllArmies().ToList();
            ViewBag.Corps = info.GetAllCorps().ToList();
            ViewBag.Divisions = info.GetAllDivisions().ToList();
            ViewBag.Bases = info.GetAllMilitaryBases().ToList();
            ViewBag.Categories = wep.GetAllCategories().ToList();
            ViewBag.Types = wep.GetAllTypes().ToList();
        }

        // GET: Weaponry
        public ActionResult Index()
        {
            Session["category"] = "all";
            Session["type"] = "none";

            ViewBag.CurrentCategory = "all";
            ViewBag.Type = "всі категорії зброї";
            ViewBag.CurrentUnit = "всі підрозділи";

            return View(service.GetAllWeaponry((string)Session["category"], (string)Session["type"]).OrderBy(t => t.MilitaryBaseName));
        }

        public ActionResult GetCategory(string categoryName)
        {
            Session["category"] = categoryName;
            Session["type"] = "none";

            ViewBag.CurrentCategory = wep.GetCurrentCategory(categoryName);
            ViewBag.Type = "Категорія зброї " + categoryName;
            ViewBag.CurrentUnit = "всі підрозділи";

            return View("Index", service.GetAllWeaponry((string)Session["category"], (string)Session["type"]).OrderBy(t => t.MilitaryBaseName));
        }

        public ActionResult GetType(string typeName)
        {
            Session["category"] = wep.GetCurrentCategoryFromType(typeName);
            Session["type"] = typeName;

            ViewBag.CurrentCategory = wep.GetCurrentCategoryFromTypeEng(typeName);
            ViewBag.Type = "Вид зброї " + (string)Session["type"];
            ViewBag.CurrentUnit = "всі підрозділи";

            return View("Index", service.GetAllWeaponry((string)Session["category"], (string)Session["type"]).OrderBy(t => t.MilitaryBaseName));
        }

        public ActionResult GetWeaponryOfArmy(int armyId)
        {

            ViewBag.CurrentCategory = wep.GetCurrentCategory((string)Session["category"]);
            ViewBag.Type = GetViewBag();
            ViewBag.CurrentUnit = "Армія = " + info.GetCurrentArmyNumber(armyId);

            var result = service.GetWeaponryOfArmy(armyId, (string)Session["category"], (string)Session["type"]).OrderBy(t => t.MilitaryBaseName);

            return View("Index", result);
        }

        public ActionResult GetWeaponryOfCorp(int corpId)
        {
            ViewBag.CurrentCategory = wep.GetCurrentCategory((string)Session["category"]);
            ViewBag.Type = GetViewBag();
            ViewBag.CurrentUnit = "Корпус = " + info.GetCurrentCorpNumber(corpId);

            var result = service.GetWeaponryOfCorp(corpId, (string)Session["category"], (string)Session["type"]).OrderBy(t => t.MilitaryBaseName);

            return View("Index", result);
        }

        public ActionResult GetWeaponryOfDivision(int divisionId)
        {
            ViewBag.CurrentCategory = wep.GetCurrentCategory((string)Session["category"]);
            ViewBag.Type = GetViewBag();
            ViewBag.CurrentUnit = "Дивізія = " + info.GetCurrentDivisionName(divisionId);

            var result = service.GetWeaponryOfDivision(divisionId, (string)Session["category"], (string)Session["type"]).OrderBy(t => t.MilitaryBaseName);

            return View("Index", result);
        }

        public ActionResult GetWeaponryOfBase(int baseId)
        {
            ViewBag.CurrentCategory = wep.GetCurrentCategory((string)Session["category"]);
            ViewBag.Type = GetViewBag();
            ViewBag.CurrentUnit = "Військова частина = " + info.GetCurrentBaseName(baseId);

            var result = service.GetWeaponryOfMilitaryBase(baseId, (string)Session["category"], (string)Session["type"]).OrderBy(t => t.MilitaryBaseName);

            return View("Index", result);
        }

        private string GetViewBag()
        {
            string answer;

            string typeStr = (string)Session["type"];

            if (typeStr.Equals("none"))
            {
                var str = (string)Session["category"];

                if (str.Equals("all"))
                {
                    answer = "всі види зброї";
                }
                else
                {
                    answer = "Категорія зброї = " + (string)Session["category"];
                }

            }
            else
            {
                answer = "Вид зброї " + (string)Session["type"]; 
            }

            return answer;
        }
    }
}