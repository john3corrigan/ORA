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
    public class TeamRepository : BaseRespository<Team>, ITeamRepository {
        public TeamRepository() : base(new RepositoryContext("ora")) {
            InitMap();
        }

        private void InitMap() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Team, TeamVM>().ReverseMap();
                cfg.CreateMap<Assignment, AssignmentVM>().ReverseMap();
                cfg.CreateMap<CreateTeamVM, Team>();
            });
        }

        public List<TeamVM> GetAllTeams() {
            var mapper = config.CreateMapper();
            return mapper.Map<List<TeamVM>>(DbSet.Include("Assignment"));
        }

        public TeamVM GetTeamByID(int id) {
            var mapper = config.CreateMapper();
            var team = GetAllTeams().Where(t => t.TeamID == id).FirstOrDefault();
            return mapper.Map<TeamVM>(team);
        }

        public void AddTeam(CreateTeamVM team) {
            var mapper = config.CreateMapper();
            Add(mapper.Map<Team>(team));
            Save();
        }

        public void UpdateTeam(TeamVM team) {
            var mapper = config.CreateMapper();
            Update(mapper.Map<Team>(team));
            Save();
        }

        public void DeleteTeam(int id) {
            Delete(id);
            Save();
        }
    }
}
