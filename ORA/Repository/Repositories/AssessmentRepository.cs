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
        }

        public AssessmentVM GetAssessmentByID(int id) {
            var assessment = DbSet.Where(a => a.AssessmentID == id).FirstOrDefault();
            return Mapper.Map<AssessmentVM>(assessment);
        }

        public List<AssessmentVM> GetAllAssessments() {
            return Mapper.Map<List<AssessmentVM>>(GetAll().ToList());
        }

        public void AddAssessment(AssessmentVM assessment) {
            Add(Mapper.Map<Assessment>(assessment));
            Save();
        }

        public void UpdateAssessment(AssessmentVM assessment) {
            Update(Mapper.Map<Assessment>(assessment));
            Save();
        }

        public void DeleteAssessment(int id) {
            Delete(id);
            Save();
        }
    }
}
