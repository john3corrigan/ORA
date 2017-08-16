using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces {
    public interface IProfileRepository {
        List<ProfileVM> GetAllProfiles();
        ProfileVM GetProfileByID(int id);
        void AddProfile(ProfileVM profile);
        void UpdateProfile(CreateProfileVM profile);
        void DeleteProfile(int id);
        CreateProfileVM GetCreateProfileByID(int id);
    }
}
