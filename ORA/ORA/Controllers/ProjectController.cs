using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;
using Lib.Attributes;
using System.Collections.Generic;

namespace ORA.Controllers
{
    [Authorize]
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

        public ActionResult ViewListProjectsByClient(int ClientID)
        {
            return View("Index", Projects.GetProjectByClientID(ClientID));
        }
        
        [HttpGet]
        [ORAAuthorize(Roles = "MANAGER, DIRECTOR")]
        public ActionResult CreateProject()
        {
            return View(Projects.AddProject());
        }

        [HttpPost]
        public ActionResult CreateProject(CreateProjectVM Project)
        {
            Projects.AddProject(Project);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult ViewProject(int ProjectID)
        {
            return View(Projects.GetProjectByID(ProjectID));
        }

        [HttpGet]
        [ORAAuthorize(Roles = "MANAGER, DIRECTOR")]
        public ActionResult UpdateProject(int ProjectID)
        {
            return View(Projects.GetProjectByID(ProjectID));
        }

        [HttpPost]
        public ActionResult UpdateProject(ProjectVM updatedProject)
        {
            Projects.UpdateProject(updatedProject);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [ORAAuthorize(Roles = "DIRECTOR")]
        public ActionResult DeleteProject(int ProjectID)
        {
            Projects.DeleteProject(ProjectID);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}