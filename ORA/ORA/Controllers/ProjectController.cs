using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;


namespace ORA.Controllers
{
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
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(ProjectVM Project)
        {
            Projects.AddProject(Project);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        public ActionResult ViewAllProjects()
        {
            return View(Projects.GetAllProjects());
        }

        public ActionResult ViewProject(int ProjectID)
        {
            return View(Projects.GetProjectByID(ProjectID));
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
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