﻿using Lib.ViewModels;
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
            return View(Clients.GetAllClients());
        }

        [HttpGet]
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

        [ORAAuthorize(Roles = "Admin, Director")]
        public ActionResult DeleteClient(int ClientID)
        {
            Clients.RemoveClient(ClientID);
            return View();
        }
    }
}