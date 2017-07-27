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
            InitMaps();
        }

        private void InitMaps() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Lib.EFModels.Profile, ProfileVM>().ReverseMap();
                cfg.CreateMap<Position, PositionVM>().ReverseMap();
            });
        }

        public List<ProfileVM> GetAllProfiles() {
            var mapper = config.CreateMapper();
            return mapper.Map<List<ProfileVM>>(DbSet.Include("Position").ToList());
        }

        public ProfileVM GetProfileByID(int id) {
            var mapper = config.CreateMapper();
            return mapper.Map<ProfileVM>(GetAllProfiles().Where(p => p.ProfileID == id).FirstOrDefault());
        }

        public void AddProfile(ProfileVM profile) {
            var mapper = config.CreateMapper();
            Add(mapper.Map<Lib.EFModels.Profile>(profile));
            Save();
        }

        public void UpdateProfile(ProfileVM profile) {
            var mapper = config.CreateMapper();
            Update(mapper.Map<Lib.EFModels.Profile>(profile));
            Save();
        }

        public void DeleteProfile(int id) {
            Delete(id);
            Save();
        }
    }
}
