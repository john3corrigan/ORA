using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Repository.Repositories;
using Lib.Interfaces;

namespace BusinessLogic.ORALogic
{
    public class AssignmentLogic
    {
        private IAssignmentRepository Assignments;

        public AssignmentLogic(IAssignmentRepository assign)
        {
            Assignments = assign;
        }

        public AssignmentVM GetAssignmentByAssignmentID(int assignmentID)
        {
            throw new NotImplementedException();
        }

        public void CreateAssignment(AssignmentVM assignment)
        {
            throw new NotImplementedException();
        }

        public List<AssignmentVM> GetAllAssignments()
        {
            throw new NotImplementedException();
        }

        public void UpdateAssignment(AssignmentVM updatedAssignment)
        {
            throw new NotImplementedException();
        }
    }
}
