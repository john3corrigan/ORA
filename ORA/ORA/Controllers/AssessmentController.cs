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
       [ORAAuthorize(Roles = "ADMINISTRATOR, MANAGER, LEAD")]
        public ActionResult CreateAssessment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAssessment(AssessmentVM Assessment)
        {
            Assessments.AddAssessment(Assessment);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        public ActionResult ViewListAssessments(List<AssessmentVM> AssessmentList)
        {
            return View(AssessmentList);
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
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }
    }
}