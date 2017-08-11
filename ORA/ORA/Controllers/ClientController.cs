using Lib.ViewModels;
using System.Web.Mvc;
using Lib.InterfacesLogic;
using Lib.Attributes;

namespace ORA.Controllers
{
    [ORAAuthorize]
    public class ClientController : Controller
    {
        private IClientLogic Clients;

        public ClientController(IClientLogic clnts)
        {
            Clients = clnts;
        }

        // GET: Client
        public ActionResult Index()
        {
            if (Session["Roles"].ToString().Contains("DIRECTOR") || Session["Roles"].ToString().Contains("ADMINISTRATOR"))
            {
                return View(Clients. GetAllClients());
            }
            else if (Session["Roles"].ToString().Contains("MANAGER"))
            {
                return View(Clients.GetClientsManager((int)Session["ID"]));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [ORAAuthorize(Roles = "ADMINISTRATOR, DIRECTOR")]
        public ActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddClient(ClientVM Client)
        {
            Clients.AddClient(Client);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        [ORAAuthorize(Roles = "ADMINISTRATOR, DIRECTOR")]
        public ActionResult UpdateClient(int ClientID)
        {
            return View(Clients.GetClientByID(ClientID));
        }

        [HttpPost]
        public ActionResult UpdateClient(ClientVM updatedClient)
        {
            Clients.UpdateClient(updatedClient);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult ViewClient(int ClientID)
        {
            return View(Clients.GetClientByID(ClientID));
        }

        [ORAAuthorize(Roles = "ADMINISTRATOR, DIRECTOR")]
        public ActionResult DeleteClient(int ClientID)
        {
            Clients.RemoveClient(ClientID);
            return View();
        }
    }
}