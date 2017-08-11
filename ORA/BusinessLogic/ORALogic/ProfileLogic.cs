using Lib.Interfaces;
using Lib.InterfacesLogic;
using Lib.ViewModels;
using System.Collections.Generic;

namespace BusinessLogic.ORALogic
{
    public class ProfileLogic : IProfileLogic
    {
        private IProfileRepository Profiles;
        private IPositionRepository Positions;

        public ProfileLogic(IProfileRepository prfl, IPositionRepository pstn)
        {
            Profiles = prfl;
            Positions = pstn;
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
        public CreateProfileVM GetCreateProfileByID(int id)
        {
            CreateProfileVM Profile = Profiles.GetCreateProfileByID(id);
            Profile.PositionList = Positions.GetAllPositions();
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
