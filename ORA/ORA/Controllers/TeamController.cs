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
            if (Session["Roles"].ToString().Contains("DIRECTOR") || Session["Roles"].ToString().Contains("ADMINISTRATOR"))
            {
                return View(Teams.GetAllTeams());
            }
            else if (Session["Roles"].ToString().Contains("MANAGER"))
            {
                return View(Teams.GetTeamsForManager((int)Session["ID"]));
            }
            else if (Session["Roles"].ToString().Contains("LEAD"))
            {
                return View(Teams.GetTeamsForLead((int)Session["ID"]));
            }
            else
            {
                return View(Teams.GetTeamsForEmployee((int)Session["ID"]));
            }
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
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult ViewTeam(int TeamID)
        {
            return View(Teams.GetTeamByID(TeamID));
        }

        public ActionResult ViewListTeamsByClient(int ClientID)
        {
            return View("Index", Teams.GetTeamByClientID(ClientID));
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
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [ORAAuthorize(Roles = "ADMINISTRATOR, DIRECTOR")]
        public ActionResult DeleteTeam(int TeamID)
        {
            Teams.DeleteTeam(TeamID);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}