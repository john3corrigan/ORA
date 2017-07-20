using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.ORALogic;

namespace ORA.Controllers
{
    public class ClientController : Controller
    {
        private ClientLogic clientLogic = new ClientLogic();

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
            clientLogic.AddClient(Client);
            return RedirectToAction("", "", new { area = "" });
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateClient(int ClientID)
        {
            return View(clientLogic.GetClientByClientID(ClientID));
        }

        [HttpPost]
        public ActionResult UpdateClient(ClientVM updatedClient)
        {
            clientLogic.UpdateClient(updatedClient);
            return View("");
        }

        public ActionResult ViewClient(int AssignmentID)
        {
            return View(clientLogic.GetClientByAssignmentID(AssignmentID));
        }

        //[Authorize(Roles = "Admin, Director")]
        public ActionResult ViewAllClients()
        {
            return View(clientLogic.GetAllClients());
        }

        //[Authorize(Roles = "Admin, Director")]
        public ActionResult DeleteClient(int ClientID)
        {
            clientLogic.DeleteClient(ClientID);
            return View("");
        }
    }
}