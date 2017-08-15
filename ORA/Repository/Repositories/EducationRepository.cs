using AutoMapper;
using Lib.Interfaces;
using Lib.ViewModels;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class EducationRepository : BaseRespository<Lib.EFModels.Education>, IEducationRepository {
        public EducationRepository() : base(new RepositoryContext("ora")) {
        }

        public List<EducationVM> GetAllEducation()
        {
            return Mapper.Map<List<EducationVM>>(GetAll().ToList());
        }

        public EducationVM GetEducationByID(int id)
        {
            EducationVM profile = Mapper.Map<EducationVM>(GetAllEducation().Where(e => e.EducationID == id).FirstOrDefault());
            return profile;
        }

        public void AddEducation(EducationVM Education)
        {
            Add(Mapper.Map<Lib.EFModels.Education>(Education));
            Save();
        }

        public void UpdateEducation(EducationVM Education)
        {
            Update(Mapper.Map<Lib.EFModels.Education>(Education));
            Save();
        }
    }
}
