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
        private IProfileRepository Profiles;
        private IPositionRepository Positions;

        public EmployeeLogic(IEmployeeRepository repo, IProfileRepository prfls, IPositionRepository pstn) {
            Employees = repo;
            Profiles = prfls;
            Positions = pstn;
        }

        public CreateEmployeeVM AddEmployee()
        {
            CreateEmployeeVM create = new CreateEmployeeVM() {
                Position = Positions.GetAllPositions()
            };
            return create;
        }

        public void AddEmployee(CreateEmployeeVM employee)
        {
            CreateEmployeeVM Employee = employee;
            Employee.Salt = HashHelper.GetSalt();
            Employee.Password = HashHelper.ComputeHash(employee.Password, employee.Salt);
            ProfileVM profile = new ProfileVM() {
                FirstName = employee.EmployeeFirstName,
                LastName = employee.EmployeeLastName,
                Created = employee.Created,
                CreatedBy = employee.CreatedBy,
                Modified = employee.Modified,
                ModifiedBy = employee.ModifiedBy,
                PositionID = employee.PositionID
            };
            Profiles.AddProfile(profile);
            Employee.ProfileID = Profiles.GetAllProfiles().Where(p => p.FirstName == employee.EmployeeFirstName && p.LastName == employee.EmployeeLastName).FirstOrDefault().ProfileID;
            Employees.AddEmployee(Employee);
        }

        public EmployeeVM Login(EmployeeVM employee)
        {
            EmployeeVM emp = Employees.GetAllEmployees().Where(e => e.Email == employee.Email).FirstOrDefault();

            if (emp == null) {
                return null;
            }

            if (HashHelper.CheckHash(emp.Password, employee.Password, emp.Salt)) {
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
