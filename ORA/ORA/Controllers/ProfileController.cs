using Lib.InterfacesLogic;
using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORA.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileLogic Profiles;
        public ProfileController(IProfileLogic prfl)
        {
            Profiles = prfl;
        }

        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize(Profiles = "Admin, Director")]
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
        //[Authorize(Profiles = "Admin, Director")]
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

        //[Authorize(Profiles = "Admin, Director")]
        public ActionResult ViewAllProfiles()
        {
            return View(Profiles.GetAllProfiles());
        }

        //[Authorize(Profiles = "Admin, Director")]
        public ActionResult DeleteProfile(int ProfileID)
        {
            Profiles.DeleteProfile(ProfileID);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }
    }
}