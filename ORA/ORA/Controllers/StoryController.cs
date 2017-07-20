using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.ORALogic;

namespace ORA.Controllers
{
    public class StoryController : Controller
    {
        private StoryLogic storyLogic = new StoryLogic();

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
            storyLogic.CreateStory(Story);
            return RedirectToAction("", "", new { area = "" });
        }

        public ActionResult ViewAllStories()
        {
            return View(storyLogic.GetAllStories());
        }

        public ActionResult ViewStory(int StoryID)
        {
            return View(storyLogic.GetStoryByStoryID(StoryID));
        }

        [HttpGet]
        //[Authorize(Roles = "Admin, Director")]
        public ActionResult UpdateStory(int StoryID)
        {
            return View(storyLogic.GetStoryByStoryID(StoryID));
        }

        [HttpPost]
        public ActionResult UpdateStory(StoryVM updatedStory)
        {
            storyLogic.UpdateStory(updatedStory);
            return RedirectToAction("", "", new { area = "" });
        }

        public ActionResult DeleteStory(int StoryID)
        {
            storyLogic.DeleteStory(StoryID);
            return RedirectToAction("", "", new { area = "" });
        }
    }
}