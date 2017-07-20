using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.ORALogic;

namespace ORA.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeLogic employeeLogic = new EmployeeLogic();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAllEmployees()
        {
            return View(employeeLogic.ViewAllEmployees());
        }

        public ActionResult ViewEmployee(int EmployeeID)
        {
            return View(employeeLogic.GetEmployeeByEmployeeID(EmployeeID));
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
            employeeLogic.AddEmployee(Employee);
            return RedirectToAction("", "", new { area = "" });
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateEmployee(int EmployeeID)
        {
            return View(employeeLogic.GetEmployeeByEmployeeID(EmployeeID));
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeVM updatedEmployee)
        {
            employeeLogic.UpdateEmployee(updatedEmployee);
            return RedirectToAction("", "", new { area = "" });
        }

        [HttpPost]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult DisableEmployee(int EmployeeID)
        {
            employeeLogic.DieableEmployee(EmployeeID);
            return RedirectToAction("", "", new { area = "" });
        }

    }
}