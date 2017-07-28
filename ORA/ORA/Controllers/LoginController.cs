using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;


namespace ORA.Controllers
{
    public class LoginController : Controller
    {
        private IEmployeeLogic Employees;

        public LoginController(IEmployeeLogic emply)
        {
            Employees = emply;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Login(EmployeeVM Employee)
        {
            EmployeeVM employee = Employees.Login(Employee);
            if (employee != null)
            {
                Session["Name"] = employee.EmployeeName;
                Session["MyID"] = employee.EmployeeID;
            }
            return PartialView();
        }
        
        public ActionResult LogOut()
        {
            Session.Clear();
            return View();
        }
    }
}