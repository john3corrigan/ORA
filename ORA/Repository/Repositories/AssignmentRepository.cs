using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.EFModels;
using Lib.ViewModels;
using Lib.Interfaces;
using AutoMapper;
using Repository.Context;

namespace Repository.Repositories {
    public class AssignmentRepository : BaseRespository<Assignment>, IAssignmentRepository {

        public AssignmentRepository() : base(new RepositoryContext("ora")) {
            InitMap();
        }

        private void InitMap() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Assignment, AssignmentVM>().ReverseMap();
                cfg.CreateMap<KPI, KPIVM>().ReverseMap();
                cfg.CreateMap<Assessment, AssessmentVM>().ReverseMap();
                cfg.CreateMap<Team, TeamVM>().ReverseMap();
                cfg.CreateMap<Client, ClientVM>().ReverseMap();
                cfg.CreateMap<Position, PositionVM>().ReverseMap();
                cfg.CreateMap<Role, RoleVM>().ReverseMap();
                cfg.CreateMap<Employee, EmployeeVM>().ReverseMap();
                cfg.CreateMap<CreateAssignmentVM, Assignment>().ReverseMap();
            });
        }

        public List<AssignmentVM> GetAllAssignments() {
            var mapper = config.CreateMapper();
            return mapper.Map<List<AssignmentVM>>(DbSet.Include("Assessment")
                                                       .Include("KPI")
                                                       .Include("Team")
                                                       .Include("Client")
                                                       .Include("Position")
                                                       .Include("Employee")
                                                       .Include("Role"));
        }

        public AssignmentVM GetAssignmentByID(int id) {
            var mapper = config.CreateMapper();
            return mapper.Map<AssignmentVM>(GetAllAssignments().Where(a => a.AssignmentID == id));
        }

        public List<AssignmentVM> GetAssignmentsByDateRange(DateTime start, DateTime end) {
            var mapper = config.CreateMapper();
            var assignments = GetAllAssignments().ToList();
            assignments = assignments.Where(a => a.StartDate >= start && a.EndDate <= end).ToList();
            return mapper.Map<List<AssignmentVM>>(assignments);
        }

        public void AddAssignment(CreateAssignmentVM assignment) {
            var mapper = config.CreateMapper();
            Add(mapper.Map<Assignment>(assignment));
            Save();
        }

        public void UpdateAssignment(AssignmentVM assignment) {
            var mapper = config.CreateMapper();
            Update(mapper.Map<Assignment>(assignment));
            Save();
        }

        public void DeleteAssignment(int id) {
            Delete(id);
            Save();
        }
    }
}
