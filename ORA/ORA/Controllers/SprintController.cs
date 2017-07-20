using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.ORALogic;

namespace ORA.Controllers
{
    public class SprintController : Controller
    {
        private SprintLogic sprintLogic = new SprintLogic();

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
            sprintLogic.CreateSprint(Sprint);
            return RedirectToAction("", "", new { area = "" });
        }

        public ActionResult ViewAllSprints()
        {
            return View(sprintLogic.GetAllSprints());
        }

        public ActionResult ViewSprint(int SprintID)
        {
            return View(sprintLogic.GetSprintBySprintID(SprintID));
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateSprint(int SprintID)
        {
            return View(sprintLogic.GetSprintBySprintID(SprintID));
        }

        [HttpPost]
        public ActionResult UpdateSprint(SprintVM updatedSprint)
        {
            sprintLogic.UpdateSprint(updatedSprint);
            return RedirectToAction("", "", new { area = "" });
        }

        public ActionResult DeleteSprint(int SprintID)
        {
            sprintLogic.DeleteSprint(SprintID);
            return RedirectToAction("", "", new { area = "" });
        }
    }
}