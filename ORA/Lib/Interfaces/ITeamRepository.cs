using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces {
    public interface ITeamRepository {
        List<TeamVM> GetAllTeams();
        TeamVM GetTeamByID(int id);
        void AddTeam(CreateTeamVM team);
        void UpdateTeam(TeamVM team);
        void DeleteTeam(TeamVM team);
    }
}
