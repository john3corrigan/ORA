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
            return View(Assignments.GetAllAssignments());
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

        public ActionResult ViewListAssignments(int AssignmentsList)
        {
            return View("Index", AssignmentsList);
        }

        public ActionResult ViewAssigment(int AssignmentID)
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