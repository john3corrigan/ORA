using Lib.ViewModels;
using System.Web.Mvc;
using Lib.InterfacesLogic;
using Lib.Attributes;

namespace ORA.Controllers
{
    [ORAAuthorize]
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
        [ORAAuthorize(Roles = "MANAGER, DIRECTOR, LEAD")]
        public ActionResult CreateSprint()
        {
            return View();
        }

        [HttpPost]
        [ORAAuthorize(Roles = "MANAGER, DIRECTOR, LEAD")]
        public ActionResult CreateSprint(SprintVM Sprint)
        {
            Sprints.AddSprint(Sprint);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult ViewSprint(int SprintID)
        {
            return View(Sprints.GetSprintByID(SprintID));
        }

        [HttpGet]
        [ORAAuthorize(Roles = "MANAGER, DIRECTOR, LEAD")]
        public ActionResult UpdateSprint(int SprintID)
        {
            return View(Sprints.GetSprintByID(SprintID));
        }

        [HttpPost]
        public ActionResult UpdateSprint(SprintVM updatedSprint)
        {
            Sprints.UpdateSprint(updatedSprint);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [ORAAuthorize(Roles = "DIRECTOR")]
        public ActionResult DeleteSprint(int SprintID)
        {
            Sprints.DeleteSprint(SprintID);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}