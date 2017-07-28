using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;
using Lib.Attributes;

namespace ORA.Controllers
{
    [Authorize]
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
        [ORAAuthorize(Roles = "Admin, Director")]
        public ActionResult CreateTeam()
        {
            return View(Teams.AddTeam());
        }

        [HttpPost]
        public ActionResult CreateTeam(CreateTeamVM Team)
        {
            Teams.AddTeam(Team);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        public ActionResult ViewTeam(int TeamID)
        {
            return View(Teams.GetTeamByID(TeamID));
        }

        [HttpGet]
        [ORAAuthorize(Roles = "Admin, Director")]
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