using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.ORALogic;
using Lib.InterfacesLogic;


namespace ORA.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeLogic Employees;

        public EmployeeController(IEmployeeLogic emply)
        {
            Employees = emply;
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAllEmployees()
        {
            return View(Employees.ViewAllEmployees());
        }

        public ActionResult ViewEmployee(int EmployeeID)
        {
            return View(Employees.GetEmployeeByID(EmployeeID));
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
            Employees.AddEmployee(Employee);
            return RedirectToAction("", "", new { area = "" });
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateEmployee(int EmployeeID)
        {
            return View(Employees.GetEmployeeByID(EmployeeID));
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeVM updatedEmployee)
        {
            Employees.UpdateEmployee(updatedEmployee);
            return RedirectToAction("", "", new { area = "" });
        }

        [HttpPost]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult DisableEmployee(int EmployeeID)
        {
            Employees.DisableEmployee(EmployeeID);
            return RedirectToAction("", "", new { area = "" });
        }

    }
}