using Lib.InterfacesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class HomeController : Controller
    {
        // GET: Assignment
        public ActionResult Index()
        {
            if (Session.SessionID != null)
            {
                return View("Index");
            }
            else
            {
                return PartialView("Login");
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}