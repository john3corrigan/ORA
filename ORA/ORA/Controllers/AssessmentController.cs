using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using BusinessLogic.ORALogic;

namespace ORA.Controllers
{
    public class AssessmentController : Controller
    {
        private AssessmentLogic assessmentLogic = new AssessmentLogic();
        static List<AssessmentVM> Model { get; set; }
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
            assessmentLogic.CreateAssessment(Assessment);
            return RedirectToAction("", "", new { area = "" });
        }

        public ActionResult ViewAllAssessments()
        {
            return View(assessmentLogic.GetAllAssessments());
        }

        public ActionResult ViewAssessment(int AssessmentID)
        {
            return View(assessmentLogic.GetAssessmentByAssessmentID(AssessmentID));
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateAssessment(int AssessmentID)
        {
            return View(assessmentLogic.GetAssessmentByAssessmentID(AssessmentID));
        }

        [HttpPost]
        public ActionResult UpdateAssessment(AssessmentVM updatedAssessment)
        {
            assessmentLogic.UpdateAssessment(updatedAssessment);
            return RedirectToAction("", "", new { area = "" });
        }

        public ActionResult DeleteAssessment(int AssessmentID)
        {
            assessmentLogic.DeleteAssessment(AssessmentID);
            return RedirectToAction("", "", new { area = "" });
        }
    }
}