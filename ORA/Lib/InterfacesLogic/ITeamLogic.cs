using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.InterfacesLogic
{
    public interface ITeamLogic
    {
        TeamVM GetTeamByID(int teamID);
        List<TeamVM> GetAllTeams();
        void AddTeam(TeamVM team);
        void DeleteTeam(int teamID);
        void UpdateTeam(TeamVM updatedTeam);
    }
}
