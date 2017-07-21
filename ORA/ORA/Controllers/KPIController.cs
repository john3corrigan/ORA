using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using BusinessLogic.ORALogic;

namespace ORA.Controllers
{
    public class KPIController : Controller
    {
        private KPILogic kpiLogic = new KPILogic();
        // GET: KPI
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAllKPI()
        {
            return View(kpiLogic.GetAllKPIs());
        }
        
        public ActionResult ViewKPI(int KPIID)
        {
            return View(kpiLogic.GetKPIByKPIID(KPIID));
        }
        
        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateKPI(int KPIID)
        {
            return View(kpiLogic.GetKPIByKPIID(KPIID));
        }

        [HttpPost]
        public ActionResult UpdateKPI(KPIVM updatedKPI)
        {
            kpiLogic.UpdateKPI(updatedKPI);
            return RedirectToAction("", "", new { area = "" });
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult CreateKPI()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateKPI(KPIVM KPI)
        {
            kpiLogic.CreateKPI(KPI);
            return RedirectToAction("", "", new { area = "" });
        }
    }
}