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
    public class SprintRepository : BaseRespository<Sprint>, ISprintRepository {
        public SprintRepository() : base(new RepositoryContext("ora")) {
            InitMap();
        }

        private void InitMap() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Sprint, SprintVM>().ReverseMap();
                cfg.CreateMap<KPI, KPIVM>().ReverseMap();
            });
        }

        public List<SprintVM> GetAllSprints() {
            var mapper = config.CreateMapper();
            return mapper.Map<List<SprintVM>>(DbSet.Include("KPI"));
        }

        public SprintVM GetSprintByID(int id) {
            var mapper = config.CreateMapper();
            var sprint = GetAllSprints().Where(s => s.SprintID == id).FirstOrDefault();
            return mapper.Map<SprintVM>(sprint);
        }

        public void AddSprint(SprintVM sprint) {
            var mapper = config.CreateMapper();
            Add(mapper.Map<Sprint>(sprint));
            Save();
        }

        public void UpdateSprint(SprintVM sprint) {
            var mapper = config.CreateMapper();
            Update(mapper.Map<Sprint>(sprint));
            Save();
        }

        public void DeleteSprint(SprintVM sprint) {
            Delete(sprint.SprintID);
            Save();
        }
    }
}
