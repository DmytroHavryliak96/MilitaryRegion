using MilitaryRegion.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitaryRegion.Controllers.AdminControllers
{
    public class TechnicController : Controller
    {
        private IManageTechnik service;
        private IRegionInfo info;
        private ICategoryInfo cat;

        public TechnicController(IManageTechnik _service, IRegionInfo _info, ICategoryInfo _cat)
        {
            service = _service;
            info = _info;
            cat = _cat;

            ViewBag.Armies = info.GetAllArmies().ToList();
            ViewBag.Corps = info.GetAllCorps().ToList();
            ViewBag.Divisions = info.GetAllDivisions().ToList();
            ViewBag.Bases = info.GetAllMilitaryBases().ToList();
            ViewBag.Categories = cat.GetAllCategories().ToList();
            ViewBag.Types = cat.GetAllTypes().ToList();
        }


        // GET: Technic
        public ActionResult Index()
        {
            Session["category"] = "all";
            Session["type"] = 0;
           
            ViewBag.CurrentCategory = "all";
            ViewBag.Type = "всі категорії техніки";
            ViewBag.CurrentUnit = "всі підрозділи";

            return View(service.GetAllTechnik((string)Session["category"], (int)Session["type"]).OrderBy(t => t.MilitaryBaseName));
        }

        public ActionResult GetCategory(string categoryName)
        {
            Session["category"] = categoryName;
            Session["type"] = 0;

            ViewBag.CurrentCategory = cat.GetCurrentCategory(categoryName);
            ViewBag.Type = "Категорія техніки " + categoryName;
            ViewBag.CurrentUnit = "всі підрозділи";

            return View("Index", service.GetAllTechnik((string)Session["category"], (int)Session["type"]).OrderBy(t => t.MilitaryBaseName));
        }

        public ActionResult GetType(int typeId)
        {
            Session["category"] = cat.GetCurrentCategoryFromTypeId(typeId);
            Session["type"] = typeId;

            ViewBag.CurrentCategory = cat.GetCurrentCategoryFromTypeIdEng(typeId);
            ViewBag.Type = "Вид техніки " + cat.GetCurrentTypeFormId(typeId);
            ViewBag.CurrentUnit = "всі підрозділи";

            return View("Index", service.GetAllTechnik((string)Session["category"], (int)Session["type"]).OrderBy(t => t.MilitaryBaseName));
        }


        public ActionResult GetTechnicOfArmy(int armyId)
        {

            ViewBag.CurrentCategory = cat.GetCurrentCategory((string)Session["category"]);
            ViewBag.Type = GetViewBag();
            ViewBag.CurrentUnit = "Армія = " + info.GetCurrentArmyNumber(armyId);

            var result = service.GetTechnikOfArmy(armyId, (string)Session["category"], (int)Session["type"]).OrderBy(t => t.MilitaryBaseName);
            
            return View("Index", result);
        }

        public ActionResult GetTechnicOfCorp(int corpId)
        {
            ViewBag.CurrentCategory = cat.GetCurrentCategory((string)Session["category"]);
            ViewBag.Type = GetViewBag();
            ViewBag.CurrentUnit = "Корпус = " + info.GetCurrentCorpNumber(corpId);

            var result = service.GetTechnikOfCorp(corpId, (string)Session["category"], (int)Session["type"]).OrderBy(t => t.MilitaryBaseName);

            return View("Index", result);
        }

        public ActionResult GetTechnicOfDivision(int divisionId)
        {
            ViewBag.CurrentCategory = cat.GetCurrentCategory((string)Session["category"]);
            ViewBag.Type = GetViewBag();
            ViewBag.CurrentUnit = "Дивізія = " + info.GetCurrentDivisionName(divisionId);

            var result = service.GetTechnikOfDivision(divisionId, (string)Session["category"], (int)Session["type"]).OrderBy(t => t.MilitaryBaseName);

            return View("Index", result);
        }

        public ActionResult GetTechnicOfBase(int baseId)
        {
            ViewBag.CurrentCategory = cat.GetCurrentCategory((string)Session["category"]);
            ViewBag.Type = GetViewBag();
            ViewBag.CurrentUnit = "Військова частина = " + info.GetCurrentBaseName(baseId);

            var result = service.GetTechnikOfMilitaryBase(baseId, (string)Session["category"], (int)Session["type"]).OrderBy(t => t.MilitaryBaseName);

            return View("Index", result);
        }

        private string GetViewBag()
        {
            string answer;

            if ((int)Session["type"] == 0)
            {
                var str = (string)Session["category"];
                if (str.Equals("all"))
                {
                    answer = "всі види техніки";
                }
                else
                {
                    answer = "Категорія техніки = " + (string)Session["category"];
                }

            }
            else
            {
                answer = "Вид техніки " + cat.GetCurrentTypeFormId((int)Session["type"]); ;
            }

            return answer;
        }
    }
}