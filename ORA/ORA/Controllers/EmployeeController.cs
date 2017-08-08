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
        [ORAAuthorize(Roles = "ADMINISTRATOR, DIRECTOR")]
        public ActionResult Index()
        {
            return View(Employees.GetAllEmployees());
        }

        public ActionResult ViewEmployee(int EmployeeID)
        {
            return View(Employees.GetEmployeeByID(EmployeeID));
        }
        [HttpGet]
        [ORAAuthorize(Roles = "ADMINISTRATOR")]
        public ActionResult AddEmployee()
        {
            return View(Employees.AddEmployee());
        }

        [HttpPost]
        [ORAAuthorize(Roles = "ADMINISTRATOR")]
        public ActionResult AddEmployee(CreateEmployeeVM Employee)
        {
            Employees.AddEmployee(Employee);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        [ORAAuthorize(Roles = "ADMINISTRATOR")]
        public ActionResult UpdateEmployee(int EmployeeID)
        {
            return View(Employees.GetEmployeeByID(EmployeeID));
        }

        [HttpPost]
        [ORAAuthorize(Roles = "ADMINISTRATOR")]
        public ActionResult UpdateEmployee(EmployeeVM updatedEmployee)
        {
            Employees.UpdateEmployee(updatedEmployee);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpPost]
        [ORAAuthorize(Roles = "ADMINISTRATOR, DIRECTOR")]
        public ActionResult DisableEmployee(int EmployeeID)
        {
            Employees.DisableEmployee(EmployeeID);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}