using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.EFModels;
using Lib.ViewModels;
using Lib.Interfaces;
using AutoMapper;
using System.Data.Entity;
using Repository.Context;

namespace Repository.Repositories {
    public class AssessmentRepository : BaseRespository<Assessment>, IAssessmentRepository {

        public AssessmentRepository() : base(new RepositoryContext("ora")) {
            InitMap();
        }

        private void InitMap() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Assessment, AssessmentVM>().ReverseMap();
            });
        }

        public AssessmentVM GetAssessmentByID(int id) {
            var mapper = config.CreateMapper();
            var assessment = DbSet.Where(a => a.AssessmentID == id).FirstOrDefault();
            return mapper.Map<AssessmentVM>(assessment);
        }

        public List<AssessmentVM> GetAllAssessments() {
            var mapper = config.CreateMapper();
            return mapper.Map<List<AssessmentVM>>(GetAll());
        }

        public void AddAssessment(AssessmentVM assessment) {
            var mapper = config.CreateMapper();
            Add(mapper.Map<Assessment>(assessment));
            Save();
        }

        public void UpdateAssessment(AssessmentVM assessment) {
            var mapper = config.CreateMapper();
            Update(mapper.Map<Assessment>(assessment));
            Save();
        }
    }
}
