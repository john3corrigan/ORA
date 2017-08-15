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
        private IRoleRepository Roles;

        public AssessmentLogic(IAssessmentRepository assess, IAssignmentRepository assign, IEmployeeRepository mply, IRoleRepository rls)
        {
            Assessments = assess;
            Assignments = assign;
            Employees = mply;
            Roles = rls;
        }

        public void AddAssessment(CreateAssessmentVM assessment, int teamID)
        {
            //The Assignment id is an employeeID until this point because of my inability to be creative.
            assessment.AssignmentID = Employees.GetEmployeeByID(assessment.AssignmentID).Assignment.Where(a => a.TeamID == teamID && a.EmployeeID == assessment.AssignmentID).FirstOrDefault().AssignmentID;
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

        public List<AssessmentVM> GetAssessmentByAssignmentID(int assignmentID)
        {
            return Assessments.GetAllAssessments().Where(a => a.AssignmentID == assignmentID).ToList();
        }

        public List<AssessmentVM> GetAssessmentByEmployeeID(int employee)
        {
            List<AssignmentVM> Assignment = Employees.GetEmployeeByID(employee).Assignment.Where(a => a.EmployeeID == employee).ToList();
            List<AssessmentVM> assessments = Assessments.GetAllAssessments().Where(a =>
            {
                foreach (var assign in Assignment)
                {
                    if (assign.AssignmentID == a.AssignmentID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            return assessments;
        }

        public List<EmployeeVM> GetAssessmentForTeamLead(int employeeID,  DateTime Start, DateTime End)
        {
            List<AssignmentVM> myAssignmentsList = Employees.GetEmployeeByID(employeeID).Assignment.Where(a => a.RoleID < 7  && (a.StartDate <= Start && Start <= a.EndDate || a.StartDate <= End && End <= a.EndDate)).ToList();
            return Employees.GetAllEmployees().Where(e =>
            {
                foreach (var assign in myAssignmentsList)
                {
                    var assignments = Assignments.GetAllAssignments().Where(a => a.EmployeeID == e.EmployeeID);
                    foreach (var item in assignments)
                    {
                        if (item.TeamID == assign.TeamID)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }).ToList();
        }

        public List<EmployeeVM> GetAssessmentForServiceManager(int employeeID, DateTime Start, DateTime End)
        {
            List<AssignmentVM> myAssignmentsList = Employees.GetEmployeeByID(employeeID).Assignment.Where(a => a.RoleID < 6 && (a.StartDate <= Start && Start <= a.EndDate || a.StartDate <= End && End <= a.EndDate)).ToList();
            return Employees.GetAllEmployees().Where(e =>
            {
                foreach (var assign in myAssignmentsList)
                {
                    var assignments = Assignments.GetAllAssignments().Where(a => a.EmployeeID == e.EmployeeID);
                    foreach (var item in assignments)
                    {
                        if (item.ClientID == assign.ClientID)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }).ToList();
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
            if (assignment == null)
            {
                return null;
            }
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
