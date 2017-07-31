using Lib.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using Lib.InterfacesLogic;
using Lib.Attributes;

namespace ORA.Controllers
{
    [ORAAuthorize]
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
            return View(Stories.GetAllStories());
        }

        [HttpGet]
        [ORAAuthorize(Roles = "Admin, Manager, Director")]
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

        public ActionResult ViewStory(int StoryID)
        {
            return View(Stories.GetStoryByID(StoryID));
        }

        [HttpGet]
        [ORAAuthorize(Roles = "Admin, Manager, Director")]
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

        [ORAAuthorize(Roles = "Admin, Director")]
        public ActionResult DeleteStory(int StoryID)
        {
            Stories.DeleteStory(StoryID);
            return RedirectToAction("Dashboard", "Home", new { area = "" });
        }
    }
}