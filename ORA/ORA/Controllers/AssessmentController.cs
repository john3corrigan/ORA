using System.Collections.Generic;
using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;
using Lib.Attributes;

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
            return View(Employee.GetAllEmployees());
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
        public ActionResult CreateAssessment(CreateAssessmentVM Assessment)
        {
            Assessments.AddAssessment(Assessment, (int)Session["Team"]);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpPost]
        [ORAAuthorize(Roles = "ADMINISTRATOR, DIRECTOR, MANAGER, LEAD")]
        public ActionResult GetEmployeeAssessment(CreateAssessmentVM Assessment)
        {
            TempData["Stage"] = 2;
            TempData["Created"] = Assessment.Created;
            return View("CreateAssessment", Assessments.AddAssessment(Assessment.Created, (int)Session["ID"], (int)Session["Team"]));
        }

        public ActionResult ViewAssessment(int AssessmentID)
        {
            //return View(Assessments.GetAssessmentByID(AssessmentID));
            return View(Assessments.GetAssessmentByEmployeeID(AssessmentID));
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
    }
}