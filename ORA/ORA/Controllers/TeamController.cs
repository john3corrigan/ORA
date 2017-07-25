using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;


namespace ORA.Controllers
{
    public class TeamController : Controller
    {
        private ITeamLogic Teams;

        public TeamController(ITeamLogic tm)
        {
            Teams = tm;
        }

        // GET: Team
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult CreateTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTeam(TeamVM Team)
        {
            Teams.AddTeam(Team);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        public ActionResult ViewAllTeams()
        {
            return View(Teams.GetAllTeams());
        }

        public ActionResult ViewTeam(int TeamID)
        {
            return View(Teams.GetTeamByID(TeamID));
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateTeam(int TeamID)
        {
            return View(Teams.GetTeamByID(TeamID));
        }

        [HttpPost]
        public ActionResult UpdateTeam(TeamVM updatedTeam)
        {
            Teams.UpdateTeam(updatedTeam);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        public ActionResult DeleteTeam(int TeamID)
        {
            Teams.DeleteTeam(TeamID);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }
    }
}