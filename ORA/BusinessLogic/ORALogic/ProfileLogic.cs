using Lib.Interfaces;
using Lib.InterfacesLogic;
using Lib.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.ORALogic
{
    public class ProfileLogic : IProfileLogic
    {
        private IProfileRepository Profiles;
        private IPositionRepository Positions;
        private IEducationRepository Education;

        public ProfileLogic(IProfileRepository prfl, IPositionRepository pstn, IEducationRepository edu)
        {
            Profiles = prfl;
            Positions = pstn;
            Education = edu;
        }
        public List<ProfileVM> GetAllProfiles()
        {
            return Profiles.GetAllProfiles();
        }
        public ProfileVM GetProfileByID(int id)
        {
            ProfileVM Profile = Profiles.GetProfileByID(id);
            Profile.Education = Education.GetEducationByID(Profile.EducationID);
            return Profile;
        }
        public CreateProfileVM GetCreateProfileByID(int id)
        {
            CreateProfileVM Profile = Profiles.GetCreateProfileByID(id);
            if (Profile != null)
            {
                Profile.PositionList = Positions.GetAllPositions();
                Profile.EducationList = Education.GetAllEducation();
                Profile.Position = Positions.GetPositionByID(Profile.PositionID);
                return Profile;
            }
            else
            {
                return null;
            }
        }
        public void AddProfile(ProfileVM profile)
        {
            Profiles.AddProfile(profile);
        }
        public void UpdateProfile(CreateProfileVM profile)
        {
            if (profile.NewEducation != null)
            {
                EducationVM edu = new EducationVM() { EducationName = profile.NewEducation };
                Education.AddEducation(edu);
                profile.EducationID = Education.GetAllEducation().Where(e => e.EducationName == edu.EducationName).FirstOrDefault().EducationID;
            }
            Profiles.UpdateProfile(profile);
        }
        public void DeleteProfile(int id)
        {
            Profiles.DeleteProfile(id);
        }
    }
}
