using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Lib.Interfaces;
using Lib.Helpers;

namespace BusinessLogic.ORALogic
{
    public class EmployeeLogic
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

            if (HashHelper.CheckHash(emp.Password, employee.Password, emp.Salt)) {
                return emp;
            }
            return null;
        }

        public List<EmployeeVM> ViewAllEmployees()
        {
            throw new NotImplementedException();
        }

        public EmployeeVM GetEmployeeByEmployeeID(int employeeID)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(EmployeeVM updatedEmployee)
        {
            throw new NotImplementedException();
        }

        public void DieableEmployee(int employeeID)
        {
            throw new NotImplementedException();
        }
    }
}
