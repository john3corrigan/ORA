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
            return Mapper.Map<AssessmentVM>(GetByID(id));
        }
    }
}
