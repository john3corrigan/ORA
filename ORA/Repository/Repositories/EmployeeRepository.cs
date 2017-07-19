using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lib.EFModels;
using Lib.ViewModels;

namespace Repository.Repositories {
    public class EmployeeRepository : BaseRespository<Employee, EmployeeVM> {

        public EmployeeRepository() : base() { }

        public List<EmployeeVM> GetAllEmployees() {
            //TODO add includes
            return Mapper.Map<List<EmployeeVM>>(dbset.Include("Metadata").Include("Assignment"));
        }

        public EmployeeVM GetEmployeeByID(int id) {
            var employee = GetAllEmployees().Where(e => e.EmployeeID == id).FirstOrDefault();
            return Mapper.Map<EmployeeVM>(employee);
        }

        public void AddEmployee(EmployeeVM employee) {
            Add(Mapper.Map<Employee>(employee));
            Save();
        }

        public void UpdateEmployee(EmployeeVM employee) {
            Update(Mapper.Map<Employee>(employee));
            Save();
        }
    }
}
