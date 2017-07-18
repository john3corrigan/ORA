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
            return Mapper.Map<List<EmployeeVM>>(GetAll());
        }

        public EmployeeVM GetEmployeeByID(int id) {
            return Mapper.Map<EmployeeVM>(GetByID(id));
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
