using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;


namespace ORA.Controllers
{
    public class KPIController : Controller
    {
        private IKPILogic KPIs;

        public KPIController(IKPILogic kpi)
        {
            KPIs = kpi;
        }

        // GET: KPI
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAllKPI()
        {
            return View(KPIs.GetAllKPIs());
        }
        
        public ActionResult ViewKPI(int KPIID)
        {
            return View(KPIs.GetKPIByID(KPIID));
        }
        
        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateKPI(int KPIID)
        {
            return View(KPIs.GetKPIByID(KPIID));
        }

        [HttpPost]
        public ActionResult UpdateKPI(KPIVM updatedKPI)
        {
            KPIs.UpdateKPI(updatedKPI);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult CreateKPI()
        {
            return View(KPIs.AddKPI());
        }

        [HttpPost]
        public ActionResult CreateKPI(CreateKPIVM KPI)
        {
            KPIs.AddKPI(KPI);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }
    }
}