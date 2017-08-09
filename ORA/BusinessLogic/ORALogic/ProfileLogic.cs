using Lib.Interfaces;
using Lib.InterfacesLogic;
using Lib.ViewModels;
using System.Collections.Generic;

namespace BusinessLogic.ORALogic
{
    public class ProfileLogic : IProfileLogic
    {
        private IProfileRepository Profiles;
        public ProfileLogic(IProfileRepository prfl)
        {
            Profiles = prfl;
        }
        public List<ProfileVM> GetAllProfiles()
        {
            return Profiles.GetAllProfiles();
        }
        public ProfileVM GetProfileByID(int id)
        {
            ProfileVM Profile = Profiles.GetProfileByID(id);
            return Profile;
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
