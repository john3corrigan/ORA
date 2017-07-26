using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Repository.Repositories;
using Lib.Interfaces;
using Lib.InterfacesLogic;

namespace BusinessLogic.ORALogic
{
    public class StoryLogic : IStoryLogic
    {
        private IStoryRepository Stories;

        public StoryLogic(IStoryRepository stry)
        {
            Stories = stry;
        }

        public StoryVM GetStoryByID(int storyID)
        {
            return Stories.GetStoryByID(storyID);
        }

        public void UpdateStory(StoryVM updatedStory)
        {
            Stories.UpdateStory(updatedStory);
        }

        public void DeleteStory(int storyID)
        {
            Stories.DeleteStory(storyID);
        }

        public void AddStory(StoryVM newStory)
        {
            Stories.AddStory(newStory);
        }

        public List<StoryVM> GetAllStories()
        {
            return Stories.GetAllStories();
        }
    }
}
