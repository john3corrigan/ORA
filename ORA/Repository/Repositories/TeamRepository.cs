using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.EFModels;
using Lib.ViewModels;
using Lib.Interfaces;
using AutoMapper;

namespace Repository.Repositories {
    public class TeamRepository : BaseRespository<Team, TeamVM>, ITeamRepository{
        public TeamRepository() : base() { }

        public List<TeamVM> GetAllTeams() {
            return Mapper.Map<List<TeamVM>>(dbset.Include("Metadata").Include("Assignment"));
        }

        public TeamVM GetTeamByID(int id) {
            var team = GetAllTeams().Where(t => t.TeamID == id).FirstOrDefault();
            return Mapper.Map<TeamVM>(team);
        }

        public void AddTeam(TeamVM team) {
            Add(Mapper.Map<Team>(team));
            Save();
        }

        public void UpdateTeam(TeamVM team) {
            Update(Mapper.Map<Team>(team));
            Save();
        }

        public void DeleteTeam(TeamVM team) {
            Delete(team.TeamID);
            Save();
        }
    }
}
