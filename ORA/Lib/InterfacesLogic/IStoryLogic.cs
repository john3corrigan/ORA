using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.InterfacesLogic
{
    public interface IStoryLogic
    {
        List<StoryVM> GetAllStories();
        StoryVM GetStoryByID(int StoryID);
        void UpdateStory(StoryVM updatedStory);
        void DeleteStory(int storyID);
        void AddStory(StoryVM story);
        CreateStoryVM AddStory();
    }
}
