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
            InitMap();
        }

        private void InitMap() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeVM>().ReverseMap();
                cfg.CreateMap<Assignment, AssignmentVM>().ReverseMap();
                cfg.CreateMap<Lib.EFModels.Profile, ProfileVM>().ReverseMap();
                cfg.CreateMap<Assessment, AssessmentVM>().ReverseMap();
                cfg.CreateMap<Client, ClientVM>().ReverseMap();
            });
        }

        public List<EmployeeVM> GetAllEmployees() {
            var mapper = config.CreateMapper();
            return mapper.Map<List<EmployeeVM>>(DbSet.Include("Assignment").Include("Profile").ToList());
        }

        public EmployeeVM GetEmployeeByID(int id) {
            var mapper = config.CreateMapper();
            var employee = GetAllEmployees().Where(e => e.EmployeeID == id).FirstOrDefault();
            return mapper.Map<EmployeeVM>(employee);
        }

        public EmployeeVM GetEmployeeByProfileID(int id) {
            var mapper = config.CreateMapper();
            return mapper.Map<EmployeeVM>(GetAllEmployees().Where(e => e.ProfileID == id).FirstOrDefault());
        }

        public void AddEmployee(EmployeeVM employee) {
            var mapper = config.CreateMapper();
            Add(mapper.Map<Employee>(employee));
            Save();
        }

        public void UpdateEmployee(EmployeeVM employee) {
            var mapper = config.CreateMapper();
            Update(mapper.Map<Employee>(employee));
            Save();
        }

        public void DeleteEmployee(int id) {
            Delete(id);
            Save();
        }
    }
}
