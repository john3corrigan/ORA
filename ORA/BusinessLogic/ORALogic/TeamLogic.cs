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

        public TeamLogic(ITeamRepository tm,
            IClientRepository clnts)
        {
            Teams = tm;
            Clients = clnts;
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
            return Teams.GetTeamByID(teamID);
        }

        public List<TeamVM> GetTeamByClientID(int ClientID)
        {
            return Teams.GetAllTeams().Where(t => t.ClientID == ClientID).ToList();
        }

        public List<TeamVM> GetAllTeams()
        {
            List<TeamVM> TeamList = Teams.GetAllTeams();
            foreach (TeamVM team in TeamList)
            {
                team.Client = Clients.GetClientByID(team.ClientID);
            }
            return TeamList;
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
    }
}
