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
    public class TeamLogic
    {
        private ITeamRepository Teams;

        public TeamLogic(ITeamRepository tm)
        {
            Teams = tm;
        }

        public void DeleteTeam(int teamID)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam(TeamVM updatedTeam)
        {
            throw new NotImplementedException();
        }

        public TeamVM GetTeamByTeamID(int teamID)
        {
            throw new NotImplementedException();
        }

        public List<TeamVM> GetAllTeams()
        {
            throw new NotImplementedException();
        }

        public void CreateTeam(TeamVM team)
        {
            throw new NotImplementedException();
        }
    }
}
