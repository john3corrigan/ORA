using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;

namespace BusinessLogic
{
    public class ORALogic
    {
        public void AddEmployee(EmployeeVM Employee)
        {
            
        }

        public bool Login(EmployeeVM Employee)
        {
            return true;
        }

        public StoryVM GetStoryByStoryID(int StoryID)
        {
            throw new NotImplementedException();
        }

        public object GetSprintBySprintID(int SprintID)
        {
            throw new NotImplementedException();
        }

        public object GetClientByClientID(int ClientID)
        {
            throw new NotImplementedException();
        }

        public object GetAssignmentByAssinmentID(int assignmentID)
        {
            throw new NotImplementedException();
        }
    }
}
