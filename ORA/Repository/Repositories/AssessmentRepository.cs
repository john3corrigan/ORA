using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.EFModels;
using Lib.ViewModels;
using AutoMapper;

namespace Repository.Repositories {
    public class AssessmentRepository : BaseRespository<Assessment> {
        private Mapper Mapper;
        public AssessmentRepository() : base() {
            InitMap();
        }

        private void InitMap() {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Assessment, AssessmentVM>().ReverseMap());
            Mapper = new Mapper(config);
        }

        public AssessmentVM GetAssessmentByID(int id) {
            var assessment = dbset.Include("Metadata")
                .Include("Assignment")
                .Where(a => a.AssessmentID == id).FirstOrDefault();
            return Mapper.Map<AssessmentVM>(assessment);
        }

        public List<AssessmentVM> GetAllAssessments() {
            return Mapper.Map<List<AssessmentVM>>(GetAll());
        }

        public void AddAssessment(AssessmentVM assessment) {
            Add(Mapper.Map<Assessment>(assessment));
            Save();
        }

        public void UpdateAssessment(AssessmentVM assessment) {
            Update(Mapper.Map<Assessment>(assessment));
            Save();
        }
    }
}
