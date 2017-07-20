using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using BusinessLogic.ORALogic;

namespace ORA.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectLogic projectLogic = new ProjectLogic();

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
            projectLogic.CreateProject(Project);
            return RedirectToAction("", "", new { area = "" });
        }

        public ActionResult ViewAllProjects()
        {
            return View(projectLogic.GetAllProjects());
        }

        public ActionResult ViewProject(int ProjectID)
        {
            return View(projectLogic.GetProjectByProjectID(ProjectID));
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateProject(int ProjectID)
        {
            return View(projectLogic.GetProjectByProjectID(ProjectID));
        }

        [HttpPost]
        public ActionResult UpdateProject(ProjectVM updatedProject)
        {
            projectLogic.UpdateProject(updatedProject);
            return RedirectToAction("", "", new { area = "" });
        }

        public ActionResult DeleteProject(int ProjectID)
        {
            projectLogic.DeleteProject(ProjectID);
            return RedirectToAction("", "", new { area = "" });
        }
    }
}