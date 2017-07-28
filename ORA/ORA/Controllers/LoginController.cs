using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;
using System.Web.Security;

namespace ORA.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(EmployeeVM Employee)
        {
            EmployeeVM employee = Employees.Login(Employee);
            if (employee != null)
            {
                CreateCookie(employee);
                Session["Name"] = employee.EmployeeName;
                Session["Roles"] = RolesByUser(employee);
                Session["ID"] = employee.ProfileID;
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        private void CreateCookie(EmployeeVM employee)
        {
            FormsAuthentication.SetAuthCookie(employee.EmployeeName, false);
            var authTicket = new FormsAuthenticationTicket(1, employee.EmployeeName, DateTime.Now, DateTime.Now.AddMinutes(30), false, RolesByUser(employee));
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Response.Cookies.Add(authCookie);
        }

        private string RolesByUser(EmployeeVM employee)
        {
            List<string> Roles = new List<string>();
            foreach (AssignmentVM value in employee.Assignment)
            {
                if (!Roles.Contains(value.Role.RoleName))
                {
                    Roles.Add(value.Role.RoleName);
                }
            }
            string role = string.Empty;
            foreach (string value in Roles)
            {
                role += value + "|";
            }
            return role;
        }
    }
}