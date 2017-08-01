﻿using System.Collections.Generic;
using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;
using Lib.Attributes;

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
            return View(KPIList);
        }
        
        public ActionResult ViewKPI(int KPIID)
        {
            return View(KPIs.GetKPIByID(KPIID));
        }
        
        [HttpGet]
        [ORAAuthorize(Roles = "ADMINISTRATOR, MANAGER, DIRECTOR, LEAD")]
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
        [ORAAuthorize(Roles = "ADMINISTRATOR, MANAGER, DIRECTOR, LEAD")]
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