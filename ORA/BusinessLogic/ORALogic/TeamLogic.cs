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

        public TeamLogic(ITeamRepository tm)
        {
            Teams = tm;
        }

        public void DeleteTeam(int teamID)
        {
            Teams.DeleteTeam(Teams.GetTeamByID(teamID));
        }

        public void UpdateTeam(TeamVM updatedTeam)
        {
            Teams.UpdateTeam(updatedTeam);
        }

        public TeamVM GetTeamByID(int teamID)
        {
            return Teams.GetTeamByID(teamID);
        }

        public List<TeamVM> GetAllTeams()
        {
            return Teams.GetAllTeams();
        }

        public void AddTeam(TeamVM newTeam)
        {
            Teams.AddTeam(newTeam);
        }
    }
}
