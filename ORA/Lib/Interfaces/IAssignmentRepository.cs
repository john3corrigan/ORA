using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces {
    public interface IAssignmentRepository {
        List<AssignmentVM> GetAllAssignments();
        AssignmentVM GetAssignmentByID(int id);
        List<AssignmentVM> GetAssignmentsByDateRange(DateTime start, DateTime end);
        void AddAssignment(CreateAssignmentVM assignment);
        void UpdateAssignment(AssignmentVM assignment);
    }
}
