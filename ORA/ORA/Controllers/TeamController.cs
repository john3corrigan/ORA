using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using BusinessLogic.ORALogic;

namespace ORA.Controllers
{
    public class TeamController : Controller
    {
        private TeamLogic teamLogic = new TeamLogic();

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
            teamLogic.CreateTeam(Team);
            return RedirectToAction("", "", new { area = "" });
        }

        public ActionResult ViewAllTeams()
        {
            return View(teamLogic.GetAllTeams());
        }

        public ActionResult ViewTeam(int TeamID)
        {
            return View(teamLogic.GetTeamByTeamID(TeamID));
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateTeam(int TeamID)
        {
            return View(teamLogic.GetTeamByTeamID(TeamID));
        }

        [HttpPost]
        public ActionResult UpdateTeam(TeamVM updatedTeam)
        {
            teamLogic.UpdateTeam(updatedTeam);
            return RedirectToAction("", "", new { area = "" });
        }

        public ActionResult DeleteTeam(int TeamID)
        {
            teamLogic.DeleteTeam(TeamID);
            return RedirectToAction("", "", new { area = "" });
        }
    }
}