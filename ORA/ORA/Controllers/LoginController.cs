using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Lib.ViewModels;
using Lib.InterfacesLogic;
using System.Web.Security;
using Lib.Attributes;

namespace ORA.Controllers
{
    [ORAAuthorize]
    public class LoginController : Controller
    {
        private IEmployeeLogic Employees;
        private IAssignmentLogic Assignments;
        private IRoleLogic Role;

        public LoginController(IEmployeeLogic emply, IAssignmentLogic assign, IRoleLogic roles)
        {
            Employees = emply;
            Assignments = assign;
            Role = roles;
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
            return PartialView();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(EmployeeVM Employee)
        {
            EmployeeVM employee = Employees.Login(Employee);
            if (employee != null)
            {
                employee.Assignment = Assignments.GetAllAssignmentsForEmployee(employee.EmployeeID);
                employee.Assignment[0].Role = new RoleVM();
                employee.Assignment[0].Role.RoleName = "test";
                CreateCookie(employee);
                Session["Name"] = employee.EmployeeName;
                Session["Roles"] = RolesByUser(employee);
                Session["ID"] = employee.ProfileID;
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return PartialView();
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
                RoleVM rolevm = Role.GetRoleByID(value.RoleID);
                if (!Roles.Contains(rolevm.RoleName))
                {
                    Roles.Add(rolevm.RoleName);
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