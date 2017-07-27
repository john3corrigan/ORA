using Lib.ViewModels;
using System.Web.Mvc;
using Lib.InterfacesLogic;
using Lib.Attributes;

namespace ORA.Controllers
{
    //[Authorize]
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
            return View(Sprints.GetAllSprints());
        }

        [HttpGet]
        [ORAAuthorize(Roles = "Admin, Director")]
        public ActionResult CreateSprint()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSprint(SprintVM Sprint)
        {
            Sprints.AddSprint(Sprint);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        public ActionResult ViewSprint(int SprintID)
        {
            return View(Sprints.GetSprintByID(SprintID));
        }

        [HttpGet]
        [ORAAuthorize(Roles = "Admin, Director")]
        public ActionResult UpdateSprint(int SprintID)
        {
            return View(Sprints.GetSprintByID(SprintID));
        }

        [HttpPost]
        public ActionResult UpdateSprint(SprintVM updatedSprint)
        {
            Sprints.UpdateSprint(updatedSprint);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        public ActionResult DeleteSprint(int SprintID)
        {
            Sprints.DeleteSprint(SprintID);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }
    }
}