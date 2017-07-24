using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.InterfacesLogic
{
    public interface IEmployeeLogic
    {
        EmployeeVM Login(EmployeeVM Employee);
        List<EmployeeVM> GetAllEmployees();
        EmployeeVM GetEmployeeByID(int employeeID);
        void AddEmployee(EmployeeVM Employee);
        void UpdateEmployee(EmployeeVM updatedEmployee);
        void DisableEmployee(int employeeID);
    }
}
