using System.Collections.Generic;
using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;
using Lib.Attributes;
using System;
using Newtonsoft.Json.Linq;
using Rotativa;

namespace ORA.Controllers
{
    [ORAAuthorize]
    public class AssessmentController : Controller
    {
        private IEmployeeLogic Employee;
        private IAssessmentLogic Assessments;
        private IClientLogic Client;
        private ITeamLogic Team;

        public AssessmentController(IAssessmentLogic assess, 
            IEmployeeLogic emp,
            IClientLogic clnt,
            ITeamLogic tm)
        {
            Assessments = assess;
            Employee = emp;
            Client = clnt;
            Team = tm;
        }


        // GET: Assessment
        public ActionResult Index()
        {
            if (Session["Roles"].ToString().Contains("DIRECTOR") || Session["Roles"].ToString().Contains("ADMINISTRATOR"))
            {
                TempData["Stage"] = 2;
                return View(Employee.GetAllEmployees());
            }
            else if (Session["Roles"].ToString().Contains("MANAGER") || Session["Roles"].ToString().Contains("LEAD"))
            {
                TempData["Stage"] = 1;
                return View();
            }
            else if (Session["Roles"].ToString().Contains("EMPLOYEE"))
            {
                TempData["Stage"] = 3;
                int ID = (int)Session["ID"];
                return RedirectToAction("ViewAssessment", "Assessment", routeValues: new { EmployeeID = ID});
            }
            else
            {
                return View();
            }
        }

        public ActionResult GetEmployeesAssessments(FormCollection form)
        {
            if (Session["Roles"].ToString().Contains("MANAGER"))
            {
                TempData["Stage"] = 2;
                return View("Index", Assessments.GetAssessmentForServiceManager((int)Session["ID"], DateTime.Parse(form[0]), DateTime.Parse(form[1])));
            }
            else
            {
                TempData["Stage"] = 2;
                return View("Index", Assessments.GetAssessmentForTeamLead((int)Session["ID"], DateTime.Parse(form[0]), DateTime.Parse(form[1])));
            }
        }

        [HttpGet]
        [ORAAuthorize(Roles = "ADMINISTRATOR, DIRECTOR, MANAGER, LEAD")]
        public ActionResult CreateAssessment()
        {
            TempData["Stage"] = 1;
            return View();
        }

        [HttpPost]
        [ORAAuthorize(Roles = "ADMINISTRATOR, DIRECTOR, MANAGER, LEAD")]
        public ActionResult GetEmployeeAssessment(CreateAssessmentVM Assessment)
        {
            TempData["Stage"] = 2;
            TempData["Created"] = Assessment.Created;
            return View("CreateAssessment", Assessments.AddAssessment(Assessment.Created, (int)Session["ID"]));
        }

        [HttpPost]
        [ORAAuthorize(Roles = "ADMINISTRATOR, DIRECTOR, MANAGER, LEAD")]
        public ActionResult CreateAssessment(CreateAssessmentVM Assessment)
        {
            Assessments.AddAssessment(Assessment);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        
        public ActionResult ViewAssessment(int EmployeeID)
        {
            TempData["EmployeeName"] = Employee.GetEmployeeByID(EmployeeID).EmployeeName;
            return View(Assessments.GetAssessmentByEmployeeID(EmployeeID));
        }

        public ActionResult ViewAssessmentByAssignmentID(int AssignmentID)
        {
            return View("ViewAssessment", Assessments.GetAssessmentByAssignmentID(AssignmentID));
        }

        [HttpGet]
        [ORAAuthorize(Roles = "ADMINISTRATOR, MANAGER, DIRECTOR, LEAD")]
        public ActionResult UpdateAssessment(int AssessmentID)
        {
            return View(Assessments.GetAssessmentByID(AssessmentID));
        }

        [HttpPost]
        public ActionResult UpdateAssessment(AssessmentVM updatedAssessment)
        {
            Assessments.UpdateAssessment(updatedAssessment);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        //------------------------------------------------------------------------------------------------------------//

        public ActionResult ViewDCenter()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult ViewClientAssessments()
        {
            if (Session["Roles"].ToString().Contains("DIRECTOR") || Session["Roles"].ToString().Contains("ADMINISTRATOR"))
            {
                CreateAssessmentVM assess = new CreateAssessmentVM() { ClientList = Client.GetAllClients() };
                return View(assess);
            }
            else
            {
                CreateAssessmentVM assess = new CreateAssessmentVM() { ClientList = Client.GetClientsManager((int)Session["ID"]) };
                return View(assess);
            }
        }

        [HttpPost]
        public ActionResult ViewClientAssessments(FormCollection form)
        {
            DateTime StartDate = DateTime.Parse(form[0]);
            DateTime EndDate = DateTime.Parse(form[1]);
            int ClientID = int.Parse(form[2]);
            return View("ViewAssessment", Assessments.GetClientAssessments(StartDate, EndDate, ClientID));
        }

        [HttpGet]
        public ActionResult ViewTeamAssessments()
        {
            if (Session["Roles"].ToString().Contains("DIRECTOR") || Session["Roles"].ToString().Contains("ADMINISTRATOR"))
            {
                CreateAssessmentVM assess = new CreateAssessmentVM() { TeamList = Team.GetAllTeams() };
                return View(assess);
            }
            else if(Session["Roles"].ToString().Contains("MANAGER"))
            {
                CreateAssessmentVM assess = new CreateAssessmentVM() { TeamList = Team.GetTeamsForManager((int)Session["ID"]) };
                return View(assess);
            }
            else
            {
                CreateAssessmentVM assess = new CreateAssessmentVM() { TeamList = Team.GetTeamsForLead((int)Session["ID"]) };
                return View(assess);
            }
        }

        [HttpPost]
        public ActionResult ViewTeamAssessments(FormCollection form)
        {
            DateTime StartDate = DateTime.Parse(form[0]);
            DateTime EndDate = DateTime.Parse(form[1]);
            int TeamID = int.Parse(form[2]);
            return View("ViewAssessment", Assessments.GetTeamsAssessments(StartDate, EndDate, TeamID));
        }
        [HttpGet]
        public ActionResult ViewIndividualAssessments()
        {
            CreateAssessmentVM assess = new CreateAssessmentVM() { EmployeeList = Employee.GetAllEmployees() };
            return View(assess);
        }

        [HttpPost]
        public ActionResult ViewIndividualAssessments(FormCollection form)
        {
            DateTime StartDate = DateTime.Parse(form[0]);
            DateTime EndDate = DateTime.Parse(form[1]);
            return View("ViewAssessment", Assessments.GetIndividualAssessments(StartDate, EndDate));
        }

        //------------------------------------------------------------------------------------------------------------------//

        public JsonResult GetAverage(string profileID)
        {
            var averages = Assessments.GetAverage(Convert.ToInt32(profileID));
            return Json(averages.ToString(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewAssessmentPDF(string url)
        {
            var report = new UrlAsPdf(url);
            return report;
        }
    }
}