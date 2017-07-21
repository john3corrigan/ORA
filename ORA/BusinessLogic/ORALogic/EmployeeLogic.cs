using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Repository.Repositories;
using Lib.Interfaces;
using Lib.InterfacesLogic;

namespace BusinessLogic.ORALogic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private IEmployeeRepository Employees;

        public EmployeeLogic(IEmployeeRepository emply)
        {
            Employees = emply;
        }
        public void AddEmployee(EmployeeVM Employee)
        {
            Employees.AddEmployee(Employee);
        }

        public EmployeeVM Login(EmployeeVM Employee)
        {
            foreach(EmployeeVM value in Employees.GetAllEmployees())
            {
                if(value.EmployeeNumber == Employee.EmployeeNumber)
                {
                    if (value.Password == Employee.Password)
                    {
                        return value;
                    }
                }
            }
            return null;
        }

        public List<EmployeeVM> ViewAllEmployees()
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
