using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Lib.Interfaces;
using Lib.Helpers;
using Lib.InterfacesLogic;

namespace BusinessLogic.ORALogic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private IEmployeeRepository Employees;

        public EmployeeLogic(IEmployeeRepository repo) {
            Employees = repo;
        }

        public void AddEmployee(EmployeeVM employee)
        {
            employee.Salt = HashHelper.GetSalt();
            employee.Password = HashHelper.ComputeHash(employee.Password, employee.Salt);
            Employees.AddEmployee(employee);
        }

        public EmployeeVM Login(EmployeeVM employee)
        {
            EmployeeVM emp = Employees.GetAllEmployees().Where(e => e.EmployeeNumber == employee.EmployeeNumber).FirstOrDefault();
            
            if(emp == null) {
                return null;
            }

            if (HashHelper.CheckHash(emp.Password, employee.Password, emp.Salt))
            {
                return emp;
            }
            return null;
        }

        public List<EmployeeVM> GetAllEmployees()
        {
            return Employees.GetAllEmployees();
        }

        public EmployeeVM GetEmployeeByID(int employeeID)
        {
            return Employees.GetEmployeeByID(employeeID);
        }

        public void UpdateEmployee(EmployeeVM updatedEmployee)
        {
            Employees.UpdateEmployee(updatedEmployee);
        }

        public void DisableEmployee(int employeeID)
        {
            throw new NotImplementedException();
        }
    }
}
