using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.InterfacesLogic
{
    public interface IAssignmentLogic
    {
        AssignmentVM GetAssignmentByID(int assignmentID);
        List<AssignmentVM> GetAllAssignments();
        List<AssignmentVM> GetAllAssignmentsForEmployee(int empID);
        CreateAssignmentVM AddAssignment();
        void AddAssignment(CreateAssignmentVM assignment);
        void UpdateAssignment(AssignmentVM updatedAssignment);
    }
}
