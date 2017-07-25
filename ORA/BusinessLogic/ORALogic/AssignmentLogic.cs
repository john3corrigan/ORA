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
            return Assignments.GetAssignmentByID(assignmentID);
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
            return Assignments.GetAllAssignments();
        }

        public void UpdateAssignment(AssignmentVM updatedAssignment)
        {
            Assignments.UpdateAssignment(updatedAssignment);
        }
    }
}
