using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using BusinessLogic.ORALogic;
using Lib.InterfacesLogic;


namespace ORA.Controllers
{
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
            return View();
        }
        
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult CreateAssignment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAssignment(AssignmentVM Assignment, FormCollection collection)
        {
            Assignment.ClientID = Convert.ToInt32(collection["Client"]);
            Assignments.AddAssignment(Assignment);
            return RedirectToAction("Dashboard", "Home", new { area = ""});
        }

        public ActionResult ViewAllAssigments()
        {
            return View(Assignments.GetAllAssignments());
        }

        public ActionResult ViewAssigment(int AssignmentID)
        {
            return View(Assignments.GetAssignmentByID(AssignmentID));
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateAssigments(int AssignmentID)
        {
            return View(Assignments.GetAssignmentByID(AssignmentID));
        }

        [HttpPost]
        public ActionResult UpdateAssigments(AssignmentVM updatedAssignment)
        {
            Assignments.UpdateAssignment(updatedAssignment);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }
        public JsonResult GetAssignments()
        {
            var List = Assignments.GetAllAssignments();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
    }
}