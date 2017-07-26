using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.ORALogic;
using Lib.InterfacesLogic;


namespace ORA.Controllers
{
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
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddClient(ClientVM Client)
        {
            Clients.AddClient(Client);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateClient(int ClientID)
        {
            return View(Clients.GetClientByID(ClientID));
        }

        [HttpPost]
        public ActionResult UpdateClient(ClientVM updatedClient)
        {
            Clients.UpdateClient(updatedClient);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        public ActionResult ViewClient(int AssignmentID)
        {
            return View(Clients.GetClientByID(AssignmentID));
        }

        //[Authorize(Roles = "Admin, Director")]
        public ActionResult ViewAllClients()
        {
            return View(Clients.GetAllClients());
        }

        //[Authorize(Roles = "Admin, Director")]
        public ActionResult DeleteClient(int ClientID)
        {
            Clients.RemoveClient(ClientID);
            return View();
        }
    }
}