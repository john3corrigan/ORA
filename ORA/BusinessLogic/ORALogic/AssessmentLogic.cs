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
    public class AssessmentLogic : IAssessmentLogic
    {
        private IAssessmentRepository Assessments;
        private IAssignmentRepository Assignments;
        private IEmployeeRepository Employees;

        public AssessmentLogic(IAssessmentRepository assess, IAssignmentRepository assign, IEmployeeRepository mply)
        {
            Assessments = assess;
            Assignments = assign;
            Employees = mply;
        }

        public void AddAssessment(CreateAssessmentVM assessment, int teamID)
        {
            //The Assignment id is an employeeID until this point because of my inability to be creative.
            assessment.AssignmentID = Employees.GetEmployeeByID(assessment.AssignmentID).Assignment.Where(a => a.TeamID == teamID && a.RoleID < 7).FirstOrDefault().AssignmentID;
            Assessments.AddAssessment(assessment);
        }
        public CreateAssessmentVM AddAssessment(DateTime created, int myID, int teamID)
        {
            CreateAssessmentVM createAssessment = new CreateAssessmentVM() {
                EmployeeList = FilterEmployeeByTeam(created, myID, teamID)
            };
            return createAssessment;
        }

        public AssessmentVM GetAssessmentByID(int assessmentID)
        {
            return Assessments.GetAssessmentByID(assessmentID);
        }

        public List<AssessmentVM> GetAllAssessments()
        {
            return Assessments.GetAllAssessments();
        }

        public void UpdateAssessment(AssessmentVM updatedAssessment)
        {
            Assessments.UpdateAssessment(updatedAssessment);
        }

        private List<EmployeeVM> FilterEmployeeByTeam(DateTime created, int myID, int teamID)
        {
            var assignment = Employees.GetEmployeeByID(myID).Assignment.Where(a => a.RoleID < 7 && a.TeamID == teamID && a.StartDate <= created && a.EndDate >= created).FirstOrDefault();
            var employees = Employees.GetAllEmployees().Where(e =>
            {
                foreach (var assign in e.Assignment)
                {
                if (assign.TeamID == assignment.TeamID && assign.StartDate <= created && assign.EndDate >= created) 
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            return employees;
        }
    }
}
