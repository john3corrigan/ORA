using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using BusinessLogic;

namespace ORA.Controllers
{
    public class DashboardController : Controller
    {
        static ORALogic _businesslogic = new ORALogic();
        // GET: Dashboard
        public ActionResult Index()
        {
            return View(_businesslogic.GetAssignmentsByEmployeeID((int)Session["MyID"]));
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
        public ActionResult UpdateAssigments(int AssignmentID)
        {
            return View(_businesslogic.GetAssignmentByAssignmentID(AssignmentID));
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
        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateClient(int ClientID)
        {
            return View(_businesslogic.GetClientByClientID(ClientID));
        }
        [HttpPost]
        public ActionResult UpdateClient(ClientVM updatedClient)
        {
            return View("");
        }
        public ActionResult ViewClient(int AssignmentID)
        {
            return View(_businesslogic.GetClientByAssignmentID(AssignmentID));
        }
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult DeleteClient(int ClientID)
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
        public ActionResult ViewKPI(int AssignmentID)
        {
            return View(_businesslogic.GetKPIByAssignmentID(AssignmentID));
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
        public ActionResult UpdateSprint(int SprintID)
        {
            return View(_businesslogic.GetSprintBySprintID(SprintID));
        }
        [HttpPost]
        public ActionResult UpdateSprint(SprintVM updatedSprint)
        {
            return View("");
        }
        public ActionResult DeleteSprint(int SprintID)
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
        public ActionResult UpdateStory(int StoryID)
        {
            return View(_businesslogic.GetStoryByStoryID(StoryID));
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