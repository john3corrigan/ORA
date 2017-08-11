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
        CreateTeamVM AddTeam();
        void AddTeam(CreateTeamVM newTeam);
        void DeleteTeam(int teamID);
        void UpdateTeam(TeamVM updatedTeam);
        List<TeamVM> GetTeamByClientID(int CLientID);
        List<TeamVM> GetTeamsForEmployee(int empID);
        List<TeamVM> GetTeamsForLead(int empID);
        List<TeamVM> GetTeamsForManager(int empID);
    }
}
