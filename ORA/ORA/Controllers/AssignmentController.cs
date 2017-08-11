using System.Collections.Generic;
using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;
using Lib.Attributes;
using System.Collections;

namespace ORA.Controllers
{
    [ORAAuthorize]
    public class AssignmentController : Controller
    {
        private IAssignmentLogic Assignments;
        public AssignmentController(IAssignmentLogic assign)
        {
            Assignments = assign;
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
                return View(Assignments
                    .GetAllAssignmentsForEmployee((int)Session["ID"]));
            }
        }

        [ORAAuthorize(Roles = "ADMINISTRATOR, MANAGER, DIRECTOR")]
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
        [ORAAuthorize(Roles = "ADMINISTRATOR, MANAGER, DIRECTOR")]
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
    }
}