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

        public EmployeeRepository() : base(new RepositoryContext("ora")) { }

        private void InitMap() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeVM>().ReverseMap();
            });
        }

        public List<EmployeeVM> GetAllEmployees() {
            return Mapper.Map<List<EmployeeVM>>(DbSet.Include("Assignment"));
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
