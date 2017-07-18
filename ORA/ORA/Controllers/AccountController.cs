using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using BusinessLogic;

namespace ORA.Controllers
{
    public class AccountController : Controller
    {
        static ORALogic _businesslogic = new ORALogic();
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
            if (_businesslogic.Login(Employee))
            {
                Session["Name"] = Employee.EmployeeName;
                Session["Role"] = Employee.Title;
            }
            return View();
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult AddEmployee(EmployeeVM Employee)
        {
            _businesslogic.AddEmployee(Employee);
            return View();
        }
        public ActionResult MyAccount()
        {
            return View();
        }
    }
}