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
        private ITeamRepository Team;
        private IRoleRepository Role;
        private IPositionRepository Position;
        private IClientRepository Client;
        private IEmployeeRepository Employee;

        public AssignmentLogic(IAssignmentRepository assign,
                                ITeamRepository team,
                                IRoleRepository role,
                                IPositionRepository pos,
                                IEmployeeRepository emp,
                                IClientRepository client)
        {
            Assignments = assign;
            Team = team;
            Role = role;
            Position = pos;
            Client = client;
            Employee = emp;
        }

        public AssignmentVM GetAssignmentByID(int assignmentID)
        {
            AssignmentVM assignment = Assignments.GetAssignmentByID(assignmentID);
            assignment.Client = Client.GetClientByID(assignment.ClientID);
            assignment.Employee = Employee.GetEmployeeByID(assignment.EmployeeID);
            assignment.Position = Position.GetPositionByID(assignment.PositionID);
            assignment.Role = Role.GetRoleByID(assignment.RoleID);
            assignment.Team = Team.GetTeamByID(assignment.TeamID);
            return assignment;
        }

        public CreateAssignmentVM AddAssignment() {
            CreateAssignmentVM create = new CreateAssignmentVM() {
                TeamList = Team.GetAllTeams(),
                RoleList = Role.GetAllRoles(),
                PositionList = Position.GetAllPositions(),
                EmployeeList = Employee.GetAllEmployees(),
                ClientList = Client.GetAllClients()
            };
            return create;
        }

        public void AddAssignment(CreateAssignmentVM assignment)
        {
            Assignments.AddAssignment(assignment);
        }

        public List<AssignmentVM> GetAllAssignments()
        {
            return EmployeeInfo(Assignments.GetAllAssignments());
        }

        public List<AssignmentVM> GetAllAssignmentsForEmployee(int empID)
        {
            return EmployeeInfo(Assignments.GetAllAssignments().Where(a => a.EmployeeID == empID).ToList());
        }

        public List<AssignmentVM> GetAllAssignmentsForTeam(int teamID)
        {
            return Assignments.GetAllAssignments().Where(a => a.TeamID == teamID).ToList();
        }

        public List<AssignmentVM> GetAssignmentsForManager(int empID)
        {
            var employee = Employee.GetEmployeeByID(empID).Assignment;
            return Assignments.GetAllAssignments().Where(a => {
                foreach (var assign in employee)
                {
                    if (a.EmployeeID == empID || assign.ClientID == a.ClientID || assign.TeamID == a.TeamID)
                    {
                        return true;
                    }
                }
                return false;
            }).OrderBy(a => a.ClientID).ToList();
        }

        public List<AssignmentVM> GetAssignmentsForLead(int empID)
        {
            var employee = Employee.GetEmployeeByID(empID).Assignment;
            return Assignments.GetAllAssignments().Where(a => {
                foreach (var assign in employee)
                {
                    if (a.EmployeeID == empID || assign.TeamID == a.TeamID)
                    {
                        return true;
                    }
                }
                return false;
            }).OrderBy(a => a.StartDate).ToList();
        }

        public void UpdateAssignment(AssignmentVM updatedAssignment)
        {
            Assignments.UpdateAssignment(updatedAssignment);
        }

        public List<AssignmentVM> GetIndividualAssignments(DateTime startDate, DateTime endDate)
        {
            var assignment = Assignments.GetAllAssignments().Where(a => (startDate >= a.StartDate && startDate <= a.EndDate) || (endDate >= a.StartDate && endDate <= a.EndDate)).OrderBy(a => a.EmployeeID).ToList();
            return EmployeeInfo(assignment);
        }

        public List<AssignmentVM> GetTeamsAssignments(DateTime startDate, DateTime endDate, int teamID)
        {
            var assignment = Assignments.GetAllAssignments().Where(a => ((startDate >= a.StartDate && startDate <= a.EndDate) || (endDate >= a.StartDate && endDate <= a.EndDate)) && teamID == a.TeamID).OrderBy(a => a.EmployeeID).ToList();
            return EmployeeInfo(assignment);
        }

        public List<AssignmentVM> GetClientAssignments(DateTime startDate, DateTime endDate, int clientID)
        {
            var assignment = Assignments.GetAllAssignments().Where(a => ((startDate >= a.StartDate && startDate <= a.EndDate) || (endDate >= a.StartDate && endDate <= a.EndDate)) && clientID == a.ClientID).OrderBy(a => a.EmployeeID).ToList();
            return EmployeeInfo(assignment);
        }
        private List<AssignmentVM> EmployeeInfo(List<AssignmentVM> assignments)
        {
            foreach (var assign in assignments)
            {
                assign.Employee = Employee.GetEmployeeByID(assign.EmployeeID);
            }
            return assignments;
        }
    }
}
