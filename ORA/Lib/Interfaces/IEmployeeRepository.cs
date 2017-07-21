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
        void AddEmployee(EmployeeVM employee);
        void UpdateEmployee(EmployeeVM employee);
    }
}
