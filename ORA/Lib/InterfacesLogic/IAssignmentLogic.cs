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
        AssignmentVM GetAssignmentByAssignmentID(int assignmentID);
        List<AssignmentVM> GetAllAssignments();
        void CreateAssignment(AssignmentVM assignment);
        void UpdateAssignment(AssignmentVM updatedAssignment);
    }
}
