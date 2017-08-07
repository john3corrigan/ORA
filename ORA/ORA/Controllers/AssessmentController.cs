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
        private IAssessmentLogic Assessments;

        public AssessmentController(IAssessmentLogic assess)
        {
            Assessments = assess;
        }
        // GET: Assessment
        public ActionResult Index()
        {
            return View(Assessments.GetAllAssessments());
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

        public ActionResult ViewListAssessments(int AssignmentID)
        {
            return View("Index", Assessments.GetAssessmentByAssignmentID(AssignmentID));
        }

        public ActionResult ViewAssessment(int AssessmentID)
        {
            return View(Assessments.GetAssessmentByID(AssessmentID));
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