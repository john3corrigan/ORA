using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.EFModels;
using Lib.ViewModels;
using Lib.Interfaces;
using AutoMapper;
using Repository.Context;

namespace Repository.Repositories {
    public class TeamRepository : BaseRespository<Team>, ITeamRepository{
        public TeamRepository() : base(new RepositoryContext("ora")) { }

        private void InitMap() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Team, TeamVM>().ReverseMap();
            });
        }

        public List<TeamVM> GetAllTeams() {
            return Mapper.Map<List<TeamVM>>(DbSet.Include("Assignment"));
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
