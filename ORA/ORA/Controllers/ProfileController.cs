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
        public ActionResult UpdateProfile(CreateProfileVM updatedProfile)
        {
            Profiles.UpdateProfile(updatedProfile);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public ActionResult ViewProfileByID(int ProfileID)
        {
            CreateProfileVM profile = Profiles.GetCreateProfileByID(ProfileID);
            if (profile == null)
            {
                TempData["ProfileID"] = ProfileID;
                TempData["Error"] = 1;
                return View();
            }
            else
            {
                if (profile.Summary == null)
                {
                    if (!Session["Name"].ToString().Contains(profile.FirstName))
                    {
                        TempData["Error"] = 1;
                        return View();
                    }
                    else
                    {
                        return View("UpdateProfile", profile);
                    }
                }
                else
                {
                    TempData["Error"] = 0;
                    return View(Profiles.GetProfileByID(ProfileID));
                }
            }
        }

        [HttpPost]
        public ActionResult ViewProfile(FormCollection form)
        {
            ProfileVM profile = Profiles.GetProfileByID(int.Parse(form[0]));
            if (profile != null)
            {
                return View("ViewProfileByID", profile);
            }
            else
            {
                TempData["Error"] = 2;
                return View("ViewProfileByID");
            }
        }

        [ORAAuthorize(Roles = "ADMINISTRATOR, DIRECTOR")]
        public ActionResult DeleteProfile(int ProfileID)
        {
            Profiles.DeleteProfile(ProfileID);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}