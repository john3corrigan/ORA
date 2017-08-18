using System.Collections.Generic;
using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;
using Lib.Attributes;
using System;

namespace ORA.Controllers
{
    [ORAAuthorize]
    public class AssessmentController : Controller
    {
        private IEmployeeLogic Employee;
        private IAssessmentLogic Assessments;


        public AssessmentController(IAssessmentLogic assess, IEmployeeLogic emp)
        {
            Assessments = assess;
            Employee = emp;
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

        public JsonResult GetAverage()
        {
            var averages = Assessments.GetAverage((int)Session["ID"]);
            return Json(averages.ToString(), JsonRequestBehavior.AllowGet);
        }
    }
}