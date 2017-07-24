using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.InterfacesLogic;


namespace ORA.Controllers
{
    public class SprintController : Controller
    {
        private ISprintLogic Sprints;

        public SprintController(ISprintLogic sprnt)
        {
            Sprints = sprnt;
        }

        // GET: Sprint
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult CreateSprint()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSprint(SprintVM Sprint)
        {
            Sprints.AddSprint(Sprint);
            return RedirectToAction("", "", new { area = "" });
        }

        public ActionResult ViewAllSprints()
        {
            return View(Sprints.GetAllSprints());
        }

        public ActionResult ViewSprint(int SprintID)
        {
            return View(Sprints.GetSprintByID(SprintID));
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateSprint(int SprintID)
        {
            return View(Sprints.GetSprintByID(SprintID));
        }

        [HttpPost]
        public ActionResult UpdateSprint(SprintVM updatedSprint)
        {
            Sprints.UpdateSprint(updatedSprint);
            return RedirectToAction("", "", new { area = "" });
        }

        public ActionResult DeleteSprint(int SprintID)
        {
            Sprints.DeleteSprint(SprintID);
            return RedirectToAction("", "", new { area = "" });
        }
        public JsonResult GetSprints()
        {
            var List = Sprints.GetAllSprints();
            return Json(List, JsonRequestBehavior.AllowGet);
        }
    }
}