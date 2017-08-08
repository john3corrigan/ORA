using System.Collections.Generic;
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
            if (Session["Roles"].ToString().Contains("DIRECTOR"))
            {
                return View(KPIs.GetAllKPIs());
            }
            else if (Session["Roles"].ToString().Contains("LEAD"))
            {
                return View(KPIs.GetKPIByDate());
            }
            else if (Session["Roles"].ToString().Contains("EMPLOYEE"))
            {
                return View(KPIs.GetAllKPIs());
            }

            return View();
        }

        public ActionResult ViewListKPI(List<KPIVM> KPIList)
        {
            if (Session["Roles"].ToString().Contains("DIRECTOR"))
            {
                return View("Index", KPIList);
            }

            else if (Session["Roles"].ToString().Contains("LEAD"))
            {
                return View("Index", KPIList);
            }

            else if (Session["Roles"].ToString().Contains("EMPLOYEE"))
            {
                return View("Index", KPIList);
            }

            return View();
            
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
            return View(KPIs.AddKPI());
        }

        [HttpPost]
        public ActionResult CreateKPI(CreateKPIVM KPI)
        {
            KPIs.AddKPI(KPI);
            return RedirectToAction("Index", "KPI", new { area = "" });
        }
    }
}