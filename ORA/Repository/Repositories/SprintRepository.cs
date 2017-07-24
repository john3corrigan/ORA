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
        public SprintRepository() : base(new RepositoryContext("ora")) { }

        public List<SprintVM> GetAllSprints() {
            return Mapper.Map<List<SprintVM>>(DbSet.Include("Metadata").Include("KPI"));
        }

        public SprintVM GetSprintByID(int id) {
            var sprint = GetAllSprints().Where(s => s.SprintID == id).FirstOrDefault();
            return Mapper.Map<SprintVM>(sprint);
        }

        public void AddSprint(SprintVM sprint) {
            Add(Mapper.Map<Sprint>(sprint));
            Save();
        }

        public void UpdateSprint(SprintVM sprint) {
            Update(Mapper.Map<Sprint>(sprint));
            Save();
        }

        public void DeleteSprint(SprintVM sprint) {
            Delete(sprint.SprintID);
            Save();
        }
    }
}
