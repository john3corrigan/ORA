using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using BusinessLogic.ORALogic;

namespace ORA.Controllers
{
    public class LoginController : Controller
    {
        EmployeeLogic EmpLogic = new EmployeeLogic();
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
            EmployeeVM employee = EmpLogic.Login(Employee);
            if (employee != null)
            {
                Session["Name"] = employee.EmployeeName;
                Session["MyID"] = employee.EmployeeID;
                Session["Role"] = employee.Title;
            }
            return View();
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin, Director")]
        public ActionResult AddEmployee(EmployeeVM Employee)
        {
            AddEmployee(Employee);
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return View();
        }
    }
}