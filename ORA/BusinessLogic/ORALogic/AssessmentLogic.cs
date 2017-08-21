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

        public void AddAssessment(CreateAssessmentVM assessment)
        {
            //The Assignment id is an employeeID until this point because of my inability to be creative. 
            assessment.AssignmentID = Employees.GetEmployeeByID(assessment.AssignmentID).Assignment.Where(a => a.StartDate < assessment.Created && a.EndDate > assessment.Created).FirstOrDefault().AssignmentID;
            Assessments.AddAssessment(assessment);
        }
        public CreateAssessmentVM AddAssessment(DateTime created, int myID)
        {
            CreateAssessmentVM createAssessment = new CreateAssessmentVM()
            {
                EmployeeList = FilterEmployeeByTeam(created, myID)
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
            foreach (var assess in assessments)
            {
                assess.EmployeeName = Employees.GetEmployeeByID(Assignments.GetAssignmentByID(assess.AssignmentID).EmployeeID).EmployeeName;
            }
            return assessments;
        }

        public List<EmployeeVM> GetAssessmentForTeamLead(int employeeID, DateTime Start, DateTime End)
        {
            List<AssignmentVM> myAssignmentsList = Employees.GetEmployeeByID(employeeID).Assignment.Where(a => a.RoleID < 7 && (a.StartDate <= Start && Start <= a.EndDate || a.StartDate <= End && End <= a.EndDate)).ToList();
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

        private List<EmployeeVM> FilterEmployeeByTeam(DateTime created, int myID)
        {
            var assignment = Employees.GetEmployeeByID(myID).Assignment.Where(a => a.RoleID < 7 && a.StartDate <= created && a.EndDate >= created).ToList();
            if (assignment == null)
            {
                return null;
            }
            return Employees.GetAllEmployees().Where(e =>
            {
                foreach (var item in assignment)
                {
                    if (item.RoleID < 6) {
                        foreach (var assign in e.Assignment)
                        {
                            if (assign.StartDate <= created && assign.EndDate >= created && item.ClientID == assign.ClientID)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        foreach (var assign in e.Assignment)
                        {
                            if (assign.StartDate <= created && assign.EndDate >= created && item.TeamID == assign.TeamID)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }).ToList();
        }

        public string GetAverage(int profileID)
        {
            var employeeAssignmnt = Employees.GetEmployeeByProfileID(profileID).Assignment;
            var assessments = Assessments.GetAllAssessments().Where(a =>
            {
                foreach (var assign in employeeAssignmnt)
                {
                    if (assign.AssignmentID == a.AssignmentID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            double[] total = new double[5];
            foreach (var assess in assessments)
            {
                total[0] += (assess.ADAttendence + assess.ADEthiclBehavior + assess.ADMeetsDeadlines + assess.ADOrganizeDetailedWork) / 4;
                total[1] += (assess.CSRListeningSkills + assess.CSRProfessionalismTeamwork + assess.CSRVerbalSkills + assess.CSRWrittenSkills) / 4;
                total[2] += (assess.TDProblemSolving + assess.TDProductivity + assess.TDProductKnowledge + assess.TDQualityOfWork) / 4;
                total[3] += (assess.MIGroomingAppearence + assess.MIAttitudeWork + assess.MIPersonalGrowth + assess.MIPotencialAdvancement) / 4;
                total[4] += (assess.TMAskingQuestions + assess.TMFeedBack + assess.TMResourceUse + assess.TMTechnicalMonitoring) / 4;
            }
            string average = (total[0] / assessments.Count).ToString();
            average += "," + (total[1] / assessments.Count).ToString();
            average += "," + (total[2] / assessments.Count).ToString();
            average += "," + (total[3] / assessments.Count).ToString();
            average += "," + (total[4] / assessments.Count).ToString();
            return average;
        }

        public List<AssessmentVM> GetIndividualAssessments(DateTime startDate, DateTime endDate)
        {
            var assignment = Assignments.GetAllAssignments().Where(a => (startDate >= a.StartDate && startDate <= a.EndDate) || (endDate >= a.StartDate && endDate <= a.EndDate)).ToList();
            var assessment = Assessments.GetAllAssessments().Where(a =>
            {
                foreach (var assign in assignment)
                {
                    if (assign.AssignmentID == a.AssignmentID)
                    {
                        return true;
                    }
                }
                return false;
            }).OrderBy(a => a.Created).ToList();
            return GetEmployeeName(assessment).OrderBy(a => a.EmployeeName).ToList();
        }

        public List<AssessmentVM> GetTeamsAssessments(DateTime startDate, DateTime endDate, int teamID)
        {
            var assignment = Assignments.GetAllAssignments().Where(a => ((startDate >= a.StartDate && startDate <= a.EndDate) || (endDate >= a.StartDate && endDate <= a.EndDate)) && teamID == a.TeamID).ToList();
            var assessment = Assessments.GetAllAssessments().Where(a =>
            {
                foreach (var assign in assignment)
                {
                    if (assign.AssignmentID == a.AssignmentID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            return GetEmployeeName(assessment).OrderBy(a => a.EmployeeName).ToList();
        }

        public List<AssessmentVM> GetClientAssessments(DateTime startDate, DateTime endDate, int clientID)
        {
            var assignment = Assignments.GetAllAssignments().Where(a => ((startDate >= a.StartDate && startDate <= a.EndDate) || (endDate >= a.StartDate && endDate <= a.EndDate)) && clientID == a.ClientID).ToList();
            var assessment = Assessments.GetAllAssessments().Where(a =>
            {
                foreach (var assign in assignment)
                {
                    if (assign.AssignmentID == a.AssignmentID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            return GetEmployeeName(assessment).OrderBy(a => a.EmployeeName).ToList();
        }

        private List<AssessmentVM> GetEmployeeName(List<AssessmentVM> assessment)
        {
            foreach (var assess in assessment)
            {
                assess.EmployeeName = Employees.GetEmployeeByID(Assignments.GetAssignmentByID(assess.AssignmentID).EmployeeID).EmployeeName;
            }
            return assessment;
        }
    }
}
