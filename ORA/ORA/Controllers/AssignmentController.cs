using System.Collections.Generic;
using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;
using Lib.Attributes;
using System.Collections;
using System;

namespace ORA.Controllers
{
    [ORAAuthorize]
    public class AssignmentController : Controller
    {
        private IAssignmentLogic Assignments;
        private IClientLogic Client;
        private IEmployeeLogic Employee;
        private ITeamLogic Team;

        public AssignmentController(IAssignmentLogic assign,
            IClientLogic clnt,
            IEmployeeLogic mply,
            ITeamLogic tms)
        {
            Assignments = assign;
            Client = clnt;
            Employee = mply;
            Team = tms;
        }

        // GET: Assignment
        public ActionResult Index()
        {
            if (Session["Roles"].ToString().Contains("DIRECTOR") || Session["Roles"].ToString().Contains("ADMINISTRATOR"))
            {
                return View(Assignments.GetAllAssignments());
            }
            else if (Session["Roles"].ToString().Contains("MANAGER"))
            {

                return View(Assignments.GetAssignmentsForManager((int)Session["ID"]));
            }
            else if (Session["Roles"].ToString().Contains("LEAD"))
            {
                return View(Assignments.GetAssignmentsForLead((int)Session["ID"]));
            }
            else
            {
                return View(Assignments.GetAllAssignmentsForEmployee((int)Session["ID"]));
            }
        }

        [ORAAuthorize(Roles = "MANAGER, DIRECTOR")]
        public ActionResult CreateAssignment()
        {
            return View(Assignments.AddAssignment());
        }

        [HttpPost]
        public ActionResult CreateAssignment(CreateAssignmentVM Assignment)
        {
            Assignments.AddAssignment(Assignment);
            return RedirectToAction("Index", "Home", new { area = ""});
        }

        public ActionResult ViewTeamAssignments(int TeamID)
        {
            return View("Index", Assignments.GetAllAssignmentsForTeam(TeamID));
        }

        public ActionResult ViewAssignment(int AssignmentID)
        {
            return View(Assignments.GetAssignmentByID(AssignmentID));
        }

        public ActionResult ViewEmployeeAssignment(int EmployeeID)
        {
            return View("Index", Assignments.GetAllAssignmentsForEmployee(EmployeeID));
        }

        [HttpGet]
        [ORAAuthorize(Roles = "MANAGER, DIRECTOR")]
        public ActionResult UpdateAssignments(int AssignmentID)
        {
            return View(Assignments.GetAssignmentByID(AssignmentID));
        }

        [HttpPost]
        public ActionResult UpdateAssignments(AssignmentVM updatedAssignment)
        {
            Assignments.UpdateAssignment(updatedAssignment);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        //---------------------------------------------------------------------------------------------//

        public ActionResult ViewDCenter()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult ViewClientAssignments()
        {
            if (Session["Roles"].ToString().Contains("DIRECTOR") || Session["Roles"].ToString().Contains("ADMINISTRATOR"))
            {
                CreateAssignmentVM assign = new CreateAssignmentVM() { ClientList = Client.GetAllClients() };
                return View(assign);
            }
            else
            {
                CreateAssignmentVM assign = new CreateAssignmentVM() { ClientList = Client.GetClientsManager((int)Session["ID"]) };
                return View(assign);
            }
        }

        [HttpPost]
        public ActionResult ViewClientAssignments(FormCollection form)
        {
            DateTime StartDate = DateTime.Parse(form[0]);
            DateTime EndDate = DateTime.Parse(form[1]);
            int ClientID = int.Parse(form[2]);
            return View("Index", Assignments.GetClientAssignments(StartDate, EndDate, ClientID));
        }

        [HttpGet]
        public ActionResult ViewTeamAssignments()
        {
            if (Session["Roles"].ToString().Contains("DIRECTOR") || Session["Roles"].ToString().Contains("ADMINISTRATOR"))
            {
                CreateAssignmentVM assign = new CreateAssignmentVM() { TeamList = Team.GetAllTeams() };
                return View(assign);
            }
            else if (Session["Roles"].ToString().Contains("MANAGER"))
            {
                CreateAssignmentVM assign = new CreateAssignmentVM() { TeamList = Team.GetTeamsForManager((int)Session["ID"]) };
                return View(assign);
            }
            else
            {
                CreateAssignmentVM assign = new CreateAssignmentVM() { TeamList = Team.GetTeamsForLead((int)Session["ID"]) };
                return View(assign);
            }
        }

        [HttpPost]
        public ActionResult ViewTeamAssignments(FormCollection form)
        {
            DateTime StartDate = DateTime.Parse(form[0]);
            DateTime EndDate = DateTime.Parse(form[1]);
            int TeamID = int.Parse(form[2]);
            return View("Index", Assignments.GetTeamsAssignments(StartDate, EndDate, TeamID));
        }
        [HttpGet]
        public ActionResult ViewIndividualAssignments()
        {
            CreateAssignmentVM assign = new CreateAssignmentVM() { EmployeeList = Employee.GetAllEmployees() };
            return View(assign);
        }

        [HttpPost]
        public ActionResult ViewIndividualAssignments(FormCollection form)
        {
            DateTime StartDate = DateTime.Parse(form[0]);
            DateTime EndDate = DateTime.Parse(form[1]);
            return View("Index", Assignments.GetIndividualAssignments(StartDate, EndDate));
        }

        //---------------------------------------------------------------------------------------------//
    }
}