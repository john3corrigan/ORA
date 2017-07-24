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

        public AssignmentRepository() : base(new RepositoryContext("ora")) { }

        private void InitMap() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Assignment, AssignmentVM>().ReverseMap();
            });
        }

        public List<AssignmentVM> GetAllAssignments() {
            return Mapper.Map<List<AssignmentVM>>(DbSet.Include("Assessment")
                                                       .Include("KPI"));
        }

        public AssignmentVM GetAssignmentByID(int id) {
            return Mapper.Map<AssignmentVM>(GetAllAssignments().Where(a => a.AssignmentID == id));
        }

        public List<AssignmentVM> GetAssignmentsByDateRange(DateTime start, DateTime end) {
            var assignments = GetAllAssignments().ToList();
            assignments = assignments.Where(a => a.StartDate >= start && a.EndDate <= end).ToList();
            return Mapper.Map<List<AssignmentVM>>(assignments);
        }

        public void AddAssignment(AssignmentVM assignment) {
            Add(Mapper.Map<Assignment>(assignment));
            Save();
        }

        public void UpdateAssignment(AssignmentVM assignment) {
            Update(Mapper.Map<Assignment>(assignment));
            Save();
        }
    }
}
