using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.InterfacesLogic
{
    public interface IProfileLogic {
        List<ProfileVM> GetAllProfiles();
        ProfileVM GetProfileByID(int id);
        void AddProfile(ProfileVM profile);
        void UpdateProfile(ProfileVM profile);
        void DeleteProfile(int id);
    }
}
