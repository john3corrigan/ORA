using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.EFModels;
using Lib.ViewModels;
using Repository.Context;
using AutoMapper;
using Lib.Interfaces;

namespace Repository.Repositories {
    public class ProfileRepository : BaseRespository<Lib.EFModels.Profile>, IProfileRepository {
        public ProfileRepository() : base(new RepositoryContext("ora")) {
        }

        public List<ProfileVM> GetAllProfiles() {
            return Mapper.Map<List<ProfileVM>>(DbSet.Include("Position").ToList());
        }

        public ProfileVM GetProfileByID(int id) {
            ProfileVM profile = Mapper.Map<ProfileVM>(GetAllProfiles().Where(p => p.ProfileID == id).FirstOrDefault());
            return profile;
        }

        public void AddProfile(ProfileVM profile) {
            Add(Mapper.Map<Lib.EFModels.Profile>(profile));
            Save();
        }

        public void UpdateProfile(ProfileVM profile) {
            Update(Mapper.Map<Lib.EFModels.Profile>(profile));
            Save();
        }

        public void DeleteProfile(int id) {
            Delete(id);
            Save();
        }
    }
}
