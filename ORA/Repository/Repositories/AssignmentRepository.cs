using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.EFModels;
using Lib.ViewModels;
using AutoMapper;

namespace Repository.Repositories {
    public class AssignmentRepository : BaseRespository<Assignment, AssignmentVM> {

        public AssignmentRepository() : base() { }

        public List<AssignmentVM> GetAllAssignments() {
            return Mapper.Map<List<AssignmentVM>>(dbset.Include("Assessment")
                                                       .Include("KPI")
                                                       .Include("Metadata"));
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
