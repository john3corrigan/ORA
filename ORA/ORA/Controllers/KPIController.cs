using System.Collections.Generic;
using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;
using Lib.Attributes;
using System;
using Rotativa;

namespace ORA.Controllers
{
    [ORAAuthorize]
    public class KPIController : Controller
    {
        private IKPILogic KPIs;
        private ITeamLogic Teams;
        private IClientLogic Client;
        private IEmployeeLogic Employee;

        public KPIController(IKPILogic kpi, 
            ITeamLogic tms,
            IClientLogic clnt,
            IEmployeeLogic mply)
        {
            KPIs = kpi;
            Teams = tms;
            Client = clnt;
            Employee = mply;
        }

        // GET: KPI
        public ActionResult Index()
        {
            if(Session["Roles"].ToString().Contains("DIRECTOR") || Session["Roles"].ToString().Contains("ADMINISTRATOR"))
            {
                return View(KPIs.GetAllKPIs());
            }
            else if (Session["Roles"].ToString().Contains("MANAGER"))
            {
                return View(KPIs.GetKPIsForManager((int)Session["ID"]));
            }
            else if (Session["Roles"].ToString().Contains("LEAD"))
            {
                return View(KPIs.GetKPIsForLead((int)Session["ID"]));
            }
            else
            {
                return View(KPIs.GetMyKPIs((int)Session["ID"]));
            }
        }

        public ActionResult ViewListKPIBySprint(int SprintID)
        {
            return View("Index", KPIs.GetKPIBySprintID(SprintID));
        }

        public ActionResult ViewListKPIByAssignment(int AssignmentID)
        {
            return View("Index", KPIs.GetKPIByAssignmentID(AssignmentID));
        }

        public ActionResult ViewKPI(int KPIID)
        {
            return View(KPIs.GetKPIByID(KPIID));
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
            TempData["Date"] = KPI.Created;
            CreateKPIVM create = KPIs.AddKPI(KPI.Created);
            foreach (var assignment in create.AssignmentList)
            {
                assignment.Title = assignment.Employee.EmployeeName + " " + Teams.GetTeamByID(assignment.TeamID).TeamName;
            }
            return View("CreateKPI", create);
        }

        [HttpPost]
        public ActionResult CreateKPI(CreateKPIVM KPI)
        {
            KPIs.AddKPI(KPI);
            return RedirectToAction("Index", "KPI", new { area = "" });
        }

        //---------------------------------------------------------------------------------------------//

        public ActionResult ViewDCenter()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult ViewClientKPIs()
        {
            if (Session["Roles"].ToString().Contains("DIRECTOR") || Session["Roles"].ToString().Contains("ADMINISTRATOR"))
            {
                List<KPIVM> kpi = KPIs.GetAllKPIs();
                return View(kpi);
            }
            else
            {
                List<KPIVM> kpi = KPIs.GetKPIsForManager((int)Session["ID"]);
                return View(kpi);
            }
        }

        [HttpPost]
        public ActionResult ViewClientKPIs(FormCollection form)
        {
            DateTime StartDate = DateTime.Parse(form[0]);
            DateTime EndDate = DateTime.Parse(form[1]);
            int ClientID = int.Parse(form[2]);
            return View("Index", KPIs.GetClientKPIs(StartDate, EndDate, ClientID));
        }

        [HttpGet]
        public ActionResult ViewTeamKPIs()
        {
            if (Session["Roles"].ToString().Contains("DIRECTOR") || Session["Roles"].ToString().Contains("ADMINISTRATOR"))
            {
                CreateKPIVM kpi = new CreateKPIVM() { TeamList = Teams.GetAllTeams() };
                return View(kpi);
            }
            else if (Session["Roles"].ToString().Contains("MANAGER"))
            {
                CreateKPIVM kpi = new CreateKPIVM() { TeamList = Teams.GetTeamsForManager((int)Session["ID"]) };
                return View(kpi);
            }
            else
            {
                CreateKPIVM kpi = new CreateKPIVM() { TeamList = Teams.GetTeamsForLead((int)Session["ID"]) };
                return View(kpi);
            }
        }

        [HttpPost]
        public ActionResult ViewTeamKPIs(FormCollection form)
        {
            DateTime StartDate = DateTime.Parse(form[0]);
            DateTime EndDate = DateTime.Parse(form[1]);
            int TeamID = int.Parse(form[2]);
            return View("Index", KPIs.GetTeamsKPIs(StartDate, EndDate, TeamID));
        }

        [HttpGet]
        public ActionResult ViewIndividualKPI()
        {
            CreateKPIVM kpi = new CreateKPIVM() { EmployeeList = Employee.GetAllEmployees() };
            return View(kpi);
        }

        [HttpPost]
        public ActionResult ViewIndividualKPI(FormCollection form)
        {
            DateTime StartDate = DateTime.Parse(form[0]);
            DateTime EndDate = DateTime.Parse(form[1]);
            return View("Index", KPIs.GetIndividualKPIs(StartDate, EndDate));
        }

        //---------------------------------------------------------------------------------------------//

        public ActionResult ViewKPIPDF(string url)
        {
            var report = new UrlAsPdf(url);
            return report;
        }
    }
}