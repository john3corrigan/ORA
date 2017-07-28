using Lib.ViewModels;
using System.Web.Mvc;
using Lib.InterfacesLogic;
using Lib.Attributes;

namespace ORA.Controllers
{
    [ORAAuthorize]
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
            return View(Employees.GetAllEmployees());
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
        [ORAAuthorize(Roles = "Admin")]
        public ActionResult AddEmployee(EmployeeVM Employee)
        {
            Employees.AddEmployee(Employee);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        [HttpGet]
        public ActionResult UpdateEmployee(int EmployeeID)
        {
            return View(Employees.GetEmployeeByID(EmployeeID));
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeVM updatedEmployee)
        {
            Employees.UpdateEmployee(updatedEmployee);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        [HttpPost]
        [ORAAuthorize(Roles = "Admin, Director")]
        public ActionResult DisableEmployee(int EmployeeID)
        {
            Employees.DisableEmployee(EmployeeID);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }
    }
}