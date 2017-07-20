using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Repository.Repositories;
using Lib.Interfaces;

namespace BusinessLogic.ORALogic
{
    public class StoryLogic
    {
        private IStoryRepository Stories;

        public StoryLogic(IStoryRepository stry)
        {
            Stories = stry;
        }

        public StoryVM GetStoryByStoryID(int StoryID)
        {
            throw new NotImplementedException();
        }

        public void UpdateStory(StoryVM updatedStory)
        {
            throw new NotImplementedException();
        }

        public void DeleteStory(int storyID)
        {
            throw new NotImplementedException();
        }

        public void CreateStory(StoryVM story)
        {
            throw new NotImplementedException();
        }

        public List<StoryVM> GetAllStories()
        {
            throw new NotImplementedException();
        }
    }
}
