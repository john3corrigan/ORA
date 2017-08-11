using Lib.Attributes;
using Lib.InterfacesLogic;
using Lib.ViewModels;
using System.Web.Mvc;

namespace ORA.Controllers
{
    [ORAAuthorize]
    public class ProfileController : Controller
    {
        private IProfileLogic Profiles;
        public ProfileController(IProfileLogic prfl)
        {
            Profiles = prfl;
        }

        [HttpGet]
        public ActionResult UpdateProfile(int ProfileID)
        {
            return View(Profiles.GetProfileByID(ProfileID));
        }

        [HttpPost]
        public ActionResult UpdateProfile(ProfileVM updatedProfile)
        {
            Profiles.UpdateProfile(updatedProfile);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public ActionResult ViewProfileByID(int ProfileID)
        {
            CreateProfileVM profile = Profiles.GetCreateProfileByID(ProfileID);
            if (profile.Summary == null && Session["Name"].ToString().Contains(profile.FirstName))
            {
                return View("UpdateProfile", profile);
            }
            else if(profile.Summary == null && !Session["Name"].ToString().Contains(profile.FirstName))
            {
                TempData["Error"] = 1;
                return View();
            }
            else
            {
                return View(Profiles.GetProfileByID(ProfileID));
            }
        }

        [HttpGet]
        public ActionResult ViewProfile(FormCollection form)
        {
            return View(Profiles.GetProfileByID(int.Parse(form[0])));
        }

        [ORAAuthorize(Roles = "ADMINISTRATOR, DIRECTOR")]
        public ActionResult DeleteProfile(int ProfileID)
        {
            Profiles.DeleteProfile(ProfileID);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}