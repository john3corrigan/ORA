using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.EFModels;
using Lib.ViewModels;
using AutoMapper;

namespace Repository.Repositories {
    public class SprintRepository : BaseRespository<Sprint, SprintVM> {
        public SprintRepository() : base() { }

        public List<SprintVM> GetAllSprints() {
            return Mapper.Map<List<SprintVM>>(dbset.Include("Metadata").Include("KPI"));
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
