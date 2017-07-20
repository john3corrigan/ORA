using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using BusinessLogic.ORALogic;

namespace ORA.Controllers
{
    public class AssignmentController : Controller
    {
        private AssignmentLogic assignmentLogic = new AssignmentLogic();

        // GET: Assignment
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult CreateAssignment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAssignment(AssignmentVM Assignment)
        {
            assignmentLogic.CreateAssignment(Assignment);
            return RedirectToAction("ViewAssignments", "Assignments", new { area = ""});
        }

        public ActionResult ViewAllAssigments()
        {
            return View(assignmentLogic.GetAllAssignments());
        }

        public ActionResult ViewAssigment(int AssignmentID)
        {
            return View(assignmentLogic.GetAssignmentByAssignmentID(AssignmentID));
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateAssigments(int AssignmentID)
        {
            return View(assignmentLogic.GetAssignmentByAssignmentID(AssignmentID));
        }

        [HttpPost]
        public ActionResult UpdateAssigments(AssignmentVM updatedAssignment)
        {
            assignmentLogic.UpdateAssignment(updatedAssignment);
            return RedirectToAction("ViewAssignments", "Assignments", new { area = "" });
        }

        //[Authorize(Roles = "Admin, Director")]
        public ActionResult DeleteAssigments(int AssignmentID)
        {
            assignmentLogic.DeleteAssignmentByAssignmentID(AssignmentID);
            return RedirectToAction("ViewAssignments", "Assignments", new { area = "" });
        }
    }
}