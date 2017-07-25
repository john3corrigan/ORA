using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Repository.Repositories;
using Lib.Interfaces;
using Lib.InterfacesLogic;

namespace BusinessLogic.ORALogic
{
    public class AssignmentLogic : IAssignmentLogic
    {
        private IAssignmentRepository Assignments;

        public AssignmentLogic(IAssignmentRepository assign)
        {
            Assignments = assign;
        }

        public AssignmentVM GetAssignmentByID(int assignmentID)
        {
            return Assignments.GetAssignmentByID(assignmentID);
        }

        public void AddAssignment(AssignmentVM assignment)
        {
            Assignments.AddAssignment(assignment);
        }

        public List<AssignmentVM> GetAllAssignments()
        {
            return Assignments.GetAllAssignments();
        }

        public void UpdateAssignment(AssignmentVM updatedAssignment)
        {
            Assignments.UpdateAssignment(updatedAssignment);
        }
    }
}
