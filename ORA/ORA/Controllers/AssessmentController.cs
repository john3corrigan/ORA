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
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
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

        public ActionResult ViewAllAssessments()
        {
            return View(Assessments.GetAllAssessments());
        }

        public ActionResult ViewAssessment(int AssessmentID)
        {
            return View(Assessments.GetAssessmentByID(AssessmentID));
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
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