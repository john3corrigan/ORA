using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;
using Lib.Attributes;
using System.Collections.Generic;

namespace ORA.Controllers
{
    [ORAAuthorize]
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
            return View(Teams.GetAllTeams());
        }

        [HttpGet]
        public ActionResult CreateTeam()
        {
            return View(Teams.AddTeam());
        }

        [HttpPost]
        [ORAAuthorize(Roles = "ADMINISTRATOR, DIRECTOR")]
        public ActionResult CreateTeam(CreateTeamVM Team)
        {
            Teams.AddTeam(Team);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        public ActionResult ViewTeam(int TeamID)
        {
            return View(Teams.GetTeamByID(TeamID));
        }

        public ActionResult ViewListTeams(List<TeamVM> TeamsList)
        {
            return View(TeamsList);
        }

        [HttpGet]
        [ORAAuthorize(Roles = "ADMINISTRATOR, MANAGER, DIRECTOR")]
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

        [ORAAuthorize(Roles = "ADMINISTRATOR, DIRECTOR")]
        public ActionResult DeleteTeam(int TeamID)
        {
            Teams.DeleteTeam(TeamID);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }
    }
}