using Lib.Attributes;
using Lib.InterfacesLogic;
using Lib.ViewModels;
using System.Web.Mvc;

namespace ORA.Controllers
{
    //[Authorize]
    public class ProfileController : Controller
    {
        private IProfileLogic Profiles;
        public ProfileController(IProfileLogic prfl)
        {
            Profiles = prfl;
        }

        // GET: Profile
        [ORAAuthorize(Roles = "Admin, Director")]
        public ActionResult Index()
        {
            return View(Profiles.GetAllProfiles());
        }

        [HttpGet]
        [ORAAuthorize(Roles = "Admin, Director")]
        public ActionResult AddProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProfile(ProfileVM Profile)
        {
            Profiles.AddProfile(Profile);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        [HttpGet]
        [ORAAuthorize(Roles = "Admin, Director")]
        public ActionResult UpdateProfile(int ProfileID)
        {
            return View(Profiles.GetProfileByID(ProfileID));
        }

        [HttpPost]
        public ActionResult UpdateProfile(ProfileVM updatedProfile)
        {
            Profiles.UpdateProfile(updatedProfile);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        public ActionResult ViewProfile(int ProfileID)
        {
            return View(Profiles.GetProfileByID(ProfileID));
        }

        [ORAAuthorize(Roles = "Admin, Director")]
        public ActionResult DeleteProfile(int ProfileID)
        {
            Profiles.DeleteProfile(ProfileID);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }
    }
}