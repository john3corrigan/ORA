using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lib.EFModels;
using Lib.ViewModels;
using Lib.Interfaces;
using Repository.Context;

namespace Repository.Repositories {
    public class EmployeeRepository : BaseRespository<Employee>, IEmployeeRepository {

        public EmployeeRepository() : base(new RepositoryContext("ora")) {
        }

        public List<EmployeeVM> GetAllEmployees() {
            var emps = DbSet.Include("Assignment")
                            .Include("Profile").ToList();
            return Mapper.Map<List<EmployeeVM>>(emps);
        }

        public EmployeeVM GetEmployeeByID(int id) {
            var employee = GetAllEmployees().Where(e => e.EmployeeID == id).FirstOrDefault();
            return Mapper.Map<EmployeeVM>(employee);
        }

        public EmployeeVM GetEmployeeByProfileID(int id) {
            return Mapper.Map<EmployeeVM>(GetAllEmployees().Where(e => e.ProfileID == id).FirstOrDefault());
        }

        public void AddEmployee(EmployeeVM employee) {
            Add(Mapper.Map<Employee>(employee));
            Save();
        }

        public void UpdateEmployee(EmployeeVM employee) {
            Update(Mapper.Map<Employee>(employee));
            Save();
        }

        public void DeleteEmployee(int id) {
            Delete(id);
            Save();
        }

        private List<EmployeeVM> ConstructEmployVMList(List<Employee> emps) {
            List<EmployeeVM> empsVM = new List<EmployeeVM>();
            foreach (var emp in emps) {
                var empVM = new EmployeeVM() {
                    EmployeeID = emp.EmployeeID,
                    EmployeeNumber = emp.EmployeeNumber,
                    Password = emp.Password,
                    Salt = emp.Salt,
                    Email = emp.Email,
                    EmployeeName = emp.EmployeeName,
                    EmployeeFirstName = emp.EmployeeFirstName,
                    EmployeeMI = emp.EmployeeMI,
                    EmployeeLastName = emp.EmployeeLastName,
                    ActiveFlag = emp.ActiveFlag,
                    Profile = Mapper.Map<ProfileVM>(emp.Profile),
                    Assignment = Mapper.Map<List<AssignmentVM>>(emp.Assignment),
                    Modified = emp.Modified,
                    Created = emp.Created,
                    ModifiedBy = emp.ModifiedBy,
                    CreatedBy = emp.CreatedBy
                };
                empsVM.Add(empVM);
            }
            return empsVM;
        }
    }
}
