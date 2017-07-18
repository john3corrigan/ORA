using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string replaceWithAppropriateValue)
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Register(string replaceWithAppropriateValue)
        {
            return View();
        }
        public ActionResult MyAccount()
        {
            return View();
        }
    }
}