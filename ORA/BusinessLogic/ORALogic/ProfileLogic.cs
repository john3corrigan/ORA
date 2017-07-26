using Lib.InterfacesLogic;
using Lib.ViewModels;
using System.Collections.Generic;

namespace BusinessLogic.ORALogic
{
    class ProfileLogic : IProfileLogic
    {
        private IProfileLogic Profiles;
        public ProfileLogic(IProfileLogic prfl)
        {
            Profiles = prfl;
        }
        public List<ProfileVM> GetAllProfiles()
        {
            return Profiles.GetAllProfiles();
        }
        public ProfileVM GetProfileByID(int id)
        {
            return Profiles.GetProfileByID(id);
        }
        public void AddProfile(ProfileVM profile)
        {
            Profiles.AddProfile(profile);
        }
        public void UpdateProfile(ProfileVM profile)
        {
            Profiles.UpdateProfile(profile);
        }
        public void DeleteProfile(int id)
        {
            Profiles.DeleteProfile(id);
        }
    }
}
