using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lib.InterfacesLogic;


namespace ORA.Controllers
{
    public class StoryController : Controller
    {
        private IStoryLogic Stories;

        public StoryController(IStoryLogic stry)
        {
            Stories = stry;
        }

        // GET: Story
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult CreateStory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStory(StoryVM Story)
        {
            Stories.AddStory(Story);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        public ActionResult ViewListStories(List<StoryVM> StoriesList)
        {
            return View(StoriesList);
        }

        public ActionResult ViewAllStories()
        {
            return View(Stories.GetAllStories());
        }

        public ActionResult ViewStory(int StoryID)
        {
            return View(Stories.GetStoryByID(StoryID));
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateStory(int StoryID)
        {
            return View(Stories.GetStoryByID(StoryID));
        }

        [HttpPost]
        public ActionResult UpdateStory(StoryVM updatedStory)
        {
            Stories.UpdateStory(updatedStory);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }

        public ActionResult DeleteStory(int StoryID)
        {
            Stories.DeleteStory(StoryID);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }
    }
}