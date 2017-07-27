using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;
using Lib.Attributes;

namespace ORA.Controllers
{
    //[Authorize]
    public class ProjectController : Controller
    {
        private IProjectLogic Projects;

        public ProjectController(IProjectLogic prjct)
        {
            Projects = prjct;
        }

        // GET: Project
        public ActionResult Index()
        {
            return View(Projects.GetAllProjects());
        }

        [HttpGet]
        [ORAAuthorize(Roles = "Admin, Director")]
        public ActionResult CreateProject()
        {
            return View(Projects.AddProject());
        }

        [HttpPost]
        public ActionResult CreateProject(CreateProjectVM Project)
        {
            Projects.AddProject(Project);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        public ActionResult ViewProject(int ProjectID)
        {
            return View(Projects.GetProjectByID(ProjectID));
        }

        [HttpGet]
        [ORAAuthorize(Roles = "Admin, Director")]
        public ActionResult UpdateProject(int ProjectID)
        {
            return View(Projects.GetProjectByID(ProjectID));
        }

        [HttpPost]
        public ActionResult UpdateProject(ProjectVM updatedProject)
        {
            Projects.UpdateProject(updatedProject);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        public ActionResult DeleteProject(int ProjectID)
        {
            Projects.DeleteProject(ProjectID);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }
    }
}