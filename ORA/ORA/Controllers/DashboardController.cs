using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;

namespace ORA.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View("");
        }
        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult CreateAssignment()
        {
            return View("");
        }
        [HttpPost]
        public ActionResult CreateAssignment(AssignmentVM updatedAssignment)
        {
            return View("");
        }
        public ActionResult ViewAssigments()
        {
            return View("");
        }
        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateAssigments()
        {
            return View("");
        }
        [HttpPost]
        public ActionResult UpdateAssigments(AssignmentVM updatedAssignment)
        {
            return View("");
        }
        public ActionResult DeleteAssigments(int AssignmentID)
        {
            return View("");
        }
        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult AddClient()
        {
            return View("");
        }
        [HttpPost]
        public ActionResult AddClient(ClientVM Client)
        {
            return View("");
        }
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult DeleteClient(ClientVM ClientID)
        {
            return View("");
        }
        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateClient(int ClientID)
        {
            return View("");
        }
        [HttpPost]
        public ActionResult UpdateClient(ClientVM updatedClient)
        {
            return View("");
        }
        public ActionResult ViewClient()
        {
            return View("");
        }
        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult CreateKPI()
        {
            return View("");
        }
        [HttpPost]
        public ActionResult CreateKPI(KPIVM KPI)
        {
            return View("");
        }
        public ActionResult ViewKPI()
        {
            return View("");
        }
        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult CreateSprint()
        {
            return View("");
        }
        [HttpPost]
        public ActionResult CreateSprint(SprintVM Sprint)
        {
            return View("");
        }
        public ActionResult ViewSprint()
        {
            return View("");
        }
        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateSprint()
        {
            return View("");
        }
        [HttpPost]
        public ActionResult UpdateSprint(SprintVM updatedSprint)
        {
            return View("");
        }
        public ActionResult DeleteSprint()
        {
            return View("");
        }
        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult CreateStory()
        {
            return View("");
        }
        [HttpPost]
        public ActionResult CreateStory(StoryVM Story)
        {
            return View("");
        }
        public ActionResult ViewStory()
        {
            return View("");
        }
        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateStory()
        {
            return View("");
        }
        [HttpPost]
        public ActionResult UpdateStory(StoryVM updatedStory)
        {
            return View("");
        }
        public ActionResult DeleteStory(int StoryID)
        {
            return View("");
        }
    }
}