using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces {
    public interface IEmployeeRepository {
        List<EmployeeVM> GetAllEmployees();
        EmployeeVM GetEmployeeByID(int id);
        EmployeeVM GetEmployeeByProfileID(int id);
        void AddEmployee(CreateEmployeeVM employee);
        void UpdateEmployee(EmployeeVM employee);
        void DeleteEmployee(int id);
    }
}
