using System.Collections.Generic;
using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;
using Lib.Attributes;
using System;

namespace ORA.Controllers
{
    [ORAAuthorize]
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
            return View(KPIs.GetAllKPIs());
        }

        public ActionResult ViewListKPI(List<KPIVM> KPIList)
        {
            return View("Index", KPIList);
        }
        
        public ActionResult ViewKPI(int KPIID)
        {
            KPIVM Value = KPIs.GetKPIByID(KPIID);
            Value.CreatedBy = Session["Name"].ToString();
            return View(Value);
        }

        public ActionResult RemoveKPI(int KPIID)
        {
            return View(KPIs.GetKPIByID(KPIID));
        }


        
        [HttpGet]
        [ORAAuthorize(Roles = "ADMINISTRATOR, MANAGER, DIRECTOR, LEAD")]
        public ActionResult UpdateKPI(int KPIID)
        {
            CreateKPIVM Value = KPIs.GetCreateKPIByID(KPIID);
            TempData["TempCreatedBy"] = Value.CreatedBy;
            TempData["TempKPI"] = Value.Created;
            return View(Value);
        }

        [HttpPost]
        public ActionResult UpdateKPI(KPIVM updatedKPI)
        {
            KPIs.UpdateKPI(updatedKPI);
            return RedirectToAction("Index", "KPI", new { area = "" });
        }

        [HttpGet]
        [ORAAuthorize(Roles = "ADMINISTRATOR, MANAGER, DIRECTOR, LEAD")]
        public ActionResult CreateKPI()
        {
            TempData["Stage"] = 1;
            return View();
        }

        public ActionResult GetKPIByDate(CreateKPIVM KPI)
        {
            TempData["Stage"] = 2;
            return View("CreateKPI", KPIs.AddKPI(KPI.Created));
        }

        [HttpPost]
        public ActionResult CreateKPI(CreateKPIVM KPI)
        {
            KPIs.AddKPI(KPI);
            return RedirectToAction("Index", "KPI", new { area = "" });
        }
    }
}