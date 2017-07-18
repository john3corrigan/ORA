using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;

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
        public ActionResult Login(EmployeeVM Employee)
        {
            return View();
        }
        public ActionResult AddEmployee()
        {
            return View();
        }
        public ActionResult AddEmployee(EmployeeVM Employee)
        {
            return View();
        }
        public ActionResult MyAccount()
        {
            return View();
        }
    }
}