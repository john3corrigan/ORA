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
    public class TeamLogic : ITeamLogic
    {
        private ITeamRepository Teams;
        private IClientRepository Clients;
        private IEmployeeRepository Employees;
        private IAssignmentRepository Assignments;

        public TeamLogic(ITeamRepository tm,
            IClientRepository clnts,
            IEmployeeRepository mply,
            IAssignmentRepository assign)
        {
            Teams = tm;
            Clients = clnts;
            Employees = mply;
            Assignments = assign;
        }

        public void DeleteTeam(int teamID)
        {
            Teams.DeleteTeam(teamID);
        }

        public void UpdateTeam(TeamVM updatedTeam)
        {
            Teams.UpdateTeam(updatedTeam);
        }

        public TeamVM GetTeamByID(int teamID)
        {
            TeamVM team = Teams.GetTeamByID(teamID);
            team.Client = Clients.GetClientByID(team.ClientID);
            return team;
        }

        public List<TeamVM> GetTeamByClientID(int ClientID)
        {
            return Teams.GetAllTeams().Where(t => t.ClientID == ClientID).ToList();
        }


        public List<TeamVM> GetTeamsForEmployee(int empID)
        {
            var assignments = Employees.GetEmployeeByID(empID).Assignment;
            var teams = Teams.GetAllTeams().Where(t =>
            {
                foreach (var assign in assignments)
                {
                    if (assign.TeamID == t.TeamID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            return FillClientInfo(teams);
        }
        public List<TeamVM> GetTeamsForLead(int empID)
        {
            var assignments = Employees.GetEmployeeByID(empID).Assignment.Where(a => a.RoleID < 7);
            var teamAssignments = Assignments.GetAllAssignments().Where(a =>
            {
                foreach (var assign in assignments)
                {
                    if (assign.TeamID == a.TeamID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            var teams = Teams.GetAllTeams().Where(t =>
            {
                foreach (var assign in teamAssignments)
                {
                    if (assign.TeamID == t.TeamID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            return FillClientInfo(teams);
        }
        public List<TeamVM> GetTeamsForManager(int empID)
        {
            var assignments = Employees.GetEmployeeByID(empID).Assignment.Where(a => a.RoleID < 6);
            var clientsAssignments = Assignments.GetAllAssignments().Where(a =>
            {
                foreach (var assign in assignments)
                {
                    if (assign.ClientID == a.ClientID || assign.TeamID == a.TeamID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            var teams = Teams.GetAllTeams().Where(t =>
            {
                foreach (var assign in clientsAssignments)
                {
                    if (assign.TeamID == t.TeamID)
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
            return FillClientInfo(teams);
        }

        public List<TeamVM> GetAllTeams()
        {
            return FillClientInfo(Teams.GetAllTeams());
        }

        public CreateTeamVM AddTeam()
        {
            CreateTeamVM create = new CreateTeamVM(){
                ClientList = Clients.GetAllClients()
            };
            return create;
        }

        public void AddTeam(CreateTeamVM newTeam)
        {
            Teams.AddTeam(newTeam);
        }

        private List<TeamVM> FillClientInfo(List<TeamVM> teams)
        {
            List<TeamVM> tempTeams = teams;
            foreach (TeamVM team in tempTeams)
            {
                team.Client = Clients.GetClientByID(team.ClientID);
            }
            return tempTeams;
        }
    }
}
